using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaMilhas.Migrations
{
    /// <inheritdoc />
    public partial class ProjetoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfertasViagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RotaId = table.Column<int>(type: "int", nullable: false),
                    Periodo_DataInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Periodo_DataFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Desconto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertasViagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfertasViagem_Rotas_RotaId",
                        column: x => x.RotaId,
                        principalTable: "Rotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfertasViagem_RotaId",
                table: "OfertasViagem",
                column: "RotaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfertasViagem");

            migrationBuilder.DropTable(
                name: "Rotas");
        }
    }
}
