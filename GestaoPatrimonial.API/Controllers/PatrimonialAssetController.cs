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
    public class PatrimonialAssetController : ControllerBase
    {
        private readonly IPatrimonialAssetService _service;

        public PatrimonialAssetController(IPatrimonialAssetService service)
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
        [Route("listCategory")]
        [Authorize]
        public async Task<IActionResult> ListByCategory(int categoryId)
        {
            return new ResponseController().Response(await _service.ListByCategoryAsync(categoryId));
        }

        [HttpPost]
        [Route("listSubcategory")]
        [Authorize]
        public async Task<IActionResult> ListBySubcategory(int subcategoryId)
        {
            return new ResponseController().Response(await _service.ListBySubcategoryAsync(subcategoryId));
        }

        [HttpPost]
        [Route("listBrachOffice")]
        [Authorize]
        public async Task<IActionResult> ListByBranchOffice(int branchOfficeId)
        {
            return new ResponseController().Response(await _service.ListByBranchOfficeAsync(branchOfficeId));
        }

        [HttpPost]
        [Route("listDepartment")]
        [Authorize]
        public async Task<IActionResult> ListByDepartment(int departmentId)
        {
            return new ResponseController().Response(await _service.ListByDepartmentAsync(departmentId));
        }

        [HttpPost]
        [Route("add")]
        [Authorize]
        public async Task<IActionResult> Add(PatrimonialAssetDto patrimonialAssetDto)
        {
            return new ResponseController().Response(await _service.Add(patrimonialAssetDto));
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task<IActionResult> Update(PatrimonialAssetDto patrimonialAssetDto)
        {
            return new ResponseController().Response(await _service.Update(patrimonialAssetDto));
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
