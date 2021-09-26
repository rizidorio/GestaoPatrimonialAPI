using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GestaoPatrimonial.Application.CqrsPatrimonialAsset.Queries
{
    public class GetPatrimonialAssetByBranchOfficeQuery : IRequest<IEnumerable<PatrimonialAsset>>
    {
        public int BranchOfficeId { get; set; }

        public GetPatrimonialAssetByBranchOfficeQuery(int branchOfficeId)
        {
            BranchOfficeId = branchOfficeId;
        }
    }
}
