using GestaoPatrimonial.Application.CqrsPatrimonialAsset.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsPatrimonialAsset.Handlers
{
    public class PatrimonialAssetCreateCommandHandler : IRequestHandler<PatrimonialAssetCreateCommand, PatrimonialAsset>
    {
        private readonly IPatrimonialAssetRepository _repository;

        public PatrimonialAssetCreateCommandHandler(IPatrimonialAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<PatrimonialAsset> Handle(PatrimonialAssetCreateCommand request, CancellationToken cancellationToken)
        {
            PatrimonialAsset patrimonialAsset = new PatrimonialAsset(request.Name, request.PurchasePrice, request.PurchaseData, request.PurchaseQuantity, request.Supplier,
                                                                     request.Invoice, request.PurchaseTotalValue, request.Status, request.CategoryId, request.SubcategoryId,
                                                                     request.DepartmentId);

            if (patrimonialAsset != null)
                return await _repository.CreateAsync(patrimonialAsset);

            throw new ArgumentException("Erro ao criar o patrimônio");
        }
    }
}
