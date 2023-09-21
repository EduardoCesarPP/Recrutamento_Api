using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecrutamentoApi.Migrations
{
    /// <inheritdoc />
    public partial class Criar_Vaga3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscricao_Candidatos_CandidatoId",
                table: "Inscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscricao_Vaga_VagaId",
                table: "Inscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaga_Empresas_EmpresaId",
                table: "Vaga");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vaga",
                table: "Vaga");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inscricao",
                table: "Inscricao");

            migrationBuilder.RenameTable(
                name: "Vaga",
                newName: "Vagas");

            migrationBuilder.RenameTable(
                name: "Inscricao",
                newName: "Inscricoes");

            migrationBuilder.RenameIndex(
                name: "IX_Vaga_EmpresaId",
                table: "Vagas",
                newName: "IX_Vagas_EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Inscricao_VagaId",
                table: "Inscricoes",
                newName: "IX_Inscricoes_VagaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vagas",
                table: "Vagas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inscricoes",
                table: "Inscricoes",
                columns: new[] { "CandidatoId", "VagaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricoes_Candidatos_CandidatoId",
                table: "Inscricoes",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricoes_Vagas_VagaId",
                table: "Inscricoes",
                column: "VagaId",
                principalTable: "Vagas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Empresas_EmpresaId",
                table: "Vagas",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscricoes_Candidatos_CandidatoId",
                table: "Inscricoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscricoes_Vagas_VagaId",
                table: "Inscricoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Empresas_EmpresaId",
                table: "Vagas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vagas",
                table: "Vagas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inscricoes",
                table: "Inscricoes");

            migrationBuilder.RenameTable(
                name: "Vagas",
                newName: "Vaga");

            migrationBuilder.RenameTable(
                name: "Inscricoes",
                newName: "Inscricao");

            migrationBuilder.RenameIndex(
                name: "IX_Vagas_EmpresaId",
                table: "Vaga",
                newName: "IX_Vaga_EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Inscricoes_VagaId",
                table: "Inscricao",
                newName: "IX_Inscricao_VagaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vaga",
                table: "Vaga",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inscricao",
                table: "Inscricao",
                columns: new[] { "CandidatoId", "VagaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricao_Candidatos_CandidatoId",
                table: "Inscricao",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricao_Vaga_VagaId",
                table: "Inscricao",
                column: "VagaId",
                principalTable: "Vaga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaga_Empresas_EmpresaId",
                table: "Vaga",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
