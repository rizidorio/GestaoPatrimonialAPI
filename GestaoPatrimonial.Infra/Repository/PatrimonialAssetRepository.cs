using GestaoPatrimonial.Data.Context;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Data.Repository
{
    public class PatrimonialAssetRepository : BaseRepository<PatrimonialAsset>, IPatrimonialAssetRepository
    {
        private readonly ApplicationDbContext _context;

        public PatrimonialAssetRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatrimonialAsset>> ListByBranchOfficeAsync(int branchOfficeId)
        {
            return await _context.PatrimonialAssets.Include(x => x.Department).Where(x => x.Department.BranchOfficeId.Equals(branchOfficeId)).ToListAsync();
        }

        public async Task<IEnumerable<PatrimonialAsset>> ListByCategoryAsync(int categoryId)
        {
            return await _context.PatrimonialAssets.Where(x => x.CategoryId.Equals(categoryId)).ToListAsync();
        }

        public async Task<IEnumerable<PatrimonialAsset>> ListByDepartmentAsync(int departmentId)
        {
            return await _context.PatrimonialAssets.Where(x => x.DepartmentId.Equals(departmentId)).ToListAsync();
        }

        public async Task<IEnumerable<PatrimonialAsset>> ListBySubcategoryAsync(int subcategoryId)
        {
            return await _context.PatrimonialAssets.Where(x => x.SubcategoryId.Equals(subcategoryId)).ToListAsync();
        }
    }
}
