using Microsoft.AspNetCore.Mvc;
using Arborize.Models;
using Arborize.Data;
using System.Linq;

namespace Arborize.Controllers
{
    public class FeedController : Controller
    {
        private readonly AppDbContext _context;

        public FeedController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FeedPage (Redirecionamento após login)
        [HttpGet]
        public IActionResult FeedPage()
        {
            var posts = _context.Feed
                                .OrderByDescending(p => p.DataPost)
                                .ToList();

            return View("~/Views/Feed/Feed.cshtml", posts);
        }

        // Rota para Cadastrar Árvore
        [HttpGet]
        public IActionResult CadastrarArvore()
        {
            // Retorna a view para o cadastro de árvore
            return View("Views/CadastrarArvore/CadastrarArvore.cshtml");
        }

        // Rota para Minhas Árvores
        [HttpGet]
        public IActionResult MinhasArvores()
        {

            return View("Views/MinhasArvores/MinhasArvores.cshtml");
        }

        [HttpGet]
        public IActionResult Perfil()
        {
            return View("Views/Perfil/Perfil.cshtml");
        }
    }
}
