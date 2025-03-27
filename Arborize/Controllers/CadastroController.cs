using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Arborize.Models;
using Arborize.Data;
using System.Security.Cryptography;
using System;
using System.Text;

namespace Arborize.Controllers
{
    public class CadastroController : Controller
    {
        private readonly DatabaseConnection _databaseConnection;
        private readonly ILogger<CadastroController> _logger;

        public CadastroController(ILogger<CadastroController> logger, DatabaseConnection databaseConnection)
        {
            _logger = logger;
            _databaseConnection = databaseConnection;

            try
            {
                bool isConnected = _databaseConnection.TestConnection();
                if (isConnected)
                {
                    _logger.LogInformation("Conexão com o banco de dados bem-sucedida no controlador.");
                }
                else
                {
                    _logger.LogError("Falha ao conectar ao banco de dados no controlador.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao testar a conexão com o banco de dados.");
            }
        }

        [HttpGet]
        [Route("Cadastro")]
        public IActionResult Index()
        {
            _logger.LogInformation("Página de Cadastro acessada.");
            return View("Cadastro");
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(CadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation("Tentando cadastrar um novo usuário.");

                    // Verificar se o e-mail já existe no banco de dados
                    bool emailExiste = _databaseConnection.VerificarEmailExistente(model.Email);
                    if (emailExiste)
                    {
                        _logger.LogWarning($"O e-mail {model.Email} já está cadastrado.");
                        ModelState.AddModelError("", "Este e-mail já está cadastrado.");
                        return View("Cadastro", model);
                    }

                    // Gerar salt e hash da senha
                    var (salt, hash) = HashPassword(model.Senha);

                    model.Salt = salt;
                    model.HashSenha = hash;

                    _databaseConnection.InsertCadastro(model);

                    _logger.LogInformation("Cadastro realizado com sucesso, redirecionando para a home.");
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao cadastrar usuário.");
                    ModelState.AddModelError("", "Erro ao cadastrar usuário: " + ex.Message);
                }
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogWarning($"Erro de validação: {error.ErrorMessage}");
                }
                _logger.LogWarning("ModelState inválido, retornando à página de cadastro.");
            }

            return View("Cadastro", model);
        }

        private (string Salt, string Hash) HashPassword(string password)
        {
            try
            {
                _logger.LogInformation("Iniciando a geração do hash e salt da senha.");

                byte[] salt = new byte[16];
                RandomNumberGenerator.Fill(salt);

                using (var hmac = new HMACSHA256(salt))
                {
                    byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                    string hash = Convert.ToBase64String(hashBytes);

                    _logger.LogInformation("Hash e salt gerados com sucesso.");
                    return (Convert.ToBase64String(salt), hash);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao gerar o hash da senha: {ex.Message}");
                throw new Exception("Erro ao gerar o hash da senha.", ex);
            }
        }
    }
}
