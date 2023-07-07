using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_colunas_tb_res_registro_salao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "res_b_lido",
                table: "tb_res_registroSalao",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<bool>(
                name: "res_b_tocado",
                table: "tb_res_registroSalao",
                nullable: false,
                defaultValueSql: "((0))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "res_b_lido",
                table: "tb_res_registroSalao");

            migrationBuilder.DropColumn(
                name: "res_b_tocado",
                table: "tb_res_registroSalao");
        }
    }
}
