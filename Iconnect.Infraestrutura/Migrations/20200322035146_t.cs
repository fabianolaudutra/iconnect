using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class t : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_upa_uploadAPK",
                columns: table => new
                {
                    upa_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    upa_c_arquivo = table.Column<byte[]>(nullable: true),
                    upa_n_versaoName = table.Column<string>(nullable: true),
                    upa_n_versaoCode = table.Column<int>(nullable: true),
                    upa_c_nome = table.Column<string>(nullable: true),
                    upa_d_inclusao = table.Column<DateTime>(nullable: true),
                    upa_c_unique = table.Column<Guid>(nullable: true),
                    upa_c_usuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_upa_uploadAPK", x => x.upa_n_codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_upa_uploadAPK");
        }
    }
}
