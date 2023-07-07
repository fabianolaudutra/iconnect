using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_campo_especialista_agenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age_mor_n_codigo",
                table: "tb_age_agenda",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_age_agenda_age_mor_n_codigo",
                table: "tb_age_agenda",
                column: "age_mor_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_age_agenda_tb_mor_Morador",
                table: "tb_age_agenda",
                column: "age_mor_n_codigo",
                principalTable: "tb_mor_Morador",
                principalColumn: "mor_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_age_agenda_tb_mor_Morador",
                table: "tb_age_agenda");

            migrationBuilder.DropIndex(
                name: "IX_tb_age_agenda_age_mor_n_codigo",
                table: "tb_age_agenda");

            migrationBuilder.DropColumn(
                name: "age_mor_n_codigo",
                table: "tb_age_agenda");
        }
    }
}
