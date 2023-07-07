using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class campos_connectionSignalR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "csr_s_connectionId",
                table: "tb_csr_connectionSignalR");

            migrationBuilder.AddColumn<string>(
                name: "csr_c_connectionId",
                table: "tb_csr_connectionSignalR",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "csr_n_perfil",
                table: "tb_csr_connectionSignalR",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "csr_n_usuarioId",
                table: "tb_csr_connectionSignalR",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_csr_connectionSignalR_csr_c_connectionId",
                table: "tb_csr_connectionSignalR",
                column: "csr_c_connectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_csr_connectionSignalR_csr_c_connectionId",
                table: "tb_csr_connectionSignalR");

            migrationBuilder.DropColumn(
                name: "csr_c_connectionId",
                table: "tb_csr_connectionSignalR");

            migrationBuilder.DropColumn(
                name: "csr_n_perfil",
                table: "tb_csr_connectionSignalR");

            migrationBuilder.DropColumn(
                name: "csr_n_usuarioId",
                table: "tb_csr_connectionSignalR");

            migrationBuilder.AddColumn<string>(
                name: "csr_s_connectionId",
                table: "tb_csr_connectionSignalR",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
