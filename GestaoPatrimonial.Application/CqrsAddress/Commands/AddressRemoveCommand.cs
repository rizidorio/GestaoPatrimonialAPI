using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsAddress.Commands
{
    public class AddressRemoveCommand : IRequest<Address>
    {
        public int Id { get; set; }

        public AddressRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
