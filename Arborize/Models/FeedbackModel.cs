using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arborize.Models
{
    public class FeedbackModel
    {
        [Key]
        public int IdFeedback { get; set; }

        [StringLength(100)]
        public required string Titulo { get; set; }

        [StringLength(100)]
        public required string FeedbackTexto { get; set; }

        public DateTime DataEnvio { get; set; } = DateTime.Now;

        // Chave estrangeira para CadastroModel
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; } // FK para CadastroModel

        // Propriedade de navegação
        public CadastroModel? Usuario { get; set; }
    }
}
