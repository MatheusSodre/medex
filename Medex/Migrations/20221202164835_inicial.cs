using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Medex.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Sigla = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Especialidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cat = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Tratamento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Sobrenome = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Endereco = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Numero = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    Complemento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cep = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Uf = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Pais = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Idioma = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Categoria = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => new { x.id, x.Cpf });
                });

            migrationBuilder.CreateTable(
                name: "Solicitacao",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cpf = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DetalhesPrdId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Kit = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    IntervaloDesde = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IntervaloAte = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Frequencia = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    RefreshToken = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    RefreshTokenExperyTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Solicitacao");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
