using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecrutamentoApi.Migrations
{
    /// <inheritdoc />
    public partial class correcproficiencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proficiencias_Curriculos_CurriculoId",
                table: "Proficiencias");

            migrationBuilder.RenameColumn(
                name: "CurriculoId",
                table: "Proficiencias",
                newName: "CandidatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proficiencias_Curriculos_CandidatoId",
                table: "Proficiencias",
                column: "CandidatoId",
                principalTable: "Curriculos",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proficiencias_Curriculos_CandidatoId",
                table: "Proficiencias");

            migrationBuilder.RenameColumn(
                name: "CandidatoId",
                table: "Proficiencias",
                newName: "CurriculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proficiencias_Curriculos_CurriculoId",
                table: "Proficiencias",
                column: "CurriculoId",
                principalTable: "Curriculos",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
