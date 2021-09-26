using GestaoPatrimonial.Application.CqrsAddress.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CQRS.CqrsAddress.Handlers
{
    public class GetAddressByPostalCodeQueryHandler : IRequestHandler<GetAddressByPostalCodeQuery, Address>
    {
        private readonly IAddressRepository _repository;

        public GetAddressByPostalCodeQueryHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<Address> Handle(GetAddressByPostalCodeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByPostalCodeAsync(request.PostalCode);
        }
    }
}