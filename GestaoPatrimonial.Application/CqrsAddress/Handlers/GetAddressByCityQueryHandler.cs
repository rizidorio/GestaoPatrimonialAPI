using GestaoPatrimonial.Application.CqrsAddress.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsAddress.Handlers
{
    public class GetAddressByCityQueryHandler : IRequestHandler<GetAddressByCityQuery, IEnumerable<Address>>
    {
        private readonly IAddressRepository _repository;

        public GetAddressByCityQueryHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Address>> Handle(GetAddressByCityQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListByCityAsync(request.City);
        }
    }
}
