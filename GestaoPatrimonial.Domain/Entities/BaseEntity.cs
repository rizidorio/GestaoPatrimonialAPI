using GestaoPatrimonial.Domain.Validation;
using System;
using System.Text.RegularExpressions;

namespace GestaoPatrimonial.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public void ValidationName(string name)
        {
            DomainExceptionValidation.Validate(string.IsNullOrEmpty(name), "Nome é obrigatório");
            DomainExceptionValidation.Validate(name.Length < 3, "Nome deve ter no mínimo 3 caracteres");
            DomainExceptionValidation.Validate(name.Length > 100, "Nome deve ter no máximo 100 caracteres");
            Name = name;
        }

        public static void EmailValidation(string email)
        {
            Regex EmailRegex = new Regex(@".+@.+\..+");

            if (!string.IsNullOrEmpty(email))
            {
                DomainExceptionValidation.Validate(!EmailRegex.IsMatch(email), "E-mail inválido");
                DomainExceptionValidation.Validate(email.Length > 80, "E-mail deve ter até 80 caracteres");
            }
        }

        public static void PhoneValidation(string phoneNumber)
        {
            Regex PhoneRegex = new Regex(@"(\([\d]{2}\) [\d]{4}\-[\d]{4})");

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                DomainExceptionValidation.Validate(!PhoneRegex.IsMatch(phoneNumber), "Telefone inválido");
            }
        }

        public static void CellPhoneValidation(string cellPhoneNumber)
        {
            Regex CellPhoneRegex = new Regex(@"(\([\d]{2}\) [\d]{5}\-[\d]{4})");

            if (!string.IsNullOrEmpty(cellPhoneNumber))
            {
                DomainExceptionValidation.Validate(!CellPhoneRegex.IsMatch(cellPhoneNumber), "Celular inválido");
            }
        }
    }
}
