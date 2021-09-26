using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GestaoPatrimonial.Application.CqrsPatrimonialAsset.Queries
{
    public class GetPatrimonialAssetByCategoryQuery : IRequest<IEnumerable<PatrimonialAsset>>
    {
        public int CategoryId { get; set; }

        public GetPatrimonialAssetByCategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
