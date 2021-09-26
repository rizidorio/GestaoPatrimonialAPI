using GestaoPatrimonial.Application.CqrsPatrimonialAsset.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsPatrimonialAsset.Handlers
{
    public class PatrimonialAssetUpdateCommandHandler : IRequestHandler<PatrimonialAssetUpdateCommand, PatrimonialAsset>
    {
        private readonly IPatrimonialAssetRepository _repository;

        public PatrimonialAssetUpdateCommandHandler(IPatrimonialAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<PatrimonialAsset> Handle(PatrimonialAssetUpdateCommand request, CancellationToken cancellationToken)
        {
            PatrimonialAsset findPatrimonialAsset = await _repository.GetAsync(request.Id);

            if (findPatrimonialAsset != null)
            {
                findPatrimonialAsset.Update(request.Name, request.PurchasePrice, request.PurchaseData, request.PurchaseQuantity, request.Supplier, request.Invoice,
                                            request.PurchaseTotalValue, request.Status, request.CategoryId, request.SubcategoryId, request.DepartmentId);

                return await _repository.UpdateAsync(findPatrimonialAsset);
            }

            throw new ArgumentException("Patrimônio não encontrado");
        }
    }
}
