using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GestaoPatrimonial.Application.Interfaces;
using System.Threading.Tasks;
using GestaoPatrimonial.API.Utils;
using GestaoPatrimonial.Application.Dtos;

namespace GestaoPatrimonial.API.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return new ResponseController().Response(await _service.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            return new ResponseController().Response(await _service.GetById(id));
        }

        [HttpPost]
        [Route("getInitials")]
        [Authorize]
        public async Task<IActionResult> ListByStates(string initials)
        {
            return new ResponseController().Response(await _service.GetByInitials(initials));
        }

        [HttpPost]
        [Route("add")]
        [Authorize]
        public async Task<IActionResult> Add(DepartmentDto departmentDto)
        {
            return new ResponseController().Response(await _service.Add(departmentDto));
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task<IActionResult> Update(DepartmentDto departmentDto)
        {
            return new ResponseController().Response(await _service.Update(departmentDto));
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return new ResponseController().Response(await _service.Delete(id));
        }
    }
}
