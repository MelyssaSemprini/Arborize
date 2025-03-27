using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arborize.Migrations
{
    public partial class InitialCreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.Sql(@"
                CREATE TABLE IF NOT EXISTS `Cadastro` (
                    `CadastroModelId` int NOT NULL AUTO_INCREMENT,
                    `NomeCompleto` longtext NOT NULL,
                    `DataDeNascimento` datetime(6) NOT NULL,
                    `Email` longtext NOT NULL,
                    `NumeroDaCasa` longtext NOT NULL,
                    `Rua` longtext NOT NULL,
                    `Bairro` longtext NOT NULL,
                    `Cidade` longtext NOT NULL,
                    `Estado` longtext NOT NULL,
                    `Cep` longtext NOT NULL,
                    `Senha` longtext NOT NULL,
                    PRIMARY KEY (`CadastroModelId`)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;");

            // Criação de outras tabelas permanece como está
            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            // Continue com a criação das outras tabelas...
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Método Down permanece o mesmo
            migrationBuilder.DropTable(name: "Login");
            migrationBuilder.DropTable(name: "Cadastro");
            // Continue com a exclusão das outras tabelas...
        }
    }
}
