using GestaoPatrimonial.API.Models;
using GestaoPatrimonial.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPatrimonial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authenticate, IConfiguration configuration)
        {
            _authenticate = authenticate;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Token([FromBody] LoginModel model)
        {
            var result = await _authenticate.Authenticate(model.Email, model.Password);

            if (result)
                return GenerateToken(model);

            return BadRequest("Usuário ou senha incorreto");
        }

        [HttpPost]
        [Route("CreateUser")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> CreateUser([FromBody] LoginModel model)
        {
            var result = await _authenticate.RegisterUser(model.Email, model.Password);

            if (result)
                return Ok("Usuário criado com sucesso");

            return BadRequest("Erro ao criar usuário");
        }

        private UserToken GenerateToken(LoginModel model)
        {
            //declarações do usuário
            var claims = new[]
            {
                new Claim("email", model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            //gerar chave privada para assinar token
            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

            //gerar a assinatura digital
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            //definir tempo de expiração
            var expiration = DateTime.UtcNow.AddDays(1);

            //gerar o token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials        
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
