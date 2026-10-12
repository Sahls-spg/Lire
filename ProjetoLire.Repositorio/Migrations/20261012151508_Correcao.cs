using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLire.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class Correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Leitura",
                table: "Leituras",
                newName: "PaginaAtual");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaginaAtual",
                table: "Leituras",
                newName: "Leitura");
        }
    }
}
