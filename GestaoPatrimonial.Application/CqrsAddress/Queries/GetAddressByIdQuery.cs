using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsAddress.Queries
{
    public class GetAddressByIdQuery : IRequest<Address>
    {
        public int Id { get; set; }

        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
