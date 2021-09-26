using GestaoPatrimonial.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int id);
        Task Add(CategoryDto categoryDto);
        Task Update(CategoryDto categoryDto);
        Task Delete(int id);
    }
}
