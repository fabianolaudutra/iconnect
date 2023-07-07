using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_tb_age_agenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_age_agenda",
                columns: table => new
                {
                    age_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    age_grf_n_codigo = table.Column<int>(nullable: false),
                    age_vis_n_codigo = table.Column<int>(nullable: false),
                    age_d_dataAgendamento = table.Column<DateTime>(nullable: true),
                    age_c_horarioInicio = table.Column<string>(unicode: false, nullable: true),
                    age_c_horarioFim = table.Column<string>(unicode: false, nullable: true),
                    age_c_usuario = table.Column<string>(unicode: false, nullable: true),
                    age_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    age_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_age_agenda", x => x.age_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_age_agenda_tb_grf_grupoFamiliar",
                        column: x => x.age_grf_n_codigo,
                        principalTable: "tb_grf_grupoFamiliar",
                        principalColumn: "grf_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_age_agenda_tb_vis_visitante",
                        column: x => x.age_vis_n_codigo,
                        principalTable: "tb_vis_visitante",
                        principalColumn: "vis_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_age_agenda_age_grf_n_codigo",
                table: "tb_age_agenda",
                column: "age_grf_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_age_agenda_age_vis_n_codigo",
                table: "tb_age_agenda",
                column: "age_vis_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_age_agenda");
        }
    }
}
