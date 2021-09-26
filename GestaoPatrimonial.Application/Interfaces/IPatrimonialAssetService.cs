using GestaoPatrimonial.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface IPatrimonialAssetService
    {
        Task<IEnumerable<PatrimonialAssetDto>> GetAll();
        Task<IEnumerable<PatrimonialAssetDto>> ListByCategoryAsync(int categoryId);
        Task<IEnumerable<PatrimonialAssetDto>> ListBySubcategoryAsync(int subcategoryId);
        Task<IEnumerable<PatrimonialAssetDto>> ListByBranchOfficeAsync(int branchOfficeId);
        Task<IEnumerable<PatrimonialAssetDto>> ListByDepartmentAsync(int departmentId);
        Task<PatrimonialAssetDto> GetById(int id);
        Task Add(PatrimonialAssetDto patrimonialAssetDto);
        Task Update(PatrimonialAssetDto patrimonialAssetDto);
        Task Delete(int? id);
    }
}
