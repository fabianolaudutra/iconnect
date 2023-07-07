using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_tb_fen_foto_entrega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_fen_foto_entrega",
                columns: table => new
                {
                    fen_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fen_c_imagem = table.Column<byte[]>(nullable: true),
                    fen_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    fen_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fen_n_codigo", x => x.fen_n_codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_fen_foto_entrega");
        }
    }
}
