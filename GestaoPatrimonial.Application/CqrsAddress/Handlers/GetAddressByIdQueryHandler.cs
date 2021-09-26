using GestaoPatrimonial.Application.CqrsAddress.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CQRS.CqrsAddress.Handlers
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, Address>
    {
        private readonly IAddressRepository _repository;

        public GetAddressByIdQueryHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<Address> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(request.Id);
        }
    }
}
