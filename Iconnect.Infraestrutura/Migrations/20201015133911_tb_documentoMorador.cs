using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class tb_documentoMorador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_dmo_documentoMorador",
                columns: table => new
                {
                    dmo_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dmo_mor_n_codigo = table.Column<int>(nullable: false),
                    dmo_doc_n_codigo = table.Column<int>(nullable: false),
                    dmo_d_vencimento = table.Column<DateTime>(nullable: false),
                    dmo_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    dmo_c_unique = table.Column<Guid>(nullable: false),
                    dmo_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    dmo_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_dmo_documentoMorador", x => x.dmo_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_dmo_documentoMorador_tb_doc_documento",
                        column: x => x.dmo_doc_n_codigo,
                        principalTable: "tb_doc_documento",
                        principalColumn: "doc_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_dmo_documentoMorador_tb_mor_Morador",
                        column: x => x.dmo_mor_n_codigo,
                        principalTable: "tb_mor_Morador",
                        principalColumn: "mor_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_dmo_documentoMorador_dmo_doc_n_codigo",
                table: "tb_dmo_documentoMorador",
                column: "dmo_doc_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_dmo_documentoMorador_dmo_mor_n_codigo",
                table: "tb_dmo_documentoMorador",
                column: "dmo_mor_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_dmo_documentoMorador");
        }
    }
}
