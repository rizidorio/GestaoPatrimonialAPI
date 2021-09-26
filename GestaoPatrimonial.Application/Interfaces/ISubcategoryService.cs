using GestaoPatrimonial.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface ISubcategoryService
    {
        Task<IEnumerable<SubcategoryDto>> GetAll();
        Task<SubcategoryDto> GetById(int id);
        Task Add(SubcategoryDto subcategoryDto);
        Task Update(SubcategoryDto subcategoryDto);
        Task Delete(int id);
    }
}
