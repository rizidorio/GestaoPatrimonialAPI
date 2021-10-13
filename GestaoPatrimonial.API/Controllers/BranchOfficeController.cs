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
    public class BranchOfficeController : ControllerBase
    {
        private readonly IBranchOfficeService _service;

        public BranchOfficeController(IBranchOfficeService service)
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
        public async Task<IActionResult> Get(int? id)
        {
            return new ResponseController().Response(await _service.GetById(id));
        }

        [HttpGet]
        [Route("list/{companyId}")]
        [Authorize]
        public async Task<IActionResult> ListByCompanyId(int companyId)
        {
            return new ResponseController().Response(await _service.ListByCompanyAsync(companyId));
        }

        [HttpPost]
        [Route("add")]
        [Authorize]
        public async Task<IActionResult> Add(BranchOfficeDto branchOfficeDto)
        {
            return new ResponseController().Response(await _service.Add(branchOfficeDto));
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task<IActionResult> Update(BranchOfficeDto branchOfficeDto)
        {
            return new ResponseController().Response(await _service.Update(branchOfficeDto));
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            return new ResponseController().Response(await _service.Delete(id));
        }
    }
}
