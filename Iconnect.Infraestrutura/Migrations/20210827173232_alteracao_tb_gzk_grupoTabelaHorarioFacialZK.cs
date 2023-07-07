using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class alteracao_tb_gzk_grupoTabelaHorarioFacialZK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_gzk_grupoTabelaHorarioFacialZK_tb_fzk_tabelaHorarioFacialZK",
                table: "tb_gzk_grupoTabelaHorarioFacialZK");

            migrationBuilder.DropIndex(
                name: "IX_tb_gzk_grupoTabelaHorarioFacialZK_gzk_fzk_n_codigo",
                table: "tb_gzk_grupoTabelaHorarioFacialZK");

            migrationBuilder.DropColumn(
                name: "gzk_fzk_n_codigo",
                table: "tb_gzk_grupoTabelaHorarioFacialZK");

            migrationBuilder.AddColumn<int>(
                name: "gzk_phr_n_codigo",
                table: "tb_gzk_grupoTabelaHorarioFacialZK",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_gzk_grupoTabelaHorarioFacialZK_gzk_phr_n_codigo",
                table: "tb_gzk_grupoTabelaHorarioFacialZK",
                column: "gzk_phr_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_gzk_grupoTabelaHorarioFacialZK_tb_phr_perfilHorario",
                table: "tb_gzk_grupoTabelaHorarioFacialZK",
                column: "gzk_phr_n_codigo",
                principalTable: "tb_phr_perfilHorario",
                principalColumn: "phr_n_codigo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_gzk_grupoTabelaHorarioFacialZK_tb_phr_perfilHorario",
                table: "tb_gzk_grupoTabelaHorarioFacialZK");

            migrationBuilder.DropIndex(
                name: "IX_tb_gzk_grupoTabelaHorarioFacialZK_gzk_phr_n_codigo",
                table: "tb_gzk_grupoTabelaHorarioFacialZK");

            migrationBuilder.DropColumn(
                name: "gzk_phr_n_codigo",
                table: "tb_gzk_grupoTabelaHorarioFacialZK");

            migrationBuilder.AddColumn<int>(
                name: "gzk_fzk_n_codigo",
                table: "tb_gzk_grupoTabelaHorarioFacialZK",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_gzk_grupoTabelaHorarioFacialZK_gzk_fzk_n_codigo",
                table: "tb_gzk_grupoTabelaHorarioFacialZK",
                column: "gzk_fzk_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_gzk_grupoTabelaHorarioFacialZK_tb_fzk_tabelaHorarioFacialZK",
                table: "tb_gzk_grupoTabelaHorarioFacialZK",
                column: "gzk_fzk_n_codigo",
                principalTable: "tb_fzk_tabelaHorarioFacialZK",
                principalColumn: "fzk_n_codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
