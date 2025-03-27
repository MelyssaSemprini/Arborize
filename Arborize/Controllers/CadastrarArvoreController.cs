using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Arborize.Data;
using Arborize.Models;
using System.Linq;
using System.Security.Claims;

namespace Arborize.Controllers
{
    public class CadastrarArvoreController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CadastrarArvoreController> _logger;

        public CadastrarArvoreController(AppDbContext context, ILogger<CadastrarArvoreController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarArvore model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    // obter o idUsuario do usuário logado a partir claims
                    var idUsuarioClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    if (int.TryParse(idUsuarioClaim, out int idUsuario))
                    {
                        model.IdUsuario = idUsuario; // associa o idUsuario ao modelo da árvore
                    }
                    else
                    {

                        _logger.LogError("Erro ao obter IdUsuario do usuário logado.");
                        return Unauthorized();
                    }

                    // adicionar a árvore ao banco de dados
                    _context.CadastrarArvores.Add(model);
                    _context.SaveChanges();

                    // redirecionar para a página de detalhes da árvore recém-cadastrada
                    return RedirectToAction("Detalhes", "DetalhesArvore", new { id = model.IdArvore });
                }
            }
            catch (Exception ex)
            {
                // Logar o erro
                _logger.LogError(ex, "Erro ao cadastrar uma árvore.");
                ViewBag.ErrorMessage = "Ocorreu um erro ao cadastrar a árvore. Por favor, tente novamente.";
                return View(model); // Retornar a view com mensagem de erro
            }

            return View(model); // retornar a view com o modelo em caso de falha de validação
        }


    }
}