using GestaoPatrimonial.Application.CqrsAddress.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CQRS.CqrsAddress.Handlers
{
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, IEnumerable<Address>>
    {
        private readonly IAddressRepository _repository;

        public GetAddressQueryHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Address>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
