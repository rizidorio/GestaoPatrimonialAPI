using GestaoPatrimonial.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Domain.Interfaces
{
    public interface IPatrimonialAssetRepository : IBaseRepository<PatrimonialAsset>
    {
        Task<IEnumerable<PatrimonialAsset>> ListByCategoryAsync(int categoryId);
        Task<IEnumerable<PatrimonialAsset>> ListBySubcategoryAsync(int subcategoryId);
        Task<IEnumerable<PatrimonialAsset>> ListByBranchOfficeAsync(int branchOfficeId);
        Task<IEnumerable<PatrimonialAsset>> ListByDepartmentAsync(int departmentId);
    }
}
