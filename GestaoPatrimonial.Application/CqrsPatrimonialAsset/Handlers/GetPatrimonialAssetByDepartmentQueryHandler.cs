using GestaoPatrimonial.Application.CqrsPatrimonialAsset.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsPatrimonialAsset.Handlers
{
    public class GetPatrimonialAssetByDepartmentQueryHandler : IRequestHandler<GetPatrimonialAssetByDepartmentQuery, IEnumerable<PatrimonialAsset>>
    {
        private readonly IPatrimonialAssetRepository _repository;

        public GetPatrimonialAssetByDepartmentQueryHandler(IPatrimonialAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PatrimonialAsset>> Handle(GetPatrimonialAssetByDepartmentQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListByDepartmentAsync(request.DepartmentId);
        }
    }
}
