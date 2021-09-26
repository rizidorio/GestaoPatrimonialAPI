using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GestaoPatrimonial.Application.CqrsAddress.Queries
{
    public class GetAddressByCityQuery : IRequest<IEnumerable<Address>>
    {
        public string City { get; set; }

        public GetAddressByCityQuery(string city)
        {
            City = city;
        }
    }
}
