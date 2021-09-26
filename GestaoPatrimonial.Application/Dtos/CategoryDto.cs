using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoPatrimonial.Application.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da categoria é obrigatório")]
        [MaxLength(100, ErrorMessage = "Nome da categoria deve ter até 100 caracteres")]
        [DisplayName("Nome Categoria")]
        public string Name { get; set; }
    }
}
