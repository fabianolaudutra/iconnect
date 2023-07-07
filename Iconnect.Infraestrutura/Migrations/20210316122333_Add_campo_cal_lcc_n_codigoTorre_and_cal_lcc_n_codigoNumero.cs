using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class Add_campo_cal_lcc_n_codigoTorre_and_cal_lcc_n_codigoNumero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cal_lcc_n_codigoNumero",
                table: "tb_cal_catalogo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cal_lcc_n_codigoTorre",
                table: "tb_cal_catalogo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cal_lcc_n_codigoNumero",
                table: "tb_cal_catalogo");

            migrationBuilder.DropColumn(
                name: "cal_lcc_n_codigoTorre",
                table: "tb_cal_catalogo");
        }
    }
}
