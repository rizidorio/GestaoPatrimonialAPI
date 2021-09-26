using GestaoPatrimonial.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Domain.Interfaces
{
    public interface IBrachOfficeRepository : IBaseRepository<BranchOffice>
    {
        Task<IEnumerable<BranchOffice>> ListByCompanyAsync(int companyId);
    }
}
