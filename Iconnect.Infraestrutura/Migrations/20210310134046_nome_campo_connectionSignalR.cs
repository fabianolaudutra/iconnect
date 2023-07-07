using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class nome_campo_connectionSignalR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "crs_n_id",
                table: "tb_csr_connectionSignalR");

            migrationBuilder.AddColumn<int>(
                name: "csr_n_id",
                table: "tb_csr_connectionSignalR",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "csr_n_id",
                table: "tb_csr_connectionSignalR");

            migrationBuilder.AddColumn<int>(
                name: "crs_n_id",
                table: "tb_csr_connectionSignalR",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
