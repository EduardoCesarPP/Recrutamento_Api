using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecrutamentoApi.Migrations
{
    /// <inheritdoc />
    public partial class Nivel_formacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Opcao",
                table: "FormacoesAcademicas",
                newName: "TextoNivelFormacao");

            migrationBuilder.AddColumn<int>(
                name: "NivelFormacao",
                table: "FormacoesAcademicas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NivelFormacao",
                table: "FormacoesAcademicas");

            migrationBuilder.RenameColumn(
                name: "TextoNivelFormacao",
                table: "FormacoesAcademicas",
                newName: "Opcao");
        }
    }
}
