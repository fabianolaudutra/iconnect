using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class visitante_app : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "vis_vpp_n_codigo",
                table: "tb_vis_visitante",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tb_vpp_visitanteApp",
                columns: table => new
                {
                    vpp_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vpp_c_email = table.Column<string>(nullable: true),
                    vpp_c_senha = table.Column<string>(nullable: true),
                    vpp_c_codigoRecuperacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vpp_visitanteApp", x => x.vpp_n_codigo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_vis_visitante_vis_vpp_n_codigo",
                table: "tb_vis_visitante",
                column: "vis_vpp_n_codigo",
                unique: true,
                filter: "[vis_vpp_n_codigo] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vis_visitante_tb_vpp_visitanteApp_vis_vpp_n_codigo",
                table: "tb_vis_visitante",
                column: "vis_vpp_n_codigo",
                principalTable: "tb_vpp_visitanteApp",
                principalColumn: "vpp_n_codigo",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_vis_visitante_tb_vpp_visitanteApp_vis_vpp_n_codigo",
                table: "tb_vis_visitante");

            migrationBuilder.DropTable(
                name: "tb_vpp_visitanteApp");

            migrationBuilder.DropIndex(
                name: "IX_tb_vis_visitante_vis_vpp_n_codigo",
                table: "tb_vis_visitante");

            migrationBuilder.DropColumn(
                name: "vis_vpp_n_codigo",
                table: "tb_vis_visitante");
        }
    }
}
