using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_coluna_grf_ace_n_codigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "grf_ace_n_codigo",
                table: "tb_grf_grupoFamiliar",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_grf_grupoFamiliar_grf_ace_n_codigo",
                table: "tb_grf_grupoFamiliar",
                column: "grf_ace_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_grf_grupoFamiliar_tb_ace_acesso",
                table: "tb_grf_grupoFamiliar",
                column: "grf_ace_n_codigo",
                principalTable: "tb_ace_acesso",
                principalColumn: "ace_n_codigo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_grf_grupoFamiliar_tb_ace_acesso",
                table: "tb_grf_grupoFamiliar");

            migrationBuilder.DropIndex(
                name: "IX_tb_grf_grupoFamiliar_grf_ace_n_codigo",
                table: "tb_grf_grupoFamiliar");

            migrationBuilder.DropColumn(
                name: "grf_ace_n_codigo",
                table: "tb_grf_grupoFamiliar");
        }
    }
}
