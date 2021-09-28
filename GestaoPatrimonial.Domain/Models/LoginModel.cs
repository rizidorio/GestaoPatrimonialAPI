using System.ComponentModel.DataAnnotations;

namespace GestaoPatrimonial.Domain.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
