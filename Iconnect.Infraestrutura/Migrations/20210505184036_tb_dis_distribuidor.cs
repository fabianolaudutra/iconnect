using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class tb_dis_distribuidor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tb_dis_distribuidordis_n_codigo",
                table: "tb_emp_empresa",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tb_dis_distribuidor",
                columns: table => new
                {
                    dis_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dis_c_razaoSocial = table.Column<string>(unicode: false, nullable: true),
                    dis_c_nomeFantasia = table.Column<string>(unicode: false, nullable: true),
                    dis_d_contrato = table.Column<DateTime>(type: "datetime", nullable: true),
                    dis_c_cnpj = table.Column<string>(unicode: false, nullable: true),
                    dis_c_ie = table.Column<string>(unicode: false, nullable: true),
                    dis_c_pessoaContato = table.Column<string>(unicode: false, nullable: true),
                    dis_c_email = table.Column<string>(unicode: false, nullable: true),
                    dis_c_email2 = table.Column<string>(unicode: false, nullable: true),
                    dis_c_foneComercial = table.Column<string>(unicode: false, nullable: true),
                    dis_c_foneComercial2 = table.Column<string>(unicode: false, nullable: true),
                    dis_c_celular = table.Column<string>(unicode: false, nullable: true),
                    dis_c_celular2 = table.Column<string>(unicode: false, nullable: true),
                    dis_c_rua = table.Column<string>(unicode: false, nullable: true),
                    dis_c_numero = table.Column<string>(unicode: false, nullable: true),
                    dis_c_complemento = table.Column<string>(unicode: false, nullable: true),
                    dis_c_bairro = table.Column<string>(unicode: false, nullable: true),
                    dis_c_cep = table.Column<string>(unicode: false, nullable: true),
                    dis_cid_n_codigo = table.Column<int>(nullable: true),
                    dis_est_n_codigo = table.Column<int>(nullable: true),
                    dis_c_observacao = table.Column<string>(unicode: false, nullable: true),
                    dis_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
                    dis_c_usuario = table.Column<string>(unicode: false, nullable: true),
                    dis_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    dis_b_ativo = table.Column<bool>(nullable: true),
                    dis_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    dis_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    dis_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_dis_distribuidor", x => x.dis_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_dis_distribuidor_tb_cid_cidade",
                        column: x => x.dis_cid_n_codigo,
                        principalTable: "tb_cid_cidade",
                        principalColumn: "cid_n_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_dis_distribuidor_tb_est_estado",
                        column: x => x.dis_est_n_codigo,
                        principalTable: "tb_est_estado",
                        principalColumn: "est_n_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_emp_empresa_tb_dis_distribuidordis_n_codigo",
                table: "tb_emp_empresa",
                column: "tb_dis_distribuidordis_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_dis_distribuidor_dis_cid_n_codigo",
                table: "tb_dis_distribuidor",
                column: "dis_cid_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_dis_distribuidor_dis_est_n_codigo",
                table: "tb_dis_distribuidor",
                column: "dis_est_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_emp_empresa_tb_dis_distribuidor_tb_dis_distribuidordis_n_codigo",
                table: "tb_emp_empresa",
                column: "tb_dis_distribuidordis_n_codigo",
                principalTable: "tb_dis_distribuidor",
                principalColumn: "dis_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_emp_empresa_tb_dis_distribuidor_tb_dis_distribuidordis_n_codigo",
                table: "tb_emp_empresa");

            migrationBuilder.DropTable(
                name: "tb_dis_distribuidor");

            migrationBuilder.DropIndex(
                name: "IX_tb_emp_empresa_tb_dis_distribuidordis_n_codigo",
                table: "tb_emp_empresa");

            migrationBuilder.DropColumn(
                name: "tb_dis_distribuidordis_n_codigo",
                table: "tb_emp_empresa");
        }
    }
}
