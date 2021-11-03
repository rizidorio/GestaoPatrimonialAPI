using GestaoPatrimonial.API.Utils;
using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Application.FilterModels.Subcategory;
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
    public class SubcategoryController : ControllerBase
    {
        private readonly ISubcategoryService _service;

        public SubcategoryController(ISubcategoryService service)
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
        public async Task<IActionResult> GetAll(SubcategoryFilterModel filterModel)
        {
            return new ResponseController().Response(await _service.GetAll(filterModel));
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> Add(SubcategoryDto subcategoryDto)
        {
            return new ResponseController().Response(await _service.Add(subcategoryDto));
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task<IActionResult> Update(SubcategoryDto subcategoryDto)
        {
            return new ResponseController().Response(await _service.Update(subcategoryDto));
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
