using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class movimentacaoVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_mve_movimentacaoVeiculo",
                columns: table => new
                {
                    mve_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mve_fro_n_codigo = table.Column<int>(nullable: false),
                    mve_mor_n_codigo = table.Column<int>(nullable: false),
                    mve_c_fluxo = table.Column<string>(nullable: true),
                    mve_n_quilometragem = table.Column<int>(nullable: false),
                    mve_d_dataRegistro = table.Column<DateTime>(nullable: false),
                    mve_c_usuarioLogado = table.Column<string>(nullable: true),
                    mve_b_registroAutomatico = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    mve_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    mve_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    mve_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    mve_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_mve_movimentacaoVeiculo", x => x.mve_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_mve_movimentacaoVeiculo_tb_fro_frota",
                        column: x => x.mve_fro_n_codigo,
                        principalTable: "tb_fro_frota",
                        principalColumn: "fro_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_mve_movimentacaoVeiculo_tb_mor_Morador",
                        column: x => x.mve_mor_n_codigo,
                        principalTable: "tb_mor_Morador",
                        principalColumn: "mor_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_mve_movimentacaoVeiculo_mve_fro_n_codigo",
                table: "tb_mve_movimentacaoVeiculo",
                column: "mve_fro_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_mve_movimentacaoVeiculo_mve_mor_n_codigo",
                table: "tb_mve_movimentacaoVeiculo",
                column: "mve_mor_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_mve_movimentacaoVeiculo");
        }
    }
}
