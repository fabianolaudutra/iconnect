using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class frota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_fro_frota",
                columns: table => new
                {
                    fro_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fro_cli_n_codigo = table.Column<int>(nullable: false),
                    fro_mav_n_codigo = table.Column<int>(nullable: false),
                    fro_c_modelo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    fro_c_ano = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    fro_c_cor = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    fro_c_placa = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    fro_c_caracteristicas = table.Column<string>(unicode: false, nullable: true),
                    fro_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    fro_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    fro_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    fro_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_fro_frota", x => x.fro_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_fro_veiculo_tb_cli_cliente",
                        column: x => x.fro_cli_n_codigo,
                        principalTable: "tb_cli_cliente",
                        principalColumn: "cli_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_fro_frota_tb_mav_marcaVeiculo",
                        column: x => x.fro_mav_n_codigo,
                        principalTable: "tb_mav_marcaVeiculo",
                        principalColumn: "mav_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_fro_frota_fro_cli_n_codigo",
                table: "tb_fro_frota",
                column: "fro_cli_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_fro_frota_fro_mav_n_codigo",
                table: "tb_fro_frota",
                column: "fro_mav_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_fro_frota");
        }
    }
}
