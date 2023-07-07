using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class AlteracoesTabelaBiometria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_bio_biometria_tb_cli_cliente",
                table: "tb_bio_biometria");

            migrationBuilder.AddColumn<int>(
                name: "Altura",
                table: "tb_bio_biometria",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Largura",
                table: "tb_bio_biometria",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_bio_biometria_bio_cli_n_codigo",
                table: "tb_bio_biometria",
                column: "bio_cli_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_bio_biometria_tb_cli_cliente",
                table: "tb_bio_biometria",
                column: "bio_cli_n_codigo",
                principalTable: "tb_cli_cliente",
                principalColumn: "cli_n_codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_bio_biometria_tb_con_controladora",
                table: "tb_bio_biometria",
                column: "bio_con_n_codigo",
                principalTable: "tb_con_controladora",
                principalColumn: "con_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_bio_biometria_tb_cli_cliente",
                table: "tb_bio_biometria");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_bio_biometria_tb_con_controladora",
                table: "tb_bio_biometria");

            migrationBuilder.DropIndex(
                name: "IX_tb_bio_biometria_bio_cli_n_codigo",
                table: "tb_bio_biometria");

            migrationBuilder.DropColumn(
                name: "Altura",
                table: "tb_bio_biometria");

            migrationBuilder.DropColumn(
                name: "Largura",
                table: "tb_bio_biometria");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_bio_biometria_tb_cli_cliente",
                table: "tb_bio_biometria",
                column: "bio_con_n_codigo",
                principalTable: "tb_con_controladora",
                principalColumn: "con_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
