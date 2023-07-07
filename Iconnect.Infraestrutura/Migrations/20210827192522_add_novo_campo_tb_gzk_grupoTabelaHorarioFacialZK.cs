using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_novo_campo_tb_gzk_grupoTabelaHorarioFacialZK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "gzk_con_n_codigo",
                table: "tb_gzk_grupoTabelaHorarioFacialZK",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_gzk_grupoTabelaHorarioFacialZK_gzk_con_n_codigo",
                table: "tb_gzk_grupoTabelaHorarioFacialZK",
                column: "gzk_con_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_gzk_grupoTabelaHorarioFacialZK_tb_con_controladora",
                table: "tb_gzk_grupoTabelaHorarioFacialZK",
                column: "gzk_con_n_codigo",
                principalTable: "tb_con_controladora",
                principalColumn: "con_n_codigo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_gzk_grupoTabelaHorarioFacialZK_tb_con_controladora",
                table: "tb_gzk_grupoTabelaHorarioFacialZK");

            migrationBuilder.DropIndex(
                name: "IX_tb_gzk_grupoTabelaHorarioFacialZK_gzk_con_n_codigo",
                table: "tb_gzk_grupoTabelaHorarioFacialZK");

            migrationBuilder.DropColumn(
                name: "gzk_con_n_codigo",
                table: "tb_gzk_grupoTabelaHorarioFacialZK");
        }
    }
}
