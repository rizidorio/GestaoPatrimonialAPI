using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoPatrimonial.Application.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório")]
        [RegularExpression(@"[\d]{2}.[\d]{3}-[\d]{3}", ErrorMessage = "CEP inválido")]
        [DisplayName("CEP")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Logradouro é obrigatório")]
        [MaxLength(100, ErrorMessage = "Logradouro deve ter até 100 caracteres")]
        [DisplayName("Logradouro")]
        public string Adrress { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        [MaxLength(50, ErrorMessage = "Bairro deve ter até 50 caracteres")]
        [DisplayName("Bairro")]
        public string District { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório")]
        [MaxLength(50, ErrorMessage = "Cidade deve ter até 50 caracteres")]
        [DisplayName("Cidade")]
        public string City { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório")]
        [MaxLength(2, ErrorMessage = "Estado deve ter até 2 caracteres")]
        [DisplayName("Estado")]
        public string State { get; set; }
    }
}
