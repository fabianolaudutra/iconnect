using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class campo_foto_catalogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cal_fot_n_codigo",
                table: "tb_cal_catalogo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_cal_catalogo_cal_fot_n_codigo",
                table: "tb_cal_catalogo",
                column: "cal_fot_n_codigo",
                unique: true,
                filter: "[cal_fot_n_codigo] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_cal_catalogo_tb_fot_foto",
                table: "tb_cal_catalogo",
                column: "cal_fot_n_codigo",
                principalTable: "tb_fot_foto",
                principalColumn: "fot_n_codigo",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_cal_catalogo_tb_fot_foto",
                table: "tb_cal_catalogo");

            migrationBuilder.DropIndex(
                name: "IX_tb_cal_catalogo_cal_fot_n_codigo",
                table: "tb_cal_catalogo");

            migrationBuilder.DropColumn(
                name: "cal_fot_n_codigo",
                table: "tb_cal_catalogo");
        }
    }
}
