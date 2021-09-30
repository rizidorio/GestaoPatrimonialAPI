using GestaoPatrimonial.Domain.Utils.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPatrimonial.API.Utils
{
    public class ResponseController : ControllerBase
    {
        public new IActionResult Response(ResponseModel model)
        {
            return model.StatusCode switch
            {
                200 => Ok(model),
                404 => NotFound(model),
                409 => Conflict(model),
                _ => StatusCode(model.StatusCode, model),
            };
        }
    }
}
