using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_cascate_tb_ope_oreador_tb_ace_acesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_ope_operador_tb_ace_acesso",
                table: "tb_ope_operador");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_ope_operador_tb_ace_acesso",
                table: "tb_ope_operador",
                column: "ope_ace_n_codigo",
                principalTable: "tb_ace_acesso",
                principalColumn: "ace_n_codigo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_ope_operador_tb_ace_acesso",
                table: "tb_ope_operador");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_ope_operador_tb_ace_acesso",
                table: "tb_ope_operador",
                column: "ope_ace_n_codigo",
                principalTable: "tb_ace_acesso",
                principalColumn: "ace_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
