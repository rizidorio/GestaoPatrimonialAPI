using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Domain.Utils.Models;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface ISubcategoryService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int id);
        Task<ResponseModel> Add(SubcategoryDto subcategoryDto);
        Task<ResponseModel> Update(SubcategoryDto subcategoryDto);
        Task<ResponseModel> Delete(int id);
    }
}
