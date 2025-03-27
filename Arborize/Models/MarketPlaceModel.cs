using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arborize.Models
{
    public class MarketPlaceModel
    {
        [Key]
        public int IdProduto { get; set; }

        [ForeignKey("CadastroModel")]
        public int IdUsuario { get; set; }

        public required string NomeProduto { get; set; }

        public required string DescricaoProduto { get; set; }

        public required decimal PrecoProduto { get; set; }

        public required string FotoProduto { get; set; }

        // Navegação (opcional, para o relacionamento com o Usuário)
        public virtual required CadastroModel Cadastro { get; set; }
    }
}
