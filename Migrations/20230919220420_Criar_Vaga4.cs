using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecrutamentoApi.Migrations
{
    /// <inheritdoc />
    public partial class Criar_Vaga4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusInscricao",
                table: "Inscricoes");

            migrationBuilder.AddColumn<string>(
                name: "TextoStatusInscricao",
                table: "Inscricoes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextoStatusInscricao",
                table: "Inscricoes");

            migrationBuilder.AddColumn<int>(
                name: "StatusInscricao",
                table: "Inscricoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
