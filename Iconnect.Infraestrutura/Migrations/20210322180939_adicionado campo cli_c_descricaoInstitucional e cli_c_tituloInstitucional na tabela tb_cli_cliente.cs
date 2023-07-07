using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class adicionadocampocli_c_descricaoInstitucionalecli_c_tituloInstitucionalnatabelatb_cli_cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cli_c_descricaoInstitucional",
                table: "tb_cli_cliente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cli_c_tituloInstitucional",
                table: "tb_cli_cliente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cli_c_descricaoInstitucional",
                table: "tb_cli_cliente");

            migrationBuilder.DropColumn(
                name: "cli_c_tituloInstitucional",
                table: "tb_cli_cliente");
        }
    }
}
