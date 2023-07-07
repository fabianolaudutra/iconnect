using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_relacionamento_tb_fzk_tabelaHorarioFacialZK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tb_fzk_tabelaHorarioFacialZK_fzk_con_n_codigo",
                table: "tb_fzk_tabelaHorarioFacialZK",
                column: "fzk_con_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_fzk_tabelaHorarioFacialZK_tb_con_controladora",
                table: "tb_fzk_tabelaHorarioFacialZK",
                column: "fzk_con_n_codigo",
                principalTable: "tb_con_controladora",
                principalColumn: "con_n_codigo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_fzk_tabelaHorarioFacialZK_tb_con_controladora",
                table: "tb_fzk_tabelaHorarioFacialZK");

            migrationBuilder.DropIndex(
                name: "IX_tb_fzk_tabelaHorarioFacialZK_fzk_con_n_codigo",
                table: "tb_fzk_tabelaHorarioFacialZK");
        }
    }
}
