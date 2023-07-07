using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class tb_age_agenteComercial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_age_agenteComercial",
                columns: table => new
                {
                    age_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    age_c_nome = table.Column<string>(nullable: true),
                    age_c_rg = table.Column<string>(nullable: true),
                    age_c_email = table.Column<string>(nullable: true),
                    age_c_celular = table.Column<string>(nullable: true),
                    age_ace_n_codigo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_age_agenteComercial", x => x.age_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_age_agenteComercial_tb_ace_acesso",
                        column: x => x.age_ace_n_codigo,
                        principalTable: "tb_ace_acesso",
                        principalColumn: "ace_n_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_age_agenteComercial_age_ace_n_codigo",
                table: "tb_age_agenteComercial",
                column: "age_ace_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_age_agenteComercial");
        }
    }
}
