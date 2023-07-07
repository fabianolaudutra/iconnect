using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class ativo_codigoVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "fro_b_ativo",
                table: "tb_fro_frota",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<string>(
                name: "fro_c_codigoVeiculo",
                table: "tb_fro_frota",
                unicode: false,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fro_b_ativo",
                table: "tb_fro_frota");

            migrationBuilder.DropColumn(
                name: "fro_c_codigoVeiculo",
                table: "tb_fro_frota");
        }
    }
}
