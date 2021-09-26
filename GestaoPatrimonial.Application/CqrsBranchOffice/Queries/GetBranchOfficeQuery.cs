using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GestaoPatrimonial.Application.CqrsBranchOffice.Queries
{
    public class GetBranchOfficeQuery : IRequest<IEnumerable<BranchOffice>>
    {
    }
}
