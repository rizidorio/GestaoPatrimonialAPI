using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoPatrimonial.Application.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do setor é obrigatório")]
        [MaxLength(100)]
        [DisplayName("Nome Setor")]
        public string Name {  get; set; }

        [MaxLength(10)]
        [DisplayName("Sigla Setor")]
        public string Initials { get; set; }

        public int? BranchOfficeId { get; set; }
        public int? CompanyId { get; set; }
    }
}