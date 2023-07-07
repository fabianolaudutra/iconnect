using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_tb_ocp_ocorrenciasOperador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_ocp_ocorrenciasOperador",
                columns: table => new
                {
                    ocp_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ocp_cli_n_codigo = table.Column<int>(nullable: false),
                    ocp_c_descricao = table.Column<string>(nullable: true),
                    ocp_c_data = table.Column<DateTime>(nullable: false),
                    ocp_ope_n_cadastrou = table.Column<int>(nullable: false),
                    ocp_ope_n_modificou = table.Column<int>(nullable: true),
                    ocp_c_unique = table.Column<string>(nullable: true, defaultValueSql: "(newid())"),
                    ocp_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ocp_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ocp_ocorrenciasOperador", x => x.ocp_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_ocp_ocorrenciasOperador_tb_cli_cliente",
                        column: x => x.ocp_cli_n_codigo,
                        principalTable: "tb_cli_cliente",
                        principalColumn: "cli_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_ocp_ocorrenciasOperador_tb_ope_operadorCadastrou",
                        column: x => x.ocp_ope_n_cadastrou,
                        principalTable: "tb_ope_operador",
                        principalColumn: "ope_n_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_ocp_ocorrenciasOperador_tb_ope_operadorModificou",
                        column: x => x.ocp_ope_n_modificou,
                        principalTable: "tb_ope_operador",
                        principalColumn: "ope_n_codigo",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_ocp_ocorrenciasOperador_ocp_cli_n_codigo",
                table: "tb_ocp_ocorrenciasOperador",
                column: "ocp_cli_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ocp_ocorrenciasOperador_ocp_ope_n_cadastrou",
                table: "tb_ocp_ocorrenciasOperador",
                column: "ocp_ope_n_cadastrou");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ocp_ocorrenciasOperador_ocp_ope_n_modificou",
                table: "tb_ocp_ocorrenciasOperador",
                column: "ocp_ope_n_modificou");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_ocp_ocorrenciasOperador");
        }
    }
}
