using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_coluna_grf_b_permiteHomeCare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_dva_duvidasApp_tb_cli_cliente",
                table: "tb_dva_duvidasApp");

            migrationBuilder.AddColumn<bool>(
                name: "grf_b_permiteHomeCare",
                table: "tb_grf_grupoFamiliar",
                nullable: true,
                defaultValueSql: "((1))");

            migrationBuilder.AlterColumn<int>(
                name: "dva_cli_n_codigo",
                table: "tb_dva_duvidasApp",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_dva_duvidasApp_tb_cli_cliente",
                table: "tb_dva_duvidasApp",
                column: "dva_cli_n_codigo",
                principalTable: "tb_cli_cliente",
                principalColumn: "cli_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_dva_duvidasApp_tb_cli_cliente",
                table: "tb_dva_duvidasApp");

            migrationBuilder.DropColumn(
                name: "grf_b_permiteHomeCare",
                table: "tb_grf_grupoFamiliar");

            migrationBuilder.AlterColumn<int>(
                name: "dva_cli_n_codigo",
                table: "tb_dva_duvidasApp",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_dva_duvidasApp_tb_cli_cliente",
                table: "tb_dva_duvidasApp",
                column: "dva_cli_n_codigo",
                principalTable: "tb_cli_cliente",
                principalColumn: "cli_n_codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
