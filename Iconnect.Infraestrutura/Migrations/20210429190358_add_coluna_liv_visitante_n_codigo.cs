using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_coluna_liv_visitante_n_codigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "liv_visitante_n_codigo",
                table: "tb_liv_liberacaoVisitante",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_liv_liberacaoVisitante_liv_visitante_n_codigo",
                table: "tb_liv_liberacaoVisitante",
                column: "liv_visitante_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_liv_liberacaoVisitante_tb_vis_visitante",
                table: "tb_liv_liberacaoVisitante",
                column: "liv_visitante_n_codigo",
                principalTable: "tb_vis_visitante",
                principalColumn: "vis_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_liv_liberacaoVisitante_tb_vis_visitante",
                table: "tb_liv_liberacaoVisitante");

            migrationBuilder.DropIndex(
                name: "IX_tb_liv_liberacaoVisitante_liv_visitante_n_codigo",
                table: "tb_liv_liberacaoVisitante");

            migrationBuilder.DropColumn(
                name: "liv_visitante_n_codigo",
                table: "tb_liv_liberacaoVisitante");
        }
    }
}
