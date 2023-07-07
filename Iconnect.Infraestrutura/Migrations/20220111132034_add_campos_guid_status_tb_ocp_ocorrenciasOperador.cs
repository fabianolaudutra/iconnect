using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_campos_guid_status_tb_ocp_ocorrenciasOperador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ocp_c_unique",
                table: "tb_ocp_ocorrenciasOperador",
                nullable: false,
                defaultValueSql: "(newid())",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "(newid())");

            migrationBuilder.AddColumn<string>(
                name: "ocp_c_status",
                table: "tb_ocp_ocorrenciasOperador",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ocp_c_status",
                table: "tb_ocp_ocorrenciasOperador");

            migrationBuilder.AlterColumn<string>(
                name: "ocp_c_unique",
                table: "tb_ocp_ocorrenciasOperador",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "(newid())",
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "(newid())");
        }
    }
}
