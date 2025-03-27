using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MySql.Data.MySqlClient;

public class LayoutController : Controller
{
    private readonly IConfiguration _configuration;

    public LayoutController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private IDbConnection GetConnection()
    {
        return new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var userId = HttpContext.User.Identity.Name;
        Console.WriteLine($"LayoutController - UserId: {userId}");  // Depuração

        if (string.IsNullOrEmpty(userId))
        {
            ViewData["Coins"] = 0; // Se o usuário não estiver logado
        }
        else
        {
            if (int.TryParse(userId, out int idUsuario))
            {
                using var connection = GetConnection();
                string query = "SELECT Saldo FROM Cadastro WHERE IdUsuario = @IdUsuario";
                var saldo = connection.QueryFirstOrDefault<decimal?>(query, new { IdUsuario = idUsuario });

                Console.WriteLine($"LayoutController - Saldo Recuperado: {saldo}");  // Depuração
                ViewData["Coins"] = saldo ?? 0; // Se não encontrar saldo, coloca 0
            }
        }
    }
}
