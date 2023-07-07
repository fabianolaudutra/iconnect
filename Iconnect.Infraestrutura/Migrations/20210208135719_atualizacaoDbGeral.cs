using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class atualizacaoDbGeral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_ace_acesso_tb_emp_empresa",
                table: "tb_ace_acesso");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_lid_liberacaoDelivery_tb_mor_Morador",
                table: "tb_lid_liberacaoDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_lip_liberacaoPrestador_tb_mor_Morador",
                table: "tb_lip_liberacaoPrestador");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pan_panicoApp_tb_mor_Morador",
                table: "tb_pan_panicoApp");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_vis_visitasApp_tb_mor_Morador",
                table: "tb_vis_visitasApp");

            migrationBuilder.AlterColumn<int>(
                name: "vis_mor_n_codigo",
                table: "tb_vis_visitasApp",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "sol_cli_n_codigo",
                table: "tb_sol_solicitacaoAberturaRemota",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "pan_mor_n_codigo",
                table: "tb_pan_panicoApp",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "mol_b_comboUsuarioGuard",
                table: "tb_mol_modulosLiberados",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "lip_mor_n_codigo",
                table: "tb_lip_liberacaoPrestador",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "lid_mor_n_codigo",
                table: "tb_lid_liberacaoDelivery",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "grf_b_permiteHomeCare",
                table: "tb_grf_grupoFamiliar",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "((1))");

            migrationBuilder.AddColumn<string>(
                name: "gpp_pta_c_codigo",
                table: "tb_gpp_grupoPermissaoOperador",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "exc_cli_c_unique",
                table: "tb_exc_exclusoes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "exc_d_dataExclusao",
                table: "tb_exc_exclusoes",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.CreateTable(
                name: "tb_dow_downloads_arquivos",
                columns: table => new
                {
                    dow_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dow_c_descricao = table.Column<string>(nullable: true),
                    dow_d_data = table.Column<DateTime>(nullable: false),
                    dow_c_arquivo = table.Column<byte[]>(nullable: true),
                    dow_cli_n_codigo = table.Column<int>(nullable: false),
                    dow_c_titulo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("[PK_tb_dow_downloads_arquivos", x => x.dow_n_codigo);
                    table.ForeignKey(
                        name: "FK_tb_dow_downloads_arquivos_tb_cli_cliente",
                        column: x => x.dow_cli_n_codigo,
                        principalTable: "tb_cli_cliente",
                        principalColumn: "cli_n_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_mch_monitoramentoControleAcesso_historico",
                columns: table => new
                {
                    mch_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mch_con_n_codigo = table.Column<int>(nullable: false),
                    mch_d_evento = table.Column<DateTime>(nullable: false),
                    mch_c_pin = table.Column<string>(nullable: true),
                    mch_cli_n_codigo = table.Column<int>(nullable: false),
                    mch_c_cardNumber = table.Column<string>(nullable: true),
                    mch_c_doorId = table.Column<string>(nullable: true),
                    mch_c_tipoPessoa = table.Column<string>(nullable: true),
                    mch_c_usuario = table.Column<string>(nullable: true),
                    mch_c_pontoAcesso = table.Column<string>(nullable: true),
                    mch_c_acao = table.Column<string>(nullable: true),
                    mch_c_status = table.Column<string>(nullable: true),
                    mch_c_tipoEventoMotivo = table.Column<string>(nullable: true),
                    mch_usu_n_codigo = table.Column<int>(nullable: false),
                    mch_fot_n_codigo = table.Column<int>(nullable: false),
                    mch_b_inOut = table.Column<bool>(nullable: false),
                    mch_b_panico = table.Column<bool>(nullable: false),
                    mch_ate_n_codigo = table.Column<int>(nullable: false),
                    mch_b_precisaAtendimento = table.Column<bool>(nullable: false),
                    mch_n_h = table.Column<int>(nullable: false),
                    mch_d_modificacao = table.Column<DateTime>(nullable: false),
                    mch_b_LimparEvento = table.Column<bool>(nullable: false),
                    mch_b_panicoTratado = table.Column<bool>(nullable: false),
                    mch_d_dataTratamentoPanico = table.Column<DateTime>(nullable: false),
                    mch_c_obsTratamentoPanico = table.Column<string>(nullable: true),
                    mch_c_UsuarioTratamentoPanico = table.Column<string>(nullable: true),
                    mch_b_tipoPanico = table.Column<bool>(nullable: false),
                    mch_pec_n_codigo = table.Column<int>(nullable: false),
                    mch_b_pendenteVideo = table.Column<bool>(nullable: false),
                    mch_c_destino = table.Column<string>(nullable: true),
                    mch_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    mch_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    mch_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mch_monitoramentoControleAcesso_historico", x => x.mch_n_codigo);
                });

            migrationBuilder.CreateTable(
                name: "tb_vap_versaoApp",
                columns: table => new
                {
                    vap_n_codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vap_c_apk = table.Column<byte[]>(nullable: true),
                    vap_c_numeroVersao = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    vap_d_dataInclusao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vap_versaoApp", x => x.vap_n_codigo);
                });

            migrationBuilder.CreateIndex(
                name: "idx_tb_exc_exclusoes99",
                table: "tb_exc_exclusoes",
                column: "exc_cli_c_unique")
                .Annotation("SqlServer:Include", new[] { "exc_c_tabela", "exc_c_id", "exc_d_dataExclusao" });

            migrationBuilder.CreateIndex(
                name: "idx_tb_con_monitoramentoControleAces99",
                table: "tb_con_monitoramentoControleAcesso",
                column: "con_c_unique");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ate_atendimento_ate_cli_n_codigo",
                table: "tb_ate_atendimento",
                column: "ate_cli_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_apa_aplicacoesAlarme_apa_emp_n_codigo",
                table: "tb_apa_aplicacoesAlarme",
                column: "apa_emp_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ace_acesso_ace_per_n_codigo",
                table: "tb_ace_acesso",
                column: "ace_per_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_aba_agendaBackupAutomatico_aba_cli_n_codigo",
                table: "tb_aba_agendaBackupAutomatico",
                column: "aba_cli_n_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_dow_downloads_arquivos_dow_cli_n_codigo",
                table: "tb_dow_downloads_arquivos",
                column: "dow_cli_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_aba_agendaBackupAutomatico_tb_cli_cliente",
                table: "tb_aba_agendaBackupAutomatico",
                column: "aba_cli_n_codigo",
                principalTable: "tb_cli_cliente",
                principalColumn: "cli_n_codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_ace_acesso_tb_emp_empresa",
                table: "tb_ace_acesso",
                column: "ace_emp_n_codigo",
                principalTable: "tb_emp_empresa",
                principalColumn: "emp_n_codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_ace_acesso_tb_per_perfil",
                table: "tb_ace_acesso",
                column: "ace_per_n_codigo",
                principalTable: "tb_per_perfil",
                principalColumn: "per_n_codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_apa_aplicacoesAlarme_tb_emp_empresa",
                table: "tb_apa_aplicacoesAlarme",
                column: "apa_emp_n_codigo",
                principalTable: "tb_emp_empresa",
                principalColumn: "emp_n_codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_ate_atendimento_tb_cli_cliente",
                table: "tb_ate_atendimento",
                column: "ate_cli_n_codigo",
                principalTable: "tb_cli_cliente",
                principalColumn: "cli_n_codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_lid_liberacaoDelivery_tb_mor_Morador",
                table: "tb_lid_liberacaoDelivery",
                column: "lid_mor_n_codigo",
                principalTable: "tb_mor_Morador",
                principalColumn: "mor_n_codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_lip_liberacaoPrestador_tb_mor_Morador",
                table: "tb_lip_liberacaoPrestador",
                column: "lip_mor_n_codigo",
                principalTable: "tb_mor_Morador",
                principalColumn: "mor_n_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pan_panicoApp_tb_mor_Morador",
                table: "tb_pan_panicoApp",
                column: "pan_mor_n_codigo",
                principalTable: "tb_mor_Morador",
                principalColumn: "mor_n_codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vis_visitasApp_tb_mor_Morador",
                table: "tb_vis_visitasApp",
                column: "vis_mor_n_codigo",
                principalTable: "tb_mor_Morador",
                principalColumn: "mor_n_codigo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_aba_agendaBackupAutomatico_tb_cli_cliente",
                table: "tb_aba_agendaBackupAutomatico");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_ace_acesso_tb_emp_empresa",
                table: "tb_ace_acesso");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_ace_acesso_tb_per_perfil",
                table: "tb_ace_acesso");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_apa_aplicacoesAlarme_tb_emp_empresa",
                table: "tb_apa_aplicacoesAlarme");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_ate_atendimento_tb_cli_cliente",
                table: "tb_ate_atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_lid_liberacaoDelivery_tb_mor_Morador",
                table: "tb_lid_liberacaoDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_lip_liberacaoPrestador_tb_mor_Morador",
                table: "tb_lip_liberacaoPrestador");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pan_panicoApp_tb_mor_Morador",
                table: "tb_pan_panicoApp");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_vis_visitasApp_tb_mor_Morador",
                table: "tb_vis_visitasApp");

            migrationBuilder.DropTable(
                name: "tb_dow_downloads_arquivos");

            migrationBuilder.DropTable(
                name: "tb_mch_monitoramentoControleAcesso_historico");

            migrationBuilder.DropTable(
                name: "tb_vap_versaoApp");

            migrationBuilder.DropIndex(
                name: "idx_tb_exc_exclusoes99",
                table: "tb_exc_exclusoes");

            migrationBuilder.DropIndex(
                name: "idx_tb_con_monitoramentoControleAces99",
                table: "tb_con_monitoramentoControleAcesso");

            migrationBuilder.DropIndex(
                name: "IX_tb_ate_atendimento_ate_cli_n_codigo",
                table: "tb_ate_atendimento");

            migrationBuilder.DropIndex(
                name: "IX_tb_apa_aplicacoesAlarme_apa_emp_n_codigo",
                table: "tb_apa_aplicacoesAlarme");

            migrationBuilder.DropIndex(
                name: "IX_tb_ace_acesso_ace_per_n_codigo",
                table: "tb_ace_acesso");

            migrationBuilder.DropIndex(
                name: "IX_tb_aba_agendaBackupAutomatico_aba_cli_n_codigo",
                table: "tb_aba_agendaBackupAutomatico");

            migrationBuilder.DropColumn(
                name: "mol_b_comboUsuarioGuard",
                table: "tb_mol_modulosLiberados");

            migrationBuilder.DropColumn(
                name: "gpp_pta_c_codigo",
                table: "tb_gpp_grupoPermissaoOperador");

            migrationBuilder.DropColumn(
                name: "exc_cli_c_unique",
                table: "tb_exc_exclusoes");

            migrationBuilder.DropColumn(
                name: "exc_d_dataExclusao",
                table: "tb_exc_exclusoes");

            migrationBuilder.AlterColumn<int>(
                name: "vis_mor_n_codigo",
                table: "tb_vis_visitasApp",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "sol_cli_n_codigo",
                table: "tb_sol_solicitacaoAberturaRemota",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "pan_mor_n_codigo",
                table: "tb_pan_panicoApp",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "lip_mor_n_codigo",
                table: "tb_lip_liberacaoPrestador",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "lid_mor_n_codigo",
                table: "tb_lid_liberacaoDelivery",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "grf_b_permiteHomeCare",
                table: "tb_grf_grupoFamiliar",
                type: "bit",
                nullable: true,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValueSql: "((0))");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_ace_acesso_tb_emp_empresa",
                table: "tb_ace_acesso",
                column: "ace_emp_n_codigo",
                principalTable: "tb_emp_empresa",
                principalColumn: "emp_n_codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_lid_liberacaoDelivery_tb_mor_Morador",
                table: "tb_lid_liberacaoDelivery",
                column: "lid_mor_n_codigo",
                principalTable: "tb_mor_Morador",
                principalColumn: "mor_n_codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_lip_liberacaoPrestador_tb_mor_Morador",
                table: "tb_lip_liberacaoPrestador",
                column: "lip_mor_n_codigo",
                principalTable: "tb_mor_Morador",
                principalColumn: "mor_n_codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pan_panicoApp_tb_mor_Morador",
                table: "tb_pan_panicoApp",
                column: "pan_mor_n_codigo",
                principalTable: "tb_mor_Morador",
                principalColumn: "mor_n_codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vis_visitasApp_tb_mor_Morador",
                table: "tb_vis_visitasApp",
                column: "vis_mor_n_codigo",
                principalTable: "tb_mor_Morador",
                principalColumn: "mor_n_codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
