using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class Informacoes_Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_inc_informacoesCliente",
                columns: table => new
                {
                    inc_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inc_cli_n_codigo = table.Column<int>(unicode: false, nullable: false),
                    inc_c_titulo = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    inc_c_descricao = table.Column<string>(unicode: false, nullable: true),
                    inc_n_ordem = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    inc_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    inc_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    inc_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inc_n_codigo", x => x.inc_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_inc_informacoesCliente_tb_cli_cliente",
                        column: x => x.inc_cli_n_codigo,
                        principalTable: "tb_cli_cliente",
                        principalColumn: "cli_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_inc_informacoesCliente_inc_cli_n_codigo",
                table: "tb_inc_informacoesCliente",
                column: "inc_cli_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_inc_informacoesCliente");
        }
    }
}
