using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecrutamentoApi.Migrations
{
    /// <inheritdoc />
    public partial class criar2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_FormacoesAcademicas_CurriculoCandidatoId",
                table: "FormacoesAcademicas");

            migrationBuilder.DropIndex(
                name: "IX_ExperienciasProfissionais_CurriculoCandidatoId",
                table: "ExperienciasProfissionais");

            migrationBuilder.DropIndex(
                name: "IX_Certificacoes_CurriculoCandidatoId",
                table: "Certificacoes");

            migrationBuilder.DropColumn(
                name: "CurriculoCandidatoId",
                table: "FormacoesAcademicas");

            migrationBuilder.DropColumn(
                name: "CurriculoCandidatoId",
                table: "ExperienciasProfissionais");

            migrationBuilder.DropColumn(
                name: "CurriculoCandidatoId",
                table: "Certificacoes");

            migrationBuilder.CreateIndex(
                name: "IX_FormacoesAcademicas_CandidatoId",
                table: "FormacoesAcademicas",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienciasProfissionais_CandidatoId",
                table: "ExperienciasProfissionais",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificacoes_CandidatoId",
                table: "Certificacoes",
                column: "CandidatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificacoes_Curriculos_CandidatoId",
                table: "Certificacoes",
                column: "CandidatoId",
                principalTable: "Curriculos",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienciasProfissionais_Curriculos_CandidatoId",
                table: "ExperienciasProfissionais",
                column: "CandidatoId",
                principalTable: "Curriculos",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormacoesAcademicas_Curriculos_CandidatoId",
                table: "FormacoesAcademicas",
                column: "CandidatoId",
                principalTable: "Curriculos",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificacoes_Curriculos_CandidatoId",
                table: "Certificacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienciasProfissionais_Curriculos_CandidatoId",
                table: "ExperienciasProfissionais");

            migrationBuilder.DropForeignKey(
                name: "FK_FormacoesAcademicas_Curriculos_CandidatoId",
                table: "FormacoesAcademicas");

            migrationBuilder.DropIndex(
                name: "IX_FormacoesAcademicas_CandidatoId",
                table: "FormacoesAcademicas");

            migrationBuilder.DropIndex(
                name: "IX_ExperienciasProfissionais_CandidatoId",
                table: "ExperienciasProfissionais");

            migrationBuilder.DropIndex(
                name: "IX_Certificacoes_CandidatoId",
                table: "Certificacoes");

            migrationBuilder.AddColumn<int>(
                name: "CurriculoCandidatoId",
                table: "FormacoesAcademicas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurriculoCandidatoId",
                table: "ExperienciasProfissionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurriculoCandidatoId",
                table: "Certificacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FormacoesAcademicas_CurriculoCandidatoId",
                table: "FormacoesAcademicas",
                column: "CurriculoCandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienciasProfissionais_CurriculoCandidatoId",
                table: "ExperienciasProfissionais",
                column: "CurriculoCandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificacoes_CurriculoCandidatoId",
                table: "Certificacoes",
                column: "CurriculoCandidatoId");

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
    }
}
