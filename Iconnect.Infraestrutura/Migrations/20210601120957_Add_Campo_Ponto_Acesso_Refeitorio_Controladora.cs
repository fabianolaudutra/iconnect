using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class Add_Campo_Ponto_Acesso_Refeitorio_Controladora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "pta_b_refeicao",
                table: "tb_pta_pontosAcesso",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pta_b_refeicao",
                table: "tb_pta_pontosAcesso");
        }
    }
}
