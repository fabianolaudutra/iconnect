using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_columm_tb_lid_liberacaoDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "lid_c_nomeEmpresa",
                table: "tb_lid_liberacaoDelivery",
                unicode: false,
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lid_c_nomeEmpresa",
                table: "tb_lid_liberacaoDelivery");
        }
    }
}
