using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GestaoPatrimonial.Application.CqrsAddress.Queries
{
    public class GetAddressQuery : IRequest<IEnumerable<Address>>
    {
    }
}
