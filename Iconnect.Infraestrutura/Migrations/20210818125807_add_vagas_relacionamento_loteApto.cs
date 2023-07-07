using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class add_vagas_relacionamento_loteApto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_lcg_localidadeClienteGrupoFamiliar_tb_lcc_localidadeCliente",
                table: "tb_lcg_localidadeClienteGrupoFamiliar");

            migrationBuilder.DropIndex(
                name: "IX_tb_lcg_localidadeClienteGrupoFamiliar_lcg_lcc_n_codigo",
                table: "tb_lcg_localidadeClienteGrupoFamiliar");

            migrationBuilder.DropColumn(
                name: "lcg_lcc_n_codigo",
                table: "tb_lcg_localidadeClienteGrupoFamiliar");

            migrationBuilder.AddColumn<int>(
                name: "lcg_lcc_n_codigoBlocoQuadra",
                table: "tb_lcg_localidadeClienteGrupoFamiliar",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "lcg_lcc_n_codigoLoteApto",
                table: "tb_lcg_localidadeClienteGrupoFamiliar",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "lcg_n_vagas",
                table: "tb_lcg_localidadeClienteGrupoFamiliar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "cli_d_inclusao",
                table: "tb_cli_cliente",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.CreateIndex(
                name: "IX_tb_lcg_localidadeClienteGrupoFamiliar_lcg_lcc_n_codigoBlocoQuadra",
                table: "tb_lcg_localidadeClienteGrupoFamiliar",
                column: "lcg_lcc_n_codigoBlocoQuadra");

            migrationBuilder.CreateIndex(
                name: "IX_tb_lcg_localidadeClienteGrupoFamiliar_lcg_lcc_n_codigoLoteApto",
                table: "tb_lcg_localidadeClienteGrupoFamiliar",
                column: "lcg_lcc_n_codigoLoteApto");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_lcg_localidadeClienteGrupoFamiliar_tb_lcc_localidadeCliente",
                table: "tb_lcg_localidadeClienteGrupoFamiliar",
                column: "lcg_lcc_n_codigoBlocoQuadra",
                principalTable: "tb_lcc_localidadeCliente",
                principalColumn: "lcc_n_codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_lcg_localidadeClienteGrupoFamiliar_tb_lcc_localidadeClienteLoteApto",
                table: "tb_lcg_localidadeClienteGrupoFamiliar",
                column: "lcg_lcc_n_codigoLoteApto",
                principalTable: "tb_lcc_localidadeCliente",
                principalColumn: "lcc_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_lcg_localidadeClienteGrupoFamiliar_tb_lcc_localidadeCliente",
                table: "tb_lcg_localidadeClienteGrupoFamiliar");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_lcg_localidadeClienteGrupoFamiliar_tb_lcc_localidadeClienteLoteApto",
                table: "tb_lcg_localidadeClienteGrupoFamiliar");

            migrationBuilder.DropIndex(
                name: "IX_tb_lcg_localidadeClienteGrupoFamiliar_lcg_lcc_n_codigoBlocoQuadra",
                table: "tb_lcg_localidadeClienteGrupoFamiliar");

            migrationBuilder.DropIndex(
                name: "IX_tb_lcg_localidadeClienteGrupoFamiliar_lcg_lcc_n_codigoLoteApto",
                table: "tb_lcg_localidadeClienteGrupoFamiliar");

            migrationBuilder.DropColumn(
                name: "lcg_lcc_n_codigoBlocoQuadra",
                table: "tb_lcg_localidadeClienteGrupoFamiliar");

            migrationBuilder.DropColumn(
                name: "lcg_lcc_n_codigoLoteApto",
                table: "tb_lcg_localidadeClienteGrupoFamiliar");

            migrationBuilder.DropColumn(
                name: "lcg_n_vagas",
                table: "tb_lcg_localidadeClienteGrupoFamiliar");

            migrationBuilder.AddColumn<int>(
                name: "lcg_lcc_n_codigo",
                table: "tb_lcg_localidadeClienteGrupoFamiliar",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "cli_d_inclusao",
                table: "tb_cli_cliente",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.CreateIndex(
                name: "IX_tb_lcg_localidadeClienteGrupoFamiliar_lcg_lcc_n_codigo",
                table: "tb_lcg_localidadeClienteGrupoFamiliar",
                column: "lcg_lcc_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_lcg_localidadeClienteGrupoFamiliar_tb_lcc_localidadeCliente",
                table: "tb_lcg_localidadeClienteGrupoFamiliar",
                column: "lcg_lcc_n_codigo",
                principalTable: "tb_lcc_localidadeCliente",
                principalColumn: "lcc_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
