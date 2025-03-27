using System.ComponentModel.DataAnnotations;
using Arborize.Controllers;
using Arborize.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;


namespace Arborize.Models
{
    [Table("cadastro")]
    public class CadastroModel
    {
        [Key]
        public required int IdUsuario { get; set; }

        [StringLength(45, ErrorMessage = "O nome completo não pode exceder 45 caracteres.")]
        public required string NomeCompleto { get; set; }
        public required DateTime DataDeNascimento { get; set; }

        [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
        public required string Email { get; set; }
        public required int NumeroDaCasa { get; set; }
        public required string Rua { get; set; }
        public required string Bairro { get; set; }
        public required string Cidade { get; set; }
        public required string Estado { get; set; }

        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP deve estar no formato XXXXX-XXX.")]
        public required string Cep { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
          // Não armazenar a senha diretamente no banco de dados
        [NotMapped]
        public required string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        [NotMapped]
        public required string RepetirSenha { get; set; }

        // Campos para armazenar o hash e salt, agora sem o NotMapped
        public string? Salt { get; set; }
        public string? HashSenha { get; set; }

        public ICollection<FeedbackModel>? Feedbacks { get; set; }
        public ICollection<CadastrarArvore>? Arvores {get;set;}
    }
}
