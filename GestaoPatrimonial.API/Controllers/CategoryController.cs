using GestaoPatrimonial.API.Utils;
using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoPatrimonial.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
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
        [Route("add")]
        [Authorize]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            return new ResponseController().Response(await _service.Add(categoryDto));
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            return new ResponseController().Response(await _service.Update(categoryDto));
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
