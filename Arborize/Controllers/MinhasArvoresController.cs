using Microsoft.AspNetCore.Mvc;
using Arborize.Models;
using Arborize.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arborize.Controllers
{
    public class MinhasArvoresController : Controller
    {
        private readonly AppDbContext _context;

        public MinhasArvoresController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // verificação se o userId foi encontrado
            if (int.TryParse(userIdClaim, out int userId))
            {
                var arvores = _context.CadastrarArvores
                    .Where(a => a.IdUsuario == userId)
                    .ToList();

                return View(arvores);  
            }
            else
            {
                // caso não encontrar, mostra erro
                return Unauthorized(); 
            }
        }
    }
}