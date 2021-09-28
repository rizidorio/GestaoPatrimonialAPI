using GestaoPatrimonial.Domain.Account;
using GestaoPatrimonial.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GestaoPatrimonial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;

        public AuthController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserTokenModel>> Token([FromBody] LoginModel model)
        {
            try
            {
                return await _authenticate.Authenticate(model);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
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
    }
}
