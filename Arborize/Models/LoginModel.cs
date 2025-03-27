using System.ComponentModel.DataAnnotations;

namespace Arborize.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        public required string Email { get; set; }


        [Required (ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        public required string Senha { get; set; }

    } 
}