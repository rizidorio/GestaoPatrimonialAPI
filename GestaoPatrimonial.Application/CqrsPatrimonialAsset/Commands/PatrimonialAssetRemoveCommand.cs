using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsPatrimonialAsset.Commands
{
    public class PatrimonialAssetRemoveCommand : IRequest<PatrimonialAsset>
    {
        public int Id { get; set; }

        public PatrimonialAssetRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
