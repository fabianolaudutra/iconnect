using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class alter_obrig_coluna_vis_mor_n_codigo_tb_vis_visitasApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_vis_visitasApp_tb_mor_Morador",
                table: "tb_vis_visitasApp");

            migrationBuilder.AlterColumn<int>(
                name: "vis_mor_n_codigo",
                table: "tb_vis_visitasApp",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vis_visitasApp_tb_mor_Morador",
                table: "tb_vis_visitasApp",
                column: "vis_mor_n_codigo",
                principalTable: "tb_mor_Morador",
                principalColumn: "mor_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_vis_visitasApp_tb_mor_Morador",
                table: "tb_vis_visitasApp");

            migrationBuilder.AlterColumn<int>(
                name: "vis_mor_n_codigo",
                table: "tb_vis_visitasApp",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vis_visitasApp_tb_mor_Morador",
                table: "tb_vis_visitasApp",
                column: "vis_mor_n_codigo",
                principalTable: "tb_mor_Morador",
                principalColumn: "mor_n_codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
