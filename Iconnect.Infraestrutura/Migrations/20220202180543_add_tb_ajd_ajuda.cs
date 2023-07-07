using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_tb_ajd_ajuda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_ajd_ajuda",
                columns: table => new
                {
                    ajd_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ajd_cli_n_codigo = table.Column<int>(nullable: false),
                    ajd_c_topico = table.Column<string>(nullable: true),
                    ajd_c_duvida = table.Column<string>(nullable: true),
                    ajd_c_descricao = table.Column<string>(nullable: true),
                    ajd_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ajd_d_inclusao = table.Column<DateTime>(nullable: true),
                    ajd_d_atualizado = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ajd_ajuda", x => x.ajd_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_ajd_ajuda_tb_cli_cliente",
                        column: x => x.ajd_cli_n_codigo,
                        principalTable: "tb_cli_cliente",
                        principalColumn: "cli_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_ajd_ajuda_ajd_cli_n_codigo",
                table: "tb_ajd_ajuda",
                column: "ajd_cli_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_ajd_ajuda");
        }
    }
}
