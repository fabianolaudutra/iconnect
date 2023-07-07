using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class dependenciaFoto_setNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_dpn_dependencias_tb_ftd_fotoDependencia",
                table: "tb_dpn_dependencias");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_dpn_dependencias_tb_ftd_fotoDependencia",
                table: "tb_dpn_dependencias",
                column: "dpn_ftd_n_codigo",
                principalTable: "tb_ftd_fotoDependencia",
                principalColumn: "ftd_n_codigo",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_dpn_dependencias_tb_ftd_fotoDependencia",
                table: "tb_dpn_dependencias");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_dpn_dependencias_tb_ftd_fotoDependencia",
                table: "tb_dpn_dependencias",
                column: "dpn_ftd_n_codigo",
                principalTable: "tb_ftd_fotoDependencia",
                principalColumn: "ftd_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
