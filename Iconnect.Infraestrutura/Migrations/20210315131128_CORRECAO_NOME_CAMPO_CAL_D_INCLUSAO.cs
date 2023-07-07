using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class CORRECAO_NOME_CAMPO_CAL_D_INCLUSAO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cal_d_inclsao",
                table: "tb_cal_catalogo",
                newName: "cal_d_inclusao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cal_d_inclusao",
                table: "tb_cal_catalogo",
                newName: "cal_d_inclsao");
        }
    }
}
