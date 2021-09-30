using System.ComponentModel.DataAnnotations;

namespace GestaoPatrimonial.Domain.AuthModels
{
    public class RegisterUserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de senha")]
        [Compare("Password", ErrorMessage = "Senha não confere")]
        public string ConfirmPassword { get; set; }
    }
}
