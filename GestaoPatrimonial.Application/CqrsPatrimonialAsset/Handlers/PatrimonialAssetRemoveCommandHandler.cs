using GestaoPatrimonial.Application.CqrsPatrimonialAsset.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsPatrimonialAsset.Handlers
{
    public class PatrimonialAssetRemoveCommandHandler : IRequestHandler<PatrimonialAssetRemoveCommand, PatrimonialAsset>
    {
        private readonly IPatrimonialAssetRepository _repository;

        public PatrimonialAssetRemoveCommandHandler(IPatrimonialAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<PatrimonialAsset> Handle(PatrimonialAssetRemoveCommand request, CancellationToken cancellationToken)
        {
            PatrimonialAsset findPatrimonialAsset = await _repository.GetAsync(request.Id);

            if (findPatrimonialAsset != null)
                return await _repository.DeleteAsync(findPatrimonialAsset);

            throw new ArgumentException("Patrimônio não encontrado");
        }
    }
}
