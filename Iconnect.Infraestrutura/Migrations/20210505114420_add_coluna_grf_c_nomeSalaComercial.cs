using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_coluna_grf_c_nomeSalaComercial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "grf_c_nomeSalaComercial",
                table: "tb_grf_grupoFamiliar",
                unicode: false,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "grf_c_nomeSalaComercial",
                table: "tb_grf_grupoFamiliar");
        }
    }
}
