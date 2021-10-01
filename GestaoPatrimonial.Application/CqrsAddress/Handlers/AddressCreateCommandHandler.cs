using GestaoPatrimonial.Application.CqrsAddress.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CQRS.CqrsAddress.Handlers
{
    public class AddressCreateCommandHandler : IRequestHandler<AddressCreateCommand, Address>
    {
        private readonly IAddressRepository _repository;

        public AddressCreateCommandHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<Address> Handle(AddressCreateCommand request, CancellationToken cancellationToken)
        {
            Address address = new Address(request.PostalCode, request.PublicPlace, request.District, request.City, request.State);

            if (address == null)
                throw new ArgumentException("Erro ao criar endereço");

            return await _repository.CreateAsync(address);
        }
    }
}
