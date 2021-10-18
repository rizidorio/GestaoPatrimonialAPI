using Microsoft.AspNetCore.Mvc;

namespace GestaoPatrimonial.API.Controllers
{
    [Route("[controller]")]
    [Route("")]
    [ApiController]
    public class InitialController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("API OK");
        }
    }
}
