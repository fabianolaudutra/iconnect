using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_colunas_tb_mon_monitoramento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mon_c_pessoa",
                table: "tb_mon_monitoramento",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mon_c_pessoaConclusao",
                table: "tb_mon_monitoramento",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mon_c_tipoPessoa",
                table: "tb_mon_monitoramento",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mon_c_tipoPessoaConclusao",
                table: "tb_mon_monitoramento",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "mon_n_codigoPessoa",
                table: "tb_mon_monitoramento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "mon_n_codigoPessoaConclusao",
                table: "tb_mon_monitoramento",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mon_c_pessoa",
                table: "tb_mon_monitoramento");

            migrationBuilder.DropColumn(
                name: "mon_c_pessoaConclusao",
                table: "tb_mon_monitoramento");

            migrationBuilder.DropColumn(
                name: "mon_c_tipoPessoa",
                table: "tb_mon_monitoramento");

            migrationBuilder.DropColumn(
                name: "mon_c_tipoPessoaConclusao",
                table: "tb_mon_monitoramento");

            migrationBuilder.DropColumn(
                name: "mon_n_codigoPessoa",
                table: "tb_mon_monitoramento");

            migrationBuilder.DropColumn(
                name: "mon_n_codigoPessoaConclusao",
                table: "tb_mon_monitoramento");
        }
    }
}
