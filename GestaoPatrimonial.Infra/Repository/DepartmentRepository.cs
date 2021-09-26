using GestaoPatrimonial.Data.Context;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Data.Repository
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Department> GetByInitialsAsync(string initials)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.Initials.Equals(initials));
        }
    }
}
