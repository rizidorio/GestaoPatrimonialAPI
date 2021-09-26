using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GestaoPatrimonial.Application.CqrsPatrimonialAsset.Queries
{
    public class GetPatrimonialAssetBySubcategoryQuery : IRequest<IEnumerable<PatrimonialAsset>>
    {
        public int SubcategoryId { get; set; }

        public GetPatrimonialAssetBySubcategoryQuery(int subcategoryId)
        {
            SubcategoryId = subcategoryId;
        }
    }
}
