using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecrutamentoApi.Migrations
{
    /// <inheritdoc />
    public partial class criar3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DeficienciaAuditiva",
                table: "Curriculos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeficienciaAutista",
                table: "Curriculos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeficienciaFisica",
                table: "Curriculos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeficienciaIntelectual",
                table: "Curriculos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeficienciaVisual",
                table: "Curriculos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeficienciaAuditiva",
                table: "Curriculos");

            migrationBuilder.DropColumn(
                name: "DeficienciaAutista",
                table: "Curriculos");

            migrationBuilder.DropColumn(
                name: "DeficienciaFisica",
                table: "Curriculos");

            migrationBuilder.DropColumn(
                name: "DeficienciaIntelectual",
                table: "Curriculos");

            migrationBuilder.DropColumn(
                name: "DeficienciaVisual",
                table: "Curriculos");
        }
    }
}
