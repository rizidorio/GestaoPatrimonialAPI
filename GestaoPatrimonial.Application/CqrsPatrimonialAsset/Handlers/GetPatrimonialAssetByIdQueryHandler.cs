using GestaoPatrimonial.Application.CqrsPatrimonialAsset.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsPatrimonialAsset.Handlers
{
    public class GetPatrimonialAssetByIdQueryHandler : IRequestHandler<GetPatrimonialAssetByIdQuery, PatrimonialAsset>
    {
        private readonly IPatrimonialAssetRepository _repository;

        public GetPatrimonialAssetByIdQueryHandler(IPatrimonialAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<PatrimonialAsset> Handle(GetPatrimonialAssetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(request.Id);
        }
    }
}
