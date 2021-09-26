using GestaoPatrimonial.Application.CqrsAddress.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CQRS.CqrsAddress.Handlers
{
    public class AddressRemoveCommandHandler : IRequestHandler<AddressRemoveCommand, Address>
    {
        private readonly IAddressRepository _repository;

        public AddressRemoveCommandHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<Address> Handle(AddressRemoveCommand request, CancellationToken cancellationToken)
        {
            Address findAddress = await _repository.GetAsync(request.Id);

            if (findAddress != null)
                return await _repository.DeleteAsync(findAddress);

            throw new ArgumentException("Endereço não encontrado");
        }
    }
}
