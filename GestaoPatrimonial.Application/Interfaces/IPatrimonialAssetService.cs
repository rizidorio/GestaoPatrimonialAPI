using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Domain.Utils.Models;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface IPatrimonialAssetService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> ListByCategoryAsync(int categoryId);
        Task<ResponseModel> ListBySubcategoryAsync(int subcategoryId);
        Task<ResponseModel> ListByBranchOfficeAsync(int branchOfficeId);
        Task<ResponseModel> ListByDepartmentAsync(int departmentId);
        Task<ResponseModel> GetById(int id);
        Task<ResponseModel> Add(PatrimonialAssetDto patrimonialAssetDto);
        Task<ResponseModel> Update(PatrimonialAssetDto patrimonialAssetDto);
        Task<ResponseModel> Delete(int? id);
    }
}
