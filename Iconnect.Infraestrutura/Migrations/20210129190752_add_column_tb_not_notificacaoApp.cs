using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_column_tb_not_notificacaoApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "not_b_lido",
                table: "tb_not_notificacaoApp",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<bool>(
                name: "not_b_tocado",
                table: "tb_not_notificacaoApp",
                nullable: false,
                defaultValueSql: "((0))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "not_b_lido",
                table: "tb_not_notificacaoApp");

            migrationBuilder.DropColumn(
                name: "not_b_tocado",
                table: "tb_not_notificacaoApp");
        }
    }
}
