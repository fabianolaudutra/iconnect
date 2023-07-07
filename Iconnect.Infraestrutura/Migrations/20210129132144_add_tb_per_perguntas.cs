using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_tb_per_perguntas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_per_perguntas",
                columns: table => new
                {
                    per_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    per_cli_n_codigo = table.Column<int>(nullable: true),
                    per_c_pergunta = table.Column<string>(nullable: true),
                    per_c_link = table.Column<string>(nullable: true),
                    per_c_titulo = table.Column<string>(nullable: true),
                    per_c_resposta = table.Column<string>(nullable: true),
                    per_d_data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_per_n_codigo", x => x.per_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_per_perguntas_tb_cli_cliente",
                        column: x => x.per_cli_n_codigo,
                        principalTable: "tb_cli_cliente",
                        principalColumn: "cli_n_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_per_perguntas_per_cli_n_codigo",
                table: "tb_per_perguntas",
                column: "per_cli_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_per_perguntas");
        }
    }
}
