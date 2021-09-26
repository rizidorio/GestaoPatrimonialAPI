using GestaoPatrimonial.Data.Context;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Data.Repository
{
    public class BrachOfficeRepository : BaseRepository<BranchOffice>, IBrachOfficeRepository
    {
        private readonly ApplicationDbContext _context;
        public BrachOfficeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BranchOffice>> ListByCompanyAsync(int companyId)
        {
            return await _context.BranchOffices.Where(x => x.CompanyId.Equals(companyId)).ToListAsync();
        }
    }
}
