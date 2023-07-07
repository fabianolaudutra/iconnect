using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_tb_aco_acompanhante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_aco_acompanhante",
                columns: table => new
                {
                    aco_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aco_age_n_codigo = table.Column<int>(nullable: true),
                    aco_vis_n_codigo = table.Column<int>(nullable: true),
                    aco_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    aco_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_aco_acompanhante", x => x.aco_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_aco_acompanhante_tb_age_agenda",
                        column: x => x.aco_age_n_codigo,
                        principalTable: "tb_age_agenda",
                        principalColumn: "age_n_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_aco_acompanhante_tb_vis_visitante",
                        column: x => x.aco_vis_n_codigo,
                        principalTable: "tb_vis_visitante",
                        principalColumn: "vis_n_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_aco_acompanhante_aco_age_n_codigo",
                table: "tb_aco_acompanhante",
                column: "aco_age_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_aco_acompanhante_aco_vis_n_codigo",
                table: "tb_aco_acompanhante",
                column: "aco_vis_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_aco_acompanhante");
        }
    }
}
