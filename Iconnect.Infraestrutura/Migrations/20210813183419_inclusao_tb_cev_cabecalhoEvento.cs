using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class inclusao_tb_cev_cabecalhoEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "vis_cev_n_codigo",
                table: "tb_vis_visitasApp",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "cli_d_inclusao",
                table: "tb_cli_cliente",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.CreateTable(
                name: "tb_cev_cabecalhoEvento",
                columns: table => new
                {
                    cev_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cev_c_nome = table.Column<string>(nullable: true),
                    cev_c_descricao = table.Column<string>(nullable: true),
                    cev_d_inclusao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cev_cabecalhoEvento", x => x.cev_n_codigo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_vis_visitasApp_vis_cev_n_codigo",
                table: "tb_vis_visitasApp",
                column: "vis_cev_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vis_visitasApp_tb_cev_cabecalhoEvento",
                table: "tb_vis_visitasApp",
                column: "vis_cev_n_codigo",
                principalTable: "tb_cev_cabecalhoEvento",
                principalColumn: "cev_n_codigo",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_vis_visitasApp_tb_cev_cabecalhoEvento",
                table: "tb_vis_visitasApp");

            migrationBuilder.DropTable(
                name: "tb_cev_cabecalhoEvento");

            migrationBuilder.DropIndex(
                name: "IX_tb_vis_visitasApp_vis_cev_n_codigo",
                table: "tb_vis_visitasApp");

            migrationBuilder.DropColumn(
                name: "vis_cev_n_codigo",
                table: "tb_vis_visitasApp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "cli_d_inclusao",
                table: "tb_cli_cliente",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");
        }
    }
}
