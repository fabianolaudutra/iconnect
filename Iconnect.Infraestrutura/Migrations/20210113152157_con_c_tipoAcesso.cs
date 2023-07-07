using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class con_c_tipoAcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "con_c_tipoAcesso",
                table: "tb_con_monitoramentoControleAcesso",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "con_c_tipoAcesso",
                table: "tb_con_monitoramentoControleAcesso");
        }
    }
}
