using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_tb_dva_duvidasApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_dva_duvidasApp",
                columns: table => new
                {
                    dva_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dva_cli_n_codigo = table.Column<int>(nullable: false),
                    dva_c_duvida = table.Column<string>(nullable: true),
                    dva_c_resposta = table.Column<string>(nullable: true),
                    dva_c_link = table.Column<string>(nullable: true),
                    dva_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    dva_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    dva_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dva_n_codigo", x => x.dva_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_dva_duvidasApp_tb_cli_cliente",
                        column: x => x.dva_cli_n_codigo,
                        principalTable: "tb_cli_cliente",
                        principalColumn: "cli_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_dva_duvidasApp_dva_cli_n_codigo",
                table: "tb_dva_duvidasApp",
                column: "dva_cli_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_dva_duvidasApp");
        }
    }
}
