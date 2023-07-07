using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_tb_tpc_topico_vinculo_tb_ajd_ajuda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ajd_c_topico",
                table: "tb_ajd_ajuda");

            migrationBuilder.AddColumn<int>(
                name: "ajd_tpc_n_codigo",
                table: "tb_ajd_ajuda",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tb_tpc_topicos",
                columns: table => new
                {
                    tpc_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tpc_c_descricao = table.Column<string>(nullable: true),
                    tpc_d_modificacao = table.Column<DateTime>(nullable: true),
                    tpc_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    tpc_d_atualizado = table.Column<DateTime>(nullable: false),
                    tpc_d_inclusao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tpc_topicos", x => x.tpc_n_codigo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_ajd_ajuda_ajd_tpc_n_codigo",
                table: "tb_ajd_ajuda",
                column: "ajd_tpc_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_ajd_ajuda_tb_tpc_topicos",
                table: "tb_ajd_ajuda",
                column: "ajd_tpc_n_codigo",
                principalTable: "tb_tpc_topicos",
                principalColumn: "tpc_n_codigo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_ajd_ajuda_tb_tpc_topicos",
                table: "tb_ajd_ajuda");

            migrationBuilder.DropTable(
                name: "tb_tpc_topicos");

            migrationBuilder.DropIndex(
                name: "IX_tb_ajd_ajuda_ajd_tpc_n_codigo",
                table: "tb_ajd_ajuda");

            migrationBuilder.DropColumn(
                name: "ajd_tpc_n_codigo",
                table: "tb_ajd_ajuda");

            migrationBuilder.AddColumn<string>(
                name: "ajd_c_topico",
                table: "tb_ajd_ajuda",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
