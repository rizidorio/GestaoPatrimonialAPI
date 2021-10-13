using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Domain.Utils.Models;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> GetByInitials(string initials);
        Task<ResponseModel> Add(DepartmentDto departmentDto);
        Task<ResponseModel> Update(DepartmentDto departmentDto);
        Task<ResponseModel> Delete(int? id);
    }
}
