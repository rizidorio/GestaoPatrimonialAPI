using GestaoPatrimonial.Domain.Validation;
using System;
using System.Collections.Generic;

namespace GestaoPatrimonial.Domain.Entities
{
    public sealed class BranchOffice : BaseEntity
    {
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string CellPhoneNumber { get; private set; }
        public string ResponsibleName { get; private set; }
        public string ResponsiblePhoneNumber { get; private set; }
        public string ResponsibleCellPhoneNumber { get; private set; }
        public string ResponsibleEmail { get; private set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public string AddressNumber { get; private set; }
        public string AddressComplement { get; private set; }

        public ICollection<Department> Departments { get; set; }

        private BranchOffice()
        {

        }

        public BranchOffice(string name, string email, string phoneNumber, string cellPhoneNumber, string responsibleName, string responsiblePhoneNumber, string responsibleCellPhoneNumber, string responsibleEmail, int? companyId, int? addressId, string addressNumber, string addressComplement)
        {
            ValidationName(name);
            EmailValidation(email);
            EmailValidation(responsibleEmail);
            PhoneValidation(phoneNumber);
            CellPhoneValidation(cellPhoneNumber);
            ValidationBranchOffice(responsibleName, addressComplement);

            PhoneNumber = phoneNumber;
            CellPhoneNumber = cellPhoneNumber;
            ResponsiblePhoneNumber = responsiblePhoneNumber;
            ResponsibleCellPhoneNumber = responsibleCellPhoneNumber;
            CompanyId = companyId;
            AddressId = addressId;
            AddressNumber = addressNumber;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        public void Update(string name, string email, string phoneNumber, string cellPhoneNumber, string responsibleName, string responsiblePhoneNumber, string responsibleCellPhoneNumber, string responsibleEmail, int? companyId, int? addressId, string addressNumber, string addressComplement)
        {
            ValidationName(name);
            EmailValidation(email);
            EmailValidation(responsibleEmail);
            PhoneValidation(phoneNumber);
            CellPhoneValidation(cellPhoneNumber);
            ValidationBranchOffice(responsibleName, addressComplement);

            PhoneNumber = phoneNumber;
            CellPhoneNumber = cellPhoneNumber;
            ResponsiblePhoneNumber = responsiblePhoneNumber;
            ResponsibleCellPhoneNumber = responsibleCellPhoneNumber;
            CompanyId = companyId;
            AddressId = addressId;
            AddressNumber = addressNumber;
            UpdateAt = DateTime.Now;
        }

        private void ValidationBranchOffice(string responsibleName, string addressComplement)
        {
            DomainExceptionValidation.Validate(string.IsNullOrEmpty(responsibleName), "Nome do responsável é obrigatório");
            DomainExceptionValidation.Validate(responsibleName.Length < 3, "Nome do responsável deve ter mais de 3 caracteres");
            DomainExceptionValidation.Validate(responsibleName.Length > 100, "Nome do responsável deve ter menos de 100 caracteres");

            DomainExceptionValidation.Validate(addressComplement?.Length > 80, "Complemento deve ter menos de 80 caracteres");

        }
    }
}
