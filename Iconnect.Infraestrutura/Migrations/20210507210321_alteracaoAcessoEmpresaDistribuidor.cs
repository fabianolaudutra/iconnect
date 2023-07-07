using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class alteracaoAcessoEmpresaDistribuidor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_emp_empresa_tb_dis_distribuidor_tb_dis_distribuidordis_n_codigo",
                table: "tb_emp_empresa");

            migrationBuilder.DropIndex(
                name: "IX_tb_emp_empresa_tb_dis_distribuidordis_n_codigo",
                table: "tb_emp_empresa");

            migrationBuilder.DropColumn(
                name: "tb_dis_distribuidordis_n_codigo",
                table: "tb_emp_empresa");

            migrationBuilder.AddColumn<int>(
                name: "emp_dis_n_codigo",
                table: "tb_emp_empresa",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ace_b_relacionalDist",
                table: "tb_ace_acesso",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ace_dis_n_codigo",
                table: "tb_ace_acesso",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_emp_empresa_emp_dis_n_codigo",
                table: "tb_emp_empresa",
                column: "emp_dis_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ace_acesso_ace_dis_n_codigo",
                table: "tb_ace_acesso",
                column: "ace_dis_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_ace_acesso_tb_dis_distribuidor",
                table: "tb_ace_acesso",
                column: "ace_dis_n_codigo",
                principalTable: "tb_dis_distribuidor",
                principalColumn: "dis_n_codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_emp_empresa_tb_dis_distribuidor",
                table: "tb_emp_empresa",
                column: "emp_dis_n_codigo",
                principalTable: "tb_dis_distribuidor",
                principalColumn: "dis_n_codigo",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_ace_acesso_tb_dis_distribuidor",
                table: "tb_ace_acesso");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_emp_empresa_tb_dis_distribuidor",
                table: "tb_emp_empresa");

            migrationBuilder.DropIndex(
                name: "IX_tb_emp_empresa_emp_dis_n_codigo",
                table: "tb_emp_empresa");

            migrationBuilder.DropIndex(
                name: "IX_tb_ace_acesso_ace_dis_n_codigo",
                table: "tb_ace_acesso");

            migrationBuilder.DropColumn(
                name: "emp_dis_n_codigo",
                table: "tb_emp_empresa");

            migrationBuilder.DropColumn(
                name: "ace_b_relacionalDist",
                table: "tb_ace_acesso");

            migrationBuilder.DropColumn(
                name: "ace_dis_n_codigo",
                table: "tb_ace_acesso");

            migrationBuilder.AddColumn<int>(
                name: "tb_dis_distribuidordis_n_codigo",
                table: "tb_emp_empresa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_emp_empresa_tb_dis_distribuidordis_n_codigo",
                table: "tb_emp_empresa",
                column: "tb_dis_distribuidordis_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_emp_empresa_tb_dis_distribuidor_tb_dis_distribuidordis_n_codigo",
                table: "tb_emp_empresa",
                column: "tb_dis_distribuidordis_n_codigo",
                principalTable: "tb_dis_distribuidor",
                principalColumn: "dis_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
