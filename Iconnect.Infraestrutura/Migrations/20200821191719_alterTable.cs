using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class alterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "afa_b_sicronizado",
                table: "tb_afa_afastamento");

            migrationBuilder.AddColumn<bool>(
                name: "afa_b_sincronizado",
                table: "tb_afa_afastamento",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "afa_b_sincronizado",
                table: "tb_afa_afastamento");

            migrationBuilder.AddColumn<bool>(
                name: "afa_b_sicronizado",
                table: "tb_afa_afastamento",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
