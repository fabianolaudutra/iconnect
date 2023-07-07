using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_coluna_mor_d_dataInclusaoIntegracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "mor_d_dataInclusaoIntegracao",
                table: "tb_mor_Morador",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mor_d_dataInclusaoIntegracao",
                table: "tb_mor_Morador");
        }
    }
}
