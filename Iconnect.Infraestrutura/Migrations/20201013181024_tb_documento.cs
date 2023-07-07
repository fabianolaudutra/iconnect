using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class tb_documento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_doc_documento",
                columns: table => new
                {
                    doc_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doc_cli_n_codigo = table.Column<int>(nullable: false),
                    doc_c_nomeDocumento = table.Column<string>(unicode: false, nullable: true),
                    doc_b_bloquearAcesso = table.Column<bool>(nullable: false),
                    doc_b_preNotificacao = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    doc_b_notificacaoAcesso = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    doc_b_notificacaoVencimento = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    doc_n_diasNotificacao = table.Column<int>(unicode: false, nullable: false),
                    doc_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    doc_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    doc_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    doc_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_doc_documento", x => x.doc_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_doc_documento_tb_cli_cliente",
                        column: x => x.doc_cli_n_codigo,
                        principalTable: "tb_cli_cliente",
                        principalColumn: "cli_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_doc_documento_doc_cli_n_codigo",
                table: "tb_doc_documento",
                column: "doc_cli_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_doc_documento");
        }
    }
}
