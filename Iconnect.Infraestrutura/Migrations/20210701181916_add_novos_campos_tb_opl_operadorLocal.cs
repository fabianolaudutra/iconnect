using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_novos_campos_tb_opl_operadorLocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "opl_c_cpf",
                table: "tb_opl_operadorLocal",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "opl_c_email",
                table: "tb_opl_operadorLocal",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "opl_c_rg",
                table: "tb_opl_operadorLocal",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "opl_c_telefone",
                table: "tb_opl_operadorLocal",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "opl_c_cpf",
                table: "tb_opl_operadorLocal");

            migrationBuilder.DropColumn(
                name: "opl_c_email",
                table: "tb_opl_operadorLocal");

            migrationBuilder.DropColumn(
                name: "opl_c_rg",
                table: "tb_opl_operadorLocal");

            migrationBuilder.DropColumn(
                name: "opl_c_telefone",
                table: "tb_opl_operadorLocal");
        }
    }
}
