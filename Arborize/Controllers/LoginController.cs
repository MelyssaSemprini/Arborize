using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Arborize.Data;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text;
using Arborize.Models;

namespace Arborize.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<LoginController> _logger;

        public LoginController(AppDbContext dbContext, ILogger<LoginController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public static class PasswordHelper
        {
            public static bool VerifyPassword(string password, string? storedHash, string? storedSalt)
            {
                if (string.IsNullOrEmpty(storedHash) || string.IsNullOrEmpty(storedSalt))
                {
                    return false;
                }

                try
                {
                    byte[] saltBytes = Convert.FromBase64String(storedSalt);
                    byte[] storedHashBytes = Convert.FromBase64String(storedHash);

                    using (var hmac = new HMACSHA256(saltBytes))
                    {
                        byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                        return storedHashBytes.SequenceEqual(computedHash);
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            _logger.LogInformation("Acessando a página de login.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelo inválido ao tentar autenticar.");
                return View("Login");
            }

            _logger.LogInformation($"Tentando autenticar o usuário: {model.Email}");

            var user = _dbContext.Usuario.SingleOrDefault(u => u.Email == model.Email);

            if (user == null)
            {
                _logger.LogWarning($"Usuário não encontrado: {model.Email}");
                ModelState.AddModelError("", "E-mail ou senha inválidos.");
                return View("Login");
            }

            if (!PasswordHelper.VerifyPassword(model.Senha, user.HashSenha, user.Salt))
            {
                _logger.LogWarning($"Falha na senha para o usuário: {model.Email}");
                ModelState.AddModelError("", "E-mail ou senha inválidos.");
                return View("Login");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            _logger.LogInformation($"Usuário {model.Email} autenticado com sucesso, redirecionando para a página inicial.");
            return RedirectToAction("FeedPage", "Feed");

        }

        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Logout()
{
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return RedirectToAction("Index", "Home");
}
    }
}
