using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System;

namespace GestaoPatrimonial.Application.CqrsPatrimonialAsset.Commands
{
    public class PatrimonialAssetCommand : IRequest<PatrimonialAsset>
    {
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime? PurchaseData { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public string Supplier { get; set; }
        public string Invoice { get; set; }
        public decimal PurchaseTotalValue { get; set; }
        public int Status { get; set; }
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
        public int? DepartmentId { get; set; }
    }
}
