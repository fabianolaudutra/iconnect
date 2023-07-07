using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_tb_cde_cadastro_entregas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cde_cadastro_entregas",
                columns: table => new
                {
                    cde_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cde_fen_n_codigo = table.Column<int>(nullable: true),
                    cde_grf_n_codigo = table.Column<int>(nullable: true),
                    cde_d_dataInclusao = table.Column<DateTime>(nullable: false),
                    cde_c_descricao = table.Column<string>(nullable: true),
                    cde_c_codigoRastreio = table.Column<string>(nullable: true),
                    cde_b_entregue = table.Column<bool>(nullable: true),
                    cde_d_dataBaixa = table.Column<DateTime>(nullable: false),
                    cde_c_recebidoPor = table.Column<string>(nullable: true),
                    cde_c_obsEntrega = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cde_n_codigo", x => x.cde_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_cde_cadastro_entregas_tb_fen_foto_entrega",
                        column: x => x.cde_fen_n_codigo,
                        principalTable: "tb_fen_foto_entrega",
                        principalColumn: "fen_n_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_cde_cadastro_entregas_tb_grf_grupoFamiliar",
                        column: x => x.cde_grf_n_codigo,
                        principalTable: "tb_grf_grupoFamiliar",
                        principalColumn: "grf_n_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_cde_cadastro_entregas_cde_fen_n_codigo",
                table: "tb_cde_cadastro_entregas",
                column: "cde_fen_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cde_cadastro_entregas_cde_grf_n_codigo",
                table: "tb_cde_cadastro_entregas",
                column: "cde_grf_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cde_cadastro_entregas");
        }
    }
}
