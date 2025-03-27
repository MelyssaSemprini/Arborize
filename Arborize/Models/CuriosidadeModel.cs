using System.ComponentModel.DataAnnotations;

namespace Arborize.Models
{
    public class Curiosidade
    {
        [Key]
        public int IdCuriosidade { get; set; }
        public string? txtCuriosidade { get; set; }

    }
}