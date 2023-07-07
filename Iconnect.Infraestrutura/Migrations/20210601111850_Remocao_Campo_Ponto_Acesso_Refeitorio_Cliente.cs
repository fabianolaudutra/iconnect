using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class Remocao_Campo_Ponto_Acesso_Refeitorio_Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_cli_cliente_tb_pta_pontosAcesso",
                table: "tb_cli_cliente");

            migrationBuilder.DropIndex(
                name: "IX_tb_cli_cliente_cli_ref_pta_n_codigo",
                table: "tb_cli_cliente");

            migrationBuilder.DropColumn(
                name: "cli_ref_pta_n_codigo",
                table: "tb_cli_cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cli_ref_pta_n_codigo",
                table: "tb_cli_cliente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_cli_cliente_cli_ref_pta_n_codigo",
                table: "tb_cli_cliente",
                column: "cli_ref_pta_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_cli_cliente_tb_pta_pontosAcesso",
                table: "tb_cli_cliente",
                column: "cli_ref_pta_n_codigo",
                principalTable: "tb_pta_pontosAcesso",
                principalColumn: "pta_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
