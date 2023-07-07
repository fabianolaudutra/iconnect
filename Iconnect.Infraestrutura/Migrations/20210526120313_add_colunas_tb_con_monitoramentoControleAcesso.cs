using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_colunas_tb_con_monitoramentoControleAcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "con_ref_c_nomeRefeicao",
                table: "tb_con_monitoramentoControleAcesso",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "con_ref_d_valor",
                table: "tb_con_monitoramentoControleAcesso",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "con_ref_c_nomeRefeicao",
                table: "tb_con_monitoramentoControleAcesso");

            migrationBuilder.DropColumn(
                name: "con_ref_d_valor",
                table: "tb_con_monitoramentoControleAcesso");
        }
    }
}
