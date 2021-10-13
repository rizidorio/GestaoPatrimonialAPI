using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Domain.Utils.Models;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int id);
        Task<ResponseModel> Add(CompanyDto companyDto);
        Task<ResponseModel> Update(CompanyDto companyDto);
        Task<ResponseModel> Delete(int id);
    }
}
