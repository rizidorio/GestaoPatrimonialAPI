using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoPatrimonial.Application.Dtos
{
    public class PatrimonialAssetDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do patrimônio é obrigatório")]
        [MaxLength(100, ErrorMessage = "Nome do patrimônio deve ter no máximo 100 caracteres")]
        [DisplayName("Nome Patrimônio")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço de Compra")]
        public decimal PurchasePrice { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data da Compra")]
        public DateTime? PurchaseDate { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Quantidade")]
        public decimal PurchaseQuantity { get; set; }

        [MaxLength(80, ErrorMessage = "Fornecedor deve ter no máximo 80 caracteres")]
        [DisplayName("Fornecedor")]
        public string Supplier { get; set; }

        [MaxLength(10, ErrorMessage = "Nota fiscal deve ter no máximo 10 caracteres")]
        [DisplayName("Nota Fiscal")]
        public string Invoice { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor Total")]
        public decimal PurchaseTotalValue { get; set; }

        public int Status { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatório")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Subcategoria é obrigatório")]
        public int? SubcategoryId { get; set; }

        [Required(ErrorMessage = "Setor é obrigatório")]
        public int? DepartmentId { get; set; }
    }
}
