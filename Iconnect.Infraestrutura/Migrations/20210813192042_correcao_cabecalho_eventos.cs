using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class correcao_cabecalho_eventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_vis_visitasApp_tb_cev_cabecalhoEvento",
                table: "tb_vis_visitasApp");

            migrationBuilder.DropTable(
                name: "tb_cev_cabecalhoEvento");

            migrationBuilder.CreateTable(
                name: "tb_cab_cabecalhoEvento",
                columns: table => new
                {
                    cab_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cab_c_nome = table.Column<string>(nullable: true),
                    cab_c_descricao = table.Column<string>(nullable: true),
                    cab_d_inclusao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cab_cabecalhoEvento", x => x.cab_n_codigo);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vis_visitasApp_tb_cab_cabecalhoEvento",
                table: "tb_vis_visitasApp",
                column: "vis_cev_n_codigo",
                principalTable: "tb_cab_cabecalhoEvento",
                principalColumn: "cab_n_codigo",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_vis_visitasApp_tb_cab_cabecalhoEvento",
                table: "tb_vis_visitasApp");

            migrationBuilder.DropTable(
                name: "tb_cab_cabecalhoEvento");

            migrationBuilder.CreateTable(
                name: "tb_cev_cabecalhoEvento",
                columns: table => new
                {
                    cev_n_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cev_c_descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cev_c_nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cev_d_inclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cev_cabecalhoEvento", x => x.cev_n_codigo);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vis_visitasApp_tb_cev_cabecalhoEvento",
                table: "tb_vis_visitasApp",
                column: "vis_cev_n_codigo",
                principalTable: "tb_cev_cabecalhoEvento",
                principalColumn: "cev_n_codigo",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
