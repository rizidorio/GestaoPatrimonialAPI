using GestaoPatrimonial.Domain.Account;
using GestaoPatrimonial.Domain.AuthModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoPatrimonial.API.Controllers
{
    [Route("[controller]")]
    [Route("")]
    [ApiController]
    public class InitialController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;

        public InitialController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("API OK");
        }

        [HttpGet]
        [Route("initialUser")]
        public async Task<ActionResult> Create()
        {
            try
            {
                RegisterUserModel model = new RegisterUserModel
                {
                    Email = "user@teste.com",
                    Password = "teste123",
                    ConfirmPassword = "teste123",
                };

               await _authenticate.RegisterUser(model);

                return Ok("Usuario criado");
            }
            catch (System.Exception)
            {
                return BadRequest("Error");
            }
        }
    }
}
