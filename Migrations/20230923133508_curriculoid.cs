using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecrutamentoApi.Migrations
{
    /// <inheritdoc />
    public partial class curriculoid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificacoes_Curriculos_CurriculoId",
                table: "Certificacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienciasProfissionais_Curriculos_CurriculoId",
                table: "ExperienciasProfissionais");

            migrationBuilder.DropForeignKey(
                name: "FK_FormacoesAcademicas_Curriculos_CurriculoId",
                table: "FormacoesAcademicas");

            migrationBuilder.RenameColumn(
                name: "CurriculoId",
                table: "FormacoesAcademicas",
                newName: "CurriculoCandidatoId");

            migrationBuilder.RenameIndex(
                name: "IX_FormacoesAcademicas_CurriculoId",
                table: "FormacoesAcademicas",
                newName: "IX_FormacoesAcademicas_CurriculoCandidatoId");

            migrationBuilder.RenameColumn(
                name: "CurriculoId",
                table: "ExperienciasProfissionais",
                newName: "CurriculoCandidatoId");

            migrationBuilder.RenameIndex(
                name: "IX_ExperienciasProfissionais_CurriculoId",
                table: "ExperienciasProfissionais",
                newName: "IX_ExperienciasProfissionais_CurriculoCandidatoId");

            migrationBuilder.RenameColumn(
                name: "CurriculoId",
                table: "Certificacoes",
                newName: "CurriculoCandidatoId");

            migrationBuilder.RenameIndex(
                name: "IX_Certificacoes_CurriculoId",
                table: "Certificacoes",
                newName: "IX_Certificacoes_CurriculoCandidatoId");

            migrationBuilder.AddColumn<int>(
                name: "CandidatoId",
                table: "FormacoesAcademicas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CandidatoId",
                table: "ExperienciasProfissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CandidatoId",
                table: "Certificacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificacoes_Curriculos_CurriculoCandidatoId",
                table: "Certificacoes",
                column: "CurriculoCandidatoId",
                principalTable: "Curriculos",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienciasProfissionais_Curriculos_CurriculoCandidatoId",
                table: "ExperienciasProfissionais",
                column: "CurriculoCandidatoId",
                principalTable: "Curriculos",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormacoesAcademicas_Curriculos_CurriculoCandidatoId",
                table: "FormacoesAcademicas",
                column: "CurriculoCandidatoId",
                principalTable: "Curriculos",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificacoes_Curriculos_CurriculoCandidatoId",
                table: "Certificacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienciasProfissionais_Curriculos_CurriculoCandidatoId",
                table: "ExperienciasProfissionais");

            migrationBuilder.DropForeignKey(
                name: "FK_FormacoesAcademicas_Curriculos_CurriculoCandidatoId",
                table: "FormacoesAcademicas");

            migrationBuilder.DropColumn(
                name: "CandidatoId",
                table: "FormacoesAcademicas");

            migrationBuilder.DropColumn(
                name: "CandidatoId",
                table: "ExperienciasProfissionais");

            migrationBuilder.DropColumn(
                name: "CandidatoId",
                table: "Certificacoes");

            migrationBuilder.RenameColumn(
                name: "CurriculoCandidatoId",
                table: "FormacoesAcademicas",
                newName: "CurriculoId");

            migrationBuilder.RenameIndex(
                name: "IX_FormacoesAcademicas_CurriculoCandidatoId",
                table: "FormacoesAcademicas",
                newName: "IX_FormacoesAcademicas_CurriculoId");

            migrationBuilder.RenameColumn(
                name: "CurriculoCandidatoId",
                table: "ExperienciasProfissionais",
                newName: "CurriculoId");

            migrationBuilder.RenameIndex(
                name: "IX_ExperienciasProfissionais_CurriculoCandidatoId",
                table: "ExperienciasProfissionais",
                newName: "IX_ExperienciasProfissionais_CurriculoId");

            migrationBuilder.RenameColumn(
                name: "CurriculoCandidatoId",
                table: "Certificacoes",
                newName: "CurriculoId");

            migrationBuilder.RenameIndex(
                name: "IX_Certificacoes_CurriculoCandidatoId",
                table: "Certificacoes",
                newName: "IX_Certificacoes_CurriculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificacoes_Curriculos_CurriculoId",
                table: "Certificacoes",
                column: "CurriculoId",
                principalTable: "Curriculos",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienciasProfissionais_Curriculos_CurriculoId",
                table: "ExperienciasProfissionais",
                column: "CurriculoId",
                principalTable: "Curriculos",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormacoesAcademicas_Curriculos_CurriculoId",
                table: "FormacoesAcademicas",
                column: "CurriculoId",
                principalTable: "Curriculos",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
