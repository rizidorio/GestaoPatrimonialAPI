using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Domain.Utils.Models;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface IAddressService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> ListByStateAsync(string state);
        Task<ResponseModel> ListByCityAsync(string city);
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> GetByPostalCodeAsync(string postalCode);
        Task<ResponseModel> Add(AddressDto addressDto);
        Task<ResponseModel> Update(AddressDto addressDto);
        Task<ResponseModel> Delete(int? id);
    }
}
