using GestaoPatrimonial.Application.CqrsAddress.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsAddress.Handlers
{
    public class GetAddressByStateQueryHandler : IRequestHandler<GetAddressByStateQuery, IEnumerable<Address>>
    {
        private readonly IAddressRepository _repository;

        public GetAddressByStateQueryHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Address>> Handle(GetAddressByStateQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListByStateAsync(request.State);
        }
    }
}
