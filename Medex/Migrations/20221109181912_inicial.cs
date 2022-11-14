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
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpf = table.Column<string>(type: "text", nullable: false),
                    sigla = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    especialidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cat = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    tratamento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    nome = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    sobrenome = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    endereco = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    numero = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    complemento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cep = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    uf = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    pais = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    idioma = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    telefone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    categoria = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => new { x.id, x.cpf });
                });

            migrationBuilder.CreateTable(
                name: "Solicitacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpf = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    detalhes_prd_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    kit = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    intervalo_desde = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    intervalo_ate = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    frequencia = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacao", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Solicitacao");
        }
    }
}
