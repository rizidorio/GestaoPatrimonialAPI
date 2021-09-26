using GestaoPatrimonial.Domain.Utils.Enums;
using GestaoPatrimonial.Domain.Validation;
using System;

namespace GestaoPatrimonial.Domain.Entities
{
    public sealed class PatrimonialAsset : BaseEntity
    {
        public decimal PurchasePrice { get; private set; }
        public DateTime? PurchaseDate { get; private set; }
        public decimal PurchaseQuantity { get; private set; }
        public string Supplier { get; private set; }
        public string Invoice { get; private set; }
        public decimal PurchaseTotalValue { get; private set; }
        public PatrimonialAssestStatus Status { get; private set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int? SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        private PatrimonialAsset()
        {

        }

        public PatrimonialAsset(string name, decimal purchasePrice, DateTime? purchaseDate, decimal purchaseQuantity, string supplier, string invoice, decimal purchaseTotalValue, int status, int? categoryId, int? subcategoryId, int? departmentId)
        {
            ValidationName(name);
            ValidationPatrimonialAsset(supplier, invoice);
            PurchasePrice = purchasePrice;
            PurchaseDate = purchaseDate;
            PurchaseQuantity = purchaseQuantity;
            PurchaseTotalValue = purchaseTotalValue;
            Status = (PatrimonialAssestStatus)status;
            CategoryId = categoryId;
            SubcategoryId = subcategoryId;
            DepartmentId = departmentId;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        public void Update(string name, decimal purchasePrice, DateTime? purchaseDate, decimal purchaseQuantity, string supplier, string invoice, decimal purchaseTotalValue, int status, int? categoryId, int? subcategoryId, int? departmentId)
        {
            ValidationName(name);
            ValidationPatrimonialAsset(supplier, invoice);
            PurchasePrice = purchasePrice;
            PurchaseDate = purchaseDate;
            PurchaseQuantity = purchaseQuantity;
            PurchaseTotalValue = purchaseTotalValue;
            Status = (PatrimonialAssestStatus)status;
            CategoryId = categoryId;
            SubcategoryId = subcategoryId;
            DepartmentId = departmentId;
            UpdateAt = DateTime.Now;
        }

        private void ValidationPatrimonialAsset(string supplier, string invoice)
        {
            DomainExceptionValidation.Validate(supplier?.Length < 3, "Fornecedor deve ter mais de 3 caracteres");
            DomainExceptionValidation.Validate(supplier?.Length > 80, "Fornecedor deve ter menos de 80 caracteres");
            DomainExceptionValidation.Validate(invoice?.Length > 10, "Nota fiscal deve ter menos de 10 caracteres");
            Supplier = supplier;
            Invoice = invoice;
        }
    }
}
