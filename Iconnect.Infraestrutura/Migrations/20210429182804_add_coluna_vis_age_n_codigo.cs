using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_coluna_vis_age_n_codigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "vis_age_n_codigo",
                table: "tb_vis_visitasApp",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_vis_visitasApp_vis_age_n_codigo",
                table: "tb_vis_visitasApp",
                column: "vis_age_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vis_visitasApp_tb_age_agenda",
                table: "tb_vis_visitasApp",
                column: "vis_age_n_codigo",
                principalTable: "tb_age_agenda",
                principalColumn: "age_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_vis_visitasApp_tb_age_agenda",
                table: "tb_vis_visitasApp");

            migrationBuilder.DropIndex(
                name: "IX_tb_vis_visitasApp_vis_age_n_codigo",
                table: "tb_vis_visitasApp");

            migrationBuilder.DropColumn(
                name: "vis_age_n_codigo",
                table: "tb_vis_visitasApp");
        }
    }
}
