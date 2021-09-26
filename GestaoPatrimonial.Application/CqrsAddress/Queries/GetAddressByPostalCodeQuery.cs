using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsAddress.Queries
{
    public class GetAddressByPostalCodeQuery : IRequest<Address>
    {
        public string PostalCode { get; set; }

        public GetAddressByPostalCodeQuery(string postalCode)
        {
            PostalCode = postalCode;
        }
    }
}
