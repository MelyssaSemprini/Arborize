using System;
using System.ComponentModel.DataAnnotations;

namespace Arborize.Models
{
    public class FeedModel
    {
        [Key]
        public int IdPost { get; set; } // Ajustado para corresponder ao banco de dados

        [Required]
        public int IdUsuario { get; set; } // FK para CadastroModel

        public required string ImgPost { get; set; } // URL da imagem do post

        public DateTime DataPost { get; set; } = DateTime.Now; // Data da postagem

        [Required]
        public string? DescricaoPost { get; set; } // Descrição do post

        [Required]
        public required string Localizacao { get; set; } // Localização escolhida

        public string? TipoLocalizacao { get; set; } // Propriedade adicional
    }
}
