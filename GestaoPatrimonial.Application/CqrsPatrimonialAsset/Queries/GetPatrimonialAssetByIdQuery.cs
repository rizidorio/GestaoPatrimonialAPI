using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsPatrimonialAsset.Queries
{
    public class GetPatrimonialAssetByIdQuery : IRequest<PatrimonialAsset>
    {
        public int Id { get; set; }

        public GetPatrimonialAssetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
