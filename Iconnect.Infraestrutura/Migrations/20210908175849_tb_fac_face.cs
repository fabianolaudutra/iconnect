using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class tb_fac_face : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_fac_face",
                columns: table => new
                {
                    fac_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fac_c_status = table.Column<string>(nullable: true),
                    fac_cli_n_codigo = table.Column<int>(nullable: false),
                    fac_c_template = table.Column<string>(nullable: true),
                    fac_c_imagem = table.Column<byte[]>(type: "image", nullable: true),
                    fac_d_dataSolicitacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    fac_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    fac_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    fac_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    fac_n_tamanho = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_fac_face", x => x.fac_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_fac_face_tb_cli_cliente",
                        column: x => x.fac_cli_n_codigo,
                        principalTable: "tb_cli_cliente",
                        principalColumn: "cli_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_fac_face_fac_cli_n_codigo",
                table: "tb_fac_face",
                column: "fac_cli_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_fac_face");
        }
    }
}
