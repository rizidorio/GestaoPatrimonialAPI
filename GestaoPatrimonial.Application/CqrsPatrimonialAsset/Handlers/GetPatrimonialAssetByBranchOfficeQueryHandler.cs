using GestaoPatrimonial.Application.CqrsPatrimonialAsset.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsPatrimonialAsset.Handlers
{
    public class GetPatrimonialAssetByBranchOfficeQueryHandler : IRequestHandler<GetPatrimonialAssetByBranchOfficeQuery, IEnumerable<PatrimonialAsset>>
    {
        private readonly IPatrimonialAssetRepository _repository;

        public GetPatrimonialAssetByBranchOfficeQueryHandler(IPatrimonialAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PatrimonialAsset>> Handle(GetPatrimonialAssetByBranchOfficeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListByBranchOfficeAsync(request.BranchOfficeId);
        }
    }
}
