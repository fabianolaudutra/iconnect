using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class campo_fk_cli_fot_fachada_n_codigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cli_fot_fachada_n_codigo",
                table: "tb_cli_cliente",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_cli_cliente_cli_fot_fachada_n_codigo",
                table: "tb_cli_cliente",
                column: "cli_fot_fachada_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_cli_cliente_cli_fot_fachada_n_codigo",
                table: "tb_cli_cliente",
                column: "cli_fot_fachada_n_codigo",
                principalTable: "tb_fot_foto",
                principalColumn: "fot_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_cli_cliente_cli_fot_fachada_n_codigo",
                table: "tb_cli_cliente");

            migrationBuilder.DropIndex(
                name: "IX_tb_cli_cliente_cli_fot_fachada_n_codigo",
                table: "tb_cli_cliente");

            migrationBuilder.DropColumn(
                name: "cli_fot_fachada_n_codigo",
                table: "tb_cli_cliente");
        }
    }
}
