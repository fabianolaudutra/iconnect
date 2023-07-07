using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class tabelas_categoria_catalogo__subcategoria_categoriaCatalogo_relacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "grf_c_observacoesHomeCare",
                table: "tb_grf_grupoFamiliar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(450)",
                oldUnicode: false,
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "gpp_pta_c_codigo",
                table: "tb_gpp_grupoPermissaoOperador",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cli_c_senhaAppGarenConnect",
                table: "tb_cli_cliente",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tb_cat_categoriaCatalogo",
                columns: table => new
                {
                    cat_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat_cli_n_codigo = table.Column<int>(nullable: false),
                    cat_b_ativo = table.Column<bool>(nullable: false),
                    cat_b_tipoLink = table.Column<bool>(nullable: false),
                    cat_b_solicitarEspecialidade = table.Column<bool>(nullable: false),
                    cat_c_nome = table.Column<string>(unicode: false, nullable: true),
                    cat_c_descricao = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    cat_c_link = table.Column<string>(unicode: false, nullable: true),
                    cat_c_imagem = table.Column<string>(unicode: false, nullable: true),
                    cat_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    cat_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    cat_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cat_categoriaCatalogo", x => x.cat_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_cat_categoriaCatalogo_tb_cli_cliente",
                        column: x => x.cat_cli_n_codigo,
                        principalTable: "tb_cli_cliente",
                        principalColumn: "cli_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_scc_subCategoriaCatalogo",
                columns: table => new
                {
                    scc_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    scc_cat_n_codigo = table.Column<int>(nullable: false),
                    scc_cli_n_codigo = table.Column<int>(nullable: false),
                    scc_b_ativo = table.Column<bool>(nullable: false),
                    scc_c_nome = table.Column<string>(unicode: false, nullable: true),
                    scc_c_imagem = table.Column<string>(unicode: false, nullable: true),
                    scc_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    scc_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    scc_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_scc_subCategoriaCatalogo", x => x.scc_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_scc_subCategoriaCatalogo_tb_cat_categoriaCatalogo",
                        column: x => x.scc_cat_n_codigo,
                        principalTable: "tb_cat_categoriaCatalogo",
                        principalColumn: "cat_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_cal_catalogo",
                columns: table => new
                {
                    cal_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cal_scc_n_codigo = table.Column<int>(nullable: false),
                    cal_cli_n_codigo = table.Column<int>(nullable: false),
                    cal_c_nome = table.Column<string>(nullable: true),
                    cal_c_descricao = table.Column<string>(nullable: true),
                    cal_c_logoMarca = table.Column<string>(nullable: true),
                    cal_c_especialidade = table.Column<string>(nullable: true),
                    cal_c_telefonePrincipal = table.Column<string>(nullable: true),
                    cal_c_telefoneSecundario = table.Column<string>(nullable: true),
                    cal_c_email = table.Column<string>(nullable: true),
                    call_c_website = table.Column<string>(nullable: true),
                    cal_c_redeSocial1 = table.Column<string>(nullable: true),
                    cal_c_redeSocial2 = table.Column<string>(nullable: true),
                    cal_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    cal_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    cal_d_inclsao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cal_catalogo", x => x.cal_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_cal_catalogo_tb_scc_subCategoriaCatalogo",
                        column: x => x.cal_scc_n_codigo,
                        principalTable: "tb_scc_subCategoriaCatalogo",
                        principalColumn: "scc_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_lca_localidadeCatalogo",
                columns: table => new
                {
                    lca_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lca_lcc_n_codigo = table.Column<int>(nullable: true),
                    lca_cal_n_codigo = table.Column<int>(nullable: true),
                    lca_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    lca_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    lca_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    lca_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_lca_localidadeCatalogo", x => x.lca_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_lca_localidadeCatalogo_tb_cal_catalogo",
                        column: x => x.lca_cal_n_codigo,
                        principalTable: "tb_cal_catalogo",
                        principalColumn: "cal_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_lca_localidadeCatalogo_tb_lcc_localidadeCliente",
                        column: x => x.lca_lcc_n_codigo,
                        principalTable: "tb_lcc_localidadeCliente",
                        principalColumn: "lcc_n_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_cal_catalogo_cal_scc_n_codigo",
                table: "tb_cal_catalogo",
                column: "cal_scc_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cat_categoriaCatalogo_cat_cli_n_codigo",
                table: "tb_cat_categoriaCatalogo",
                column: "cat_cli_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_lca_localidadeCatalogo_lca_cal_n_codigo",
                table: "tb_lca_localidadeCatalogo",
                column: "lca_cal_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_lca_localidadeCatalogo_lca_lcc_n_codigo",
                table: "tb_lca_localidadeCatalogo",
                column: "lca_lcc_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_scc_subCategoriaCatalogo_scc_cat_n_codigo",
                table: "tb_scc_subCategoriaCatalogo",
                column: "scc_cat_n_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_lca_localidadeCatalogo");

            migrationBuilder.DropTable(
                name: "tb_cal_catalogo");

            migrationBuilder.DropTable(
                name: "tb_scc_subCategoriaCatalogo");

            migrationBuilder.DropTable(
                name: "tb_cat_categoriaCatalogo");

            migrationBuilder.AlterColumn<string>(
                name: "grf_c_observacoesHomeCare",
                table: "tb_grf_grupoFamiliar",
                type: "varchar(450)",
                unicode: false,
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "gpp_pta_c_codigo",
                table: "tb_gpp_grupoPermissaoOperador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cli_c_senhaAppGarenConnect",
                table: "tb_cli_cliente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldNullable: true);
        }
    }
}
