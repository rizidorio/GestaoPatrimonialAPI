using GestaoPatrimonial.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDto>> GetAll();
        Task<IEnumerable<AddressDto>> ListByStateAsync(string state);
        Task<IEnumerable<AddressDto>> ListByCityAsync(string city);
        Task<AddressDto> GetById(int? id);
        Task<AddressDto> GetByPostalCodeAsync(string postalCode);
        Task Add(AddressDto addressDto);
        Task Update(AddressDto addressDto);
        Task Delete(int? id);
    }
}
