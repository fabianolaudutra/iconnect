using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_tb_usc_usuarioSalaComercial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_usc_usuarioSalaComercial",
                columns: table => new
                {
                    usc_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usc_grf_n_codigo = table.Column<int>(nullable: true),
                    usc_mor_n_codigo = table.Column<int>(nullable: true),
                    usc_ace_n_codigo = table.Column<int>(nullable: false),
                    usc_c_perfil = table.Column<string>(unicode: false, nullable: true),
                    usc_c_nome = table.Column<string>(unicode: false, nullable: true),
                    usc_c_cpf = table.Column<string>(unicode: false, nullable: true),
                    usc_c_usuario = table.Column<string>(unicode: false, nullable: true),
                    usc_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    usc_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usc_usuarioSalaComercial", x => x.usc_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_usc_usuarioSalaComercial_tb_ace_acesso",
                        column: x => x.usc_ace_n_codigo,
                        principalTable: "tb_ace_acesso",
                        principalColumn: "ace_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_usc_usuarioSalaComercial_tb_grf_grupoFamiliar",
                        column: x => x.usc_grf_n_codigo,
                        principalTable: "tb_grf_grupoFamiliar",
                        principalColumn: "grf_n_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_usc_usuarioSalaComercial_tb_mor_Morador",
                        column: x => x.usc_mor_n_codigo,
                        principalTable: "tb_mor_Morador",
                        principalColumn: "mor_n_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_usc_usuarioSalaComercial_usc_ace_n_codigo",
                table: "tb_usc_usuarioSalaComercial",
                column: "usc_ace_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_usc_usuarioSalaComercial_usc_grf_n_codigo",
                table: "tb_usc_usuarioSalaComercial",
                column: "usc_grf_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_usc_usuarioSalaComercial_usc_mor_n_codigo",
                table: "tb_usc_usuarioSalaComercial",
                column: "usc_mor_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_usc_usuarioSalaComercial");
        }
    }
}
