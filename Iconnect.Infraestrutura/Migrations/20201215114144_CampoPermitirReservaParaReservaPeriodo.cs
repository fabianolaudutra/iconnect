using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class CampoPermitirReservaParaReservaPeriodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dpn_b_permitirReservarPeriodo",
                table: "tb_dpn_dependencias");

            migrationBuilder.AddColumn<int>(
                name: "dpn_n_reservaPeriodo",
                table: "tb_dpn_dependencias",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dpn_n_reservaPeriodo",
                table: "tb_dpn_dependencias");

            migrationBuilder.AddColumn<bool>(
                name: "dpn_b_permitirReservarPeriodo",
                table: "tb_dpn_dependencias",
                type: "bit",
                nullable: true);
        }
    }
}
