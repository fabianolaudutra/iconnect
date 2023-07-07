using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class CorrecaoNomeCamposAlturaLarguraTabelaBiometria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altura",
                table: "tb_bio_biometria");

            migrationBuilder.DropColumn(
                name: "Largura",
                table: "tb_bio_biometria");

            migrationBuilder.AddColumn<int>(
                name: "bio_n_altura",
                table: "tb_bio_biometria",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "bio_n_largura",
                table: "tb_bio_biometria",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bio_n_altura",
                table: "tb_bio_biometria");

            migrationBuilder.DropColumn(
                name: "bio_n_largura",
                table: "tb_bio_biometria");

            migrationBuilder.AddColumn<int>(
                name: "Altura",
                table: "tb_bio_biometria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Largura",
                table: "tb_bio_biometria",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
