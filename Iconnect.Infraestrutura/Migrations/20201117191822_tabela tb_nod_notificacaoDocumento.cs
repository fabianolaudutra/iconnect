using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class tabelatb_nod_notificacaoDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_nod_notificacaoDocumento",
                columns: table => new
                {
                    nod_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nod_c_assunto = table.Column<string>(nullable: true),
                    nod_c_nomeDocumento = table.Column<string>(nullable: true),
                    nod_c_nomeFuncionario = table.Column<string>(nullable: true),
                    nod_c_dataVencimento = table.Column<string>(nullable: true),
                    nod_b_processado = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    nod_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    nod_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    nod_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nod_n_codigo", x => x.nod_n_codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_nod_notificacaoDocumento");
        }
    }
}
