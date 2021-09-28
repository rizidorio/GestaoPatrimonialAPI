using GestaoPatrimonial.Domain.Account;
using GestaoPatrimonial.Domain.Models;
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

        public async Task<UserTokenModel> Authenticate(LoginModel login)
        {
            ApplicationUser findUser = await _userManager.FindByEmailAsync(login.Email);

            if (findUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    var userToken = GenerateToken(findUser);

                    findUser.UserName ??= findUser.Email;

                    return new UserTokenModel {
                        Token = new JwtSecurityTokenHandler().WriteToken(userToken),
                        User = new UserReturnModel(findUser.Id, findUser.UserName, findUser.Email, findUser.PhoneNumber),
                        Expiration = userToken.ValidTo,
                    };
                }
            }

            throw new ArgumentException("Usuário não encontrado");
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
            };

            var result = await _userManager.CreateAsync(applicationUser, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
            }

            return result.Succeeded;
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
