using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class Add_CAMPO_CAL_B_ATIVO_CORRECAO_CAMPO_CAL_C_WEBSITE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "call_c_website",
                table: "tb_cal_catalogo");

            migrationBuilder.AddColumn<bool>(
                name: "cal_b_ativo",
                table: "tb_cal_catalogo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "cal_c_website",
                table: "tb_cal_catalogo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cal_b_ativo",
                table: "tb_cal_catalogo");

            migrationBuilder.DropColumn(
                name: "cal_c_website",
                table: "tb_cal_catalogo");

            migrationBuilder.AddColumn<string>(
                name: "call_c_website",
                table: "tb_cal_catalogo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
