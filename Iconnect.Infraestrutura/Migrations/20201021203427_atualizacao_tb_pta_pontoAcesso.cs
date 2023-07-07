using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class atualizacao_tb_pta_pontoAcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "pta_b_exibirEventosReleAuxiliar",
                table: "tb_pta_pontosAcesso",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<string>(
                name: "pta_c_descricaoReleAuxiliar",
                table: "tb_pta_pontosAcesso",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pta_c_periodoMonitoramentoAte",
                table: "tb_pta_pontosAcesso",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pta_c_periodoMonitoramentoDe",
                table: "tb_pta_pontosAcesso",
                maxLength: 5,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pta_b_exibirEventosReleAuxiliar",
                table: "tb_pta_pontosAcesso");

            migrationBuilder.DropColumn(
                name: "pta_c_descricaoReleAuxiliar",
                table: "tb_pta_pontosAcesso");

            migrationBuilder.DropColumn(
                name: "pta_c_periodoMonitoramentoAte",
                table: "tb_pta_pontosAcesso");

            migrationBuilder.DropColumn(
                name: "pta_c_periodoMonitoramentoDe",
                table: "tb_pta_pontosAcesso");
        }
    }
}
