using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Domain.Utils.Models;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Interfaces
{
    public interface IBranchOfficeService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> ListByCompanyAsync(int companyId);
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Add(BranchOfficeDto branchOfficeDto);
        Task<ResponseModel> Update(BranchOfficeDto branchOfficeDto);
        Task<ResponseModel> Delete(int? id);
    }
}
