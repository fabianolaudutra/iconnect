using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class inUsuarioRegistroSalao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "res_c_inTabelaUsuario",
                table: "tb_res_registroSalao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "res_n_inUsuarioId",
                table: "tb_res_registroSalao",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "res_c_inTabelaUsuario",
                table: "tb_res_registroSalao");

            migrationBuilder.DropColumn(
                name: "res_n_inUsuarioId",
                table: "tb_res_registroSalao");
        }
    }
}
