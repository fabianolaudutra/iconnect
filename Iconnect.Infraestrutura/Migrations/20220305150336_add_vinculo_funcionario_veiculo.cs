using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_vinculo_funcionario_veiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "mor_fro_n_codigo",
                table: "tb_mor_Morador",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_mor_Morador_mor_fro_n_codigo",
                table: "tb_mor_Morador",
                column: "mor_fro_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_mor_Morador_tb_fro_frota",
                table: "tb_mor_Morador",
                column: "mor_fro_n_codigo",
                principalTable: "tb_fro_frota",
                principalColumn: "fro_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_mor_Morador_tb_fro_frota",
                table: "tb_mor_Morador");

            migrationBuilder.DropIndex(
                name: "IX_tb_mor_Morador_mor_fro_n_codigo",
                table: "tb_mor_Morador");

            migrationBuilder.DropColumn(
                name: "mor_fro_n_codigo",
                table: "tb_mor_Morador");
        }
    }
}
