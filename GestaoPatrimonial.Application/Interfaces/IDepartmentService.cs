using GestaoPatrimonial.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAll();
        Task<DepartmentDto> GetById(int? id);
        Task<DepartmentDto> GetByInitials(string initials);
        Task Add(DepartmentDto departmentDto);
        Task Update(DepartmentDto departmentDto);
        Task Delete(int? id);
    }
}
