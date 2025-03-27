using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Arborize.Models;

namespace Arborize.Controllers;

[Route("tasklist")]
public class TaskListController : Controller
{
    private readonly ILogger<TaskListController> _logger;
    private readonly IConfiguration _configuration;

    public TaskListController(ILogger<TaskListController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    private IDbConnection GetConnection()
    {
        return new MySql.Data.MySqlClient.MySqlConnection(
            _configuration.GetConnectionString("DefaultConnection"));
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var userEmail = HttpContext.User.Identity?.Name;
        decimal saldo = 0;

        try
        {
            // Verificar se o usuário está logado
            if (string.IsNullOrEmpty(userEmail))
            {
                _logger.LogWarning("Usuário não está logado.");
                TempData["Error"] = "Por favor, faça login para acessar a lista de tarefas.";
                return RedirectToAction("Login", "Account");
            }

            using var connection = GetConnection();

            // Buscar saldo do usuário
            const string querySaldo = "SELECT Saldo FROM Cadastro WHERE Email = @Email";
            saldo = connection.QueryFirstOrDefault<decimal>(querySaldo, new { Email = userEmail });

            if (saldo == 0)
            {
                _logger.LogWarning($"Saldo não encontrado para o usuário: {userEmail}");
            }

            // Armazenar saldo no ViewData
            ViewData["Coins"] = saldo;

            // Buscar tarefas
            const string queryTarefas = "SELECT IdTaskList, NomeTarefa, ValorTarefa, ControllerTarefa, ActionTarefa FROM TaskList";
            var tarefas = connection.Query<TaskListModel>(queryTarefas).ToList();

            if (!tarefas.Any())
            {
                _logger.LogInformation("Nenhuma tarefa disponível na tabela TaskList.");
            }

            return View(tarefas);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao carregar a lista de tarefas.");
            TempData["Error"] = "Ocorreu um erro ao carregar a lista de tarefas.";
            return RedirectToAction("Error", "Home");
        }
    }
}
