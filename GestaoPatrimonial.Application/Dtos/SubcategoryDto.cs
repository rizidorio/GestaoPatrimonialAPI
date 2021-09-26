using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoPatrimonial.Application.Dtos
{
    public class SubcategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da subcategoria é obrigatório")]
        [MaxLength(100, ErrorMessage = "Nome da subcategoria deve ter no máximo 100 caracteres")]
        [DisplayName("Nome Subcategoria")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatório")]
        public int? CategoryId { get; set; }
        public ICollection<PatrimonialAssetDto> PatrimonialAssets { get; set; }
    }
}
