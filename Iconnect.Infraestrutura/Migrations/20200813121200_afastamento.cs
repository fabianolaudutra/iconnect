using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class afastamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ope_pop_n_codigo",
                table: "tb_ope_operador",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tb_afa_afastamento",
                columns: table => new
                {
                    afa_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    afa_mor_n_codigo = table.Column<int>(nullable: false),
                    afa_c_descricao = table.Column<string>(nullable: true),
                    afa_d_inicio = table.Column<DateTime>(nullable: false),
                    afa_d_fim = table.Column<DateTime>(nullable: false),
                    afa_b_sicronizado = table.Column<bool>(nullable: false),
                    afa_d_modificacao = table.Column<DateTime>(nullable: true),
                    afa_c_unique = table.Column<Guid>(nullable: false),
                    afa_d_atualizado = table.Column<DateTime>(nullable: false),
                    afa_d_inclusao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_afa_afastamento", x => x.afa_n_codigo);
                    table.ForeignKey(
                        name: "tb_afa_afastamento_tb_mor_morador",
                        column: x => x.afa_mor_n_codigo,
                        principalTable: "tb_mor_Morador",
                        principalColumn: "mor_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_pop_perfilOperador",
                columns: table => new
                {
                    pop_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pop_c_nome = table.Column<string>(nullable: true),
                    pop_d_modificacao = table.Column<DateTime>(nullable: true),
                    pop_c_unique = table.Column<Guid>(nullable: false),
                    pop_d_atualizado = table.Column<DateTime>(nullable: false),
                    pop_d_inclusao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pop_perfilOperador", x => x.pop_n_codigo);
                });
 
            migrationBuilder.CreateIndex(
                name: "IX_tb_ope_operador_ope_pop_n_codigo",
                table: "tb_ope_operador",
                column: "ope_pop_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_afa_afastamento_afa_mor_n_codigo",
                table: "tb_afa_afastamento",
                column: "afa_mor_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_ope_operador_tb_pop_perfilOperador",
                table: "tb_ope_operador",
                column: "ope_pop_n_codigo",
                principalTable: "tb_pop_perfilOperador",
                principalColumn: "pop_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_ope_operador_tb_pop_perfilOperador",
                table: "tb_ope_operador");

            migrationBuilder.DropTable(
                name: "tb_afa_afastamento");

            migrationBuilder.DropTable(
                name: "tb_pop_perfilOperador");

            migrationBuilder.DropIndex(
                name: "IX_tb_ope_operador_ope_pop_n_codigo",
                table: "tb_ope_operador");

            migrationBuilder.DropColumn(
                name: "ope_pop_n_codigo",
                table: "tb_ope_operador");

            migrationBuilder.DropColumn(
                name: "moc_b_encerrar",
                table: "tb_moc_motivoOcorrenciaCliente");

            migrationBuilder.DropColumn(
                name: "lcc_c_tipoLayout",
                table: "tb_lcc_localidadeCliente");
        }
    }
}
