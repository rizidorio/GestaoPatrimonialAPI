using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GestaoPatrimonial.Application.CqrsAddress.Queries
{
    public class GetAddressByStateQuery : IRequest<IEnumerable<Address>>
    {
        public string State { get; set; }

        public GetAddressByStateQuery(string state)
        {
            State = state;
        }
    }
}
