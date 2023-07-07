using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class tabela_device : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_dev_device",
                columns: table => new
                {
                    dev_c_uuid = table.Column<string>(nullable: false),
                    dev_c_fcmToken = table.Column<string>(nullable: true),
                    dev_c_plataforma = table.Column<string>(nullable: true),
                    dev_c_versaoApp = table.Column<string>(nullable: true),
                    dev_c_versaoSO = table.Column<string>(nullable: true),
                    dev_vpp_n_visitanteApp = table.Column<int>(nullable: false),
                    dev_d_dataInclusao = table.Column<DateTime>(nullable: false),
                    dev_d_dataModificacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_dev_device", x => x.dev_c_uuid);
                    table.ForeignKey(
                        name: "FK_tb_dev_device_tb_vpp_visitanteApp_dev_vpp_n_visitanteApp",
                        column: x => x.dev_vpp_n_visitanteApp,
                        principalTable: "tb_vpp_visitanteApp",
                        principalColumn: "vpp_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_dev_device_dev_c_fcmToken",
                table: "tb_dev_device",
                column: "dev_c_fcmToken");

            migrationBuilder.CreateIndex(
                name: "IX_tb_dev_device_dev_vpp_n_visitanteApp",
                table: "tb_dev_device",
                column: "dev_vpp_n_visitanteApp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_dev_device");
        }
    }
}
