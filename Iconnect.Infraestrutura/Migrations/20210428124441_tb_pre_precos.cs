using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class tb_pre_precos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_pre_precos",
                columns: table => new
                {
                    pre_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pre_mol_c_nome = table.Column<string>(nullable: true),
                    pre_n_preco = table.Column<int>(nullable: false),
                    pre_n_precoDist = table.Column<int>(nullable: false),
                    pre_n_precoEmp = table.Column<int>(nullable: false),
                    pre_n_precoCli = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pre_precos", x => x.pre_n_codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_pre_precos");
        }
    }
}
