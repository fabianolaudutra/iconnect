using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class tb_ref_refeicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "pre_n_precoEmp",
                table: "tb_pre_precos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "pre_n_precoDist",
                table: "tb_pre_precos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "pre_n_precoCli",
                table: "tb_pre_precos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "pre_n_preco",
                table: "tb_pre_precos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "pre_n_porcentCli",
                table: "tb_pre_precos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pre_n_porcentDist",
                table: "tb_pre_precos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pre_n_porcentEmp",
                table: "tb_pre_precos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tb_ref_refeicao",
                columns: table => new
                {
                    ref_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ref_c_nomeRefeicao = table.Column<string>(nullable: true),
                    ref_d_inicio = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ref_d_fim = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ref_d_valor = table.Column<decimal>(nullable: false),
                    ref_cli_n_codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ref_refeicao", x => x.ref_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_ref_refeicao_tb_cli_cliente",
                        column: x => x.ref_cli_n_codigo,
                        principalTable: "tb_cli_cliente",
                        principalColumn: "cli_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_ref_refeicao_ref_cli_n_codigo",
                table: "tb_ref_refeicao",
                column: "ref_cli_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_ref_refeicao");

            migrationBuilder.DropColumn(
                name: "pre_n_porcentCli",
                table: "tb_pre_precos");

            migrationBuilder.DropColumn(
                name: "pre_n_porcentDist",
                table: "tb_pre_precos");

            migrationBuilder.DropColumn(
                name: "pre_n_porcentEmp",
                table: "tb_pre_precos");

            migrationBuilder.AlterColumn<int>(
                name: "pre_n_precoEmp",
                table: "tb_pre_precos",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "pre_n_precoDist",
                table: "tb_pre_precos",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "pre_n_precoCli",
                table: "tb_pre_precos",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "pre_n_preco",
                table: "tb_pre_precos",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
