using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecrutamentoApi.Migrations
{
    /// <inheritdoc />
    public partial class Criar_Vaga2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Vaga",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vaga_EmpresaId",
                table: "Vaga",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaga_Empresas_EmpresaId",
                table: "Vaga",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaga_Empresas_EmpresaId",
                table: "Vaga");

            migrationBuilder.DropIndex(
                name: "IX_Vaga_EmpresaId",
                table: "Vaga");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Vaga");
        }
    }
}
