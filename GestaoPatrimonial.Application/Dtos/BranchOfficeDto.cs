using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoPatrimonial.Application.Dtos
{
    public class BranchOfficeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da filial é obrigatório")]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [MaxLength(80)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [RegularExpression(@"[(][\d]{2}[)][\d]{4}-[\d]{4}", ErrorMessage = "Telefone inválido")]
        [DisplayName("Telefone")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"[(][\d]{2}[)][\d]{5}-[\d]{4}", ErrorMessage = "Celular inválido")]
        [DisplayName("Celular")]
        public string CellPhoneNumber { get; set; }

        [Required(ErrorMessage = "Nome do responsável pela filial é obrigatório")]
        [MaxLength(100)]
        [DisplayName("Respnsável filial")]
        public string ResponsibleName { get; set; }

        [RegularExpression(@"[(][\d]{2}[)][\d]{4}-[\d]{4}", ErrorMessage = "Telefone inválido")]
        [DisplayName("Telefone responsável")]
        public string ResponsiblePhoneNumber { get; set; }

        [RegularExpression(@"[(][\d]{2}[)][\d]{5}-[\d]{4}", ErrorMessage = "Celular inválido")]
        [DisplayName("Celular responsável")]
        public string ResponsibleCellPhoneNumber { get; set; }

        [MaxLength(80)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail responsável")]
        public string ResponsibleEmail { get; set; }

        [Required(ErrorMessage = "Matriz é obrigatório")]
        [DisplayName("Matriz")]
        public int? CompanyId { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        public int? AddressId { get; set; }

        [MaxLength(10, ErrorMessage = "Nº do endereço deve ter até 10 caracteres")]
        [DisplayName("Nº endereço")]
        public string AddressNumber { get; set; }

        [MaxLength(80, ErrorMessage = "Complemento do endereço deve ter até 80 caracteres")]
        [DisplayName("Complemento endereço")]
        public string AddressComplement { get; set; }
    }
}
