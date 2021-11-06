using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoPatrimonial.Application.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "Nome da fantasia deve ter até 100 caracteres")]
        [DisplayName("Nome Fantasia")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Razão social é obrigatório")]
        [MaxLength(100, ErrorMessage = "Razão social deve ter até 100 caracteres")]
        [DisplayName("Razão Social")]
        public string CorporateName { get; set; }

        [Required(ErrorMessage = "Tipo de pessoa é obrigatório")]
        [DisplayName("Tipo de pessoa")]
        public int CompanyType { get; set; }

        [Required(ErrorMessage = "CNPJ/CPF é obrigatório")]
        [DisplayName("CPNJ/CPF")]
        public string CnpjCpf { get; set; }

        [DisplayName("Inscrição Estadual")]
        public string IeRg { get; set; }

        [Required(ErrorMessage = "Nome do responsável é obrigatório")]
        [MaxLength(100, ErrorMessage = "Nome do responsável deve ter até 100 caracteres")]
        [DisplayName("Nome Responsável")]
        public string ResponsibleName { get; set; }

        [RegularExpression(@"[(][\d]{2}[)][\d]{4}-[\d]{4}", ErrorMessage = "Telefone inválido")]
        [DisplayName("Telefone")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"[(][\d]{2}[)][\d]{5}-[\d]{4}", ErrorMessage = "Celular inválido")]
        [DisplayName("Celular")]
        public string CellPhoneNumber { get; set; }

        [MaxLength(80)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        public int? AddressId { get; set; }

        [MaxLength(10, ErrorMessage = "Nº do endereço deve ter até 10 caracteres")]
        [DisplayName("Nº endereço")]
        public string AddressNumber { get; set; }

        [MaxLength(10, ErrorMessage = "Complemento do endereço deve ter até 80 caracteres")]
        [DisplayName("Complemento endereço")]
        public string AddressComplement { get; set; }
    }
}