using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arborize.Models
{
    public class CadastrarArvore //se trata de 'cadastro de arvores'
    {
        [Key]
        public int IdArvore { get; set; }


        [MaxLength(255)]
        public required string NomeEspecie { get; set; }
        public string? OrigemArv { get; set; }

        public required string DescricaoArv { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public DateTime DataPlantio { get; set; }

        [MaxLength(255)]
        public string? ImagemArvore { get; set; }

        // Chave estrangeira 
        public int IdUsuario { get; set; }
        public required CadastroModel Usuario { get; set; }

        public Curiosidade? Curiosidade { get; set; }
    }
}
