using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class guid_visitante_app : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "vpp_c_visitanteGuid",
                table: "tb_vpp_visitanteApp",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_vpp_visitanteApp_vpp_c_visitanteGuid",
                table: "tb_vpp_visitanteApp",
                column: "vpp_c_visitanteGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_vpp_visitanteApp_vpp_c_visitanteGuid",
                table: "tb_vpp_visitanteApp");

            migrationBuilder.DropColumn(
                name: "vpp_c_visitanteGuid",
                table: "tb_vpp_visitanteApp");
        }
    }
}
