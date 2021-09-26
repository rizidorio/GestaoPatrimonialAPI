using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GestaoPatrimonial.Application.CqrsCompany.Queries
{
    public class GetCompanyQuery : IRequest<IEnumerable<Company>>
    {
    }
}
