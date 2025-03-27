using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arborize.Models
{
    public class TaskListModel
    {
        [Key]
        public int IdTaskList { get; set; }

        [ForeignKey("CadastroModel")]
        public int IdUsuario { get; set; }

        // Propriedade de nome da tarefa com validação de tamanho
        [Required]
        [StringLength(255)]  
        public string NomeTarefa { get; set; }

        // Propriedade de valor da tarefa com validação de valor positivo
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor da tarefa deve ser positivo")]
        public decimal ValorTarefa { get; set; }

        // Novas propriedades para ControllerTarefa e ActionTarefa
        [Required]
        [StringLength(255)]  
        public string ControllerTarefa { get; set; }

        [Required]
        [StringLength(255)]  
        public string ActionTarefa { get; set; }

        // Relacionamento com o usuário (CadastroModel)
        public virtual CadastroModel Cadastro { get; set; }

        // Construtor para inicializar as propriedades obrigatórias
        public TaskListModel()
        {
            NomeTarefa = string.Empty;
            ControllerTarefa = string.Empty;
            ActionTarefa = string.Empty;
        }
    }
}
