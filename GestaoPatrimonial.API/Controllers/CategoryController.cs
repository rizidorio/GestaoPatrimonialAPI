using GestaoPatrimonial.API.Utils;
using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Application.FilterModels.Category;
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
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            return new ResponseController().Response(await _service.GetById(id));
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return new ResponseController().Response(await _service.GetAll());
        }

        [HttpPost]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> GetAll(CategoryFilterModel filter)
        {
            return new ResponseController().Response(await _service.GetAll(filter));
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            return new ResponseController().Response(await _service.Create(categoryDto));
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            return new ResponseController().Response(await _service.Update(categoryDto));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return new ResponseController().Response(await _service.Delete(id));
        }
    }
}
