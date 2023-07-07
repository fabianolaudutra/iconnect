using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_coluna_usu_c_codigoRecuperacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "usu_c_codigoRecuperacao",
                table: "tb_usu_UsuarioApp",
                unicode: false,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usu_c_codigoRecuperacao",
                table: "tb_usu_UsuarioApp");
        }
    }
}
