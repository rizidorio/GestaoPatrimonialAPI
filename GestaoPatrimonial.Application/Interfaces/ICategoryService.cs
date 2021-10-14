using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Domain.Utils.Models;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int id);
        Task<ResponseModel> Add(CategoryDto categoryDto);
        Task<ResponseModel> Update(CategoryDto categoryDto);
        Task<ResponseModel> Delete(int id);
    }
}
