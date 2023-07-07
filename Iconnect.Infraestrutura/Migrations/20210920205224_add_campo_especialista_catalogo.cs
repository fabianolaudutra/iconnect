using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_campo_especialista_catalogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cal_n_especialista",
                table: "tb_cal_catalogo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_cal_catalogo_cal_n_especialista",
                table: "tb_cal_catalogo",
                column: "cal_n_especialista");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_cal_catalogo_tb_mor_Morador",
                table: "tb_cal_catalogo",
                column: "cal_n_especialista",
                principalTable: "tb_mor_Morador",
                principalColumn: "mor_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_cal_catalogo_tb_mor_Morador",
                table: "tb_cal_catalogo");

            migrationBuilder.DropIndex(
                name: "IX_tb_cal_catalogo_cal_n_especialista",
                table: "tb_cal_catalogo");

            migrationBuilder.DropColumn(
                name: "cal_n_especialista",
                table: "tb_cal_catalogo");
        }
    }
}
