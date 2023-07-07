using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class campos_data_connectionSignalR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "csr_d_dataAlteracao",
                table: "tb_csr_connectionSignalR",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "csr_d_dataInclusao",
                table: "tb_csr_connectionSignalR",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "csr_d_dataAlteracao",
                table: "tb_csr_connectionSignalR");

            migrationBuilder.DropColumn(
                name: "csr_d_dataInclusao",
                table: "tb_csr_connectionSignalR");
        }
    }
}
