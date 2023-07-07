using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_columm_tb_dpn_dependencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "dpn_b_permitirReservarPeriodo",
                table: "tb_dpn_dependencias",
                nullable: true,
                defaultValueSql: "((0))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dpn_b_permitirReservarPeriodo",
                table: "tb_dpn_dependencias");
        }
    }
}
