using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class relacionamentoEmpresaXAcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tb_ace_acesso_ace_emp_n_codigo",
                table: "tb_ace_acesso",
                column: "ace_emp_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_ace_acesso_tb_emp_empresa",
                table: "tb_ace_acesso",
                column: "ace_emp_n_codigo",
                principalTable: "tb_emp_empresa",
                principalColumn: "emp_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_ace_acesso_tb_emp_empresa",
                table: "tb_ace_acesso");

            migrationBuilder.DropIndex(
                name: "IX_tb_ace_acesso_ace_emp_n_codigo",
                table: "tb_ace_acesso");
        }
    }
}
