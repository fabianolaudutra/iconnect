using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class tabela_gerenciar_conexoes_signalR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_csr_connectionSignalR",
                columns: table => new
                {
                    csr_n_codigo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    csr_s_connectionId = table.Column<string>(nullable: true),
                    csr_b_conectado = table.Column<bool>(nullable: false),
                    csr_n_hub = table.Column<int>(nullable: false),
                    crs_n_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_csr_connectionSignalR", x => x.csr_n_codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_csr_connectionSignalR");
        }
    }
}
