using GestaoPatrimonial.Domain.Validation;
using System.Collections.Generic;

namespace GestaoPatrimonial.Domain.Entities
{
    public sealed class Address
    {
        public int Id { get; private set; }
        public string PostalCode { get; private set; }
        public string Adrress { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public ICollection<Company> Companies { get; set; }
        public ICollection<BranchOffice> Offices { get; set; }

        private Address()
        { }

        public Address(string postalCode, string address, string district, string city, string state)
        {
            ValidateAddress(postalCode, address, district, city, state);
        }

        public void Update(string postalCode, string address, string district, string city, string state)
        {
            ValidateAddress(postalCode, address, district, city, state);
        }

        private void ValidateAddress(string postalCode, string address, string district, string city, string state)
        {
            DomainExceptionValidation.Validate(string.IsNullOrEmpty(postalCode), "Cep é obrigatório");
            DomainExceptionValidation.Validate(postalCode.Length < 8, "Cep inválido");
            DomainExceptionValidation.Validate(address.Length > 100, "Logradouro deve ter até 100 caracteres");
            DomainExceptionValidation.Validate(district.Length > 50, "Bairro deve ter até 50 caracteres");
            DomainExceptionValidation.Validate(city.Length > 50, "Cidade deve ter até 50 caracteres");
            DomainExceptionValidation.Validate(state.Length > 2, "Estado deve ter até 02 caracteres");

            PostalCode = postalCode;
            Adrress = address;
            District = district;
            City = city;
            State = state;
        }
    }
}
