using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class tb_sca_salaComercialCatalogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_sca_salaComercialCatalogo",
                columns: table => new
                {
                    sca_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sca_grf_n_codigo = table.Column<int>(nullable: false),
                    sca_cal_n_codigo = table.Column<int>(nullable: false),
                    sca_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    sca_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    sca_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_sca_salaComercialCatalogo", x => x.sca_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_sca_salaComercialCatalogo_tb_cal_catalogo",
                        column: x => x.sca_cal_n_codigo,
                        principalTable: "tb_cal_catalogo",
                        principalColumn: "cal_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_sca_salaComercialCatalogo_tb_grf_grupoFamiliar",
                        column: x => x.sca_grf_n_codigo,
                        principalTable: "tb_grf_grupoFamiliar",
                        principalColumn: "grf_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_sca_salaComercialCatalogo_sca_cal_n_codigo",
                table: "tb_sca_salaComercialCatalogo",
                column: "sca_cal_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sca_salaComercialCatalogo_sca_grf_n_codigo",
                table: "tb_sca_salaComercialCatalogo",
                column: "sca_grf_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_sca_salaComercialCatalogo");
        }
    }
}
