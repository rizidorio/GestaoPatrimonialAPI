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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
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
        [Route("getPostalCode/{postalCode}")]
        [Authorize]
        public async Task<IActionResult> GetByPostalCode(string postalCode)
        {
            return new ResponseController().Response(await _service.GetByPostalCodeAsync(postalCode));
        }

        [HttpPost]
        [Route("listStates")]
        [Authorize]
        public async Task<IActionResult> ListByStates(string state)
        {
            return new ResponseController().Response(await _service.ListByStateAsync(state));
        }

        [HttpPost]
        [Route("listCities")]
        [Authorize]
        public async Task<IActionResult> ListByCities(string city)
        {
            return new ResponseController().Response(await _service.ListByCityAsync(city));
        }

        [HttpPost]
        [Route("add")]
        [Authorize]
        public async Task<IActionResult> Add(AddressDto addressDto)
        {
            return new ResponseController().Response(await _service.Add(addressDto));
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task<IActionResult> Update(AddressDto addressDto)
        {
            return new ResponseController().Response(await _service.Update(addressDto));
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
