using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Arborize.Models;

namespace Arborize.Controllers;

[Route("marketplace")]
public class MarketPlaceController : Controller
{
    private readonly ILogger<MarketPlaceController> _logger;
    private readonly IConfiguration _configuration;

    public MarketPlaceController(ILogger<MarketPlaceController> logger, IConfiguration configuration)
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
    public IActionResult Index() // Alterado de MarketPlace para Index
    {
        var userEmail = HttpContext.User.Identity?.Name;
        Console.WriteLine($"MarketPlaceController - UserEmail: {userEmail}");  // Depuração

        decimal saldo = 0;

        // Verificar se o usuário está logado
        if (!string.IsNullOrEmpty(userEmail))
        {
            using var connection = GetConnection();
            string querySaldo = "SELECT Saldo FROM Cadastro WHERE Email = @Email";
            saldo = connection.QueryFirstOrDefault<decimal>(querySaldo, new { Email = userEmail });

            Console.WriteLine($"MarketPlaceController - Saldo Recuperado: {saldo}"); // Depuração
        }

        ViewData["Coins"] = saldo;

        // Query para buscar os produtos
        using var productConnection = GetConnection();
        string queryProdutos = "SELECT NomeProduto, DescricaoProduto, FotoProduto, PrecoProduto FROM MarketPlace";
        var produtos = productConnection.Query<MarketPlaceModel>(queryProdutos).ToList();
        return View(produtos); // A view padrão será Views/MarketPlace/Index.cshtml
    }

    [HttpPost("comprar")]
    public IActionResult Comprar(string nomeProduto)
    {
        var userEmail = HttpContext.User.Identity?.Name;
        Console.WriteLine($"UserEmail: {userEmail}");  // Log para depuração

        if (string.IsNullOrEmpty(userEmail))
        {
            Console.WriteLine("Usuário não logado ou email inválido.");
            TempData["Error"] = "Usuário não logado.";
            return RedirectToAction(nameof(Index));
        }

        using var connection = GetConnection();

        string querySaldo = "SELECT Saldo FROM Cadastro WHERE Email = @Email";
        decimal saldo = connection.QueryFirstOrDefault<decimal>(querySaldo, new { Email = userEmail });
        Console.WriteLine($"Saldo do usuário {userEmail}: {saldo}"); // Depuração

        string queryProduto = "SELECT PrecoProduto FROM MarketPlace WHERE NomeProduto = @NomeProduto";
        var produto = connection.QueryFirstOrDefault<dynamic>(queryProduto, new { NomeProduto = nomeProduto });

        if (produto == null)
        {
            Console.WriteLine("Produto não encontrado.");
            TempData["Error"] = "Produto não encontrado.";
            return RedirectToAction(nameof(Index));
        }

        decimal precoProduto = produto.PrecoProduto;
        Console.WriteLine($"Produto: {nomeProduto}, Preço: {precoProduto}");

        if (saldo < precoProduto)
        {
            Console.WriteLine("Saldo insuficiente.");
            TempData["Error"] = "Saldo insuficiente.";
            return RedirectToAction(nameof(Index));
        }

        string updateSaldo = "UPDATE Cadastro SET Saldo = Saldo - @PrecoProduto WHERE Email = @Email";
        var rowsAffected = connection.Execute(updateSaldo, new { PrecoProduto = precoProduto, Email = userEmail });
        Console.WriteLine($"Linhas afetadas ao atualizar saldo: {rowsAffected}");

        if (rowsAffected <= 0)
        {
            Console.WriteLine("Erro ao atualizar o saldo.");
            TempData["Error"] = "Erro ao atualizar o saldo.";
            return RedirectToAction(nameof(Index));
        }

        string registrarCompra = "INSERT INTO Compras (IdUsuario, NomeProduto, DataCompra) VALUES ((SELECT IdUsuario FROM Cadastro WHERE Email = @Email), @NomeProduto, NOW())";
        var compraRegistrada = connection.Execute(registrarCompra, new { Email = userEmail, NomeProduto = nomeProduto });
        Console.WriteLine($"Linhas afetadas ao registrar compra: {compraRegistrada}");

        if (compraRegistrada > 0)
        {
            TempData["Success"] = "Compra realizada com sucesso!";
        }
        else
        {
            TempData["Error"] = "Erro ao registrar a compra.";
        }

        return RedirectToAction(nameof(Index));
    }
}
