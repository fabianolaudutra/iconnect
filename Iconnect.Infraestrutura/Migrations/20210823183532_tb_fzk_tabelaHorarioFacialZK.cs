using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class tb_fzk_tabelaHorarioFacialZK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "cli_d_inclusao",
                table: "tb_cli_cliente",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.CreateTable(
                name: "tb_fzk_tabelaHorarioFacialZK",
                columns: table => new
                {
                    fzk_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fzk_con_n_codigo = table.Column<int>(nullable: false),
                    fzk_disp_n_codigo = table.Column<int>(nullable: false),
                    fzk_hor_n_codigo = table.Column<int>(nullable: false),
                    fzk_d_modificacao = table.Column<DateTime>(nullable: true),
                    fzk_c_unique = table.Column<Guid>(nullable: false),
                    fzk_d_atualizado = table.Column<DateTime>(nullable: false),
                    fzk_d_inclusao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_fzk_tabelaHorarioFacialZK", x => x.fzk_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_fzk_tabelaHorarioFacialZK_tb_hor_horario",
                        column: x => x.fzk_hor_n_codigo,
                        principalTable: "tb_hor_horario",
                        principalColumn: "hor_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_fzk_tabelaHorarioFacialZK_fzk_hor_n_codigo",
                table: "tb_fzk_tabelaHorarioFacialZK",
                column: "fzk_hor_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_fzk_tabelaHorarioFacialZK");

            migrationBuilder.AlterColumn<DateTime>(
                name: "cli_d_inclusao",
                table: "tb_cli_cliente",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");
        }
    }
}
