using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class tb_gzk_grupoTabelaHorarioFacialZK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_gzk_grupoTabelaHorarioFacialZK",
                columns: table => new
                {
                    gzk_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gzk_fzk_n_codigo = table.Column<int>(nullable: false),
                    gzk_grupo_n_codigo = table.Column<int>(nullable: false),
                    gzk_d_modificacao = table.Column<DateTime>(nullable: true),
                    gzk_c_unique = table.Column<Guid>(nullable: false),
                    gzk_d_atualizado = table.Column<DateTime>(nullable: false),
                    gzk_d_inclusao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_gzk_grupoTabelaHorarioFacialZK", x => x.gzk_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_gzk_grupoTabelaHorarioFacialZK_tb_fzk_tabelaHorarioFacialZK",
                        column: x => x.gzk_fzk_n_codigo,
                        principalTable: "tb_fzk_tabelaHorarioFacialZK",
                        principalColumn: "fzk_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_gzk_grupoTabelaHorarioFacialZK_gzk_fzk_n_codigo",
                table: "tb_gzk_grupoTabelaHorarioFacialZK",
                column: "gzk_fzk_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_gzk_grupoTabelaHorarioFacialZK");
        }
    }
}
