using GestaoPatrimonial.Application.CqrsAddress.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CQRS.CqrsAddress.Handlers
{
    public class AddressUpdateCommandHandler : IRequestHandler<AddressUpdateCommand, Address>
    {
        private readonly IAddressRepository _repository;

        public AddressUpdateCommandHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<Address> Handle(AddressUpdateCommand request, CancellationToken cancellationToken)
        {
            Address findAddress = await _repository.GetAsync(request.Id);

            if (findAddress != null)
            {
                findAddress.Update(request.PostalCode, request.Address, request.District, request.City, request.State);
                return await _repository.UpdateAsync(findAddress);
            }

            throw new ArgumentException("Endereço não encontrado");

        }
    }
}
