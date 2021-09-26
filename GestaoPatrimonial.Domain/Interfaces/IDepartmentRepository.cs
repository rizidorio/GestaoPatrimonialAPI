using GestaoPatrimonial.Domain.Entities;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Domain.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<Department> GetByInitialsAsync(string initials);
    }
}
