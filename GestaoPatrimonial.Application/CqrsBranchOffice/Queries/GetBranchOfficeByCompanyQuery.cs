using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GestaoPatrimonial.Application.CqrsBranchOffice.Queries
{
    public class GetBranchOfficeByCompanyQuery : IRequest<IEnumerable<BranchOffice>>
    {
        public int CompanyId { get; set; }

        public GetBranchOfficeByCompanyQuery(int companyId)
        {
            CompanyId = companyId;
        }
    }
}
