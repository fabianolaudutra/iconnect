using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_column_senha_app_garen_connect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cli_c_senhaAppGarenConnect",
                table: "tb_cli_cliente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cli_c_senhaAppGarenConnect",
                table: "tb_cli_cliente");
        }
    }
}
