using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Arborize.Models;
using Microsoft.AspNetCore.Authorization;


namespace Arborize.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Index() // Index aqui puxa a view Cadastro
    {
        return View();
    }

    public IActionResult Feedback()
    {
        return View("~/Views/Feedback/Feedback.cshtml");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
