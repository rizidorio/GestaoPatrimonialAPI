using GestaoPatrimonial.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAll();
        Task<CompanyDto> GetById(int id);
        Task Add(CompanyDto companyDto);
        Task Update(CompanyDto companyDto);
        Task Delete(int id);
    }
}
