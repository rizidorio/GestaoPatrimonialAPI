using GestaoPatrimonial.Domain.Account;
using GestaoPatrimonial.Domain.AuthModels;
using GestaoPatrimonial.Domain.Utils.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<ResponseModel> Authenticate(LoginModel login)
        {
            try
            {
                ApplicationUser findUser = await _userManager.FindByEmailAsync(login.Email);

                if (findUser != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, lockoutOnFailure: true);

                    if (result.Succeeded)
                    {
                        var userToken = GenerateToken(findUser);

                        findUser.UserName ??= findUser.Email;

                        UserTokenModel model = new UserTokenModel
                        {
                            Token = $"Bearer {new JwtSecurityTokenHandler().WriteToken(userToken)}" ,
                            User = new UserReturnModel(findUser.Id, findUser.UserName, findUser.Email, findUser.PhoneNumber),
                            Expiration = userToken.ValidTo,
                        };

                        return new ResponseModel(200, model, "Usuário logado com sucesso");
                    }

                    return new ResponseModel(403, "Usuário ou senha inválido");
                }

                return new ResponseModel(404, "Usuário não encontrado");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao logar usuário - {ex.Message}");
            }
        }

        public async Task<ResponseModel> RegisterUser(RegisterUserModel model)
        {
            try
            {
                ApplicationUser findUser = await _userManager.FindByEmailAsync(model.Email);

                if (findUser == null)
                {
                    ApplicationUser applicationUser = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                    };

                    var result = await _userManager.CreateAsync(applicationUser, model.Password);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(applicationUser, isPersistent: false);
                        return new ResponseModel(201, "Usuário criado com sucesso");
                    }

                    return new ResponseModel(500, "Erro ao cadastrar usuário");
                }

                return new ResponseModel(409, "Usuário já cadastrado");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao cadastrar usuário - {ex.Message}");
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        private SecurityToken GenerateToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Authentication, user.Id)
            };

            var privateKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("JWT")["SecretKey"]));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration.GetSection("JWT")["Issuer"],
                audience: _configuration.GetSection("JWT")["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
                );

            return token;
        }
    }
}
