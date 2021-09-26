using GestaoPatrimonial.Application.CqrsPatrimonialAsset.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsPatrimonialAsset.Handlers
{
    public class GetPatrimonialAssetQueryHandler : IRequestHandler<GetPatrimonialAssetQuery, IEnumerable<PatrimonialAsset>>
    {
        private readonly IPatrimonialAssetRepository _repository;

        public GetPatrimonialAssetQueryHandler(IPatrimonialAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PatrimonialAsset>> Handle(GetPatrimonialAssetQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
