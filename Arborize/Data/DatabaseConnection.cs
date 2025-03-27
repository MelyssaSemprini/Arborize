using MySql.Data.MySqlClient;
using Arborize.Models;
using Microsoft.Extensions.Logging;
using System;

public class DatabaseConnection
{
    private readonly string connectionString;
    private readonly ILogger<DatabaseConnection> _logger;

    // Alterar o construtor para aceitar a string de conexão
    public DatabaseConnection(ILogger<DatabaseConnection> logger, string connectionString)
    {
        _logger = logger;
        this.connectionString = connectionString; // Usando a string de conexão passada
    }

    public bool TestConnection()
    {
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open(); // Tenta abrir a conexão
                _logger.LogInformation("Conexão com o banco de dados bem-sucedida."); // Log de sucesso
                return true; // Retorna true se a conexão for bem-sucedida
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao conectar ao banco de dados: {ex.Message}"); // Log de erro
            return false; // Retorna false se houver algum erro na conexão
        }
    }

    // Método para inserir um novo cadastro
    public void InsertCadastro(CadastroModel model)
    {
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open(); // Abre a conexão
                _logger.LogInformation("Conexão aberta com sucesso para inserção.");

                string query = "INSERT INTO cadastro (NomeCompleto, DataDeNascimento, Email, NumeroDaCasa, Rua, Bairro, Cidade, Estado, Cep, HashSenha, Salt) " +
                               "VALUES (@NomeCompleto, @DataDeNascimento, @Email, @NumeroDaCasa, @Rua, @Bairro, @Cidade, @Estado, @Cep, @HashSenha, @Salt)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Adiciona parâmetros à consulta
                    cmd.Parameters.AddWithValue("@NomeCompleto", model.NomeCompleto);
                    cmd.Parameters.AddWithValue("@DataDeNascimento", model.DataDeNascimento.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@NumeroDaCasa", model.NumeroDaCasa);
                    cmd.Parameters.AddWithValue("@Rua", model.Rua);
                    cmd.Parameters.AddWithValue("@Bairro", model.Bairro);
                    cmd.Parameters.AddWithValue("@Cidade", model.Cidade);
                    cmd.Parameters.AddWithValue("@Estado", model.Estado);
                    cmd.Parameters.AddWithValue("@Cep", model.Cep);
                    cmd.Parameters.AddWithValue("@HashSenha", model.HashSenha);  // Alterado para HashSenha
                    cmd.Parameters.AddWithValue("@Salt", model.Salt);            // Alterado para Salt

                    cmd.ExecuteNonQuery(); // Executa a inserção
                    _logger.LogInformation("Cadastro inserido com sucesso no banco de dados.");
                }
            }
        }
        catch (MySqlException ex)
        {
            _logger.LogError($"Erro ao executar a operação no banco de dados: {ex.Message}"); // Log de erro
            throw new Exception("Erro ao executar a operação no banco de dados: " + ex.Message, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro desconhecido ao tentar inserir cadastro: {ex.Message}");
            throw new Exception("Erro desconhecido ao tentar inserir cadastro.", ex);
        }
    }

    // Método para verificar se o e-mail já existe
    public bool VerificarEmailExistente(string email)
    {
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open(); // Abre a conexão
                _logger.LogInformation("Conexão aberta com sucesso para verificar o e-mail.");

                string query = "SELECT COUNT(*) FROM cadastro WHERE Email = @Email";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    _logger.LogInformation($"Verificando e-mail. Resultado: {count} encontrado(s).");

                    return count > 0; // Se o número de registros for maior que 0, o e-mail já existe
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao verificar e-mail no banco de dados: {ex.Message}");
            throw new Exception("Erro ao verificar e-mail no banco de dados: " + ex.Message, ex);
        }
    }
}
