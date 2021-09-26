using GestaoPatrimonial.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface IBranchOfficeService
    {
        Task<IEnumerable<BranchOfficeDto>> GetAll();
        Task<IEnumerable<BranchOfficeDto>> ListByCompanyAsync(int companyId);
        Task<BranchOfficeDto> GetById(int? id);
        Task Add(BranchOfficeDto branchOfficeDto);
        Task Update(BranchOfficeDto branchOfficeDto);
        Task Delete(int? id);
    }
}
