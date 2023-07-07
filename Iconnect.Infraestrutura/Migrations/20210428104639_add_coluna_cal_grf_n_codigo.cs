using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_coluna_cal_grf_n_codigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cal_grf_n_codigo",
                table: "tb_cal_catalogo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_cal_catalogo_cal_grf_n_codigo",
                table: "tb_cal_catalogo",
                column: "cal_grf_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_cal_catalogo_tb_grf_grupoFamiliar",
                table: "tb_cal_catalogo",
                column: "cal_grf_n_codigo",
                principalTable: "tb_grf_grupoFamiliar",
                principalColumn: "grf_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_cal_catalogo_tb_grf_grupoFamiliar",
                table: "tb_cal_catalogo");

            migrationBuilder.DropIndex(
                name: "IX_tb_cal_catalogo_cal_grf_n_codigo",
                table: "tb_cal_catalogo");

            migrationBuilder.DropColumn(
                name: "cal_grf_n_codigo",
                table: "tb_cal_catalogo");
        }
    }
}
