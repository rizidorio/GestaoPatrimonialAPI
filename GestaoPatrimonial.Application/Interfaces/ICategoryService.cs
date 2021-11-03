using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Application.FilterModels.Category;
using GestaoPatrimonial.Domain.Utils.Models;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetAll(CategoryFilterModel filter);
        Task<ResponseModel> GetById(int id);
        Task<ResponseModel> Create(CategoryDto categoryDto);
        Task<ResponseModel> Update(CategoryDto categoryDto);
        Task<ResponseModel> Delete(int id);
    }
}
