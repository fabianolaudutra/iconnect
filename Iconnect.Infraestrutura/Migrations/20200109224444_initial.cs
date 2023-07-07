using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconnect.Infraestrutura.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "tb_aba_agendaBackupAutomatico",
            //    columns: table => new
            //    {
            //        aba_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        aba_cli_n_codigo = table.Column<int>(nullable: false),
            //        aba_b_ativo = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
            //        aba_c_frequencia = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
            //        aba_n_diaSemana = table.Column<int>(nullable: true),
            //        aba_n_horario = table.Column<int>(nullable: false),
            //        aba_c_usuario = table.Column<string>(unicode: false, nullable: false),
            //        aba_d_modificao = table.Column<DateTime>(type: "datetime", nullable: false),
            //        aba_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        aba_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        aba_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_aba_agendaBackupAutomatico", x => x.aba_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_ace_acesso",
            //    columns: table => new
            //    {
            //        ace_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ace_c_login = table.Column<string>(unicode: false, nullable: true),
            //        ace_c_senha = table.Column<string>(unicode: false, nullable: true),
            //        ace_b_bloqueado = table.Column<bool>(nullable: true),
            //        ace_per_n_codigo = table.Column<int>(nullable: true),
            //        ace_emp_n_codigo = table.Column<int>(nullable: true),
            //        ace_b_relacional = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
            //        ace_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ace_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        ace_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        ace_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_ace_acesso", x => x.ace_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_apa_aplicacoesAlarme",
            //    columns: table => new
            //    {
            //        apa_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        apa_c_processo = table.Column<string>(unicode: false, nullable: true),
            //        apa_c_tipo = table.Column<string>(unicode: false, nullable: true),
            //        apa_emp_n_codigo = table.Column<int>(nullable: true),
            //        apa_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        apa_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        apa_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_apa_aplicacoesAlarme", x => x.apa_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_ard_arquivoDependencias",
            //    columns: table => new
            //    {
            //        ard_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ard_usu_n_codigo = table.Column<int>(nullable: true),
            //        ard_blob_PDFImagem = table.Column<byte[]>(nullable: true),
            //        ard_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ard_c_nomePDFImagem = table.Column<string>(unicode: false, nullable: true),
            //        ard_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        ard_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        ard_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_ard_arquivoDependencias", x => x.ard_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_avi_avisoEmpresa",
            //    columns: table => new
            //    {
            //        avi_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        avi_c_titulo = table.Column<string>(unicode: false, nullable: true),
            //        avi_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        avi_d_inicio = table.Column<DateTime>(type: "date", nullable: true),
            //        avi_d_fim = table.Column<DateTime>(type: "date", nullable: true),
            //        avi_emp_c_enviarPara = table.Column<string>(unicode: false, nullable: true),
            //        avi_c_status = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        avi_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        avi_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        avi_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        avi_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        avi_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        avi_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_avi_avisoEmpresa", x => x.avi_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_cav_categorizacaoAviso",
            //    columns: table => new
            //    {
            //        cav_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        cav_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        cav_c_cor = table.Column<string>(unicode: false, nullable: true),
            //        cav_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        cav_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        cav_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cav_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        cav_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cav_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_cav_categorizacaoAviso", x => x.cav_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_cev_categorizacaoEvento",
            //    columns: table => new
            //    {
            //        cev_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        cev_c_codigoEvento = table.Column<string>(unicode: false, nullable: true),
            //        cev_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        cev_c_cor = table.Column<string>(unicode: false, nullable: true),
            //        cev_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        cev_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        cev_b_geraAtendimento = table.Column<bool>(nullable: true),
            //        cev_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cev_b_utilizaTemporizador = table.Column<bool>(nullable: true),
            //        cev_cev_n_temporizador = table.Column<int>(nullable: true),
            //        cev_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        cev_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cev_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_cev_categorizacaoEvento", x => x.cev_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_cev_categorizacaoEvento_tb_cev_categorizacaoEvento1",
            //            column: x => x.cev_cev_n_temporizador,
            //            principalTable: "tb_cev_categorizacaoEvento",
            //            principalColumn: "cev_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_cpg_comandoPGM",
            //    columns: table => new
            //    {
            //        cgp_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        cgp_c_descricao = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
            //        cgp_n_modelo = table.Column<int>(nullable: false),
            //        cgp_c_comando = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
            //        cgp_b_sirene = table.Column<bool>(nullable: false),
            //        cgp_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        cgp_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cgp_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_cpg_comandoPGM", x => x.cgp_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_csi_configuracaoSincronizacao",
            //    columns: table => new
            //    {
            //        csi_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        csi_c_tabela = table.Column<string>(unicode: false, nullable: true),
            //        csi_c_prefixo = table.Column<string>(unicode: false, nullable: true),
            //        csi_b_sobe = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
            //        csi_b_desce = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
            //        csi_b_ativo = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
            //        csi_n_importancia = table.Column<int>(nullable: true, defaultValueSql: "((1))"),
            //        csi_n_ordem = table.Column<int>(nullable: true),
            //        csi_c_where = table.Column<string>(unicode: false, nullable: false, defaultValueSql: "('')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_csi_configuracaoSincronizacao", x => x.csi_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_ema_email",
            //    columns: table => new
            //    {
            //        ema_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ema_d_data = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ema_c_assunto = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
            //        ema_c_corpo = table.Column<string>(unicode: false, nullable: true),
            //        ema_b_enviado = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
            //        ema_c_remetente = table.Column<string>(unicode: false, nullable: true),
            //        ema_c_destinatario = table.Column<string>(unicode: false, nullable: true),
            //        ema_c_copia = table.Column<string>(unicode: false, nullable: true),
            //        ema_c_copiaOculta = table.Column<string>(unicode: false, nullable: true),
            //        ema_c_caminhoAnexo = table.Column<string>(unicode: false, nullable: true),
            //        ema_c_anexo = table.Column<string>(unicode: false, nullable: true),
            //        ema_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_ema_email", x => x.ema_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_ent_entidade",
            //    columns: table => new
            //    {
            //        ent_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ent_c_nome = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
            //        ent_c_chave = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
            //        ent_c_valorPadrao = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
            //        ent_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        ent_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        ent_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_ent_entidade", x => x.ent_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_err_erro",
            //    columns: table => new
            //    {
            //        err_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        err_c_message = table.Column<string>(unicode: false, nullable: true),
            //        err_c_stack = table.Column<string>(unicode: false, nullable: true),
            //        err_c_inner = table.Column<string>(unicode: false, nullable: true),
            //        err_c_innerStack = table.Column<string>(unicode: false, nullable: true),
            //        erro_d_data = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_err_erro", x => x.err_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_est_estado",
            //    columns: table => new
            //    {
            //        est_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        est_c_descricao = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
            //        est_c_sigla = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        est_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        est_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        est_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("pk_tb_est_estado", x => x.est_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_eva_eventoAcesso",
            //    columns: table => new
            //    {
            //        eva_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        eva_n_chave = table.Column<int>(nullable: true),
            //        eva_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        eva_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        eva_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        eva_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        eva_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_eva_eventoAcesso", x => x.eva_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_exc_exclusoes",
            //    columns: table => new
            //    {
            //        exc_c_tabela = table.Column<string>(unicode: false, nullable: true),
            //        exc_c_id = table.Column<Guid>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_fap_fotoApp",
            //    columns: table => new
            //    {
            //        fap_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        fap_c_imagem = table.Column<byte[]>(nullable: true),
            //        fap_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        fap_c_unique = table.Column<Guid>(nullable: false),
            //        fap_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false),
            //        fap_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_fap_fotoApp", x => x.fap_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_fem_fotoEmpresa",
            //    columns: table => new
            //    {
            //        fem_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        fem_c_imagem = table.Column<byte[]>(nullable: true),
            //        fem_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        fem_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        fem_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        fem_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_fem_fotoEmpresa", x => x.fem_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_fot_foto",
            //    columns: table => new
            //    {
            //        fot_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        fot_c_imagem = table.Column<byte[]>(nullable: true),
            //        fot_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        fot_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        fot_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        fot_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_fot_foto", x => x.fot_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_ftd_fotoDependencia",
            //    columns: table => new
            //    {
            //        ftd_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ftd_c_imagem = table.Column<byte[]>(nullable: true),
            //        ftd_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ftd_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        ftd_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        ftd_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_ftd_fotoDependencia", x => x.ftd_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_lsm_logSMS",
            //    columns: table => new
            //    {
            //        lsm_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        lsm_mor_n_codigo = table.Column<int>(nullable: true),
            //        lsm_cli_n_codigo = table.Column<int>(nullable: true),
            //        lsm_d_data = table.Column<DateTime>(type: "datetime", nullable: true),
            //        lsm_c_nomeContato = table.Column<string>(unicode: false, nullable: true),
            //        lsm_c_numeroContato = table.Column<string>(unicode: false, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_lsm_logSMS", x => x.lsm_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_mav_marcaVeiculo",
            //    columns: table => new
            //    {
            //        mav_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        mav_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        mav_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        mav_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        mav_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        mav_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_mrv_marcaVeiculo", x => x.mav_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_mol_modulosLiberados",
            //    columns: table => new
            //    {
            //        mol_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        mol_b_controleDeAcesso = table.Column<bool>(nullable: false),
            //        mol_b_CFTV = table.Column<bool>(nullable: false),
            //        mol_b_MonitoriamentoPerimetral = table.Column<bool>(nullable: false),
            //        mol_b_OrdemServico = table.Column<bool>(nullable: false),
            //        mol_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        mol_b_connectSolutions = table.Column<bool>(nullable: false),
            //        mol_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        mol_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        mol_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        mol_b_connectSync = table.Column<bool>(nullable: false),
            //        mol_b_accessView = table.Column<bool>(nullable: false),
            //        mol_b_connectPRO = table.Column<bool>(nullable: false),
            //        mol_b_connectGaren = table.Column<bool>(nullable: false),
            //        mol_b_portariaVirtual = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_mod_modulo", x => x.mol_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_mos_moduloOrdemServicoLiberado",
            //    columns: table => new
            //    {
            //        mos_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        mos_b_abirOS = table.Column<bool>(nullable: false),
            //        mos_b_fecharOS = table.Column<bool>(nullable: false),
            //        mos_b_AcompanharOS = table.Column<bool>(nullable: false),
            //        mos_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        mos_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        mos_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        mos_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_mos_moduloOrdemServicoLiberado", x => x.mos_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_par_parametros",
            //    columns: table => new
            //    {
            //        par_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        par_c_descricao = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
            //        par_c_chave = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
            //        par_c_valor = table.Column<string>(unicode: false, nullable: true),
            //        par_c_titulo = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
            //        par_b_interno = table.Column<bool>(nullable: true),
            //        par_c_aba = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        par_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        par_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        par_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        par_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_par_parametros", x => x.par_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_pec_processoExclusaoCliente",
            //    columns: table => new
            //    {
            //        pec_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        pec_cli_n_codigo = table.Column<int>(nullable: true),
            //        pec_d_data = table.Column<DateTime>(type: "datetime", nullable: true),
            //        pec_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        pec_c_tipo = table.Column<string>(unicode: false, nullable: true),
            //        pec_c_observacao = table.Column<string>(unicode: false, nullable: true),
            //        pec_b_panico = table.Column<bool>(nullable: true),
            //        pec_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        pec_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        pec_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Tb_pec_processoExclusaoCliente", x => x.pec_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_per_perfil",
            //    columns: table => new
            //    {
            //        per_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        per_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        per_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        per_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        per_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        per_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_per_perfis", x => x.per_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_per_permissoes",
            //    columns: table => new
            //    {
            //        per_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        per_c_descricao = table.Column<string>(unicode: false, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_per_permissoes", x => x.per_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_rac_raca",
            //    columns: table => new
            //    {
            //        rac_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        rac_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        rac_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        rac_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        rac_c_tipo = table.Column<string>(unicode: false, nullable: true),
            //        rac_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        rac_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        rac_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        rac_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_rac_raca", x => x.rac_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_seb_serviceBroker",
            //    columns: table => new
            //    {
            //        seb_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        seb_cli_n_codigo = table.Column<int>(nullable: true),
            //        seb_c_usuarios = table.Column<string>(unicode: false, maxLength: 5000, nullable: true),
            //        seb_c_tipoUsuario = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
            //        seb_c_tabelaOrigem = table.Column<string>(unicode: false, maxLength: 300, nullable: true),
            //        seb_c_ramalorigem = table.Column<string>(unicode: false, maxLength: 300, nullable: true),
            //        seb_c_ramaldestino = table.Column<string>(unicode: false, maxLength: 300, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_seb_serviceBroker", x => x.seb_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_sin_sincronizacaoOffline",
            //    columns: table => new
            //    {
            //        sin_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        sin_d_data = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        sin_b_concluida = table.Column<bool>(nullable: true),
            //        SIN_CLI_N_CODIGO = table.Column<int>(nullable: true),
            //        sin_b_sincronizacaoRestauracao = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_sin_sincronizacaoOffline", x => x.sin_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_sol_solicitacaoAberturaRemota",
            //    columns: table => new
            //    {
            //        sol_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        sol_cli_n_codigo = table.Column<int>(nullable: true),
            //        sol_c_usuarioSolicitou = table.Column<string>(unicode: false, nullable: true),
            //        sol_d_data = table.Column<DateTime>(type: "datetime", nullable: true),
            //        sol_c_tipoUsuario = table.Column<string>(unicode: false, nullable: true),
            //        sol_usu_n_codigo = table.Column<int>(nullable: true),
            //        sol_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        sol_pta_n_codigo = table.Column<int>(nullable: true),
            //        sol_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        sol_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        sol_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_sol_solicitacaoAberturaRemota", x => x.sol_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_stm_statusMonitoramento",
            //    columns: table => new
            //    {
            //        stm_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        stm_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        stm_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        stm_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        stm_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        stm_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_stm_statusMonitoramento", x => x.stm_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_tcl_tipoCliente",
            //    columns: table => new
            //    {
            //        tcl_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        tcl_c_nome = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
            //        tcl_b_ativo = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
            //        tcl_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        tcl_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        tcl_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_tcl_tipoCliente", x => x.tcl_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_top_tipoPermissaoOperador",
            //    columns: table => new
            //    {
            //        top_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        top_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        top_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        top_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        top_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        top_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        top_c_chave = table.Column<string>(unicode: false, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_top_tipoPermissaoOperador", x => x.top_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_tpa_tipoAtendimento",
            //    columns: table => new
            //    {
            //        tpa_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        tpa_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        tpa_n_prioridade = table.Column<int>(nullable: true),
            //        tpa_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        tpa_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        tpa_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        tpa_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_tpa_tipoAtendimento", x => x.tpa_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_voi_voip",
            //    columns: table => new
            //    {
            //        voi_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        voi_c_json = table.Column<string>(unicode: false, nullable: true),
            //        voi_b_pendente = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
            //        voi_d_data = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        voi_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        voi_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        voi_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_voi_voip", x => x.voi_n_codigo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_cid_cidade",
            //    columns: table => new
            //    {
            //        cid_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        cid_n_ibge = table.Column<string>(unicode: false, nullable: true),
            //        cid_c_nome = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
            //        cid_c_estado = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
            //        cid_est_n_codigo = table.Column<int>(nullable: true),
            //        cid_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        cid_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cid_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_cid_cidade", x => x.cid_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_cid_cidade_tb_est_estado",
            //            column: x => x.cid_est_n_codigo,
            //            principalTable: "tb_est_estado",
            //            principalColumn: "est_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_eti_entidadeTipo",
            //    columns: table => new
            //    {
            //        eti_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        eti_tlc_n_codigo = table.Column<int>(nullable: false),
            //        eti_ent_n_codigo = table.Column<int>(nullable: false),
            //        eti_c_nome = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
            //        ent_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        ent_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        ent_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_eti_entidadeTipo", x => x.eti_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_eti_entidadeTipo_tb_ent_entidade",
            //            column: x => x.eti_ent_n_codigo,
            //            principalTable: "tb_ent_entidade",
            //            principalColumn: "ent_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_eti_entidadeTipo_tb_tcl_tipoCliente",
            //            column: x => x.eti_tlc_n_codigo,
            //            principalTable: "tb_tcl_tipoCliente",
            //            principalColumn: "tcl_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_emp_empresa",
            //    columns: table => new
            //    {
            //        emp_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        emp_c_razaoSocial = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_nomeFantasia = table.Column<string>(unicode: false, nullable: true),
            //        emp_d_contrato = table.Column<DateTime>(type: "datetime", nullable: true),
            //        emp_c_cnpj = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_ie = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_pessoaContato = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_email = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_email2 = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_foneComercial = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_foneComercial2 = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_celular = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_celular2 = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_rua = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_numero = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_complemento = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_bairro = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_cep = table.Column<string>(unicode: false, nullable: true),
            //        emp_cid_n_codigo = table.Column<int>(nullable: true),
            //        emp_est_n_codigo = table.Column<int>(nullable: true),
            //        emp_c_observacao = table.Column<string>(unicode: false, nullable: true),
            //        emp_mol_n_codigo = table.Column<int>(nullable: true),
            //        emp_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        emp_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        emp_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        emp_c_RangeRamais = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_ramais = table.Column<string>(unicode: false, nullable: true),
            //        emp_b_ativo = table.Column<bool>(nullable: true),
            //        emp_fem_n_codigo = table.Column<int>(nullable: true),
            //        emp_c_contatoNome1 = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_contatoEmail1 = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_contatoTelefone1 = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_contatoNome2 = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_contatoEmail2 = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_contatoTelefone2 = table.Column<string>(unicode: false, nullable: true),
            //        emp_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        emp_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        emp_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        emp_c_RangePortas = table.Column<string>(unicode: false, nullable: true),
            //        emp_b_tipoGaren = table.Column<bool>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_emp_empresa", x => x.emp_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_emp_empresa_tb_cid_cidade",
            //            column: x => x.emp_cid_n_codigo,
            //            principalTable: "tb_cid_cidade",
            //            principalColumn: "cid_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_emp_empresa_tb_est_estado",
            //            column: x => x.emp_est_n_codigo,
            //            principalTable: "tb_est_estado",
            //            principalColumn: "est_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_emp_empresa_tb_fem_fotoEmpresa",
            //            column: x => x.emp_fem_n_codigo,
            //            principalTable: "tb_fem_fotoEmpresa",
            //            principalColumn: "fem_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_emp_empresa_tb_mol_modulosLiberados",
            //            column: x => x.emp_mol_n_codigo,
            //            principalTable: "tb_mol_modulosLiberados",
            //            principalColumn: "mol_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_pro_proprietario",
            //    columns: table => new
            //    {
            //        pro_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        pro_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        pro_c_email = table.Column<string>(unicode: false, nullable: true),
            //        pro_c_observacao = table.Column<string>(unicode: false, nullable: true),
            //        pro_ace_n_codigo = table.Column<int>(nullable: true),
            //        pro_d_dataNascimento = table.Column<DateTime>(type: "datetime", nullable: true),
            //        pro_c_rg = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        pro_c_cpf = table.Column<string>(unicode: false, maxLength: 14, nullable: true),
            //        pro_c_telefone = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        pro_c_celular = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        pro_c_email2 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        pro_c_rua = table.Column<string>(unicode: false, nullable: true),
            //        pro_c_numero = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        pro_c_complemento = table.Column<string>(unicode: false, nullable: true),
            //        pro_c_bairro = table.Column<string>(unicode: false, nullable: true),
            //        pro_c_cep = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        pro_cid_n_codigo = table.Column<int>(nullable: true),
            //        pro_est_n_codigo = table.Column<int>(nullable: true),
            //        pro_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        pro_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        pro_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        pro_c_cargo = table.Column<string>(unicode: false, nullable: true),
            //        pro_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        pro_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        pro_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        pro_b_tipoGaren = table.Column<bool>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_pro_proprietario", x => x.pro_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_pro_proprietario_tb_ace_acesso",
            //            column: x => x.pro_ace_n_codigo,
            //            principalTable: "tb_ace_acesso",
            //            principalColumn: "ace_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_pro_proprietario_tb_cid_cidade",
            //            column: x => x.pro_cid_n_codigo,
            //            principalTable: "tb_cid_cidade",
            //            principalColumn: "cid_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_pro_proprietario_tb_est_estado",
            //            column: x => x.pro_est_n_codigo,
            //            principalTable: "tb_est_estado",
            //            principalColumn: "est_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_avi_aviso",
            //    columns: table => new
            //    {
            //        avi_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        avi_c_titulo = table.Column<string>(unicode: false, nullable: true),
            //        avi_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        avi_d_inicio = table.Column<DateTime>(type: "date", nullable: true),
            //        avi_d_fim = table.Column<DateTime>(type: "date", nullable: true),
            //        avi_ace_n_codigo = table.Column<int>(nullable: true),
            //        avi_emp_n_codigo = table.Column<int>(nullable: true),
            //        avi_ope_c_enviarPara = table.Column<string>(unicode: false, nullable: true),
            //        avi_c_status = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        avi_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        avi_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        avi_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        avi_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        avi_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        avi_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_avi_aviso", x => x.avi_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_avi_aviso_tb_ace_acesso",
            //            column: x => x.avi_ace_n_codigo,
            //            principalTable: "tb_ace_acesso",
            //            principalColumn: "ace_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_avi_aviso_tb_emp_empresa",
            //            column: x => x.avi_emp_n_codigo,
            //            principalTable: "tb_emp_empresa",
            //            principalColumn: "emp_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_ope_operador",
            //    columns: table => new
            //    {
            //        ope_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ope_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        ope_d_dataNascimento = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ope_c_rg = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        ope_c_cpf = table.Column<string>(unicode: false, maxLength: 14, nullable: true),
            //        ope_c_telefone = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        ope_c_celular = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        ope_c_email = table.Column<string>(unicode: false, nullable: true),
            //        ope_c_email2 = table.Column<string>(unicode: false, nullable: true),
            //        ope_c_rua = table.Column<string>(unicode: false, nullable: true),
            //        ope_c_numero = table.Column<string>(unicode: false, nullable: true),
            //        ope_c_complemento = table.Column<string>(unicode: false, nullable: true),
            //        ope_c_bairro = table.Column<string>(unicode: false, nullable: true),
            //        ope_c_cep = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        ope_cid_n_codigo = table.Column<int>(nullable: true),
            //        ope_est_n_codigo = table.Column<int>(nullable: true),
            //        ope_c_observacao = table.Column<string>(unicode: false, nullable: true),
            //        ope_ace_n_codigo = table.Column<int>(nullable: true),
            //        ope_emp_n_codigo = table.Column<int>(nullable: true),
            //        ope_b_ativoInativo = table.Column<bool>(nullable: true),
            //        ope_mol_n_codigo = table.Column<int>(nullable: true),
            //        ope_cli_n_atendimento = table.Column<int>(nullable: true),
            //        ope_gpp_n_codigo = table.Column<int>(nullable: true),
            //        ope_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        ope_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        ope_b_todosClientes = table.Column<bool>(nullable: true),
            //        ope_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ope_c_cargo = table.Column<string>(unicode: false, nullable: true),
            //        ope_d_ultimoContato = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ope_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        ope_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        ope_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        ope_b_solicitaRamal = table.Column<bool>(nullable: true),
            //        ope_b_admIconnect = table.Column<bool>(nullable: true),
            //        ope_emp_n_codigo_ramal = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_ope_operador", x => x.ope_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_ope_operador_tb_ace_acesso",
            //            column: x => x.ope_ace_n_codigo,
            //            principalTable: "tb_ace_acesso",
            //            principalColumn: "ace_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_ope_operador_tb_cid_cidade",
            //            column: x => x.ope_cid_n_codigo,
            //            principalTable: "tb_cid_cidade",
            //            principalColumn: "cid_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_ope_operador_tb_emp_empresa",
            //            column: x => x.ope_emp_n_codigo,
            //            principalTable: "tb_emp_empresa",
            //            principalColumn: "emp_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_ope_operador_tb_est_estado",
            //            column: x => x.ope_est_n_codigo,
            //            principalTable: "tb_est_estado",
            //            principalColumn: "est_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_ope_operador_tb_mol_modulosLiberados",
            //            column: x => x.ope_mol_n_codigo,
            //            principalTable: "tb_mol_modulosLiberados",
            //            principalColumn: "mol_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_par_parametrosEmpresa",
            //    columns: table => new
            //    {
            //        par_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        par_c_descricao = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
            //        par_c_chave = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
            //        par_c_valor = table.Column<string>(unicode: false, nullable: true),
            //        par_c_titulo = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
            //        par_b_interno = table.Column<bool>(nullable: true),
            //        par_c_aba = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        par_emp_n_codigo = table.Column<int>(nullable: true),
            //        par_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        par_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        par_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        par_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_par_parametrosEmpresaz", x => x.par_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_par_parametrosEmpresa_tb_emp_empresa",
            //            column: x => x.par_emp_n_codigo,
            //            principalTable: "tb_emp_empresa",
            //            principalColumn: "emp_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_poa_portaAlarme",
            //    columns: table => new
            //    {
            //        poa_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        poa_c_porta = table.Column<string>(unicode: false, nullable: true),
            //        poa_emp_n_codigo = table.Column<int>(nullable: true),
            //        poa_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        poa_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        poa_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_par_porta", x => x.poa_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_poa_portaAlarme_tb_emp_empresa",
            //            column: x => x.poa_emp_n_codigo,
            //            principalTable: "tb_emp_empresa",
            //            principalColumn: "emp_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_ate_atendimento",
            //    columns: table => new
            //    {
            //        ate_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ate_cli_n_codigo = table.Column<int>(nullable: true),
            //        ate_tpa_n_codigo = table.Column<int>(nullable: true),
            //        ate_c_status = table.Column<string>(unicode: false, nullable: true),
            //        ate_ope_n_preferencial = table.Column<int>(nullable: true),
            //        ate_d_data = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ate_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        ate_d_dataFinalizacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ate_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ate_c_identificacaoVOIP = table.Column<string>(unicode: false, nullable: true),
            //        ate_b_voipAbandonada = table.Column<bool>(nullable: true),
            //        ate_c_from = table.Column<string>(unicode: false, nullable: true),
            //        ate_c_ramalAtendeu = table.Column<string>(unicode: false, nullable: true),
            //        ate_b_LimparEvento = table.Column<bool>(nullable: true),
            //        ate_pec_n_codigo = table.Column<int>(nullable: true),
            //        ate_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        ate_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        ate_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_ate_atendimento", x => x.ate_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_ate_atendimento_tb_ope_operador",
            //            column: x => x.ate_ope_n_preferencial,
            //            principalTable: "tb_ope_operador",
            //            principalColumn: "ope_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_ate_atendimento_tb_pec_processoExclusaoCliente",
            //            column: x => x.ate_pec_n_codigo,
            //            principalTable: "tb_pec_processoExclusaoCliente",
            //            principalColumn: "pec_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_ate_atendimento_tb_tpa_tipoAtendimento",
            //            column: x => x.ate_tpa_n_codigo,
            //            principalTable: "tb_tpa_tipoAtendimento",
            //            principalColumn: "tpa_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_not_notificacao",
            //    columns: table => new
            //    {
            //        not_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        not_ope_n_codigo = table.Column<int>(nullable: true),
            //        not_avi_n_codigo = table.Column<int>(nullable: true),
            //        not_b_lido = table.Column<bool>(nullable: true),
            //        not_emp_n_codigo = table.Column<int>(nullable: true),
            //        not_avi_n_codigoEmpresa = table.Column<int>(nullable: true),
            //        not_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        not_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        not_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        not_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_not_notificacao", x => x.not_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_not_notificacao_tb_avi_aviso",
            //            column: x => x.not_avi_n_codigo,
            //            principalTable: "tb_avi_aviso",
            //            principalColumn: "avi_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_not_notificacao_tb_avi_avisoEmpresa",
            //            column: x => x.not_avi_n_codigoEmpresa,
            //            principalTable: "tb_avi_avisoEmpresa",
            //            principalColumn: "avi_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_not_notificacao_tb_ope_operador",
            //            column: x => x.not_ope_n_codigo,
            //            principalTable: "tb_ope_operador",
            //            principalColumn: "ope_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_rop_ramalOperador",
            //    columns: table => new
            //    {
            //        rop_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        rop_d_data = table.Column<DateTime>(type: "datetime", nullable: true),
            //        rop_c_ramal = table.Column<string>(unicode: false, nullable: true),
            //        rop_ope_n_codigo = table.Column<int>(nullable: true),
            //        rop_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        rop_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        rop_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_rop_ramalOperador", x => x.rop_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_rop_ramalOperador_tb_ope_operador",
            //            column: x => x.rop_ope_n_codigo,
            //            principalTable: "tb_ope_operador",
            //            principalColumn: "ope_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_avi_avisoMorador",
            //    columns: table => new
            //    {
            //        avm_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        avm_cav_n_codigo = table.Column<int>(nullable: true),
            //        avm_b_lidoNaoLido = table.Column<bool>(nullable: true),
            //        avm_mor_n_codigo = table.Column<int>(nullable: true),
            //        avm_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        avm_ace_n_codigo = table.Column<int>(nullable: true),
            //        avm_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        avm_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        avm_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        avm_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        avi_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        avi_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        avi_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_avm_n_codigo", x => x.avm_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_avi_avisoMorador_tb_ace_acesso",
            //            column: x => x.avm_ace_n_codigo,
            //            principalTable: "tb_ace_acesso",
            //            principalColumn: "ace_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_avi_avisoMorador_tb_cav_categorizacaoAviso",
            //            column: x => x.avm_cav_n_codigo,
            //            principalTable: "tb_cav_categorizacaoAviso",
            //            principalColumn: "cav_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_zec_zeladorCliente",
            //    columns: table => new
            //    {
            //        zec_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        zec_cli_n_codigo = table.Column<int>(nullable: true),
            //        zec_c_perfil = table.Column<string>(unicode: false, nullable: true),
            //        zec_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        zec_c_rg = table.Column<string>(unicode: false, nullable: true),
            //        zec_c_telefone = table.Column<string>(unicode: false, nullable: true),
            //        zec_mos_n_codigo = table.Column<int>(nullable: true),
            //        zec_mol_n_codigo = table.Column<int>(nullable: true),
            //        zec_ace_n_codigo = table.Column<int>(nullable: true),
            //        zec_c_autorizacao = table.Column<string>(unicode: false, nullable: true),
            //        zec_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        zec_b_notificacao = table.Column<bool>(nullable: true),
            //        zec_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        zec_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        zec_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        zec_mor_n_codigo = table.Column<int>(nullable: true),
            //        zec_c_email = table.Column<string>(unicode: false, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_zec_zeladorCliente", x => x.zec_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_zec_zeladorCliente_tb_ace_acesso",
            //            column: x => x.zec_ace_n_codigo,
            //            principalTable: "tb_ace_acesso",
            //            principalColumn: "ace_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_zec_zeladorCliente_tb_mol_modulosLiberados",
            //            column: x => x.zec_mol_n_codigo,
            //            principalTable: "tb_mol_modulosLiberados",
            //            principalColumn: "mol_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_zec_zeladorCliente_tb_mos_moduloOrdemServicoLiberado",
            //            column: x => x.zec_mos_n_codigo,
            //            principalTable: "tb_mos_moduloOrdemServicoLiberado",
            //            principalColumn: "mos_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_dpn_dependencias",
            //    columns: table => new
            //    {
            //        dpn_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        dpn_cli_n_codigo = table.Column<int>(nullable: true),
            //        dpn_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        dpn_c_bloco = table.Column<string>(unicode: false, nullable: true),
            //        dpn_c_apto = table.Column<string>(unicode: false, nullable: true),
            //        dpn_n_limitePessoas = table.Column<int>(nullable: true),
            //        dpn_c_termosUso = table.Column<string>(unicode: false, nullable: true),
            //        dpn_b_permitirReservarPeriodo = table.Column<bool>(nullable: true),
            //        dpn_c_periodoManha = table.Column<string>(unicode: false, nullable: true),
            //        dpn_c_periodoTarde = table.Column<string>(unicode: false, nullable: true),
            //        dpn_c_periodoNoite = table.Column<string>(unicode: false, nullable: true),
            //        dpn_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        dpn_ard_n_codigo = table.Column<int>(nullable: true),
            //        dpn_c_tipoTermoUso = table.Column<string>(unicode: false, nullable: true),
            //        dpn_ftd_n_codigo = table.Column<int>(nullable: true),
            //        dpn_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        dpn_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        dpn_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        dpn_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        dpn_b_autoLiberar = table.Column<bool>(nullable: true),
            //        dpn_b_ativoInativo = table.Column<bool>(nullable: true, defaultValueSql: "((1))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_dpn_dependencia", x => x.dpn_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_dpn_dependencias_tb_ard_arquivoDependencias",
            //            column: x => x.dpn_ard_n_codigo,
            //            principalTable: "tb_ard_arquivoDependencias",
            //            principalColumn: "ard_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_dpn_dependencias_tb_ftd_fotoDependencia",
            //            column: x => x.dpn_ftd_n_codigo,
            //            principalTable: "tb_ftd_fotoDependencia",
            //            principalColumn: "ftd_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_cli_cliente",
            //    columns: table => new
            //    {
            //        cli_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        cli_c_razaoSocial = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_nomeFantasia = table.Column<string>(unicode: false, nullable: true),
            //        cli_d_inicioContrato = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cli_c_cnpj = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_ie = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_pessoaContato = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_email = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_email2 = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_telefoneComercial = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_telefoneComercial2 = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_celular = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_celular2 = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_rua = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_complemento = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_bairro = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_cep = table.Column<string>(unicode: false, nullable: true),
            //        cli_cid_n_codigo = table.Column<int>(nullable: true),
            //        cli_est_n_codigo = table.Column<int>(nullable: true),
            //        cli_emp_n_codigo = table.Column<int>(nullable: true),
            //        cli_c_observacao = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_fantasiaAdministradora = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_pessoaContatoAdministradora = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_emailAdministradora = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_telefoneAdministradora = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_celularAdministradora = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_numero = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        cli_c_tipoRede = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        cli_c_ip = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        cli_c_dominio = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        cli_c_porta = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        cli_c_centralVoip = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        cli_mol_n_codigo = table.Column<int>(nullable: true),
            //        cli_c_senha = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_contraSenha = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_chave = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
            //        cli_c_zona = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_ramal = table.Column<string>(unicode: false, nullable: true),
            //        cli_n_valorLicenca = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        cli_d_dataVencimentoLicenca = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cli_b_licencaAtiva = table.Column<bool>(nullable: true),
            //        cli_b_controleAcesso = table.Column<bool>(nullable: true),
            //        cli_n_diaVencimento = table.Column<int>(nullable: true),
            //        cli_d_inicioLicenca = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cli_b_ativo = table.Column<bool>(nullable: true),
            //        cli_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        cli_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        cli_can_n_panoramica = table.Column<int>(nullable: true),
            //        cli_n_horasExpiracaoTokenDelivery = table.Column<int>(nullable: true),
            //        cli_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cli_b_disparoSMS = table.Column<bool>(nullable: true),
            //        cli_c_ramais = table.Column<string>(unicode: false, nullable: true),
            //        cli_n_tempoGravacaoGoogleDrive = table.Column<int>(nullable: true),
            //        cli_c_codigoReferencia = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
            //        cli_can_n_access = table.Column<int>(nullable: true),
            //        cli_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        cli_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cli_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cli_lay_n_codigo = table.Column<int>(nullable: true),
            //        cli_c_codInstalacaoOffline = table.Column<string>(unicode: false, maxLength: 14, nullable: true),
            //        cli_n_numDiasExpiracao = table.Column<int>(nullable: true),
            //        cli_c_serial = table.Column<string>(unicode: false, maxLength: 23, nullable: true),
            //        cli_d_dataCriacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cli_d_dataExpiracao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cli_c_codInstalacaoRenovacao = table.Column<string>(unicode: false, maxLength: 14, nullable: true),
            //        cli_c_dominioSIP = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_senhaSIP = table.Column<string>(unicode: false, nullable: true),
            //        cli_c_portaSIP = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
            //        cli_d_dataUltimaSincronizacaoCloud = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cli_c_range_periodo_aplicadorTicket = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        cli_d_ultimoContatoSolution = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cli_tcl_n_codigo = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_cli_cliente", x => x.cli_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_cli_cliente_tb_cid_cidade",
            //            column: x => x.cli_cid_n_codigo,
            //            principalTable: "tb_cid_cidade",
            //            principalColumn: "cid_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_cli_cliente_tb_emp_empresa",
            //            column: x => x.cli_emp_n_codigo,
            //            principalTable: "tb_emp_empresa",
            //            principalColumn: "emp_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_cli_cliente_tb_est_estado",
            //            column: x => x.cli_est_n_codigo,
            //            principalTable: "tb_est_estado",
            //            principalColumn: "est_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_cli_cliente_tb_mol_modulosLiberados",
            //            column: x => x.cli_mol_n_codigo,
            //            principalTable: "tb_mol_modulosLiberados",
            //            principalColumn: "mol_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_cli_cliente_tb_tcl_tipoCliente",
            //            column: x => x.cli_tcl_n_codigo,
            //            principalTable: "tb_tcl_tipoCliente",
            //            principalColumn: "tcl_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_cla_cabecalhoLayout",
            //    columns: table => new
            //    {
            //        cla_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        cla_cli_n_codigo = table.Column<int>(nullable: true),
            //        cla_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        cla_c_exibirem = table.Column<string>(unicode: false, nullable: true),
            //        cla_usu_n_codigo = table.Column<int>(nullable: true),
            //        cla_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        cla_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cla_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_cla_cabecalhoLayout", x => x.cla_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_cla_cabecalhoLayout_tb_cli_cliente",
            //            column: x => x.cla_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_con_controladora",
            //    columns: table => new
            //    {
            //        con_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        con_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        con_c_modelo = table.Column<string>(unicode: false, nullable: true),
            //        con_c_ip = table.Column<string>(unicode: false, nullable: true),
            //        con_c_porta = table.Column<string>(unicode: false, nullable: true),
            //        con_c_dominioDDNS = table.Column<string>(unicode: false, nullable: true),
            //        con_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        con_c_senha = table.Column<string>(unicode: false, nullable: true),
            //        con_cli_n_codigo = table.Column<int>(nullable: true),
            //        con_d_ultimoContato = table.Column<DateTime>(type: "datetime", nullable: true),
            //        con_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        con_c_usuarioAlteracao = table.Column<string>(unicode: false, nullable: true),
            //        con_n_h = table.Column<int>(nullable: true),
            //        con_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        con_b_online = table.Column<bool>(nullable: true),
            //        con_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        con_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        con_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        con_c_perfis = table.Column<string>(unicode: false, maxLength: 11, nullable: false, defaultValueSql: "('MOR,VIS,PSE')"),
            //        con_b_ativo = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
            //        con_b_gerouAtendimento = table.Column<bool>(nullable: false),
            //        con_n_quantidadePortas = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_con_controladora", x => x.con_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_con_controladora_tb_cli_cliente",
            //            column: x => x.con_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_con_monitoramentoControleAcesso",
            //    columns: table => new
            //    {
            //        con_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        con_d_evento = table.Column<DateTime>(type: "datetime", nullable: true),
            //        con_c_pin = table.Column<string>(unicode: false, nullable: true),
            //        con_cli_n_codigo = table.Column<int>(nullable: true),
            //        con_c_cardNumber = table.Column<string>(unicode: false, nullable: true),
            //        con_c_doorId = table.Column<string>(unicode: false, nullable: true),
            //        con_c_tipoPessoa = table.Column<string>(unicode: false, nullable: true),
            //        con_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        con_c_pontoAcesso = table.Column<string>(unicode: false, nullable: true),
            //        con_c_acao = table.Column<string>(unicode: false, nullable: true),
            //        con_c_status = table.Column<string>(unicode: false, nullable: true),
            //        cin_c_tipoEventoMotivo = table.Column<string>(unicode: false, nullable: true),
            //        con_usu_n_codigo = table.Column<int>(nullable: true),
            //        con_fot_n_codigo = table.Column<int>(nullable: true),
            //        con_b_inOut = table.Column<bool>(nullable: true),
            //        con_b_panico = table.Column<bool>(nullable: true),
            //        con_ate_n_codigo = table.Column<int>(nullable: true),
            //        con_b_precisaAtendimento = table.Column<bool>(nullable: true),
            //        con_n_h = table.Column<int>(nullable: true),
            //        con_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        con_b_LimparEvento = table.Column<bool>(nullable: true),
            //        con_b_panicoTratado = table.Column<bool>(nullable: true),
            //        con_d_dataTratamentoPanico = table.Column<DateTime>(type: "datetime", nullable: true),
            //        con_c_obsTratamentoPanico = table.Column<string>(unicode: false, nullable: true),
            //        con_c_UsuarioTratamentoPanico = table.Column<string>(unicode: false, nullable: true),
            //        con_b_tipoPanico = table.Column<bool>(nullable: true),
            //        con_pec_n_codigo = table.Column<int>(nullable: true),
            //        con_b_pendenteVideo = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
            //        con_c_destino = table.Column<string>(unicode: false, nullable: true, defaultValueSql: "('')"),
            //        con_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        con_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        con_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_con_controleAcesso", x => x.con_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_con_monitoramentoControleAcesso_tb_cli_cliente",
            //            column: x => x.con_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_con_monitoramentoControleAcesso_tb_pec_processoExclusaoCliente",
            //            column: x => x.con_pec_n_codigo,
            //            principalTable: "tb_pec_processoExclusaoCliente",
            //            principalColumn: "pec_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_ddv_dispositivoDVRCliente",
            //    columns: table => new
            //    {
            //        ddv_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ddv_fab_n_codigo = table.Column<int>(nullable: true),
            //        ddv_mod_n_codigo = table.Column<int>(nullable: true),
            //        ddv_n_canais = table.Column<int>(nullable: true),
            //        ddv_c_ip = table.Column<string>(unicode: false, nullable: true),
            //        ddv_c_porta = table.Column<string>(unicode: false, nullable: true),
            //        ddv_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        ddv_c_senha = table.Column<string>(unicode: false, nullable: true),
            //        ddv_cli_n_codigo = table.Column<int>(nullable: true),
            //        ddv_c_portaServico = table.Column<string>(unicode: false, nullable: true),
            //        ddv_c_portaHTTP = table.Column<string>(unicode: false, nullable: true),
            //        ddv_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ddv_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        ddv_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        ddv_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        ddv_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_ddv_dispositivoDVRCliente", x => x.ddv_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_ddv_dispositivoDVRCliente_tb_cli_cliente",
            //            column: x => x.ddv_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_eno_envioNotificacao",
            //    columns: table => new
            //    {
            //        eno_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        eno_c_titulo = table.Column<string>(unicode: false, nullable: true),
            //        eno_c_mensagem = table.Column<string>(unicode: false, nullable: true),
            //        eno_cli_n_codigo = table.Column<int>(nullable: true),
            //        eno_c_GruposFamiliares = table.Column<string>(unicode: false, nullable: true),
            //        eno_d_inicio = table.Column<DateTime>(type: "datetime", nullable: true),
            //        eno_d_fim = table.Column<DateTime>(type: "datetime", nullable: true),
            //        eno_c_MoradoresGruposFamiliares = table.Column<string>(unicode: false, nullable: true),
            //        eno_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        eno_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        eno_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_eno_envioNotificacao", x => x.eno_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_eno_envioNotificacao_tb_cli_cliente",
            //            column: x => x.eno_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_eqc_equipamentoCliente",
            //    columns: table => new
            //    {
            //        eqc_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        eqc_cli_n_codigo = table.Column<int>(nullable: true),
            //        eqc_n_modelo = table.Column<int>(nullable: true),
            //        eqc_c_nomePonto = table.Column<string>(unicode: false, nullable: true),
            //        eqc_c_conta = table.Column<string>(unicode: false, nullable: true),
            //        eqc_c_ip = table.Column<string>(unicode: false, nullable: true),
            //        eqc_c_porta = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
            //        eqc_usu_n_codigo = table.Column<int>(nullable: true),
            //        eqc_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        eqc_d_ultimoContato = table.Column<DateTime>(type: "datetime", nullable: true),
            //        eqc_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        eqc_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        eqc_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        eqc_b_apontamentoLocal = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
            //        eqc_c_senhaRemota = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
            //        eqc_c_versao = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_eqc_equipamentoCliente", x => x.eqc_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_eqc_equipamentoCliente_tb_cli_cliente",
            //            column: x => x.eqc_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_eve_evento",
            //    columns: table => new
            //    {
            //        eve_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        eve_c_evento = table.Column<string>(unicode: false, nullable: true),
            //        eve_c_conta = table.Column<string>(unicode: false, nullable: true),
            //        eve_c_particao = table.Column<string>(unicode: false, nullable: true),
            //        eve_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        eve_c_zona = table.Column<string>(unicode: false, nullable: true),
            //        eve_c_ip = table.Column<string>(unicode: false, nullable: true),
            //        eve_b_lido = table.Column<bool>(nullable: true),
            //        eve_cli_n_codigo = table.Column<int>(nullable: true),
            //        eve_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        eve_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        eve_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_eve_evento_1", x => x.eve_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_eve_evento_tb_cli_cliente",
            //            column: x => x.eve_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_fer_feriado",
            //    columns: table => new
            //    {
            //        fer_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        fer_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        fer_c_recorrente = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        fer_d_data = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
            //        fer_n_codigoCliente = table.Column<int>(nullable: false),
            //        fer_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        fer_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        fer_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        fer_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_feriado", x => x.fer_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_cliente",
            //            column: x => x.fer_n_codigoCliente,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_gpp_grupoPermissaoOperador",
            //    columns: table => new
            //    {
            //        gpp_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        gpp_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        gpp_emp_n_codigo = table.Column<int>(nullable: true),
            //        gpp_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        gpp_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        gpp_cli_n_codigo = table.Column<int>(nullable: true),
            //        gpp_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        gpp_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        gpp_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        gpp_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        gpp_mol_n_codigo = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_gpp_grupoPermissaoOperador", x => x.gpp_n_codigo);
            //        table.ForeignKey(
            //            name: "fk_tb_gpp_grupoPermissaoOperador",
            //            column: x => x.gpp_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_gpp_grupoPermissaoOperador_tb_emp_empresa",
            //            column: x => x.gpp_emp_n_codigo,
            //            principalTable: "tb_emp_empresa",
            //            principalColumn: "emp_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_gpp_grupoPermissaoOperador_tb_mol_modulosLiberados",
            //            column: x => x.gpp_mol_n_codigo,
            //            principalTable: "tb_mol_modulosLiberados",
            //            principalColumn: "mol_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_grf_grupoFamiliar",
            //    columns: table => new
            //    {
            //        grf_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        grf_c_status = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        grf_c_tipo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        grf_c_nomeResponsavel = table.Column<string>(unicode: false, nullable: true),
            //        grf_c_rg = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        grf_c_cpf = table.Column<string>(unicode: false, maxLength: 14, nullable: true),
            //        grf_c_telefone = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        grf_c_email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        grf_c_numeroVagas = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        grf_c_BlocoQuadra = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        grf_c_LoteApto = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        grf_c_observacao = table.Column<string>(unicode: false, nullable: true),
            //        grf_c_celular = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        grf_fot_n_codigo = table.Column<int>(nullable: true),
            //        grf_cli_n_codigo = table.Column<int>(nullable: true),
            //        grf_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        grf_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        grf_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        grf_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        grf_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        grf_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        grf_c_senhaApp = table.Column<string>(unicode: false, nullable: true),
            //        grf_n_ramal = table.Column<int>(nullable: true),
            //        grf_c_autorizacaoPRO = table.Column<string>(unicode: false, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_grf_grupoFamiliar", x => x.grf_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_grf_grupoFamiliar_tb_cli_cliente",
            //            column: x => x.grf_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_grf_grupoFamiliar_tb_fot_foto",
            //            column: x => x.grf_fot_n_codigo,
            //            principalTable: "tb_fot_foto",
            //            principalColumn: "fot_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_hor_horario",
            //    columns: table => new
            //    {
            //        hor_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        hor_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        hor_d_termina = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        hor_c_diaSemana = table.Column<string>(unicode: false, nullable: true),
            //        hor_d_inicia = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        hor_cli_n_codigo = table.Column<int>(nullable: true),
            //        hor_b_referenciaApp = table.Column<bool>(nullable: true),
            //        hor_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        hor_n_codigoLinear = table.Column<int>(nullable: true),
            //        hor_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        hor_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        hor_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_hor_horario", x => x.hor_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_hor_horario_tb_cli_cliente",
            //            column: x => x.hor_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_lbr_logBackupRestauracao",
            //    columns: table => new
            //    {
            //        lbr_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        lbr_cli_n_codigo = table.Column<int>(nullable: false),
            //        lbr_b_status = table.Column<bool>(nullable: false),
            //        lbr_d_inicio = table.Column<DateTime>(type: "datetime", nullable: false),
            //        lbr_d_fim = table.Column<DateTime>(type: "datetime", nullable: false),
            //        lbr_c_mensagem = table.Column<string>(unicode: false, nullable: false),
            //        lbr_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        lbr_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        lbr_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_lbr_logBackupRestauracao", x => x.lbr_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_lbr_logBackupRestauracao_tb_cli_cliente",
            //            column: x => x.lbr_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_lcc_localidadeCliente",
            //    columns: table => new
            //    {
            //        lcc_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        lcc_c_tipoLocalidade = table.Column<string>(unicode: false, nullable: true),
            //        lcc_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        lcc_cli_n_codigo = table.Column<int>(nullable: true),
            //        lcc_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        lcc_usu_n_codigo = table.Column<int>(nullable: true),
            //        lcc_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        lcc_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        lcc_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_lcc_localidadeCliente", x => x.lcc_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_lcc_localidadeCliente_tb_cli_cliente",
            //            column: x => x.lcc_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_moc_motivoOcorrenciaCliente",
            //    columns: table => new
            //    {
            //        moc_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        moc_c_descricao = table.Column<string>(unicode: false, nullable: false),
            //        moc_cli_n_codigo = table.Column<int>(nullable: true),
            //        moc_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        moc_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        moc_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        moc_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_moc_motivoOcorrenciaCliente", x => x.moc_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_moc_motivoOcorrenciaCliente_tb_cli_cliente",
            //            column: x => x.moc_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_mpc_mapeamentoPontoAcesso",
            //    columns: table => new
            //    {
            //        mpc_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        mpc_cli_n_codigo = table.Column<int>(nullable: true),
            //        mpc_pta_n_codigo = table.Column<int>(nullable: true),
            //        mpc_can_n_codigo = table.Column<int>(nullable: true),
            //        mpc_c_tempoGravacao = table.Column<string>(unicode: false, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_mpc_mapeamentoPontoAcesso", x => x.mpc_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_mpc_mapeamentoPontoAcesso_tb_cli_cliente",
            //            column: x => x.mpc_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_opo_operadorOnline",
            //    columns: table => new
            //    {
            //        opo_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        opo_cli_n_codigo = table.Column<int>(nullable: true),
            //        opo_opr_n_codigo = table.Column<int>(nullable: true),
            //        opo_b_online = table.Column<bool>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_opo_operadorOnline", x => x.opo_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_opo_operadorOnline_tb_cli_cliente",
            //            column: x => x.opo_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_pec_permissaoCliente",
            //    columns: table => new
            //    {
            //        pec_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        pec_cli_n_codigo = table.Column<int>(nullable: true),
            //        pec_ope_n_codigo = table.Column<int>(nullable: true),
            //        pec_b_editaInformacoes = table.Column<bool>(nullable: true),
            //        pec_usu_n_codigo = table.Column<int>(nullable: true),
            //        pec_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        pec_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        pec_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        pec_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_pec_permissaoCliente", x => x.pec_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_pec_permissaoCliente_tb_cli_cliente",
            //            column: x => x.pec_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_pec_permissaoCliente_tb_ope_operador",
            //            column: x => x.pec_ope_n_codigo,
            //            principalTable: "tb_ope_operador",
            //            principalColumn: "ope_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_por_portasStream",
            //    columns: table => new
            //    {
            //        por_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        por_n_porta = table.Column<int>(nullable: true),
            //        por_cli_n_codigo = table.Column<int>(nullable: true),
            //        pro_n_process = table.Column<int>(nullable: true),
            //        por_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        por_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        por_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_por_portasStream", x => x.por_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_por_portasStream_tb_por_portasStream",
            //            column: x => x.por_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_rel_responsavelLocacaoSaloes",
            //    columns: table => new
            //    {
            //        rel_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        rel_c_tipo = table.Column<string>(unicode: false, nullable: true),
            //        rel_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        rel_c_sobreNome = table.Column<string>(unicode: false, nullable: true),
            //        rel_c_rg = table.Column<string>(unicode: false, nullable: true),
            //        rel_c_login = table.Column<string>(unicode: false, nullable: true),
            //        rel_c_senha = table.Column<string>(unicode: false, nullable: true),
            //        rel_c_telefone = table.Column<string>(unicode: false, nullable: true),
            //        rel_c_permissao = table.Column<string>(unicode: false, nullable: true),
            //        rel_usu_n_responsavel = table.Column<int>(nullable: true),
            //        rel_cli_n_codigo = table.Column<int>(nullable: true),
            //        rel_c_origem = table.Column<string>(unicode: false, nullable: true),
            //        rel_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        rel_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        rel_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        rel_c_email = table.Column<string>(unicode: false, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_rel_responsavelLocacaoSaloes", x => x.rel_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_rel_responsavelLocacaoSaloes_tb_cli_cliente",
            //            column: x => x.rel_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_sin_sincronizacaoPlacas",
            //    columns: table => new
            //    {
            //        sin_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        sin_cli_n_codigo = table.Column<int>(nullable: true),
            //        sin_c_status = table.Column<string>(unicode: false, nullable: true),
            //        sin_d_dataSolicitacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        sin_d_dataInicio = table.Column<DateTime>(type: "datetime", nullable: true),
            //        sin_d_dataFim = table.Column<DateTime>(type: "datetime", nullable: true),
            //        sin_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        sin_c_erro = table.Column<string>(unicode: false, nullable: true),
            //        sin_b_interno = table.Column<bool>(nullable: true),
            //        sin_ace_n_codigo = table.Column<int>(nullable: true),
            //        sin_c_controladoras = table.Column<string>(unicode: false, nullable: true),
            //        sin_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        sin_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        sin_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_sin_sincronizacaoPlacas", x => x.sin_n_codigo);
            //        table.ForeignKey(
            //            name: "fk_tb_sin_sincronizacaoPlacas_tb_cli_cliente",
            //            column: x => x.sin_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_vic_vigilanteCliente",
            //    columns: table => new
            //    {
            //        vic_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        vic_cli_n_codigo = table.Column<int>(nullable: true),
            //        vic_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        vic_c_celular = table.Column<string>(unicode: false, nullable: true),
            //        vic_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        vic_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        vic_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        vic_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_vic_vigilanteCliente", x => x.vic_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_vic_vigilanteCliente_tb_cli_cliente",
            //            column: x => x.vic_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_plc_pontoLayoutCliente",
            //    columns: table => new
            //    {
            //        plc_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        plc_cli_n_codigo = table.Column<int>(nullable: true),
            //        plc_cla_n_codigo = table.Column<int>(nullable: true),
            //        plc_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        plc_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        plc_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_plc_pontoLayoutCliente", x => x.plc_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_plc_pontoLayoutCliente_tb_cla_cabecalhoLayout",
            //            column: x => x.plc_cla_n_codigo,
            //            principalTable: "tb_cla_cabecalhoLayout",
            //            principalColumn: "cla_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_plc_pontoLayoutCliente_tb_cli_cliente",
            //            column: x => x.plc_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_bio_biometria",
            //    columns: table => new
            //    {
            //        bio_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        bio_c_status = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
            //        bio_cli_n_codigo = table.Column<int>(nullable: false),
            //        bio_c_template = table.Column<string>(unicode: false, nullable: true),
            //        bio_c_imagem = table.Column<byte[]>(type: "image", nullable: true),
            //        bio_d_dataSolicitacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        bio_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        bio_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        bio_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        bio_con_n_codigo = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_bio_biometria", x => x.bio_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_bio_biometria_tb_cli_cliente",
            //            column: x => x.bio_con_n_codigo,
            //            principalTable: "tb_con_controladora",
            //            principalColumn: "con_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_cac_controleAplicacoesCliente",
            //    columns: table => new
            //    {
            //        cac_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        cac_c_processo = table.Column<string>(unicode: false, nullable: true),
            //        cac_con_n_codigo = table.Column<int>(nullable: true),
            //        cac_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        cac_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cac_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_cac_controleAplicacoesCliente", x => x.cac_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_cac_controleAplicacoesCliente_tb_con_controladora",
            //            column: x => x.cac_con_n_codigo,
            //            principalTable: "tb_con_controladora",
            //            principalColumn: "con_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_cae_controleAcessoExcluido",
            //    columns: table => new
            //    {
            //        cae_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        cae_cac_n_codigo = table.Column<int>(nullable: false),
            //        cae_mor_n_codigo = table.Column<int>(nullable: true),
            //        cae_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        cae_c_numeroCartao = table.Column<string>(unicode: false, nullable: true),
            //        cae_b_ativo = table.Column<bool>(nullable: true),
            //        cae_b_panico = table.Column<bool>(nullable: true),
            //        cae_c_tipo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        cae_c_tipoAcesso = table.Column<string>(unicode: false, nullable: true),
            //        cae_c_senha = table.Column<string>(unicode: false, nullable: true),
            //        cae_vis_n_codigo = table.Column<int>(nullable: true),
            //        cae_pse_n_codigo = table.Column<int>(nullable: true),
            //        cae_c_numeroChave = table.Column<string>(unicode: false, nullable: true),
            //        cae_usu_n_codigo = table.Column<int>(nullable: true),
            //        cae_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cae_b_sincronizado = table.Column<bool>(nullable: false),
            //        cae_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        cae_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cae_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cae_con_n_codigo = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_cae_controleAcesso", x => x.cae_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_cae_controleAcessoExcluido_tb_con_controladora",
            //            column: x => x.cae_con_n_codigo,
            //            principalTable: "tb_con_controladora",
            //            principalColumn: "con_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_hdi_historicoDispositivo",
            //    columns: table => new
            //    {
            //        hdi_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        hdi_con_n_codigo = table.Column<int>(nullable: true),
            //        hdi_d_data = table.Column<DateTime>(type: "datetime", nullable: true),
            //        hdi_c_mensagem = table.Column<string>(unicode: false, nullable: true),
            //        hdi_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        hdi_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        hdi_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_hdi_historicoDispositivo", x => x.hdi_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_hdi_historicoDispositivo_tb_con_controladora",
            //            column: x => x.hdi_con_n_codigo,
            //            principalTable: "tb_con_controladora",
            //            principalColumn: "con_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_vid_video",
            //    columns: table => new
            //    {
            //        vid_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        vid_con_n_codigo = table.Column<int>(nullable: true),
            //        vid_c_link = table.Column<string>(unicode: false, nullable: true),
            //        vid_c_status = table.Column<string>(unicode: false, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_vid_video", x => x.vid_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_vid_video_tb_con_monitoramentoControleAcesso",
            //            column: x => x.vid_con_n_codigo,
            //            principalTable: "tb_con_monitoramentoControleAcesso",
            //            principalColumn: "con_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_lay_layout",
            //    columns: table => new
            //    {
            //        lay_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        lay_ddv_n_codigo = table.Column<int>(nullable: true),
            //        lay_cli_n_codigo = table.Column<int>(nullable: true),
            //        lay_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        lay_c_exibeLayout = table.Column<string>(unicode: false, nullable: true),
            //        lay_c_canais = table.Column<string>(unicode: false, nullable: true),
            //        lay_usu_n_codigo = table.Column<int>(nullable: true),
            //        lay_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        lay_cla_n_codigo = table.Column<int>(nullable: true),
            //        lay_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        lay_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        lay_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_lay_layout", x => x.lay_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_lay_layout_tb_cla_cabecalhoLayout",
            //            column: x => x.lay_cla_n_codigo,
            //            principalTable: "tb_cla_cabecalhoLayout",
            //            principalColumn: "cla_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_lay_layout_tb_cli_cliente",
            //            column: x => x.lay_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_lay_layout_tb_ddv_dispositivoDVRCliente",
            //            column: x => x.lay_ddv_n_codigo,
            //            principalTable: "tb_ddv_dispositivoDVRCliente",
            //            principalColumn: "ddv_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_not_notificacaoApp",
            //    columns: table => new
            //    {
            //        not_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        not_zec_n_codigo = table.Column<int>(nullable: true),
            //        not_b_pendente = table.Column<bool>(nullable: true),
            //        not_d_data = table.Column<DateTime>(type: "datetime", nullable: true),
            //        not_c_mensagem = table.Column<string>(unicode: false, nullable: true),
            //        not_b_excluido = table.Column<bool>(nullable: true),
            //        not_c_cor = table.Column<string>(unicode: false, nullable: true),
            //        not_c_retornoPush = table.Column<string>(unicode: false, nullable: true),
            //        not_mor_n_codigo = table.Column<int>(nullable: true),
            //        not_c_origem = table.Column<string>(unicode: false, nullable: true),
            //        not_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        not_eno_n_codigo = table.Column<int>(nullable: true),
            //        not_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        not_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        not_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        not_grf_n_codigo = table.Column<int>(nullable: true),
            //        not_b_enviar_app_pro = table.Column<bool>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_not_notificacaoApp", x => x.not_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_not_notificacaoApp_tb_eno_envioNotificacao",
            //            column: x => x.not_eno_n_codigo,
            //            principalTable: "tb_eno_envioNotificacao",
            //            principalColumn: "eno_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_not_notificacaoApp_tb_zec_zeladorCliente",
            //            column: x => x.not_zec_n_codigo,
            //            principalTable: "tb_zec_zeladorCliente",
            //            principalColumn: "zec_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_dpg_disparoPGM",
            //    columns: table => new
            //    {
            //        dpg_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        dpg_eqc_n_codigo = table.Column<int>(nullable: false),
            //        dpg_cgp_n_codigo = table.Column<int>(nullable: false),
            //        dpg_b_pendente = table.Column<bool>(nullable: false),
            //        dpg_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: false),
            //        dpg_c_usuario = table.Column<string>(unicode: false, nullable: false),
            //        dpg_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        dpg_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        dpg_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        dpg_cli_n_codigo = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_dpg_disparoPGM", x => x.dpg_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_dpg_disparoPGM_tb_cpg_comandoPGM",
            //            column: x => x.dpg_cgp_n_codigo,
            //            principalTable: "tb_cpg_comandoPGM",
            //            principalColumn: "cgp_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_dpg_disparoPGM_tb_eqc_equipamentoCliente",
            //            column: x => x.dpg_eqc_n_codigo,
            //            principalTable: "tb_eqc_equipamentoCliente",
            //            principalColumn: "eqc_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_pgc_pgmCliente",
            //    columns: table => new
            //    {
            //        pgc_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        pgc_eqc_n_codigo = table.Column<int>(nullable: false),
            //        pgc_c_nome = table.Column<string>(unicode: false, nullable: false),
            //        pgc_cpg_n_codigo = table.Column<int>(nullable: false),
            //        pgc_cli_n_codigo = table.Column<int>(nullable: false),
            //        pgc_usu_n_codigo = table.Column<int>(nullable: false),
            //        pgc_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        pgc_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        pgc_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_pgc_pgmCliente", x => x.pgc_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_pgc_pgmCliente_tb_cli_cliente",
            //            column: x => x.pgc_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_pgc_pgmCliente_tb_cpg_comandoPGM",
            //            column: x => x.pgc_cpg_n_codigo,
            //            principalTable: "tb_cpg_comandoPGM",
            //            principalColumn: "cgp_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_pgc_pgmCliente_tb_eqc_equipamentoCliente",
            //            column: x => x.pgc_eqc_n_codigo,
            //            principalTable: "tb_eqc_equipamentoCliente",
            //            principalColumn: "eqc_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_opl_operadorLocal",
            //    columns: table => new
            //    {
            //        opl_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        opl_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        opl_cli_n_codigo = table.Column<int>(nullable: true),
            //        opl_gpp_n_codigo = table.Column<int>(nullable: true),
            //        opl_c_login = table.Column<string>(unicode: false, nullable: true),
            //        opl_c_senha = table.Column<string>(unicode: false, nullable: true),
            //        opl_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        opl_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        opl_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        opl_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        opl_d_ultimoContato = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_opl_operadorLocal", x => x.opl_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_opl_operadorLocal_tb_cli_cliente",
            //            column: x => x.opl_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_opl_operadorLocal_tb_gpp_grupoPermissaoOperador",
            //            column: x => x.opl_gpp_n_codigo,
            //            principalTable: "tb_gpp_grupoPermissaoOperador",
            //            principalColumn: "gpp_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_pgp_permissoesGrupo",
            //    columns: table => new
            //    {
            //        pgp_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        pgp_b_checado = table.Column<bool>(nullable: true),
            //        pgp_gpp_n_codigo = table.Column<int>(nullable: false),
            //        pgp_top_n_codigo = table.Column<int>(nullable: true),
            //        pgp_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        pgp_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        pgp_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        pgp_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_pgp_permissoesGrupo", x => x.pgp_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_pgp_permissoesGrupo_tb_gpp_grupoPermissaoOperador",
            //            column: x => x.pgp_gpp_n_codigo,
            //            principalTable: "tb_gpp_grupoPermissaoOperador",
            //            principalColumn: "gpp_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_pgp_permissoesGrupo_tb_top_tipoPermissaoOperador",
            //            column: x => x.pgp_top_n_codigo,
            //            principalTable: "tb_top_tipoPermissaoOperador",
            //            principalColumn: "top_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_avg_avisoGrupoFamiliar",
            //    columns: table => new
            //    {
            //        avg_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        avg_cav_n_codigo = table.Column<int>(nullable: true),
            //        avg_b_lidoNaoLido = table.Column<bool>(nullable: true),
            //        avg_grf_n_codigo = table.Column<int>(nullable: true),
            //        avg_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        avg_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        avg_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        avg_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        avg_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_avg_avisoGrupoFamiliar", x => x.avg_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_avg_avisoGrupoFamiliar_tb_cav_categorizacaoAviso",
            //            column: x => x.avg_cav_n_codigo,
            //            principalTable: "tb_cav_categorizacaoAviso",
            //            principalColumn: "cav_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_avg_avisoGrupoFamiliar_tb_grf_grupoFamiliar",
            //            column: x => x.avg_grf_n_codigo,
            //            principalTable: "tb_grf_grupoFamiliar",
            //            principalColumn: "grf_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_mor_Morador",
            //    columns: table => new
            //    {
            //        mor_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        mor_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        mor_c_rg = table.Column<string>(unicode: false, nullable: true),
            //        mor_c_cpf = table.Column<string>(unicode: false, nullable: true),
            //        mor_d_dataNascimento = table.Column<DateTime>(type: "datetime", nullable: true),
            //        mor_c_email = table.Column<string>(unicode: false, nullable: true),
            //        mor_c_telefonePermitido = table.Column<string>(unicode: false, nullable: true),
            //        mor_c_celular = table.Column<string>(unicode: false, nullable: true),
            //        mor_c_ramal = table.Column<string>(unicode: false, nullable: true),
            //        mor_c_perfil = table.Column<string>(unicode: false, nullable: true),
            //        mor_c_observacao = table.Column<string>(unicode: false, nullable: true),
            //        mor_b_ativoInativo = table.Column<bool>(nullable: true),
            //        mor_fot_n_codigo = table.Column<int>(nullable: true),
            //        mor_cli_n_codigo = table.Column<int>(nullable: true),
            //        mor_grf_n_codigo = table.Column<int>(nullable: true),
            //        mor_b_antpassback = table.Column<bool>(nullable: true),
            //        mor_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        mor_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        mor_c_autorizacao = table.Column<string>(unicode: false, nullable: true),
            //        mor_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        mor_b_notificacao = table.Column<bool>(nullable: true),
            //        mor_b_liberadoAntPassBack = table.Column<bool>(nullable: true),
            //        mor_c_senha = table.Column<string>(unicode: false, nullable: true),
            //        mor_c_contraSenha = table.Column<string>(unicode: false, nullable: true),
            //        mor_fot_n_documento = table.Column<int>(nullable: true),
            //        mor_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        mor_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        mor_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        mor_b_sindico = table.Column<bool>(nullable: true),
            //        mor_c_senhaAPPPro = table.Column<string>(unicode: false, nullable: true),
            //        mor_c_autorizacaoPRO = table.Column<string>(unicode: false, nullable: true),
            //        mor_b_inOut = table.Column<bool>(nullable: false),
            //        mor_d_dataEntrada = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("pk_tb_mor_morador", x => x.mor_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_mor_Morador_tb_cli_cliente",
            //            column: x => x.mor_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_mor_Morador_tb_fot_foto",
            //            column: x => x.mor_fot_n_codigo,
            //            principalTable: "tb_fot_foto",
            //            principalColumn: "fot_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_mor_morador_tb_fot_foto_doc",
            //            column: x => x.mor_fot_n_documento,
            //            principalTable: "tb_fot_foto",
            //            principalColumn: "fot_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_mor_Morador_tb_grf_grupoFamiliar",
            //            column: x => x.mor_grf_n_codigo,
            //            principalTable: "tb_grf_grupoFamiliar",
            //            principalColumn: "grf_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_pet_pet",
            //    columns: table => new
            //    {
            //        pet_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        pet_c_foto = table.Column<bool>(nullable: true),
            //        pet_c_nome = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        pet_c_cor = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        pet_rac_n_codigo = table.Column<int>(nullable: true),
            //        pet_c_porte = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        pet_c_pelagem = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        pet_c_caracteristicas = table.Column<string>(unicode: false, nullable: true),
            //        pet_grf_n_codigo = table.Column<int>(nullable: true),
            //        pet_fot_n_codigo = table.Column<int>(nullable: true),
            //        pet_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        pet_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        pet_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        pet_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_vec_veiculo", x => x.pet_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_pet_pet_tb_fot_foto",
            //            column: x => x.pet_fot_n_codigo,
            //            principalTable: "tb_fot_foto",
            //            principalColumn: "fot_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_pet_pet_tb_grf_grupoFamiliar",
            //            column: x => x.pet_grf_n_codigo,
            //            principalTable: "tb_grf_grupoFamiliar",
            //            principalColumn: "grf_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_pet_pet_tb_rac_raca",
            //            column: x => x.pet_rac_n_codigo,
            //            principalTable: "tb_rac_raca",
            //            principalColumn: "rac_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_vec_veiculo",
            //    columns: table => new
            //    {
            //        vec_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        vec_c_modelo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        vec_c_cor = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        vec_c_placa = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        vec_c_caracteristicas = table.Column<string>(unicode: false, nullable: true),
            //        vec_grf_n_codigo = table.Column<int>(nullable: true),
            //        vec_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        vec_mav_n_codigo = table.Column<int>(nullable: true),
            //        vec_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        vec_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        vec_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_vec_veiculo_1", x => x.vec_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_vec_veiculo_tb_grf_grupoFamiliar",
            //            column: x => x.vec_grf_n_codigo,
            //            principalTable: "tb_grf_grupoFamiliar",
            //            principalColumn: "grf_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_vec_veiculo_tb_mav_marcaVeiculo",
            //            column: x => x.vec_mav_n_codigo,
            //            principalTable: "tb_mav_marcaVeiculo",
            //            principalColumn: "mav_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_phr_perfilHorario",
            //    columns: table => new
            //    {
            //        phr_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        phr_c_status = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        phr_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        phr_c_pontoAcesso = table.Column<string>(unicode: false, nullable: true),
            //        phr_hor_n_codigo = table.Column<int>(nullable: true),
            //        phr_b_visitante = table.Column<bool>(nullable: true),
            //        phr_cli_n_codigo = table.Column<int>(nullable: true),
            //        phr_b_antipassback = table.Column<bool>(nullable: true),
            //        phr_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        phr_b_servico = table.Column<bool>(nullable: true),
            //        phr_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        phr_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        phr_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_phr_perfilHorario", x => x.phr_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_phr_perfilHorario_tb_cli_cliente",
            //            column: x => x.phr_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_phr_perfilHorario_tb_hor_horario",
            //            column: x => x.phr_hor_n_codigo,
            //            principalTable: "tb_hor_horario",
            //            principalColumn: "hor_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_lcg_localidadeClienteGrupoFamiliar",
            //    columns: table => new
            //    {
            //        lcg_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        lcg_lcc_n_codigo = table.Column<int>(nullable: true),
            //        lcg_grf_n_codigo = table.Column<int>(nullable: true),
            //        lcg_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        lcg_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        lcg_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        lcg_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_lcg_localidadeClienteGrupoFamiliar", x => x.lcg_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_lcg_localidadeClienteGrupoFamiliar_tb_grf_GrupoFamiliar",
            //            column: x => x.lcg_grf_n_codigo,
            //            principalTable: "tb_grf_grupoFamiliar",
            //            principalColumn: "grf_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_lcg_localidadeClienteGrupoFamiliar_tb_lcc_localidadeCliente",
            //            column: x => x.lcg_lcc_n_codigo,
            //            principalTable: "tb_lcc_localidadeCliente",
            //            principalColumn: "lcc_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_can_canalLayout",
            //    columns: table => new
            //    {
            //        can_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        can_lay_n_codigo = table.Column<int>(nullable: true),
            //        can_b_check = table.Column<bool>(nullable: true),
            //        can_n_index = table.Column<int>(nullable: true),
            //        can_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        can_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        can_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        can_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        can_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_can_canalLayout", x => x.can_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_can_canalLayout_tb_lay_layout",
            //            column: x => x.can_lay_n_codigo,
            //            principalTable: "tb_lay_layout",
            //            principalColumn: "lay_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_pta_pontosAcesso",
            //    columns: table => new
            //    {
            //        pta_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        pta_con_n_codigo = table.Column<int>(nullable: true),
            //        pta_b_status = table.Column<bool>(nullable: true),
            //        pta_b_visitante = table.Column<bool>(nullable: true),
            //        pta_b_servico = table.Column<bool>(nullable: true),
            //        pta_c_nomePonto = table.Column<string>(unicode: false, nullable: true),
            //        pta_c_fluxo = table.Column<string>(unicode: false, nullable: true),
            //        pta_n_indexPorta = table.Column<int>(nullable: true),
            //        pta_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        pta_b_desabilitaVisitante = table.Column<bool>(nullable: true),
            //        pta_b_desabilitaPrestador = table.Column<bool>(nullable: true),
            //        pta_lay_n_codigo = table.Column<int>(nullable: true),
            //        pta_cli_n_codigo = table.Column<int>(nullable: true),
            //        pta_cla_n_codigo = table.Column<int>(nullable: true),
            //        pta_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        pta_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        pta_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        pta_b_connectProGaren = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_pta_pontosAcesso", x => x.pta_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_pta_pontosAcesso_tb_cla_cabecalhoLayout",
            //            column: x => x.pta_cla_n_codigo,
            //            principalTable: "tb_cla_cabecalhoLayout",
            //            principalColumn: "cla_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_pta_pontosAcesso_tb_cli_cliente",
            //            column: x => x.pta_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_pta_pontosAcesso_tb_con_controladora",
            //            column: x => x.pta_con_n_codigo,
            //            principalTable: "tb_con_controladora",
            //            principalColumn: "con_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_pta_pontosAcesso_tb_lay_layout",
            //            column: x => x.pta_lay_n_codigo,
            //            principalTable: "tb_lay_layout",
            //            principalColumn: "lay_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_ral_ramalLayout",
            //    columns: table => new
            //    {
            //        ral_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ral_c_ramal = table.Column<string>(unicode: false, nullable: true),
            //        ral_lay_n_codigo = table.Column<int>(nullable: true),
            //        ral_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ral_cla_n_codigo = table.Column<int>(nullable: true),
            //        ral_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        ral_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        ral_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_ral_ramalLayout", x => x.ral_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_ral_ramalLayout_tB_cla_cabecalhoLayout",
            //            column: x => x.ral_cla_n_codigo,
            //            principalTable: "tb_cla_cabecalhoLayout",
            //            principalColumn: "cla_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_ral_ramalLayout_tb_lay_layout",
            //            column: x => x.ral_lay_n_codigo,
            //            principalTable: "tb_lay_layout",
            //            principalColumn: "lay_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_zoc_zoneamentoCliente",
            //    columns: table => new
            //    {
            //        zoc_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        zoc_cli_n_codigo = table.Column<int>(nullable: true),
            //        zoc_eqc_n_codigo = table.Column<int>(nullable: true),
            //        zoc_c_tipoSensor = table.Column<string>(unicode: false, nullable: true),
            //        zoc_c_nomePonto = table.Column<string>(unicode: false, nullable: true),
            //        zoc_c_zona = table.Column<string>(unicode: false, nullable: true),
            //        zoc_n_TemporizadorDisparo = table.Column<int>(nullable: true),
            //        zoc_lay_n_codigo = table.Column<int>(nullable: true),
            //        zoc_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        zoc_cla_n_codigo = table.Column<int>(nullable: true),
            //        zoc_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        zoc_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        zoc_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_zoc_zoneamentoCliente", x => x.zoc_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_zoc_zoneamentoCliente_tb_cla_cabecalhoLayout",
            //            column: x => x.zoc_cla_n_codigo,
            //            principalTable: "tb_cla_cabecalhoLayout",
            //            principalColumn: "cla_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_zoc_zoneamentoCliente_tb_cli_cliente",
            //            column: x => x.zoc_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_zoc_zoneamentoCliente_tb_eqc_equipamentoCliente",
            //            column: x => x.zoc_eqc_n_codigo,
            //            principalTable: "tb_eqc_equipamentoCliente",
            //            principalColumn: "eqc_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_zoc_zoneamentoCliente_tb_lay_layout",
            //            column: x => x.zoc_lay_n_codigo,
            //            principalTable: "tb_lay_layout",
            //            principalColumn: "lay_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_hil_historicoLiberacao",
            //    columns: table => new
            //    {
            //        hil_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        hil_c_nomeUsuario = table.Column<string>(unicode: false, nullable: true),
            //        hil_d_data = table.Column<DateTime>(type: "datetime", nullable: true),
            //        hil_mor_n_codigo = table.Column<int>(nullable: true),
            //        hil_c_status = table.Column<string>(unicode: false, nullable: true),
            //        hil_c_observacao = table.Column<string>(unicode: false, nullable: true),
            //        hil_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        hil_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        hil_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        hil_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_hil_historicoLiberacao", x => x.hil_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_hil_historicoLiberacao_tb_mor_morador",
            //            column: x => x.hil_mor_n_codigo,
            //            principalTable: "tb_mor_Morador",
            //            principalColumn: "mor_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_lid_liberacaoDelivery",
            //    columns: table => new
            //    {
            //        lid_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        lid_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        lid_c_token = table.Column<string>(unicode: false, nullable: true),
            //        lid_d_dataHora = table.Column<DateTime>(type: "datetime", nullable: true),
            //        lid_b_pendente = table.Column<bool>(nullable: true),
            //        lid_mor_n_codigo = table.Column<int>(nullable: true),
            //        lid_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        lid_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        lid_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        lid_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        lid_cac_n_codigo = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_lid_liberacaoDelivery", x => x.lid_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_lid_liberacaoDelivery_tb_mor_Morador",
            //            column: x => x.lid_mor_n_codigo,
            //            principalTable: "tb_mor_Morador",
            //            principalColumn: "mor_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_lip_liberacaoPrestador",
            //    columns: table => new
            //    {
            //        lip_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        lip_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        lip_c_celular = table.Column<string>(unicode: false, nullable: true),
            //        lip_c_rg = table.Column<string>(unicode: false, nullable: true),
            //        lip_d_dataHora = table.Column<DateTime>(type: "datetime", nullable: true),
            //        lip_b_pendente = table.Column<bool>(nullable: true),
            //        lip_mor_n_codigo = table.Column<int>(nullable: true),
            //        lip_n_duracao = table.Column<int>(nullable: true),
            //        lip_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        lip_n_duracaoAntes = table.Column<int>(nullable: true),
            //        lip_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        lip_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        lip_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        lip_b_entrou = table.Column<bool>(nullable: false),
            //        lip_b_saiu = table.Column<bool>(nullable: false),
            //        lip_d_dataEntrada = table.Column<DateTime>(type: "datetime", nullable: true),
            //        lip_d_dataSaida = table.Column<DateTime>(type: "datetime", nullable: true),
            //        lip_cac_n_codigo = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_lip_liberacaoPrestador", x => x.lip_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_lip_liberacaoPrestador_tb_mor_Morador",
            //            column: x => x.lip_mor_n_codigo,
            //            principalTable: "tb_mor_Morador",
            //            principalColumn: "mor_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_pan_panicoApp",
            //    columns: table => new
            //    {
            //        pan_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        pan_d_dataPanico = table.Column<DateTime>(type: "datetime", nullable: true),
            //        pan_mor_n_codigo = table.Column<int>(nullable: true),
            //        pan_b_pendente = table.Column<bool>(nullable: true),
            //        pan_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        pan_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        pan_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_pan_panicoApp", x => x.pan_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_pan_panicoApp_tb_mor_Morador",
            //            column: x => x.pan_mor_n_codigo,
            //            principalTable: "tb_mor_Morador",
            //            principalColumn: "mor_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_res_registroSalao",
            //    columns: table => new
            //    {
            //        res_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        res_mor_n_codigo = table.Column<int>(nullable: true),
            //        res_dpn_n_codigo = table.Column<int>(nullable: true),
            //        res_d_dataSolicitacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        res_c_periodo = table.Column<string>(unicode: false, nullable: true),
            //        res_c_status = table.Column<string>(unicode: false, nullable: true),
            //        res_c_observacao = table.Column<string>(unicode: false, nullable: true),
            //        res_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        res_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        res_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_res_registroSalao", x => x.res_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_res_registroSalao_tb_dpn_dependencias",
            //            column: x => x.res_dpn_n_codigo,
            //            principalTable: "tb_dpn_dependencias",
            //            principalColumn: "dpn_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_res_registroSalao_tb_mor_Morador",
            //            column: x => x.res_mor_n_codigo,
            //            principalTable: "tb_mor_Morador",
            //            principalColumn: "mor_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_soz_solicitarZelador",
            //    columns: table => new
            //    {
            //        soz_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        soz_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        soz_mor_n_codigo = table.Column<int>(nullable: true),
            //        soz_n_fila = table.Column<int>(nullable: true),
            //        soz_c_status = table.Column<string>(unicode: false, nullable: true),
            //        soz_d_dataSolicitacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        soz_c_resposta = table.Column<string>(unicode: false, nullable: true),
            //        soz_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        soz_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        soz_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        soz_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        soz_fap_n_codigo = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_soz_solicitarZelador", x => x.soz_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_soz_solicitarZelador_tb_fap_fotoApp",
            //            column: x => x.soz_fap_n_codigo,
            //            principalTable: "tb_fap_fotoApp",
            //            principalColumn: "fap_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_soz_solicitarZelador_tb_mor_Morador",
            //            column: x => x.soz_mor_n_codigo,
            //            principalTable: "tb_mor_Morador",
            //            principalColumn: "mor_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_upe_usuarioAPPpermissao",
            //    columns: table => new
            //    {
            //        upe_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        upe_per_n_codigo = table.Column<int>(nullable: true),
            //        upe_mor_n_codigo = table.Column<int>(nullable: true),
            //        upe_b_acessa = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_upe_usuarioAPPpermissao", x => x.upe_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_upe_usuarioAPPpermissao_tb_mor_Morador",
            //            column: x => x.upe_mor_n_codigo,
            //            principalTable: "tb_mor_Morador",
            //            principalColumn: "mor_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_upe_usuarioAPPpermissao_tb_per_permissoes",
            //            column: x => x.upe_per_n_codigo,
            //            principalTable: "tb_per_permissoes",
            //            principalColumn: "per_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_usu_UsuarioApp",
            //    columns: table => new
            //    {
            //        usu_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        usu_c_email = table.Column<string>(unicode: false, nullable: true),
            //        usu_c_rg = table.Column<string>(unicode: false, nullable: true),
            //        usu_c_telefone = table.Column<string>(unicode: false, nullable: true),
            //        usu_c_senha = table.Column<string>(unicode: false, nullable: true),
            //        usu_mor_n_codigo = table.Column<int>(nullable: true),
            //        usu_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        usu_b_liberado = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
            //        usu_c_condominio = table.Column<string>(unicode: false, nullable: true),
            //        usu_d_dataInclusao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        usu_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        usu_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        usu_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        usu_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_usu_UsuarioApp", x => x.usu_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_usu_UsuarioApp_tb_mor_Morador",
            //            column: x => x.usu_mor_n_codigo,
            //            principalTable: "tb_mor_Morador",
            //            principalColumn: "mor_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_vis_visitasApp",
            //    columns: table => new
            //    {
            //        vis_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        vis_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        vis_n_quantidade = table.Column<int>(nullable: true),
            //        vis_n_duracao = table.Column<int>(nullable: true),
            //        vis_d_dataHora = table.Column<DateTime>(type: "datetime", nullable: true),
            //        vis_mor_n_codigo = table.Column<int>(nullable: true),
            //        vis_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        vis_n_duracaoAntes = table.Column<int>(nullable: true),
            //        vis_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        vis_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        vis_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_vis_visitasApp", x => x.vis_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_vis_visitasApp_tb_mor_Morador",
            //            column: x => x.vis_mor_n_codigo,
            //            principalTable: "tb_mor_Morador",
            //            principalColumn: "mor_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_gpv_grupoVagas",
            //    columns: table => new
            //    {
            //        gpv_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        gpv_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        gpv_n_numeroVagas = table.Column<int>(nullable: true),
            //        gpv_c_perfil = table.Column<string>(unicode: false, nullable: true),
            //        gpv_cli_n_codigo = table.Column<int>(nullable: true),
            //        gpv_phr_n_codigo = table.Column<int>(nullable: true),
            //        gpv_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        gpv_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        gpv_n_vagasUtilizadas = table.Column<int>(nullable: true),
            //        gpv_n_vagasRestantes = table.Column<int>(nullable: true),
            //        gpv_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        gpv_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        gpv_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        gpv_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_gpv_grupoVagas", x => x.gpv_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_gpv_grupoVagas_tb_cli_cliente",
            //            column: x => x.gpv_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_gpv_grupoVagas_tb_phr_perfilhorario",
            //            column: x => x.gpv_phr_n_codigo,
            //            principalTable: "tb_phr_perfilHorario",
            //            principalColumn: "phr_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_mon_monitoramento",
            //    columns: table => new
            //    {
            //        mon_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        mon_cli_n_codigo = table.Column<int>(nullable: true),
            //        mon_eve_n_codigo = table.Column<int>(nullable: true),
            //        mon_cev_n_codigo = table.Column<int>(nullable: true),
            //        mon_d_dataInsercao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        mon_d_dataEdicao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        mon_stm_n_codigo = table.Column<int>(nullable: true),
            //        mon_zoc_n_codigo = table.Column<int>(nullable: true),
            //        mon_c_observacao = table.Column<string>(unicode: false, nullable: true),
            //        mon_n_responsavel = table.Column<int>(nullable: true),
            //        mon_d_dataEvento = table.Column<DateTime>(type: "datetime", nullable: true),
            //        mon_c_motivo = table.Column<string>(unicode: false, nullable: true),
            //        mon_ate_n_codigo = table.Column<int>(nullable: true),
            //        mon_b_precisaAtendimento = table.Column<bool>(nullable: true),
            //        mon_c_motivoConclusao = table.Column<string>(unicode: false, nullable: true),
            //        mon_n_responsavelConclusao = table.Column<int>(nullable: true),
            //        mon_c_observacaoConclusao = table.Column<string>(unicode: false, nullable: true),
            //        mon_d_dataEventoConclusao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        mon_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        mon_d_dataExibicao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        mon_b_exibido = table.Column<bool>(nullable: true),
            //        mon_b_limpaEvento = table.Column<bool>(nullable: true),
            //        mon_pec_n_codigo = table.Column<int>(nullable: true),
            //        mon_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        mon_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        mon_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_mon_monitoramento", x => x.mon_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_mon_monitoramento_tb_cev_categorizacaoEvento",
            //            column: x => x.mon_cev_n_codigo,
            //            principalTable: "tb_cev_categorizacaoEvento",
            //            principalColumn: "cev_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_mon_monitoramento_tb_cli_cliente",
            //            column: x => x.mon_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_mon_monitoramento_tb_eve_evento",
            //            column: x => x.mon_eve_n_codigo,
            //            principalTable: "tb_eve_evento",
            //            principalColumn: "eve_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_mon_monitoramento_tb_pec_processoExclusaoCliente",
            //            column: x => x.mon_pec_n_codigo,
            //            principalTable: "tb_pec_processoExclusaoCliente",
            //            principalColumn: "pec_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_mon_monitoramento_tb_stm_statusMonitoramento",
            //            column: x => x.mon_stm_n_codigo,
            //            principalTable: "tb_stm_statusMonitoramento",
            //            principalColumn: "stm_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_mon_monitoramento_tb_eqc_equipamentoCliente",
            //            column: x => x.mon_zoc_n_codigo,
            //            principalTable: "tb_zoc_zoneamentoCliente",
            //            principalColumn: "zoc_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_liv_liberacaoVisitante",
            //    columns: table => new
            //    {
            //        liv_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        liv_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        liv_c_celular = table.Column<string>(unicode: false, nullable: true),
            //        liv_c_rg = table.Column<string>(unicode: false, nullable: true),
            //        liv_d_dataHora = table.Column<DateTime>(type: "datetime", nullable: true),
            //        liv_b_pendente = table.Column<bool>(nullable: true),
            //        liv_mor_n_codigo = table.Column<int>(nullable: true),
            //        liv_vis_n_codigo = table.Column<int>(nullable: true),
            //        liv_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        liv_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        liv_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        liv_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        liv_b_entrou = table.Column<bool>(nullable: false),
            //        liv_b_saiu = table.Column<bool>(nullable: false),
            //        liv_d_dataEntrada = table.Column<DateTime>(type: "datetime", nullable: true),
            //        liv_d_dataSaida = table.Column<DateTime>(type: "datetime", nullable: true),
            //        liv_cac_n_codigo = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_liv_liberacaoVisitante", x => x.liv_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_liv_liberacaoVisitante_tb_mor_morador",
            //            column: x => x.liv_mor_n_codigo,
            //            principalTable: "tb_mor_Morador",
            //            principalColumn: "mor_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_liv_liberacaoVisitante_tb_vis_visitasApp",
            //            column: x => x.liv_vis_n_codigo,
            //            principalTable: "tb_vis_visitasApp",
            //            principalColumn: "vis_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_pse_prestadorServico",
            //    columns: table => new
            //    {
            //        pse_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        pse_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        pse_c_rg = table.Column<string>(unicode: false, nullable: true),
            //        pse_c_cpf = table.Column<string>(unicode: false, nullable: true),
            //        pse_c_celular = table.Column<string>(unicode: false, nullable: true),
            //        pse_c_email = table.Column<string>(unicode: false, nullable: true),
            //        pse_c_perfil = table.Column<string>(unicode: false, nullable: true),
            //        pse_d_dataExpriracao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        pse_c_numeroCartao = table.Column<string>(unicode: false, nullable: true),
            //        pse_c_localizacao = table.Column<string>(unicode: false, nullable: true),
            //        pse_c_observacao = table.Column<string>(unicode: false, nullable: true),
            //        pse_fot_n_codigo = table.Column<int>(nullable: true),
            //        pse_cli_n_codigo = table.Column<int>(nullable: true),
            //        pse_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        pse_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        pse_gpv_n_codigo = table.Column<int>(nullable: true),
            //        pse_c_placaVeiculo = table.Column<string>(unicode: false, nullable: true),
            //        pse_c_modeloVeiculo = table.Column<string>(unicode: false, nullable: true),
            //        pse_c_corVeiculo = table.Column<string>(unicode: false, nullable: true),
            //        pse_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        pse_b_ativoInativo = table.Column<bool>(nullable: true),
            //        pse_b_liberadoAntPassBack = table.Column<bool>(nullable: true),
            //        pse_fot_n_documento = table.Column<int>(nullable: true),
            //        pse_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        pse_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        pse_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        pse_b_inOut = table.Column<bool>(nullable: false),
            //        pse_d_dataEntrada = table.Column<DateTime>(type: "datetime", nullable: true),
            //        pse_d_dataSaidaManual = table.Column<DateTime>(type: "datetime", nullable: true),
            //        pse_b_panicoTratado = table.Column<bool>(nullable: true),
            //        pse_n_horarioAdicional = table.Column<int>(nullable: true),
            //        pse_b_gerou_atendimento = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_pse_prestadorServico", x => x.pse_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_pse_prestadorServico_tb_cli_cliente",
            //            column: x => x.pse_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_pse_prestadorServico_tb_fot_foto",
            //            column: x => x.pse_fot_n_codigo,
            //            principalTable: "tb_fot_foto",
            //            principalColumn: "fot_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_pse_prestadorServico_tb_fot_foto_documento",
            //            column: x => x.pse_fot_n_documento,
            //            principalTable: "tb_fot_foto",
            //            principalColumn: "fot_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_pse_prestadorServico_tb_gpv_grupovagas",
            //            column: x => x.pse_gpv_n_codigo,
            //            principalTable: "tb_gpv_grupoVagas",
            //            principalColumn: "gpv_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_vis_visitante",
            //    columns: table => new
            //    {
            //        vis_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        vis_c_nome = table.Column<string>(unicode: false, nullable: true),
            //        vis_c_rg = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        vis_c_cpf = table.Column<string>(unicode: false, maxLength: 14, nullable: true),
            //        vis_c_celular = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        vis_c_email = table.Column<string>(unicode: false, nullable: true),
            //        vis_c_perfil = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        vis_d_dataExpriracao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        vis_c_numeroCartao = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
            //        vis_c_observacao = table.Column<string>(unicode: false, nullable: true),
            //        vis_fot_n_codigo = table.Column<int>(nullable: true),
            //        vis_cli_n_codigo = table.Column<int>(nullable: true),
            //        vis_c_localizacao = table.Column<string>(unicode: false, nullable: true),
            //        vis_d_alteracao = table.Column<DateTime>(type: "date", nullable: true),
            //        vis_c_usuario = table.Column<string>(unicode: false, nullable: true),
            //        vis_gpv_n_codigo = table.Column<int>(nullable: true),
            //        vis_c_placaVeiculo = table.Column<string>(unicode: false, nullable: true),
            //        vis_c_modeloVeiculo = table.Column<string>(unicode: false, nullable: true),
            //        vis_c_corVeiculo = table.Column<string>(unicode: false, nullable: true),
            //        vis_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        vis_b_ativoInativo = table.Column<bool>(nullable: true),
            //        vis_b_liberadoAntPassBack = table.Column<bool>(nullable: true),
            //        vis_fot_n_documento = table.Column<int>(nullable: true),
            //        vis_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        vis_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        vis_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        vis_b_inOut = table.Column<bool>(nullable: false),
            //        vis_d_dataEntrada = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_vis_visitante", x => x.vis_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_vis_visitante_tb_cli_cliente",
            //            column: x => x.vis_cli_n_codigo,
            //            principalTable: "tb_cli_cliente",
            //            principalColumn: "cli_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_vis_visitante_tb_fot_foto",
            //            column: x => x.vis_fot_n_codigo,
            //            principalTable: "tb_fot_foto",
            //            principalColumn: "fot_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_vis_visitante_tb_fot_foto_documento",
            //            column: x => x.vis_fot_n_documento,
            //            principalTable: "tb_fot_foto",
            //            principalColumn: "fot_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_vis_visitante_tb_gpv_grupovagas",
            //            column: x => x.vis_gpv_n_codigo,
            //            principalTable: "tb_gpv_grupoVagas",
            //            principalColumn: "gpv_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_cha_chavesDeAcesso",
            //    columns: table => new
            //    {
            //        cha_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        cha_c_chave = table.Column<string>(unicode: false, nullable: true),
            //        cha_liv_n_codigo = table.Column<int>(nullable: true),
            //        cha_lid_n_codigo = table.Column<int>(nullable: true),
            //        cha_lip_n_codigo = table.Column<int>(nullable: true),
            //        cha_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cha_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        cha_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cha_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_cha_chavesDeAcesso", x => x.cha_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_cha_chavesDeAcesso_tb_lid_liberacaoDelivery",
            //            column: x => x.cha_lid_n_codigo,
            //            principalTable: "tb_lid_liberacaoDelivery",
            //            principalColumn: "lid_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_cha_chavesDeAcesso_tb_lip_liberacaoPrestador",
            //            column: x => x.cha_lip_n_codigo,
            //            principalTable: "tb_lip_liberacaoPrestador",
            //            principalColumn: "lip_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_cha_chavesDeAcesso_tb_liv_liberacaoVisitante",
            //            column: x => x.cha_liv_n_codigo,
            //            principalTable: "tb_liv_liberacaoVisitante",
            //            principalColumn: "liv_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_avp_avisoPrestador",
            //    columns: table => new
            //    {
            //        avp_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        avp_cav_n_codigo = table.Column<int>(nullable: true),
            //        avp_b_lidoNaoLido = table.Column<bool>(nullable: true),
            //        avp_pse_n_codigo = table.Column<int>(nullable: true),
            //        avp_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        avp_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        avp_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        avp_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        avp_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_avp_avisoPrestador", x => x.avp_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_avp_avisoPrestador_tb_cav_categorizacaoAviso",
            //            column: x => x.avp_cav_n_codigo,
            //            principalTable: "tb_cav_categorizacaoAviso",
            //            principalColumn: "cav_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_avp_avisoPrestador_tb_pse_prestadorServico",
            //            column: x => x.avp_pse_n_codigo,
            //            principalTable: "tb_pse_prestadorServico",
            //            principalColumn: "pse_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_avv_avisoVisitante",
            //    columns: table => new
            //    {
            //        avv_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        avv_cav_n_codigo = table.Column<int>(nullable: true),
            //        avv_b_lidoNaoLido = table.Column<bool>(nullable: true),
            //        avv_vis_n_codigo = table.Column<int>(nullable: true),
            //        avv_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        avv_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        avv_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        avv_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        avv_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_avv_n_codigo", x => x.avv_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_avv_avisoVisitante_tb_cav_categorizacaoAviso",
            //            column: x => x.avv_cav_n_codigo,
            //            principalTable: "tb_cav_categorizacaoAviso",
            //            principalColumn: "cav_n_codigo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_avv_avisoVisitante_tb_vis_visitante",
            //            column: x => x.avv_vis_n_codigo,
            //            principalTable: "tb_vis_visitante",
            //            principalColumn: "vis_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tb_cac_controleAcesso",
            //    columns: table => new
            //    {
            //        cac_n_codigo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        cac_mor_n_codigo = table.Column<int>(nullable: true),
            //        cac_c_descricao = table.Column<string>(unicode: false, nullable: true),
            //        cac_c_numeroCartao = table.Column<string>(unicode: false, nullable: true),
            //        cac_b_ativo = table.Column<bool>(nullable: true),
            //        cac_b_panico = table.Column<bool>(nullable: true),
            //        cac_c_tipo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        cac_c_tipoAcesso = table.Column<string>(unicode: false, nullable: true),
            //        cac_c_senha = table.Column<string>(unicode: false, nullable: true),
            //        cac_vis_n_codigo = table.Column<int>(nullable: true),
            //        cac_pse_n_codigo = table.Column<int>(nullable: true),
            //        cac_c_numeroChave = table.Column<string>(unicode: false, nullable: true),
            //        cac_usu_n_codigo = table.Column<int>(nullable: true),
            //        cac_d_modificacao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cac_c_unique = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        cac_d_atualizado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cac_d_inclusao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cac_c_biometria = table.Column<string>(unicode: false, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_cac_controleAcesso", x => x.cac_n_codigo);
            //        table.ForeignKey(
            //            name: "FK_tb_cac_controleAcesso_tb_mor_Morador",
            //            column: x => x.cac_mor_n_codigo,
            //            principalTable: "tb_mor_Morador",
            //            principalColumn: "mor_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_cac_controleAcesso_tb_pse_prestadorServico",
            //            column: x => x.cac_pse_n_codigo,
            //            principalTable: "tb_pse_prestadorServico",
            //            principalColumn: "pse_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_tb_cac_controleAcesso_tb_vis_visitante",
            //            column: x => x.cac_vis_n_codigo,
            //            principalTable: "tb_vis_visitante",
            //            principalColumn: "vis_n_codigo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_ate_atendimento_ate_ope_n_preferencial",
            //    table: "tb_ate_atendimento",
            //    column: "ate_ope_n_preferencial");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_ate_atendimento_ate_pec_n_codigo",
            //    table: "tb_ate_atendimento",
            //    column: "ate_pec_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_ate_atendimento_ate_tpa_n_codigo",
            //    table: "tb_ate_atendimento",
            //    column: "ate_tpa_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_avg_avisoGrupoFamiliar_avg_cav_n_codigo",
            //    table: "tb_avg_avisoGrupoFamiliar",
            //    column: "avg_cav_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_avg_avisoGrupoFamiliar_avg_grf_n_codigo",
            //    table: "tb_avg_avisoGrupoFamiliar",
            //    column: "avg_grf_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_avi_aviso_avi_ace_n_codigo",
            //    table: "tb_avi_aviso",
            //    column: "avi_ace_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_avi_aviso_avi_emp_n_codigo",
            //    table: "tb_avi_aviso",
            //    column: "avi_emp_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_avi_avisoMorador_avm_ace_n_codigo",
            //    table: "tb_avi_avisoMorador",
            //    column: "avm_ace_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_avi_avisoMorador_avm_cav_n_codigo",
            //    table: "tb_avi_avisoMorador",
            //    column: "avm_cav_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_avi_avisoMorador_avm_mor_n_codigo",
            //    table: "tb_avi_avisoMorador",
            //    column: "avm_mor_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_avp_avisoPrestador_avp_cav_n_codigo",
            //    table: "tb_avp_avisoPrestador",
            //    column: "avp_cav_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_avp_avisoPrestador_avp_pse_n_codigo",
            //    table: "tb_avp_avisoPrestador",
            //    column: "avp_pse_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_avv_avisoVisitante_avv_cav_n_codigo",
            //    table: "tb_avv_avisoVisitante",
            //    column: "avv_cav_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_avv_avisoVisitante_avv_vis_n_codigo",
            //    table: "tb_avv_avisoVisitante",
            //    column: "avv_vis_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_bio_biometria_bio_con_n_codigo",
            //    table: "tb_bio_biometria",
            //    column: "bio_con_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cac_controleAcesso_cac_mor_n_codigo",
            //    table: "tb_cac_controleAcesso",
            //    column: "cac_mor_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cac_controleAcesso_cac_pse_n_codigo",
            //    table: "tb_cac_controleAcesso",
            //    column: "cac_pse_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cac_controleAcesso_cac_vis_n_codigo",
            //    table: "tb_cac_controleAcesso",
            //    column: "cac_vis_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cac_controleAplicacoesCliente_cac_con_n_codigo",
            //    table: "tb_cac_controleAplicacoesCliente",
            //    column: "cac_con_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cae_controleAcessoExcluido_cae_con_n_codigo",
            //    table: "tb_cae_controleAcessoExcluido",
            //    column: "cae_con_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_can_canalLayout_can_lay_n_codigo",
            //    table: "tb_can_canalLayout",
            //    column: "can_lay_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cev_categorizacaoEvento_cev_cev_n_temporizador",
            //    table: "tb_cev_categorizacaoEvento",
            //    column: "cev_cev_n_temporizador");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cha_chavesDeAcesso_cha_lid_n_codigo",
            //    table: "tb_cha_chavesDeAcesso",
            //    column: "cha_lid_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cha_chavesDeAcesso_cha_lip_n_codigo",
            //    table: "tb_cha_chavesDeAcesso",
            //    column: "cha_lip_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cha_chavesDeAcesso_cha_liv_n_codigo",
            //    table: "tb_cha_chavesDeAcesso",
            //    column: "cha_liv_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cid_cidade_cid_est_n_codigo",
            //    table: "tb_cid_cidade",
            //    column: "cid_est_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cla_cabecalhoLayout_cla_cli_n_codigo",
            //    table: "tb_cla_cabecalhoLayout",
            //    column: "cla_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cli_cliente_cli_can_n_access",
            //    table: "tb_cli_cliente",
            //    column: "cli_can_n_access");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cli_cliente_cli_cid_n_codigo",
            //    table: "tb_cli_cliente",
            //    column: "cli_cid_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cli_cliente_cli_emp_n_codigo",
            //    table: "tb_cli_cliente",
            //    column: "cli_emp_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cli_cliente_cli_est_n_codigo",
            //    table: "tb_cli_cliente",
            //    column: "cli_est_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cli_cliente_cli_mol_n_codigo",
            //    table: "tb_cli_cliente",
            //    column: "cli_mol_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_cli_cliente_cli_tcl_n_codigo",
            //    table: "tb_cli_cliente",
            //    column: "cli_tcl_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_con_controladora_con_cli_n_codigo",
            //    table: "tb_con_controladora",
            //    column: "con_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_con_monitoramentoControleAcesso_2",
            //    table: "tb_con_monitoramentoControleAcesso",
            //    column: "con_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_con_monitoramentoControleAcesso_1",
            //    table: "tb_con_monitoramentoControleAcesso",
            //    column: "con_d_evento");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_con_monitoramentoControleAcesso_3",
            //    table: "tb_con_monitoramentoControleAcesso",
            //    column: "con_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_con_monitoramentoControleAcesso_con_pec_n_codigo",
            //    table: "tb_con_monitoramentoControleAcesso",
            //    column: "con_pec_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_ddv_dispositivoDVRCliente_ddv_cli_n_codigo",
            //    table: "tb_ddv_dispositivoDVRCliente",
            //    column: "ddv_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_dpg_disparoPGM_dpg_cgp_n_codigo",
            //    table: "tb_dpg_disparoPGM",
            //    column: "dpg_cgp_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_dpg_disparoPGM_dpg_eqc_n_codigo",
            //    table: "tb_dpg_disparoPGM",
            //    column: "dpg_eqc_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_dpn_dependencias_dpn_ard_n_codigo",
            //    table: "tb_dpn_dependencias",
            //    column: "dpn_ard_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_dpn_dependencias_dpn_cli_n_codigo",
            //    table: "tb_dpn_dependencias",
            //    column: "dpn_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_dpn_dependencias_dpn_ftd_n_codigo",
            //    table: "tb_dpn_dependencias",
            //    column: "dpn_ftd_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_emp_empresa_emp_cid_n_codigo",
            //    table: "tb_emp_empresa",
            //    column: "emp_cid_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_emp_empresa_emp_est_n_codigo",
            //    table: "tb_emp_empresa",
            //    column: "emp_est_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_emp_empresa_emp_fem_n_codigo",
            //    table: "tb_emp_empresa",
            //    column: "emp_fem_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_emp_empresa_emp_mol_n_codigo",
            //    table: "tb_emp_empresa",
            //    column: "emp_mol_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_eno_envioNotificacao_eno_cli_n_codigo",
            //    table: "tb_eno_envioNotificacao",
            //    column: "eno_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_eqc_equipamentoCliente_eqc_cli_n_codigo",
            //    table: "tb_eqc_equipamentoCliente",
            //    column: "eqc_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_eti_entidadeTipo_eti_ent_n_codigo",
            //    table: "tb_eti_entidadeTipo",
            //    column: "eti_ent_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_eti_entidadeTipo_eti_tlc_n_codigo",
            //    table: "tb_eti_entidadeTipo",
            //    column: "eti_tlc_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_eve_evento",
            //    table: "tb_eve_evento",
            //    columns: new[] { "eve_cli_n_codigo", "eve_b_lido" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_fer_feriado_fer_n_codigoCliente",
            //    table: "tb_fer_feriado",
            //    column: "fer_n_codigoCliente");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_gpp_grupoPermissaoOperador_gpp_cli_n_codigo",
            //    table: "tb_gpp_grupoPermissaoOperador",
            //    column: "gpp_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_gpp_grupoPermissaoOperador_gpp_emp_n_codigo",
            //    table: "tb_gpp_grupoPermissaoOperador",
            //    column: "gpp_emp_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_gpp_grupoPermissaoOperador_gpp_mol_n_codigo",
            //    table: "tb_gpp_grupoPermissaoOperador",
            //    column: "gpp_mol_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_gpv_grupoVagas_gpv_cli_n_codigo",
            //    table: "tb_gpv_grupoVagas",
            //    column: "gpv_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_gpv_grupoVagas_gpv_phr_n_codigo",
            //    table: "tb_gpv_grupoVagas",
            //    column: "gpv_phr_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_grf_grupoFamiliar_grf_cli_n_codigo",
            //    table: "tb_grf_grupoFamiliar",
            //    column: "grf_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_grf_grupoFamiliar_grf_fot_n_codigo",
            //    table: "tb_grf_grupoFamiliar",
            //    column: "grf_fot_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_hdi_historicoDispositivo_hdi_con_n_codigo",
            //    table: "tb_hdi_historicoDispositivo",
            //    column: "hdi_con_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_hil_historicoLiberacao_hil_mor_n_codigo",
            //    table: "tb_hil_historicoLiberacao",
            //    column: "hil_mor_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_hor_horario_hor_cli_n_codigo",
            //    table: "tb_hor_horario",
            //    column: "hor_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_lay_layout_lay_cla_n_codigo",
            //    table: "tb_lay_layout",
            //    column: "lay_cla_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_lay_layout_lay_cli_n_codigo",
            //    table: "tb_lay_layout",
            //    column: "lay_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_lay_layout_lay_ddv_n_codigo",
            //    table: "tb_lay_layout",
            //    column: "lay_ddv_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_lbr_logBackupRestauracao_lbr_cli_n_codigo",
            //    table: "tb_lbr_logBackupRestauracao",
            //    column: "lbr_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_lcc_localidadeCliente_lcc_cli_n_codigo",
            //    table: "tb_lcc_localidadeCliente",
            //    column: "lcc_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_lcg_localidadeClienteGrupoFamiliar_lcg_grf_n_codigo",
            //    table: "tb_lcg_localidadeClienteGrupoFamiliar",
            //    column: "lcg_grf_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_lcg_localidadeClienteGrupoFamiliar_lcg_lcc_n_codigo",
            //    table: "tb_lcg_localidadeClienteGrupoFamiliar",
            //    column: "lcg_lcc_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_lid_liberacaoDelivery_lid_mor_n_codigo",
            //    table: "tb_lid_liberacaoDelivery",
            //    column: "lid_mor_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_lip_liberacaoPrestador_lip_mor_n_codigo",
            //    table: "tb_lip_liberacaoPrestador",
            //    column: "lip_mor_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_liv_liberacaoVisitante_liv_mor_n_codigo",
            //    table: "tb_liv_liberacaoVisitante",
            //    column: "liv_mor_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_liv_liberacaoVisitante_liv_vis_n_codigo",
            //    table: "tb_liv_liberacaoVisitante",
            //    column: "liv_vis_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_moc_motivoOcorrenciaCliente_moc_cli_n_codigo",
            //    table: "tb_moc_motivoOcorrenciaCliente",
            //    column: "moc_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_mon_monitoramento_mon_cev_n_codigo",
            //    table: "tb_mon_monitoramento",
            //    column: "mon_cev_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_mon_monitoramento_mon_cli_n_codigo",
            //    table: "tb_mon_monitoramento",
            //    column: "mon_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_mon_monitoramento_mon_eve_n_codigo",
            //    table: "tb_mon_monitoramento",
            //    column: "mon_eve_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_mon_monitoramento_mon_pec_n_codigo",
            //    table: "tb_mon_monitoramento",
            //    column: "mon_pec_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_mon_monitoramento_mon_stm_n_codigo",
            //    table: "tb_mon_monitoramento",
            //    column: "mon_stm_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_mon_monitoramento_mon_zoc_n_codigo",
            //    table: "tb_mon_monitoramento",
            //    column: "mon_zoc_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_mon_monitoramento",
            //    table: "tb_mon_monitoramento",
            //    columns: new[] { "mon_b_exibido", "mon_d_dataExibicao", "mon_zoc_n_codigo" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_mor_Morador_mor_cli_n_codigo",
            //    table: "tb_mor_Morador",
            //    column: "mor_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_mor_Morador_mor_fot_n_codigo",
            //    table: "tb_mor_Morador",
            //    column: "mor_fot_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_mor_Morador_mor_fot_n_documento",
            //    table: "tb_mor_Morador",
            //    column: "mor_fot_n_documento");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_mor_Morador_mor_grf_n_codigo",
            //    table: "tb_mor_Morador",
            //    column: "mor_grf_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_mpc_mapeamentoPontoAcesso_mpc_cli_n_codigo",
            //    table: "tb_mpc_mapeamentoPontoAcesso",
            //    column: "mpc_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_not_notificacao_not_avi_n_codigo",
            //    table: "tb_not_notificacao",
            //    column: "not_avi_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_not_notificacao_not_avi_n_codigoEmpresa",
            //    table: "tb_not_notificacao",
            //    column: "not_avi_n_codigoEmpresa");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_not_notificacao_not_ope_n_codigo",
            //    table: "tb_not_notificacao",
            //    column: "not_ope_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_not_notificacaoApp_not_eno_n_codigo",
            //    table: "tb_not_notificacaoApp",
            //    column: "not_eno_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_not_notificacaoApp_not_zec_n_codigo",
            //    table: "tb_not_notificacaoApp",
            //    column: "not_zec_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_ope_operador_ope_ace_n_codigo",
            //    table: "tb_ope_operador",
            //    column: "ope_ace_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_ope_operador_ope_cid_n_codigo",
            //    table: "tb_ope_operador",
            //    column: "ope_cid_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_ope_operador_ope_emp_n_codigo",
            //    table: "tb_ope_operador",
            //    column: "ope_emp_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_ope_operador_ope_est_n_codigo",
            //    table: "tb_ope_operador",
            //    column: "ope_est_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_ope_operador_ope_mol_n_codigo",
            //    table: "tb_ope_operador",
            //    column: "ope_mol_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_opl_operadorLocal_opl_cli_n_codigo",
            //    table: "tb_opl_operadorLocal",
            //    column: "opl_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_opl_operadorLocal_opl_gpp_n_codigo",
            //    table: "tb_opl_operadorLocal",
            //    column: "opl_gpp_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_opo_operadorOnline_opo_cli_n_codigo",
            //    table: "tb_opo_operadorOnline",
            //    column: "opo_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pan_panicoApp_pan_mor_n_codigo",
            //    table: "tb_pan_panicoApp",
            //    column: "pan_mor_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_par_parametrosEmpresa_par_emp_n_codigo",
            //    table: "tb_par_parametrosEmpresa",
            //    column: "par_emp_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pec_permissaoCliente_pec_cli_n_codigo",
            //    table: "tb_pec_permissaoCliente",
            //    column: "pec_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pec_permissaoCliente_pec_ope_n_codigo",
            //    table: "tb_pec_permissaoCliente",
            //    column: "pec_ope_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pet_pet_pet_fot_n_codigo",
            //    table: "tb_pet_pet",
            //    column: "pet_fot_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pet_pet_pet_grf_n_codigo",
            //    table: "tb_pet_pet",
            //    column: "pet_grf_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pet_pet_pet_rac_n_codigo",
            //    table: "tb_pet_pet",
            //    column: "pet_rac_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pgc_pgmCliente_pgc_cli_n_codigo",
            //    table: "tb_pgc_pgmCliente",
            //    column: "pgc_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pgc_pgmCliente_pgc_cpg_n_codigo",
            //    table: "tb_pgc_pgmCliente",
            //    column: "pgc_cpg_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pgc_pgmCliente",
            //    table: "tb_pgc_pgmCliente",
            //    columns: new[] { "pgc_eqc_n_codigo", "pgc_cpg_n_codigo" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pgp_permissoesGrupo_pgp_gpp_n_codigo",
            //    table: "tb_pgp_permissoesGrupo",
            //    column: "pgp_gpp_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pgp_permissoesGrupo_pgp_top_n_codigo",
            //    table: "tb_pgp_permissoesGrupo",
            //    column: "pgp_top_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_phr_perfilHorario_phr_cli_n_codigo",
            //    table: "tb_phr_perfilHorario",
            //    column: "phr_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_phr_perfilHorario_phr_hor_n_codigo",
            //    table: "tb_phr_perfilHorario",
            //    column: "phr_hor_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_plc_pontoLayoutCliente_plc_cla_n_codigo",
            //    table: "tb_plc_pontoLayoutCliente",
            //    column: "plc_cla_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_plc_pontoLayoutCliente_plc_cli_n_codigo",
            //    table: "tb_plc_pontoLayoutCliente",
            //    column: "plc_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_poa_portaAlarme_poa_emp_n_codigo",
            //    table: "tb_poa_portaAlarme",
            //    column: "poa_emp_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_por_portasStream_por_cli_n_codigo",
            //    table: "tb_por_portasStream",
            //    column: "por_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pro_proprietario_pro_ace_n_codigo",
            //    table: "tb_pro_proprietario",
            //    column: "pro_ace_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pro_proprietario_pro_cid_n_codigo",
            //    table: "tb_pro_proprietario",
            //    column: "pro_cid_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pro_proprietario_pro_est_n_codigo",
            //    table: "tb_pro_proprietario",
            //    column: "pro_est_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pse_prestadorServico_pse_cli_n_codigo",
            //    table: "tb_pse_prestadorServico",
            //    column: "pse_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pse_prestadorServico_pse_fot_n_codigo",
            //    table: "tb_pse_prestadorServico",
            //    column: "pse_fot_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pse_prestadorServico_pse_fot_n_documento",
            //    table: "tb_pse_prestadorServico",
            //    column: "pse_fot_n_documento");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pse_prestadorServico_pse_gpv_n_codigo",
            //    table: "tb_pse_prestadorServico",
            //    column: "pse_gpv_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pta_pontosAcesso_pta_cla_n_codigo",
            //    table: "tb_pta_pontosAcesso",
            //    column: "pta_cla_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pta_pontosAcesso_pta_cli_n_codigo",
            //    table: "tb_pta_pontosAcesso",
            //    column: "pta_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pta_pontosAcesso_pta_con_n_codigo",
            //    table: "tb_pta_pontosAcesso",
            //    column: "pta_con_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_pta_pontosAcesso_pta_lay_n_codigo",
            //    table: "tb_pta_pontosAcesso",
            //    column: "pta_lay_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_ral_ramalLayout_ral_cla_n_codigo",
            //    table: "tb_ral_ramalLayout",
            //    column: "ral_cla_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_ral_ramalLayout_ral_lay_n_codigo",
            //    table: "tb_ral_ramalLayout",
            //    column: "ral_lay_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_rel_responsavelLocacaoSaloes_rel_cli_n_codigo",
            //    table: "tb_rel_responsavelLocacaoSaloes",
            //    column: "rel_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_res_registroSalao_res_dpn_n_codigo",
            //    table: "tb_res_registroSalao",
            //    column: "res_dpn_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_res_registroSalao_res_mor_n_codigo",
            //    table: "tb_res_registroSalao",
            //    column: "res_mor_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_rop_ramalOperador_rop_ope_n_codigo",
            //    table: "tb_rop_ramalOperador",
            //    column: "rop_ope_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_sin_sincronizacaoPlacas_sin_cli_n_codigo",
            //    table: "tb_sin_sincronizacaoPlacas",
            //    column: "sin_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_soz_solicitarZelador_soz_fap_n_codigo",
            //    table: "tb_soz_solicitarZelador",
            //    column: "soz_fap_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_soz_solicitarZelador_soz_mor_n_codigo",
            //    table: "tb_soz_solicitarZelador",
            //    column: "soz_mor_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_upe_usuarioAPPpermissao_upe_mor_n_codigo",
            //    table: "tb_upe_usuarioAPPpermissao",
            //    column: "upe_mor_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_upe_usuarioAPPpermissao_upe_per_n_codigo",
            //    table: "tb_upe_usuarioAPPpermissao",
            //    column: "upe_per_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_usu_UsuarioApp_usu_mor_n_codigo",
            //    table: "tb_usu_UsuarioApp",
            //    column: "usu_mor_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_vec_veiculo_vec_grf_n_codigo",
            //    table: "tb_vec_veiculo",
            //    column: "vec_grf_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_vec_veiculo_vec_mav_n_codigo",
            //    table: "tb_vec_veiculo",
            //    column: "vec_mav_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_vic_vigilanteCliente_vic_cli_n_codigo",
            //    table: "tb_vic_vigilanteCliente",
            //    column: "vic_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_vid_video_vid_con_n_codigo",
            //    table: "tb_vid_video",
            //    column: "vid_con_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_vis_visitante_vis_cli_n_codigo",
            //    table: "tb_vis_visitante",
            //    column: "vis_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_vis_visitante_vis_fot_n_codigo",
            //    table: "tb_vis_visitante",
            //    column: "vis_fot_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_vis_visitante_vis_fot_n_documento",
            //    table: "tb_vis_visitante",
            //    column: "vis_fot_n_documento");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_vis_visitante_vis_gpv_n_codigo",
            //    table: "tb_vis_visitante",
            //    column: "vis_gpv_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_vis_visitasApp_vis_mor_n_codigo",
            //    table: "tb_vis_visitasApp",
            //    column: "vis_mor_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_zec_zeladorCliente_zec_ace_n_codigo",
            //    table: "tb_zec_zeladorCliente",
            //    column: "zec_ace_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_zec_zeladorCliente_zec_cli_n_codigo",
            //    table: "tb_zec_zeladorCliente",
            //    column: "zec_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_zec_zeladorCliente_zec_mol_n_codigo",
            //    table: "tb_zec_zeladorCliente",
            //    column: "zec_mol_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_zec_zeladorCliente_zec_mor_n_codigo",
            //    table: "tb_zec_zeladorCliente",
            //    column: "zec_mor_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_zec_zeladorCliente_zec_mos_n_codigo",
            //    table: "tb_zec_zeladorCliente",
            //    column: "zec_mos_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_zoc_zoneamentoCliente_zoc_cla_n_codigo",
            //    table: "tb_zoc_zoneamentoCliente",
            //    column: "zoc_cla_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_zoc_zoneamentoCliente_zoc_cli_n_codigo",
            //    table: "tb_zoc_zoneamentoCliente",
            //    column: "zoc_cli_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_zoc_zoneamentoCliente_zoc_eqc_n_codigo",
            //    table: "tb_zoc_zoneamentoCliente",
            //    column: "zoc_eqc_n_codigo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tb_zoc_zoneamentoCliente_zoc_lay_n_codigo",
            //    table: "tb_zoc_zoneamentoCliente",
            //    column: "zoc_lay_n_codigo");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_tb_avi_avisoMorador_tb_mor_Morador",
            //    table: "tb_avi_avisoMorador",
            //    column: "avm_mor_n_codigo",
            //    principalTable: "tb_mor_Morador",
            //    principalColumn: "mor_n_codigo",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_tb_zec_zeladorCliente_tb_mor_Morador",
            //    table: "tb_zec_zeladorCliente",
            //    column: "zec_mor_n_codigo",
            //    principalTable: "tb_mor_Morador",
            //    principalColumn: "mor_n_codigo",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_tb_zec_zeladorCliente_tb_cli_cliente",
            //    table: "tb_zec_zeladorCliente",
            //    column: "zec_cli_n_codigo",
            //    principalTable: "tb_cli_cliente",
            //    principalColumn: "cli_n_codigo",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_tb_dpn_dependencia_tb_cli_cliente",
            //    table: "tb_dpn_dependencias",
            //    column: "dpn_cli_n_codigo",
            //    principalTable: "tb_cli_cliente",
            //    principalColumn: "cli_n_codigo",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_tb_cli_cliente_tb_can_canalLayout",
            //    table: "tb_cli_cliente",
            //    column: "cli_can_n_access",
            //    principalTable: "tb_can_canalLayout",
            //    principalColumn: "can_n_codigo",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_cli_cliente_tb_emp_empresa",
                table: "tb_cli_cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_can_canalLayout_tb_lay_layout",
                table: "tb_can_canalLayout");

            migrationBuilder.DropTable(
                name: "tb_aba_agendaBackupAutomatico");

            migrationBuilder.DropTable(
                name: "tb_apa_aplicacoesAlarme");

            migrationBuilder.DropTable(
                name: "tb_ate_atendimento");

            migrationBuilder.DropTable(
                name: "tb_avg_avisoGrupoFamiliar");

            migrationBuilder.DropTable(
                name: "tb_avi_avisoMorador");

            migrationBuilder.DropTable(
                name: "tb_avp_avisoPrestador");

            migrationBuilder.DropTable(
                name: "tb_avv_avisoVisitante");

            migrationBuilder.DropTable(
                name: "tb_bio_biometria");

            migrationBuilder.DropTable(
                name: "tb_cac_controleAcesso");

            migrationBuilder.DropTable(
                name: "tb_cac_controleAplicacoesCliente");

            migrationBuilder.DropTable(
                name: "tb_cae_controleAcessoExcluido");

            migrationBuilder.DropTable(
                name: "tb_cha_chavesDeAcesso");

            migrationBuilder.DropTable(
                name: "tb_csi_configuracaoSincronizacao");

            migrationBuilder.DropTable(
                name: "tb_dpg_disparoPGM");

            migrationBuilder.DropTable(
                name: "tb_ema_email");

            migrationBuilder.DropTable(
                name: "tb_err_erro");

            migrationBuilder.DropTable(
                name: "tb_eti_entidadeTipo");

            migrationBuilder.DropTable(
                name: "tb_eva_eventoAcesso");

            migrationBuilder.DropTable(
                name: "tb_exc_exclusoes");

            migrationBuilder.DropTable(
                name: "tb_fer_feriado");

            migrationBuilder.DropTable(
                name: "tb_hdi_historicoDispositivo");

            migrationBuilder.DropTable(
                name: "tb_hil_historicoLiberacao");

            migrationBuilder.DropTable(
                name: "tb_lbr_logBackupRestauracao");

            migrationBuilder.DropTable(
                name: "tb_lcg_localidadeClienteGrupoFamiliar");

            migrationBuilder.DropTable(
                name: "tb_lsm_logSMS");

            migrationBuilder.DropTable(
                name: "tb_moc_motivoOcorrenciaCliente");

            migrationBuilder.DropTable(
                name: "tb_mon_monitoramento");

            migrationBuilder.DropTable(
                name: "tb_mpc_mapeamentoPontoAcesso");

            migrationBuilder.DropTable(
                name: "tb_not_notificacao");

            migrationBuilder.DropTable(
                name: "tb_not_notificacaoApp");

            migrationBuilder.DropTable(
                name: "tb_opl_operadorLocal");

            migrationBuilder.DropTable(
                name: "tb_opo_operadorOnline");

            migrationBuilder.DropTable(
                name: "tb_pan_panicoApp");

            migrationBuilder.DropTable(
                name: "tb_par_parametros");

            migrationBuilder.DropTable(
                name: "tb_par_parametrosEmpresa");

            migrationBuilder.DropTable(
                name: "tb_pec_permissaoCliente");

            migrationBuilder.DropTable(
                name: "tb_per_perfil");

            migrationBuilder.DropTable(
                name: "tb_pet_pet");

            migrationBuilder.DropTable(
                name: "tb_pgc_pgmCliente");

            migrationBuilder.DropTable(
                name: "tb_pgp_permissoesGrupo");

            migrationBuilder.DropTable(
                name: "tb_plc_pontoLayoutCliente");

            migrationBuilder.DropTable(
                name: "tb_poa_portaAlarme");

            migrationBuilder.DropTable(
                name: "tb_por_portasStream");

            migrationBuilder.DropTable(
                name: "tb_pro_proprietario");

            migrationBuilder.DropTable(
                name: "tb_pta_pontosAcesso");

            migrationBuilder.DropTable(
                name: "tb_ral_ramalLayout");

            migrationBuilder.DropTable(
                name: "tb_rel_responsavelLocacaoSaloes");

            migrationBuilder.DropTable(
                name: "tb_res_registroSalao");

            migrationBuilder.DropTable(
                name: "tb_rop_ramalOperador");

            migrationBuilder.DropTable(
                name: "tb_seb_serviceBroker");

            migrationBuilder.DropTable(
                name: "tb_sin_sincronizacaoOffline");

            migrationBuilder.DropTable(
                name: "tb_sin_sincronizacaoPlacas");

            migrationBuilder.DropTable(
                name: "tb_sol_solicitacaoAberturaRemota");

            migrationBuilder.DropTable(
                name: "tb_soz_solicitarZelador");

            migrationBuilder.DropTable(
                name: "tb_upe_usuarioAPPpermissao");

            migrationBuilder.DropTable(
                name: "tb_usu_UsuarioApp");

            migrationBuilder.DropTable(
                name: "tb_vec_veiculo");

            migrationBuilder.DropTable(
                name: "tb_vic_vigilanteCliente");

            migrationBuilder.DropTable(
                name: "tb_vid_video");

            migrationBuilder.DropTable(
                name: "tb_voi_voip");

            migrationBuilder.DropTable(
                name: "tb_tpa_tipoAtendimento");

            migrationBuilder.DropTable(
                name: "tb_cav_categorizacaoAviso");

            migrationBuilder.DropTable(
                name: "tb_pse_prestadorServico");

            migrationBuilder.DropTable(
                name: "tb_vis_visitante");

            migrationBuilder.DropTable(
                name: "tb_lid_liberacaoDelivery");

            migrationBuilder.DropTable(
                name: "tb_lip_liberacaoPrestador");

            migrationBuilder.DropTable(
                name: "tb_liv_liberacaoVisitante");

            migrationBuilder.DropTable(
                name: "tb_ent_entidade");

            migrationBuilder.DropTable(
                name: "tb_lcc_localidadeCliente");

            migrationBuilder.DropTable(
                name: "tb_cev_categorizacaoEvento");

            migrationBuilder.DropTable(
                name: "tb_eve_evento");

            migrationBuilder.DropTable(
                name: "tb_stm_statusMonitoramento");

            migrationBuilder.DropTable(
                name: "tb_zoc_zoneamentoCliente");

            migrationBuilder.DropTable(
                name: "tb_avi_aviso");

            migrationBuilder.DropTable(
                name: "tb_avi_avisoEmpresa");

            migrationBuilder.DropTable(
                name: "tb_eno_envioNotificacao");

            migrationBuilder.DropTable(
                name: "tb_zec_zeladorCliente");

            migrationBuilder.DropTable(
                name: "tb_rac_raca");

            migrationBuilder.DropTable(
                name: "tb_cpg_comandoPGM");

            migrationBuilder.DropTable(
                name: "tb_gpp_grupoPermissaoOperador");

            migrationBuilder.DropTable(
                name: "tb_top_tipoPermissaoOperador");

            migrationBuilder.DropTable(
                name: "tb_con_controladora");

            migrationBuilder.DropTable(
                name: "tb_dpn_dependencias");

            migrationBuilder.DropTable(
                name: "tb_ope_operador");

            migrationBuilder.DropTable(
                name: "tb_fap_fotoApp");

            migrationBuilder.DropTable(
                name: "tb_per_permissoes");

            migrationBuilder.DropTable(
                name: "tb_mav_marcaVeiculo");

            migrationBuilder.DropTable(
                name: "tb_con_monitoramentoControleAcesso");

            migrationBuilder.DropTable(
                name: "tb_gpv_grupoVagas");

            migrationBuilder.DropTable(
                name: "tb_vis_visitasApp");

            migrationBuilder.DropTable(
                name: "tb_eqc_equipamentoCliente");

            migrationBuilder.DropTable(
                name: "tb_mos_moduloOrdemServicoLiberado");

            migrationBuilder.DropTable(
                name: "tb_ard_arquivoDependencias");

            migrationBuilder.DropTable(
                name: "tb_ftd_fotoDependencia");

            migrationBuilder.DropTable(
                name: "tb_ace_acesso");

            migrationBuilder.DropTable(
                name: "tb_pec_processoExclusaoCliente");

            migrationBuilder.DropTable(
                name: "tb_phr_perfilHorario");

            migrationBuilder.DropTable(
                name: "tb_mor_Morador");

            migrationBuilder.DropTable(
                name: "tb_hor_horario");

            migrationBuilder.DropTable(
                name: "tb_grf_grupoFamiliar");

            migrationBuilder.DropTable(
                name: "tb_fot_foto");

            migrationBuilder.DropTable(
                name: "tb_emp_empresa");

            migrationBuilder.DropTable(
                name: "tb_fem_fotoEmpresa");

            migrationBuilder.DropTable(
                name: "tb_lay_layout");

            migrationBuilder.DropTable(
                name: "tb_cla_cabecalhoLayout");

            migrationBuilder.DropTable(
                name: "tb_ddv_dispositivoDVRCliente");

            migrationBuilder.DropTable(
                name: "tb_cli_cliente");

            migrationBuilder.DropTable(
                name: "tb_can_canalLayout");

            migrationBuilder.DropTable(
                name: "tb_cid_cidade");

            migrationBuilder.DropTable(
                name: "tb_mol_modulosLiberados");

            migrationBuilder.DropTable(
                name: "tb_tcl_tipoCliente");

            migrationBuilder.DropTable(
                name: "tb_est_estado");
        }
    }
}
