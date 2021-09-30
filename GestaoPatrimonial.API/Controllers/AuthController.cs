using GestaoPatrimonial.API.Utils;
using GestaoPatrimonial.Domain.Account;
using GestaoPatrimonial.Domain.AuthModels;
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
        public async Task<IActionResult> Token([FromBody] LoginModel model)
        {
            return new ResponseController().Response(await _authenticate.Authenticate(model));
        }

        [HttpPost]
        [Route("CreateUser")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> CreateUser([FromBody] RegisterUserModel model)
        {
            return new ResponseController().Response(await _authenticate.RegisterUser(model));
        }
    }
}
