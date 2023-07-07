using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class novastabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "tb_per_permissionamento",
                columns: table => new
                {
                    per_u_codigo = table.Column<Guid>(nullable: false),
                    per_b_ativo = table.Column<bool>(nullable: false),
                    per_c_chave = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_per_permissionamento", x => x.per_u_codigo);
                });

            migrationBuilder.CreateTable(
                name: "tb_ace_per_acessoPermissionamento",
                columns: table => new
                {
                    ace_per_u_codigo = table.Column<Guid>(nullable: false),
                    per_u_n_codigo = table.Column<Guid>(nullable: false),
                    per_ace_n_codigo = table.Column<int>(nullable: false),
                    tb_ace_acessoace_n_codigo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ace_per_acessoPermissionamento", x => x.ace_per_u_codigo);
                    table.ForeignKey(
                        name: "FK_tb_ace_per_acessoPermissionamento_tb_per_permissionamento",
                        column: x => x.per_u_n_codigo,
                        principalTable: "tb_per_permissionamento",
                        principalColumn: "per_u_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_ace_per_acessoPermissionamento_tb_ace_acesso_tb_ace_acessoace_n_codigo",
                        column: x => x.tb_ace_acessoace_n_codigo,
                        principalTable: "tb_ace_acesso",
                        principalColumn: "ace_n_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_per_per_perfilPermissionamento",
                columns: table => new
                {
                    per_per_u_codigo = table.Column<Guid>(nullable: false),
                    per_u_n_codigo = table.Column<Guid>(nullable: false),
                    per_n_codigo = table.Column<int>(nullable: false),
                    tb_per_perfilper_n_codigo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_per_per_perfilPermissionamento", x => x.per_per_u_codigo);
                    table.ForeignKey(
                        name: "FK_tb_per_per_perfilPermissionamento_tb_per_permissionamento",
                        column: x => x.per_u_n_codigo,
                        principalTable: "tb_per_permissionamento",
                        principalColumn: "per_u_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_per_per_perfilPermissionamento_tb_per_perfil_tb_per_perfilper_n_codigo",
                        column: x => x.tb_per_perfilper_n_codigo,
                        principalTable: "tb_per_perfil",
                        principalColumn: "per_n_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_ace_per_acessoPermissionamento_per_u_n_codigo",
                table: "tb_ace_per_acessoPermissionamento",
                column: "per_u_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ace_per_acessoPermissionamento_tb_ace_acessoace_n_codigo",
                table: "tb_ace_per_acessoPermissionamento",
                column: "tb_ace_acessoace_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_per_per_perfilPermissionamento_per_u_n_codigo",
                table: "tb_per_per_perfilPermissionamento",
                column: "per_u_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_per_per_perfilPermissionamento_tb_per_perfilper_n_codigo",
                table: "tb_per_per_perfilPermissionamento",
                column: "tb_per_perfilper_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_ace_per_acessoPermissionamento");

            migrationBuilder.DropTable(
                name: "tb_per_per_perfilPermissionamento");

            migrationBuilder.DropTable(
                name: "tb_per_permissionamento");

          
        }
    }
}
