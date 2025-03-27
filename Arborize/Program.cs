using Microsoft.EntityFrameworkCore;
using Arborize.Data;
using Arborize.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar a string de conexão
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Garantir que a string de conexão não seja nula
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi encontrada no arquivo de configuração.");
}

// Registrar o DbContext no contêiner de serviços
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Registrar o DatabaseConnection com injeção de dependência
builder.Services.AddScoped<DatabaseConnection>(provider =>
{
    var logger = provider.GetRequiredService<ILogger<DatabaseConnection>>();
    return new DatabaseConnection(logger, connectionString!); // '!' usado para informar ao compilador que a string não é nula
});

// Adicionar os serviços padrão do ASP.NET Core
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication()
                .AddCookie(); // Ajuste conforme necessário, por exemplo, se usar Identity

// Configurar a aplicação
var app = builder.Build();

// Configuração do middleware da aplicação
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Definir as rotas da aplicação
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Rodar a aplicação
app.Run();
