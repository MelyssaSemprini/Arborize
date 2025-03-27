using Microsoft.EntityFrameworkCore;
using Arborize.Data;
using Arborize.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arborize.Controllers
{
    public class DetalhesArvoreController : Controller
    {
        private readonly AppDbContext _context;
         private readonly ILogger<DetalhesArvoreController> _logger;

        public DetalhesArvoreController(AppDbContext context,  ILogger<DetalhesArvoreController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            //faz a busca da árvore com o ID especificado, incluindo o usuário e a curiosidade associados
            var arvore = await _context.CadastrarArvores
                .Include(a => a.Usuario)
                .Include(a => a.Curiosidade)
                .FirstOrDefaultAsync(a => a.IdArvore == id);

            if (arvore == null)
            {
                _logger.LogWarning($"Árvore com ID {id} não encontrada.");
                return View("Erro", new { Message = "Árvore não encontrada." });
            }

            // Passa o Model para a View, sem mapeamento para ViewModel
            return View(arvore);
        }
    }
}