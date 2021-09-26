using GestaoPatrimonial.Domain.Utils.Enums;
using GestaoPatrimonial.Domain.Validation;
using System;
using System.Collections.Generic;

namespace GestaoPatrimonial.Domain.Entities
{
    public sealed class Company : BaseEntity
    {
        public string CorporateName { get; private set; }
        public CompanyType CompanyType { get; private set; }
        public string CnpjCpf { get; private set; }
        public string IeRg { get; private set; }
        public string ResponsibleName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string CellPhoneNumber { get; private set; }
        public string Email { get; private set; }

        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public string AddressNumber { get; private set; }
        public string AddressComplement { get; private set; }
        public IEnumerable<BranchOffice> Offices { get; set; }
        public IEnumerable<Department> Departments { get; set; }

        private Company()
        {

        }

        public Company(string name, string corporateName, int companyType, string cnpjCpf, string ieRg, string responsableName, string phoneNumber, string cellPhoneNumber, string email, int? addressId, string addressNumber, string addressComplement)
        {
            ValidationName(name);
            EmailValidation(email);
            PhoneValidation(phoneNumber);
            CellPhoneValidation(cellPhoneNumber);
            ValidationCompany(corporateName, cnpjCpf, responsableName, email, addressComplement);
            IeRg = ieRg;
            CompanyType = (CompanyType)companyType;
            PhoneNumber = phoneNumber;
            CellPhoneNumber = cellPhoneNumber;
            AddressId = addressId;
            AddressNumber = addressNumber;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        public void Update(string name, string corporateName, int companyType, string cnpjCpf, string ieRg, string responsableName, string phoneNumber, string cellPhoneNumber, string email, int? addressId, string addressNumber, string addressComplement)
        {
            ValidationName(name);
            EmailValidation(email);
            PhoneValidation(phoneNumber);
            CellPhoneValidation(cellPhoneNumber);
            ValidationCompany(corporateName, cnpjCpf, responsableName, email, addressComplement);
            IeRg = ieRg;
            CompanyType = (CompanyType)companyType;
            Email = email;
            PhoneNumber = phoneNumber;
            CellPhoneNumber = cellPhoneNumber;
            AddressId = addressId;
            AddressNumber = addressNumber;
            UpdateAt = DateTime.Now;
        }

        private void ValidationCompany(string corporateName, string cnpjCpf, string responsableName, string email, string addressComplement)
        {
            DomainExceptionValidation.Validate(string.IsNullOrEmpty(corporateName), "Razão social é obrigatória");
            DomainExceptionValidation.Validate(corporateName.Length < 3, "Razão social deve ter mais de 3 caracteres");
            DomainExceptionValidation.Validate(corporateName.Length > 100, "Razão social deve ter menos de 100 caracteres");

            DomainExceptionValidation.Validate(string.IsNullOrEmpty(cnpjCpf), "CNPJ/CPF é obrigatório");

            DomainExceptionValidation.Validate(responsableName?.Length < 3, "Responsável deve ter mais de 3 caracteres");
            DomainExceptionValidation.Validate(responsableName?.Length > 80, "Responsável deve ter menos de 80 caracteres");

            DomainExceptionValidation.Validate(string.IsNullOrEmpty(email), "E-mail é obrigatório");

            DomainExceptionValidation.Validate(addressComplement?.Length > 80, "Complemento deve ter até 80 caracteres");


            CorporateName = corporateName;
            CnpjCpf = cnpjCpf;
            ResponsibleName = responsableName;
            Email = email;
            AddressComplement = addressComplement;
        }
    }
}
