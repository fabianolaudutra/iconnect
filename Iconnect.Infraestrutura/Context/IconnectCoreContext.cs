using Iconnect.Infraestrutura.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Context
{
    public partial class IconnectCoreContext : DbContext
    {
        List<string> tabelasUpper = new List<string>() {
            "Iconnect.Infraestrutura.Models.tb_ace_acesso",
            "Iconnect.Infraestrutura.Models.tb_par_parametros",
            "Iconnect.Infraestrutura.Models.tb_csr_connectionSignalR",
            "Iconnect.Infraestrutura.Models.tb_cac_controleAcesso",
            "Iconnect.Infraestrutura.Models.tb_bio_biometria",
            "Iconnect.Infraestrutura.Models.tb_dva_duvidasApp"};
        List<string> propriedades = new List<string>() {
            "cli_c_senha", "ddv_c_usuario" , "zec_ace_c_login","con_c_usuario","opl_c_login","rel_c_login",
            "ddv_c_senha","cac_c_senha","con_c_senha", "opl_c_senha", "rel_c_senha","cli_c_senhaappgarenconnect","cli_c_dominiosip","cli_c_senhasip","ema_c_corpo",
            "ema_c_destinatario","ema_c_copiaoculta","cal_c_website","cat_c_link","fot_c_url" };

        private readonly IHostingEnvironment _env;

        public IconnectCoreContext(IHostingEnvironment env)
        {
            _env = env;
            Database.SetCommandTimeout(150000);
        }

        #region DbSet Tabelas
        public virtual DbSet<tb_aba_agendaBackupAutomatico> tb_aba_agendaBackupAutomatico { get; set; }
        public virtual DbSet<tb_ace_acesso> tb_ace_acesso { get; set; }
        public virtual DbSet<tb_apa_aplicacoesAlarme> tb_apa_aplicacoesAlarme { get; set; }
        public virtual DbSet<tb_ard_arquivoDependencias> tb_ard_arquivoDependencias { get; set; }
        public virtual DbSet<tb_ate_atendimento> tb_ate_atendimento { get; set; }
        public virtual DbSet<tb_avg_avisoGrupoFamiliar> tb_avg_avisoGrupoFamiliar { get; set; }
        public virtual DbSet<tb_avi_aviso> tb_avi_aviso { get; set; }
        public virtual DbSet<tb_avi_avisoEmpresa> tb_avi_avisoEmpresa { get; set; }
        public virtual DbSet<tb_dis_distribuidor> tb_dis_distribuidor { get; set; }
        public virtual DbSet<tb_avi_avisoMorador> tb_avi_avisoMorador { get; set; }
        public virtual DbSet<tb_avp_avisoPrestador> tb_avp_avisoPrestador { get; set; }
        public virtual DbSet<tb_avv_avisoVisitante> tb_avv_avisoVisitante { get; set; }
        public virtual DbSet<tb_bio_biometria> tb_bio_biometria { get; set; }
        public virtual DbSet<tb_cac_controleAcesso> tb_cac_controleAcesso { get; set; }
        public virtual DbSet<tb_cac_controleAplicacoesCliente> tb_cac_controleAplicacoesCliente { get; set; }
        public virtual DbSet<tb_cae_controleAcessoExcluido> tb_cae_controleAcessoExcluido { get; set; }
        public virtual DbSet<tb_can_canalLayout> tb_can_canalLayout { get; set; }
        public virtual DbSet<tb_cav_categorizacaoAviso> tb_cav_categorizacaoAviso { get; set; }
        public virtual DbSet<tb_cev_categorizacaoEvento> tb_cev_categorizacaoEvento { get; set; }
        public virtual DbSet<tb_cha_chavesDeAcesso> tb_cha_chavesDeAcesso { get; set; }
        public virtual DbSet<tb_cid_cidade> tb_cid_cidade { get; set; }
        public virtual DbSet<tb_cla_cabecalhoLayout> tb_cla_cabecalhoLayout { get; set; }
        public virtual DbSet<tb_cli_cliente> tb_cli_cliente { get; set; }
        public virtual DbSet<tb_con_controladora> tb_con_controladora { get; set; }
        public virtual DbSet<tb_con_monitoramentoControleAcesso> tb_con_monitoramentoControleAcesso { get; set; }
        public virtual DbSet<tb_cpg_comandoPGM> tb_cpg_comandoPGM { get; set; }
        public virtual DbSet<tb_csi_configuracaoSincronizacao> tb_csi_configuracaoSincronizacao { get; set; }
        public virtual DbSet<tb_ddv_dispositivoDVRCliente> tb_ddv_dispositivoDVRCliente { get; set; }
        public virtual DbSet<tb_dpg_disparoPGM> tb_dpg_disparoPGM { get; set; }
        public virtual DbSet<tb_dpn_dependencias> tb_dpn_dependencias { get; set; }
        public virtual DbSet<tb_dow_downloads_arquivos> tb_dow_downloads_arquivos { get; set; }
        public virtual DbSet<tb_ema_email> tb_ema_email { get; set; }
        public virtual DbSet<tb_emp_empresa> tb_emp_empresa { get; set; }
        public virtual DbSet<tb_eno_envioNotificacao> tb_eno_envioNotificacao { get; set; }
        public virtual DbSet<tb_ent_entidade> tb_ent_entidade { get; set; }
        public virtual DbSet<tb_eqc_equipamentoCliente> tb_eqc_equipamentoCliente { get; set; }
        public virtual DbSet<tb_err_erro> tb_err_erro { get; set; }
        public virtual DbSet<tb_est_estado> tb_est_estado { get; set; }
        public virtual DbSet<tb_eti_entidadeTipo> tb_eti_entidadeTipo { get; set; }
        public virtual DbSet<tb_eva_eventoAcesso> tb_eva_eventoAcesso { get; set; }
        public virtual DbSet<tb_eve_evento> tb_eve_evento { get; set; }
        public virtual DbSet<tb_exc_exclusoes> tb_exc_exclusoes { get; set; }
        public virtual DbSet<tb_fap_fotoApp> tb_fap_fotoApp { get; set; }
        public virtual DbSet<tb_fem_fotoEmpresa> tb_fem_fotoEmpresa { get; set; }
        public virtual DbSet<tb_fer_feriado> tb_fer_feriado { get; set; }
        public virtual DbSet<tb_fot_foto> tb_fot_foto { get; set; }
        public virtual DbSet<tb_ftd_fotoDependencia> tb_ftd_fotoDependencia { get; set; }
        public virtual DbSet<tb_gpp_grupoPermissaoOperador> tb_gpp_grupoPermissaoOperador { get; set; }
        public virtual DbSet<tb_gpv_grupoVagas> tb_gpv_grupoVagas { get; set; }
        public virtual DbSet<tb_grf_grupoFamiliar> tb_grf_grupoFamiliar { get; set; }
        public virtual DbSet<tb_hdi_historicoDispositivo> tb_hdi_historicoDispositivo { get; set; }
        public virtual DbSet<tb_hil_historicoLiberacao> tb_hil_historicoLiberacao { get; set; }
        public virtual DbSet<tb_hor_horario> tb_hor_horario { get; set; }
        public virtual DbSet<tb_lay_layout> tb_lay_layout { get; set; }
        public virtual DbSet<tb_lbr_logBackupRestauracao> tb_lbr_logBackupRestauracao { get; set; }
        public virtual DbSet<tb_lcc_localidadeCliente> tb_lcc_localidadeCliente { get; set; }
        public virtual DbSet<tb_lcg_localidadeClienteGrupoFamiliar> tb_lcg_localidadeClienteGrupoFamiliar { get; set; }
        public virtual DbSet<tb_lid_liberacaoDelivery> tb_lid_liberacaoDelivery { get; set; }
        public virtual DbSet<tb_lip_liberacaoPrestador> tb_lip_liberacaoPrestador { get; set; }
        public virtual DbSet<tb_liv_liberacaoVisitante> tb_liv_liberacaoVisitante { get; set; }
        public virtual DbSet<tb_lsm_logSMS> tb_lsm_logSMS { get; set; }
        public virtual DbSet<tb_mav_marcaVeiculo> tb_mav_marcaVeiculo { get; set; }
        public virtual DbSet<tb_mch_monitoramentoControleAcesso_historico> tb_mch_monitoramentoControleAcesso_historico { get; set; }
        public virtual DbSet<tb_moc_motivoOcorrenciaCliente> tb_moc_motivoOcorrenciaCliente { get; set; }
        public virtual DbSet<tb_mol_modulosLiberados> tb_mol_modulosLiberados { get; set; }
        public virtual DbSet<tb_mon_monitoramento> tb_mon_monitoramento { get; set; }
        public virtual DbSet<tb_mor_Morador> tb_mor_Morador { get; set; }
        public virtual DbSet<tb_mos_moduloOrdemServicoLiberado> tb_mos_moduloOrdemServicoLiberado { get; set; }
        public virtual DbSet<tb_mpc_mapeamentoPontoAcesso> tb_mpc_mapeamentoPontoAcesso { get; set; }
        public virtual DbSet<tb_not_notificacao> tb_not_notificacao { get; set; }
        public virtual DbSet<tb_not_notificacaoApp> tb_not_notificacaoApp { get; set; }
        public virtual DbSet<tb_ope_operador> tb_ope_operador { get; set; }
        public virtual DbSet<tb_opl_operadorLocal> tb_opl_operadorLocal { get; set; }
        public virtual DbSet<tb_opo_operadorOnline> tb_opo_operadorOnline { get; set; }
        public virtual DbSet<tb_pan_panicoApp> tb_pan_panicoApp { get; set; }
        public virtual DbSet<tb_par_parametros> tb_par_parametros { get; set; }
        public virtual DbSet<tb_par_parametrosEmpresa> tb_par_parametrosEmpresa { get; set; }
        public virtual DbSet<tb_pec_permissaoCliente> tb_pec_permissaoCliente { get; set; }
        public virtual DbSet<tb_pec_processoExclusaoCliente> tb_pec_processoExclusaoCliente { get; set; }
        public virtual DbSet<tb_per_perfil> tb_per_perfil { get; set; }
        public virtual DbSet<tb_per_permissoes> tb_per_permissoes { get; set; }
        public virtual DbSet<tb_pet_pet> tb_pet_pet { get; set; }
        public virtual DbSet<tb_pgc_pgmCliente> tb_pgc_pgmCliente { get; set; }
        public virtual DbSet<tb_pgp_permissoesGrupo> tb_pgp_permissoesGrupo { get; set; }
        public virtual DbSet<tb_phr_perfilHorario> tb_phr_perfilHorario { get; set; }
        public virtual DbSet<tb_plc_pontoLayoutCliente> tb_plc_pontoLayoutCliente { get; set; }
        public virtual DbSet<tb_poa_portaAlarme> tb_poa_portaAlarme { get; set; }
        public virtual DbSet<tb_por_portasStream> tb_por_portasStream { get; set; }
        public virtual DbSet<tb_pro_proprietario> tb_pro_proprietario { get; set; }
        public virtual DbSet<tb_pse_prestadorServico> tb_pse_prestadorServico { get; set; }
        public virtual DbSet<tb_pta_pontosAcesso> tb_pta_pontosAcesso { get; set; }
        public virtual DbSet<tb_rac_raca> tb_rac_raca { get; set; }
        public virtual DbSet<tb_ral_ramalLayout> tb_ral_ramalLayout { get; set; }
        public virtual DbSet<tb_rel_responsavelLocacaoSaloes> tb_rel_responsavelLocacaoSaloes { get; set; }
        public virtual DbSet<tb_res_registroSalao> tb_res_registroSalao { get; set; }
        public virtual DbSet<tb_rop_ramalOperador> tb_rop_ramalOperador { get; set; }
        public virtual DbSet<tb_seb_serviceBroker> tb_seb_serviceBroker { get; set; }
        public virtual DbSet<tb_sin_sincronizacaoOffline> tb_sin_sincronizacaoOffline { get; set; }
        public virtual DbSet<tb_sin_sincronizacaoPlacas> tb_sin_sincronizacaoPlacas { get; set; }
        public virtual DbSet<tb_sol_solicitacaoAberturaRemota> tb_sol_solicitacaoAberturaRemota { get; set; }
        public virtual DbSet<tb_soz_solicitarZelador> tb_soz_solicitarZelador { get; set; }
        public virtual DbSet<tb_stm_statusMonitoramento> tb_stm_statusMonitoramento { get; set; }
        public virtual DbSet<tb_tcl_tipoCliente> tb_tcl_tipoCliente { get; set; }
        public virtual DbSet<tb_per_permissionamento> tb_per_permissionamento { get; set; }
        public virtual DbSet<tb_ace_per_acessoPermissionamento> tb_ace_per_acessoPermissionamento { get; set; }
        public virtual DbSet<tb_per_per_perfilPermissionamento> tb_per_per_perfilPermissionamento { get; set; }
        public virtual DbSet<tb_top_tipoPermissaoOperador> tb_top_tipoPermissaoOperador { get; set; }
        public virtual DbSet<tb_tpa_tipoAtendimento> tb_tpa_tipoAtendimento { get; set; }
        public virtual DbSet<tb_upa_uploadAPK> tb_upa_uploadAPK { get; set; }
        public virtual DbSet<tb_pop_perfilOperador> tb_pop_perfilOperador { get; set; }
        public virtual DbSet<tb_afa_afastamento> tb_afa_afastamento { get; set; }
        public virtual DbSet<tb_upe_usuarioAPPpermissao> tb_upe_usuarioAPPpermissao { get; set; }
        public virtual DbSet<tb_usu_UsuarioApp> tb_usu_UsuarioApp { get; set; }
        public virtual DbSet<tb_vap_versaoApp> tb_vap_versaoApp { get; set; }
        public virtual DbSet<tb_vec_veiculo> tb_vec_veiculo { get; set; }
        public virtual DbSet<tb_vic_vigilanteCliente> tb_vic_vigilanteCliente { get; set; }
        public virtual DbSet<tb_vid_video> tb_vid_video { get; set; }
        public virtual DbSet<tb_vis_visitante> tb_vis_visitante { get; set; }
        public virtual DbSet<tb_vis_visitasApp> tb_vis_visitasApp { get; set; }
        public virtual DbSet<tb_voi_voip> tb_voi_voip { get; set; }
        public virtual DbSet<tb_zec_zeladorCliente> tb_zec_zeladorCliente { get; set; }
        public virtual DbSet<tb_zoc_zoneamentoCliente> tb_zoc_zoneamentoCliente { get; set; }
        public virtual DbSet<vw_aviso> vw_aviso { get; set; }
        public virtual DbSet<vw_avisoEmpresa> vw_avisoEmpresa { get; set; }
        public virtual DbSet<vw_cliente> vw_cliente { get; set; }
        public virtual DbSet<vw_connectGuard> vw_connectGuard { get; set; }
        public virtual DbSet<vw_consultaMaximosPessoas> vw_consultaMaximosPessoas { get; set; }
        public virtual DbSet<vw_empresa> vw_empresa { get; set; }
        public virtual DbSet<vw_licencas> vw_licencas { get; set; }
        public virtual DbSet<vw_notificacaoApp> vw_notificacaoApp { get; set; }
        public virtual DbSet<vw_notificacaoAppGaren> vw_notificacaoAppGaren { get; set; }
        public virtual DbSet<vw_operador> vw_operador { get; set; }
        public virtual DbSet<vw_pessoa> vw_pessoa { get; set; }
        public virtual DbSet<vw_grupo_familiar> vw_grupo_familiar { get; set; }
        public virtual DbSet<vw_pessoasRecinto> vw_pessoasRecinto { get; set; }
        public virtual DbSet<vw_proprietario> vw_proprietario { get; set; }
        public virtual DbSet<vw_relatorioControleAcesso> vw_relatorioControleAcesso { get; set; }
        public virtual DbSet<vw_relatorio_pessoa> vw_relatorio_pessoa { get; set; }
        public virtual DbSet<tb_fro_frota> tb_fro_frota { get; set; }
        public virtual DbSet<tb_pre_precos> tb_pre_precos { get; set; }
        public virtual DbSet<tb_mve_movimentacaoVeiculo> tb_mve_movimentacaoVeiculo { get; set; }
        public virtual DbSet<tb_doc_documento> tb_doc_documento { get; set; }
        public virtual DbSet<tb_dmo_documentoMorador> tb_dmo_documentoMorador { get; set; }
        public virtual DbSet<tb_inc_informacoesCliente> tb_inc_informacoesCliente { get; set; }
        public virtual DbSet<tb_nod_notificacaoDocumento> tb_nod_notificacaoDocumento { get; set; }
        public virtual DbSet<tb_dva_duvidasApp> tb_dva_duvidasApp { get; set; }
        public virtual DbSet<tb_per_perguntas> tb_per_perguntas { get; set; }
        public virtual DbSet<tb_fen_foto_entrega> tb_fen_foto_entrega { get; set; }
        public virtual DbSet<tb_cde_cadastro_entregas> tb_cde_cadastro_entregas { get; set; }
        public virtual DbSet<tb_cat_categoriaCatalogo> tb_cat_categoriaCatalogo { get; set; }
        public virtual DbSet<tb_scc_subCategoriaCatalogo> tb_scc_subCategoriaCatalogo { get; set; }
        public virtual DbSet<tb_cal_catalogo> tb_cal_catalogo { get; set; }
        public virtual DbSet<tb_csr_connectionSignalR> tb_csr_connectionSignalR { get; set; }
        public virtual DbSet<tb_vpp_visitanteApp> tb_vpp_visitanteApp { get; set; }
        public virtual DbSet<tb_ref_refeicao> tb_ref_refeicao { get; set; }
        public virtual DbSet<tb_age_agenda> tb_age_agenda { get; set; }
        public virtual DbSet<tb_usc_usuarioSalaComercial> tb_usc_usuarioSalaComercial { get; set; }
        public virtual DbSet<tb_dev_device> tb_dev_device { get; set; }
        public virtual DbSet<tb_age_agenteComercial> tb_age_agenteComercial { get; set; }
        public virtual DbSet<tb_fzk_tabelaHorarioFacialZK> tb_fzk_tabelaHorarioFacialZK { get; set; }
        public virtual DbSet<tb_gzk_grupoTabelaHorarioFacialZK> tb_gzk_grupoTabelaHorarioFacialZK { get; set; }
        public virtual DbSet<tb_fac_face> tb_fac_face { get; set; }
        public virtual DbSet<tb_sca_salaComercialCatalogo> tb_sca_salaComercialCatalogo { get; set; }
        public virtual DbSet<tb_aco_acompanhante> tb_aco_acompanhante { get; set; }
        public virtual DbSet<tb_ocp_ocorrenciasOperador> tb_ocp_ocorrenciasOperador { get; set; }
        public virtual DbSet<tb_ajd_ajuda> tb_ajd_ajuda { get; set; }
        public virtual DbSet<tb_tpc_topicos> tb_tpc_topicos { get; set; }
        #endregion

        public object HttpContext { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                        .SetBasePath(_env.ContentRootPath)
                        .AddJsonFile("appsettings.json")
                        .Build();

                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var converter = new ValueConverter<string, string>(
               v => v,
               v => v);
               //v => v.ToUpper());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (tabelasUpper.Contains(entityType.Name))
                {
                    continue;
                }
                foreach (var property in entityType.GetProperties())
                {
                    if (propriedades.Contains(property.Name) || property.Name.Contains("_unique"))
                    {
                        continue;
                    }

                    if (property.ClrType == typeof(string))
                    {
                        modelBuilder.Entity(entityType.Name)
                               .Property(property.Name)
                               .HasConversion(converter);
                    }
                }
            }

            modelBuilder.Entity<tb_afa_afastamento>(entity =>
            {
                entity.HasKey(e => e.afa_n_codigo);

                entity.HasOne(d => d.afa_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_afa_afastamento)
                    .HasForeignKey(d => d.afa_mor_n_codigo)
                    .HasConstraintName("tb_afa_afastamento_tb_mor_morador");
            });

            modelBuilder.Entity<tb_pop_perfilOperador>(entity =>
            {
                entity.Property(e => e.pop_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.pop_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pop_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pop_d_modificacao)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("(getdate())");


            });

            modelBuilder.Entity<tb_per_per_perfilPermissionamento>(entity =>
            {
                entity.HasOne(d => d.tb_per_permissionamento)
                   .WithMany(p => p.tb_per_per_perfilPermissionamento)
                   .HasForeignKey(d => d.per_u_n_codigo)
                   .HasConstraintName("FK_tb_per_per_perfilPermissionamento_tb_per_permissionamento");
            });

            modelBuilder.Entity<tb_ace_per_acessoPermissionamento>(entity =>
            {
                entity.HasOne(d => d.tb_per_permissionamento)
                   .WithMany(p => p.tb_ace_per_acessoPermissionamento)
                   .HasForeignKey(d => d.per_u_n_codigo)
                   .HasConstraintName("FK_tb_ace_per_acessoPermissionamento_tb_per_permissionamento");
            });

            modelBuilder.Entity<tb_aba_agendaBackupAutomatico>(entity =>
            {
                entity.Property(e => e.aba_b_ativo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.aba_c_frequencia)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.aba_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.aba_c_usuario)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.aba_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.aba_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.aba_d_modificao).HasColumnType("datetime");

                entity.HasOne(x => x.tb_cli_cliente)
                      .WithMany(x => x.tb_aba_agendaBackupAutomatico)
                      .HasForeignKey(x => x.aba_cli_n_codigo)
                      .HasConstraintName("FK_tb_aba_agendaBackupAutomatico_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_ace_acesso>(entity =>
            {

                entity.Property(e => e.ace_b_relacional).HasDefaultValueSql("((0))");

                entity.Property(e => e.ace_c_login).IsUnicode(false);

                entity.Property(e => e.ace_c_senha).IsUnicode(false);

                entity.Property(e => e.ace_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ace_b_relacionalDist);

                entity.Property(e => e.ace_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ace_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ace_d_modificacao).HasColumnType("datetime");

                entity.HasOne(x => x.tb_emp_empresa)
                      .WithMany(x => x.tb_ace_acesso)
                      .HasForeignKey(x => x.ace_emp_n_codigo)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("FK_tb_ace_acesso_tb_emp_empresa");

                entity.HasOne(x => x.tb_per_perfil)
                      .WithMany(x => x.tb_ace_acesso)
                      .HasForeignKey(x => x.ace_per_n_codigo)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("FK_tb_ace_acesso_tb_per_perfil");

                entity.HasOne(x => x.tb_dis_distribuidor)
                     .WithMany(x => x.tb_ace_acesso)
                     .HasForeignKey(x => x.ace_dis_n_codigo)
                     .OnDelete(DeleteBehavior.Cascade)
                     .HasConstraintName("FK_tb_ace_acesso_tb_dis_distribuidor");
            });

            modelBuilder.Entity<tb_apa_aplicacoesAlarme>(entity =>
            {
                entity.HasKey(e => e.apa_n_codigo);

                entity.Property(e => e.apa_c_processo).IsUnicode(false);

                entity.Property(e => e.apa_c_tipo).IsUnicode(false);

                entity.Property(e => e.apa_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.apa_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.apa_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(x => x.tb_emp_empresa)
                  .WithMany(x => x.tb_apa_aplicacoesAlarme)
                  .HasForeignKey(x => x.apa_emp_n_codigo)
                  .HasConstraintName("FK_tb_apa_aplicacoesAlarme_tb_emp_empresa");
            });

            modelBuilder.Entity<tb_ard_arquivoDependencias>(entity =>
            {
                entity.HasKey(e => e.ard_n_codigo);

                entity.Property(e => e.ard_c_nomePDFImagem).IsUnicode(false);

                entity.Property(e => e.ard_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ard_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ard_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ard_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_ate_atendimento>(entity =>
            {
                entity.HasKey(e => e.ate_n_codigo);

                entity.Property(e => e.ate_c_descricao).IsUnicode(false);

                entity.Property(e => e.ate_c_from).IsUnicode(false);

                entity.Property(e => e.ate_c_identificacaoVOIP).IsUnicode(false);

                entity.Property(e => e.ate_c_ramalAtendeu).IsUnicode(false);

                entity.Property(e => e.ate_c_status).IsUnicode(false);

                entity.Property(e => e.ate_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ate_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ate_d_data).HasColumnType("datetime");

                entity.Property(e => e.ate_d_dataFinalizacao).HasColumnType("datetime");

                entity.Property(e => e.ate_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ate_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.ate_ope_n_preferencialNavigation)
                    .WithMany(p => p.tb_ate_atendimento)
                    .HasForeignKey(d => d.ate_ope_n_preferencial)
                    .HasConstraintName("FK_tb_ate_atendimento_tb_ope_operador");

                entity.HasOne(d => d.ate_pec_n_codigoNavigation)
                    .WithMany(p => p.tb_ate_atendimento)
                    .HasForeignKey(d => d.ate_pec_n_codigo)
                    .HasConstraintName("FK_tb_ate_atendimento_tb_pec_processoExclusaoCliente");

                entity.HasOne(d => d.ate_tpa_n_codigoNavigation)
                    .WithMany(p => p.tb_ate_atendimento)
                    .HasForeignKey(d => d.ate_tpa_n_codigo)
                    .HasConstraintName("FK_tb_ate_atendimento_tb_tpa_tipoAtendimento");

                entity.HasOne(d => d.tb_cli_cliente)
                    .WithMany(p => p.tb_ate_atendimento)
                    .HasForeignKey(d => d.ate_cli_n_codigo)
                    .HasConstraintName("FK_tb_ate_atendimento_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_avg_avisoGrupoFamiliar>(entity =>
            {
                entity.HasKey(e => e.avg_n_codigo);

                entity.Property(e => e.avg_c_descricao).IsUnicode(false);

                entity.Property(e => e.avg_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.avg_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.avg_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.avg_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.avg_cav_n_codigoNavigation)
                    .WithMany(p => p.tb_avg_avisoGrupoFamiliar)
                    .HasForeignKey(d => d.avg_cav_n_codigo)
                    .HasConstraintName("FK_tb_avg_avisoGrupoFamiliar_tb_cav_categorizacaoAviso");

                entity.HasOne(d => d.avg_grf_n_codigoNavigation)
                    .WithMany(p => p.tb_avg_avisoGrupoFamiliar)
                    .HasForeignKey(d => d.avg_grf_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_avg_avisoGrupoFamiliar_tb_grf_grupoFamiliar");
            });

            modelBuilder.Entity<tb_avi_aviso>(entity =>
            {
                entity.HasKey(e => e.avi_n_codigo);

                entity.Property(e => e.avi_c_descricao).IsUnicode(false);

                entity.Property(e => e.avi_c_status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.avi_c_titulo).IsUnicode(false);

                entity.Property(e => e.avi_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.avi_c_usuario).IsUnicode(false);

                entity.Property(e => e.avi_d_alteracao).HasColumnType("date");

                entity.Property(e => e.avi_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.avi_d_fim).HasColumnType("date");

                entity.Property(e => e.avi_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.avi_d_inicio).HasColumnType("date");

                entity.Property(e => e.avi_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.avi_ope_c_enviarPara).IsUnicode(false);

                entity.HasOne(d => d.avi_ace_n_codigoNavigation)
                    .WithMany(p => p.tb_avi_aviso)
                    .HasForeignKey(d => d.avi_ace_n_codigo)
                    .HasConstraintName("FK_tb_avi_aviso_tb_ace_acesso");

                entity.HasOne(d => d.avi_emp_n_codigoNavigation)
                    .WithMany(p => p.tb_avi_aviso)
                    .HasForeignKey(d => d.avi_emp_n_codigo)
                    .HasConstraintName("FK_tb_avi_aviso_tb_emp_empresa");
            });

            modelBuilder.Entity<tb_avi_avisoEmpresa>(entity =>
            {
                entity.HasKey(e => e.avi_n_codigo);

                entity.Property(e => e.avi_c_descricao).IsUnicode(false);

                entity.Property(e => e.avi_c_status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.avi_c_titulo).IsUnicode(false);

                entity.Property(e => e.avi_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.avi_c_usuario).IsUnicode(false);

                entity.Property(e => e.avi_d_alteracao).HasColumnType("date");

                entity.Property(e => e.avi_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.avi_d_fim).HasColumnType("date");

                entity.Property(e => e.avi_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.avi_d_inicio).HasColumnType("date");

                entity.Property(e => e.avi_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.avi_emp_c_enviarPara).IsUnicode(false);
            });

            modelBuilder.Entity<tb_avi_avisoMorador>(entity =>
            {
                entity.HasKey(e => e.avm_n_codigo)
                    .HasName("PK_avm_n_codigo");

                entity.Property(e => e.avi_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.avi_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.avi_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.avm_c_descricao).IsUnicode(false);

                entity.Property(e => e.avm_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.avm_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.avm_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.avm_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.avm_ace_n_codigoNavigation)
                    .WithMany(p => p.tb_avi_avisoMorador)
                    .HasForeignKey(d => d.avm_ace_n_codigo)
                    .HasConstraintName("FK_tb_avi_avisoMorador_tb_ace_acesso");

                entity.HasOne(d => d.avm_cav_n_codigoNavigation)
                    .WithMany(p => p.tb_avi_avisoMorador)
                    .HasForeignKey(d => d.avm_cav_n_codigo)
                    .HasConstraintName("FK_tb_avi_avisoMorador_tb_cav_categorizacaoAviso");

                entity.HasOne(d => d.avm_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_avi_avisoMorador)
                    .HasForeignKey(d => d.avm_mor_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_avi_avisoMorador_tb_mor_Morador");
            });

            modelBuilder.Entity<tb_avp_avisoPrestador>(entity =>
            {
                entity.HasKey(e => e.avp_n_codigo);

                entity.Property(e => e.avp_c_descricao).IsUnicode(false);

                entity.Property(e => e.avp_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.avp_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.avp_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.avp_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.avp_cav_n_codigoNavigation)
                    .WithMany(p => p.tb_avp_avisoPrestador)
                    .HasForeignKey(d => d.avp_cav_n_codigo)
                    .HasConstraintName("FK_tb_avp_avisoPrestador_tb_cav_categorizacaoAviso");

                entity.HasOne(d => d.avp_pse_n_codigoNavigation)
                    .WithMany(p => p.tb_avp_avisoPrestador)
                    .HasForeignKey(d => d.avp_pse_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_avp_avisoPrestador_tb_pse_prestadorServico");
            });

            modelBuilder.Entity<tb_avv_avisoVisitante>(entity =>
            {
                entity.HasKey(e => e.avv_n_codigo)
                    .HasName("PK_avv_n_codigo");

                entity.Property(e => e.avv_c_descricao).IsUnicode(false);

                entity.Property(e => e.avv_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.avv_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.avv_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.avv_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.avv_cav_n_codigoNavigation)
                    .WithMany(p => p.tb_avv_avisoVisitante)
                    .HasForeignKey(d => d.avv_cav_n_codigo)
                    .HasConstraintName("FK_tb_avv_avisoVisitante_tb_cav_categorizacaoAviso");

                entity.HasOne(d => d.avv_vis_n_codigoNavigation)
                    .WithMany(p => p.tb_avv_avisoVisitante)
                    .HasForeignKey(d => d.avv_vis_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_avv_avisoVisitante_tb_vis_visitante");
            });

            modelBuilder.Entity<tb_bio_biometria>(entity =>
            {
                entity.HasKey(e => e.bio_n_codigo);

                entity.Property(e => e.bio_c_imagem).HasColumnType("image");

                entity.Property(e => e.bio_c_status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.bio_c_template).IsUnicode(false);

                entity.Property(e => e.bio_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.bio_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.bio_d_dataSolicitacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.bio_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.bio_con_n_codigoNavigation)
                    .WithMany(p => p.tb_bio_biometria)
                    .HasForeignKey(d => d.bio_con_n_codigo)
                    .HasConstraintName("FK_tb_bio_biometria_tb_con_controladora");

                entity.HasOne(x => x.bio_cli_n_codigoNavigation)
                  .WithMany(x => x.tb_bio_biometria)
                  .HasForeignKey(x => x.bio_cli_n_codigo)
                  .HasConstraintName("FK_tb_bio_biometria_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_cac_controleAcesso>(entity =>
            {
                entity.HasKey(e => e.cac_n_codigo);

                entity.Property(e => e.cac_c_biometria).IsUnicode(false);

                entity.Property(e => e.cac_c_descricao).IsUnicode(false);

                entity.Property(e => e.cac_c_numeroCartao).IsUnicode(false);

                entity.Property(e => e.cac_c_numeroChave).IsUnicode(false);

                entity.Property(e => e.cac_c_senha).IsUnicode(false);

                entity.Property(e => e.cac_c_tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.cac_c_tipoAcesso).IsUnicode(false);

                entity.Property(e => e.cac_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.cac_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cac_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cac_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.cac_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_cac_controleAcesso)
                    .HasForeignKey(d => d.cac_mor_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_cac_controleAcesso_tb_mor_Morador");

                entity.HasOne(d => d.cac_pse_n_codigoNavigation)
                    .WithMany(p => p.tb_cac_controleAcesso)
                    .HasForeignKey(d => d.cac_pse_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_cac_controleAcesso_tb_pse_prestadorServico");

                entity.HasOne(d => d.cac_vis_n_codigoNavigation)
                    .WithMany(p => p.tb_cac_controleAcesso)
                    .HasForeignKey(d => d.cac_vis_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_cac_controleAcesso_tb_vis_visitante");
            });

            modelBuilder.Entity<tb_cac_controleAplicacoesCliente>(entity =>
            {
                entity.HasKey(e => e.cac_n_codigo);

                entity.Property(e => e.cac_c_processo).IsUnicode(false);

                entity.Property(e => e.cac_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.cac_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cac_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.cac_con_n_codigoNavigation)
                    .WithMany(p => p.tb_cac_controleAplicacoesCliente)
                    .HasForeignKey(d => d.cac_con_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_cac_controleAplicacoesCliente_tb_con_controladora");
            });

            modelBuilder.Entity<tb_cae_controleAcessoExcluido>(entity =>
            {
                entity.HasKey(e => e.cae_n_codigo)
                    .HasName("PK_tb_cae_controleAcesso");

                entity.Property(e => e.cae_c_descricao).IsUnicode(false);

                entity.Property(e => e.cae_c_numeroCartao).IsUnicode(false);

                entity.Property(e => e.cae_c_numeroChave).IsUnicode(false);

                entity.Property(e => e.cae_c_senha).IsUnicode(false);

                entity.Property(e => e.cae_c_tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.cae_c_tipoAcesso).IsUnicode(false);

                entity.Property(e => e.cae_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.cae_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cae_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cae_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.cae_con_n_codigoNavigation)
                    .WithMany(p => p.tb_cae_controleAcessoExcluido)
                    .HasForeignKey(d => d.cae_con_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_cae_controleAcessoExcluido_tb_con_controladora");
            });

            modelBuilder.Entity<tb_can_canalLayout>(entity =>
            {
                entity.HasKey(e => e.can_n_codigo);

                entity.Property(e => e.can_c_nome).IsUnicode(false);

                entity.Property(e => e.can_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.can_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.can_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.can_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.can_lay_n_codigoNavigation)
                    .WithMany(p => p.tb_can_canalLayout)
                    .HasForeignKey(d => d.can_lay_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_can_canalLayout_tb_lay_layout");
            });

            modelBuilder.Entity<tb_cav_categorizacaoAviso>(entity =>
            {
                entity.HasKey(e => e.cav_n_codigo);

                entity.Property(e => e.cav_c_cor).IsUnicode(false);

                entity.Property(e => e.cav_c_descricao).IsUnicode(false);

                entity.Property(e => e.cav_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.cav_c_usuario).IsUnicode(false);

                entity.Property(e => e.cav_d_alteracao).HasColumnType("date");

                entity.Property(e => e.cav_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cav_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cav_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_cev_categorizacaoEvento>(entity =>
            {
                entity.HasKey(e => e.cev_n_codigo);

                entity.Property(e => e.cev_c_codigoEvento).IsUnicode(false);

                entity.Property(e => e.cev_c_cor).IsUnicode(false);

                entity.Property(e => e.cev_c_descricao).IsUnicode(false);

                entity.Property(e => e.cev_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.cev_c_usuario).IsUnicode(false);

                entity.Property(e => e.cev_d_alteracao).HasColumnType("date");

                entity.Property(e => e.cev_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cev_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cev_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.cev_cev_n_temporizadorNavigation)
                    .WithMany(p => p.Inversecev_cev_n_temporizadorNavigation)
                    .HasForeignKey(d => d.cev_cev_n_temporizador)
                    .HasConstraintName("FK_tb_cev_categorizacaoEvento_tb_cev_categorizacaoEvento1");
            });

            modelBuilder.Entity<tb_cha_chavesDeAcesso>(entity =>
            {
                entity.HasKey(e => e.cha_n_codigo);

                entity.Property(e => e.cha_c_chave).IsUnicode(false);

                entity.Property(e => e.cha_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.cha_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cha_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cha_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.cha_lid_n_codigoNavigation)
                    .WithMany(p => p.tb_cha_chavesDeAcesso)
                    .HasForeignKey(d => d.cha_lid_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_cha_chavesDeAcesso_tb_lid_liberacaoDelivery");

                entity.HasOne(d => d.cha_lip_n_codigoNavigation)
                    .WithMany(p => p.tb_cha_chavesDeAcesso)
                    .HasForeignKey(d => d.cha_lip_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_cha_chavesDeAcesso_tb_lip_liberacaoPrestador");

                entity.HasOne(d => d.cha_liv_n_codigoNavigation)
                    .WithMany(p => p.tb_cha_chavesDeAcesso)
                    .HasForeignKey(d => d.cha_liv_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_cha_chavesDeAcesso_tb_liv_liberacaoVisitante");
            });

            modelBuilder.Entity<tb_cid_cidade>(entity =>
            {
                entity.HasKey(e => e.cid_n_codigo);

                entity.Property(e => e.cid_c_estado)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.cid_c_nome)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.cid_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.cid_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cid_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cid_n_ibge).IsUnicode(false);

                entity.HasOne(d => d.cid_est_n_codigoNavigation)
                    .WithMany(p => p.tb_cid_cidade)
                    .HasForeignKey(d => d.cid_est_n_codigo)
                    .HasConstraintName("FK_tb_cid_cidade_tb_est_estado");
            });

            modelBuilder.Entity<tb_cla_cabecalhoLayout>(entity =>
            {
                entity.HasKey(e => e.cla_n_codigo);

                entity.Property(e => e.cla_c_exibirem).IsUnicode(false);

                entity.Property(e => e.cla_c_nome).IsUnicode(false);

                entity.Property(e => e.cla_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.cla_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cla_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.cla_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_cla_cabecalhoLayout)
                    .HasForeignKey(d => d.cla_cli_n_codigo)
                    .HasConstraintName("FK_tb_cla_cabecalhoLayout_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_cli_cliente>(entity =>
            {
                entity.HasKey(e => e.cli_n_codigo);
                entity.Property(e => e.cli_c_bairro).IsUnicode(false);
                entity.Property(e => e.cli_c_celular).IsUnicode(false);
                entity.Property(e => e.cli_c_celular2).IsUnicode(false);
                entity.Property(e => e.cli_c_celularAdministradora).IsUnicode(false);
                entity.Property(e => e.cli_c_centralVoip).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.cli_c_cep).IsUnicode(false);
                entity.Property(e => e.cli_c_chave).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.cli_c_cnpj).IsUnicode(false);
                entity.Property(e => e.cli_c_codInstalacaoOffline).HasMaxLength(14).IsUnicode(false);
                entity.Property(e => e.cli_c_codInstalacaoRenovacao).HasMaxLength(14).IsUnicode(false);
                entity.Property(e => e.cli_c_codigoReferencia).HasMaxLength(6).IsUnicode(false);
                entity.Property(e => e.cli_c_complemento).IsUnicode(false);
                entity.Property(e => e.cli_c_contraSenha).IsUnicode(false);
                entity.Property(e => e.cli_c_dominio).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.cli_c_dominioSIP).IsUnicode(false);
                entity.Property(e => e.cli_c_email).IsUnicode(false);
                entity.Property(e => e.cli_c_email2).IsUnicode(false);
                entity.Property(e => e.cli_c_emailAdministradora).IsUnicode(false);
                entity.Property(e => e.cli_c_fantasiaAdministradora).IsUnicode(false);
                entity.Property(e => e.cli_c_ie).IsUnicode(false);
                entity.Property(e => e.cli_c_ip).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.cli_c_nomeFantasia).IsUnicode(false);
                entity.Property(e => e.cli_c_numero).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.cli_c_observacao).IsUnicode(false);
                entity.Property(e => e.cli_c_pessoaContato).IsUnicode(false);
                entity.Property(e => e.cli_c_pessoaContatoAdministradora).IsUnicode(false);
                entity.Property(e => e.cli_c_porta).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.cli_c_portaSIP).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.cli_c_ramais).IsUnicode(false);
                entity.Property(e => e.cli_c_ramal).IsUnicode(false);
                entity.Property(e => e.cli_c_range_periodo_aplicadorTicket).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.cli_c_razaoSocial).IsUnicode(false);
                entity.Property(e => e.cli_c_rua).IsUnicode(false);
                entity.Property(e => e.cli_c_senha).IsUnicode(false);
                entity.Property(e => e.cli_c_senhaSIP).IsUnicode(false);
                entity.Property(e => e.cli_c_serial).HasMaxLength(23).IsUnicode(false);
                entity.Property(e => e.cli_c_telefoneAdministradora).IsUnicode(false);
                entity.Property(e => e.cli_c_telefoneComercial).IsUnicode(false);
                entity.Property(e => e.cli_c_telefoneComercial2).IsUnicode(false);
                entity.Property(e => e.cli_c_tipoRede).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.cli_c_unique).HasDefaultValueSql("(newid())");
                entity.Property(e => e.cli_c_usuario).IsUnicode(false);
                entity.Property(e => e.cli_c_zona).IsUnicode(false);
                entity.Property(e => e.cli_d_alteracao).HasColumnType("date");
                entity.Property(e => e.cli_d_atualizado).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.cli_d_dataCriacao).HasColumnType("datetime");
                entity.Property(e => e.cli_d_dataExpiracao).HasColumnType("datetime");
                entity.Property(e => e.cli_d_dataUltimaSincronizacaoCloud).HasColumnType("datetime");
                entity.Property(e => e.cli_d_dataVencimentoLicenca).HasColumnType("datetime");
                entity.Property(e => e.cli_d_inclusao).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.cli_d_inicioContrato).HasColumnType("datetime");
                entity.Property(e => e.cli_d_inicioLicenca).HasColumnType("datetime");
                entity.Property(e => e.cli_d_modificacao).HasColumnType("datetime");
                entity.Property(e => e.cli_d_ultimoContatoSolution).HasColumnType("datetime");
                entity.Property(e => e.cli_n_valorLicenca).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.cli_c_senhaAppGarenConnect).IsUnicode(false);
                entity.Property(e => e.cli_c_tituloInstitucional);
                entity.Property(e => e.cli_c_descricaoInstitucional);

                entity.HasOne(d => d.cli_can_n_accessNavigation)
                    .WithMany(p => p.tb_cli_cliente)
                    .HasForeignKey(d => d.cli_can_n_access)
                    .HasConstraintName("FK_tb_cli_cliente_tb_can_canalLayout");

                entity.HasOne(d => d.cli_cid_n_codigoNavigation)
                    .WithMany(p => p.tb_cli_cliente)
                    .HasForeignKey(d => d.cli_cid_n_codigo)
                    .HasConstraintName("FK_tb_cli_cliente_tb_cid_cidade");

                entity.HasOne(d => d.cli_emp_n_codigoNavigation)
                    .WithMany(p => p.tb_cli_cliente)
                    .HasForeignKey(d => d.cli_emp_n_codigo)
                    .HasConstraintName("FK_tb_cli_cliente_tb_emp_empresa");

                entity.HasOne(d => d.cli_est_n_codigoNavigation)
                    .WithMany(p => p.tb_cli_cliente)
                    .HasForeignKey(d => d.cli_est_n_codigo)
                    .HasConstraintName("FK_tb_cli_cliente_tb_est_estado");

                entity.HasOne(d => d.cli_mol_n_codigoNavigation)
                    .WithMany(p => p.tb_cli_cliente)
                    .HasForeignKey(d => d.cli_mol_n_codigo)
                    .HasConstraintName("FK_tb_cli_cliente_tb_mol_modulosLiberados");

                entity.HasOne(d => d.cli_tcl_n_codigoNavigation)
                    .WithMany(p => p.tb_cli_cliente)
                    .HasForeignKey(d => d.cli_tcl_n_codigo)
                    .HasConstraintName("FK_tb_cli_cliente_tb_tcl_tipoCliente");

                entity.HasOne(d => d.cli_fot_fachada_n_codigoNavigation)
                   .WithMany(p => p.tb_cli_cliente)
                   .HasForeignKey(d => d.cli_fot_fachada_n_codigo)
                   .HasConstraintName("FK_tb_cli_cliente_cli_fot_fachada_n_codigo");
            });

            modelBuilder.Entity<tb_con_controladora>(entity =>
            {
                entity.HasKey(e => e.con_n_codigo);

                entity.Property(e => e.con_b_ativo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.con_c_dominioDDNS).IsUnicode(false);

                entity.Property(e => e.con_c_ip).IsUnicode(false);

                entity.Property(e => e.con_c_modelo).IsUnicode(false);

                entity.Property(e => e.con_c_nome).IsUnicode(false);

                entity.Property(e => e.con_c_perfis)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('MOR,VIS,PSE')");

                entity.Property(e => e.con_c_porta).IsUnicode(false);

                entity.Property(e => e.con_c_senha).IsUnicode(false);

                entity.Property(e => e.con_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.con_c_usuario).IsUnicode(false);

                entity.Property(e => e.con_c_usuarioAlteracao).IsUnicode(false);

                entity.Property(e => e.con_d_alteracao).HasColumnType("date");

                entity.Property(e => e.con_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.con_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.con_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.con_d_ultimoContato).HasColumnType("datetime");

                entity.HasOne(d => d.con_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_con_controladora)
                    .HasForeignKey(d => d.con_cli_n_codigo)
                    .HasConstraintName("FK_tb_con_controladora_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_con_monitoramentoControleAcesso>(entity =>
            {
                entity.HasKey(e => e.con_n_codigo)
                    .HasName("PK_tb_con_controleAcesso");

                entity.HasIndex(e => e.con_cli_n_codigo)
                    .HasName("IX_tb_con_monitoramentoControleAcesso_2");

                entity.HasIndex(e => e.con_d_evento)
                    .HasName("IX_tb_con_monitoramentoControleAcesso_1");

                entity.HasIndex(e => e.con_n_codigo)
                    .HasName("IX_tb_con_monitoramentoControleAcesso_3");

                entity.HasIndex(e => e.con_c_unique)
                    .HasName("idx_tb_con_monitoramentoControleAces99");

                entity.Property(e => e.cin_c_tipoEventoMotivo).IsUnicode(false);

                entity.Property(e => e.con_b_pendenteVideo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.con_c_UsuarioTratamentoPanico).IsUnicode(false);

                entity.Property(e => e.con_c_acao).IsUnicode(false);

                entity.Property(e => e.con_c_cardNumber).IsUnicode(false);

                entity.Property(e => e.con_c_destino)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.con_c_doorId).IsUnicode(false);

                entity.Property(e => e.con_c_obsTratamentoPanico).IsUnicode(false);

                entity.Property(e => e.con_c_pin).IsUnicode(false);

                entity.Property(e => e.con_c_pontoAcesso).IsUnicode(false);

                entity.Property(e => e.con_c_status).IsUnicode(false);

                entity.Property(e => e.con_c_tipoPessoa).IsUnicode(false);

                entity.Property(e => e.con_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.con_c_usuario).IsUnicode(false);

                entity.Property(e => e.con_ref_c_nomeRefeicao);

                entity.Property(e => e.con_ref_d_valor);

                entity.Property(e => e.con_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.con_d_dataTratamentoPanico).HasColumnType("datetime");

                entity.Property(e => e.con_d_evento).HasColumnType("datetime");

                entity.Property(e => e.con_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.con_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.con_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_con_monitoramentoControleAcesso)
                    .HasForeignKey(d => d.con_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_con_monitoramentoControleAcesso_tb_cli_cliente");

                entity.HasOne(d => d.con_pec_n_codigoNavigation)
                    .WithMany(p => p.tb_con_monitoramentoControleAcesso)
                    .HasForeignKey(d => d.con_pec_n_codigo)
                    .HasConstraintName("FK_tb_con_monitoramentoControleAcesso_tb_pec_processoExclusaoCliente");
            });

            modelBuilder.Entity<tb_cpg_comandoPGM>(entity =>
            {
                entity.HasKey(e => e.cgp_n_codigo);

                entity.Property(e => e.cgp_c_comando)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.cgp_c_descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.cgp_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.cgp_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cgp_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<tb_csi_configuracaoSincronizacao>(entity =>
            {
                entity.HasKey(e => e.csi_n_codigo);

                entity.Property(e => e.csi_b_ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.csi_b_desce).HasDefaultValueSql("((1))");

                entity.Property(e => e.csi_b_sobe).HasDefaultValueSql("((1))");

                entity.Property(e => e.csi_c_prefixo).IsUnicode(false);

                entity.Property(e => e.csi_c_tabela).IsUnicode(false);

                entity.Property(e => e.csi_c_where)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.csi_n_importancia).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<tb_ddv_dispositivoDVRCliente>(entity =>
            {
                entity.HasKey(e => e.ddv_n_codigo);

                entity.Property(e => e.ddv_c_ip).IsUnicode(false);

                entity.Property(e => e.ddv_c_nome).IsUnicode(false);

                entity.Property(e => e.ddv_c_porta).IsUnicode(false);

                entity.Property(e => e.ddv_c_portaHTTP).IsUnicode(false);

                entity.Property(e => e.ddv_c_portaServico).IsUnicode(false);

                entity.Property(e => e.ddv_c_senha).IsUnicode(false);

                entity.Property(e => e.ddv_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ddv_c_usuario).IsUnicode(false);

                entity.Property(e => e.ddv_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ddv_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ddv_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.ddv_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_ddv_dispositivoDVRCliente)
                    .HasForeignKey(d => d.ddv_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_ddv_dispositivoDVRCliente_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_dpg_disparoPGM>(entity =>
            {
                entity.HasKey(e => e.dpg_n_codigo);

                entity.Property(e => e.dpg_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.dpg_c_usuario)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.dpg_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.dpg_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.dpg_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.dpg_cgp_n_codigoNavigation)
                    .WithMany(p => p.tb_dpg_disparoPGM)
                    .HasForeignKey(d => d.dpg_cgp_n_codigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_dpg_disparoPGM_tb_cpg_comandoPGM");

                entity.HasOne(d => d.dpg_eqc_n_codigoNavigation)
                    .WithMany(p => p.tb_dpg_disparoPGM)
                    .HasForeignKey(d => d.dpg_eqc_n_codigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_dpg_disparoPGM_tb_eqc_equipamentoCliente");
            });

            modelBuilder.Entity<tb_dpn_dependencias>(entity =>
            {
                entity.HasKey(e => e.dpn_n_codigo)
                    .HasName("PK_tb_dpn_dependencia");

                entity.Property(e => e.dpn_b_ativoInativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.dpn_c_apto).IsUnicode(false);

                entity.Property(e => e.dpn_c_bloco).IsUnicode(false);

                entity.Property(e => e.dpn_c_descricao).IsUnicode(false);

                entity.Property(e => e.dpn_c_nome).IsUnicode(false);

                entity.Property(e => e.dpn_c_periodoManha).IsUnicode(false);

                entity.Property(e => e.dpn_c_periodoNoite).IsUnicode(false);

                entity.Property(e => e.dpn_c_periodoTarde).IsUnicode(false);

                entity.Property(e => e.dpn_c_termosUso).IsUnicode(false);

                entity.Property(e => e.dpn_c_tipoTermoUso).IsUnicode(false);

                entity.Property(e => e.dpn_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.dpn_n_reservaPeriodo);

                entity.Property(e => e.dpn_c_periodoPorHorario);

                entity.Property(e => e.dpn_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.dpn_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.dpn_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.dpn_b_permitirReservarPeriodo)
                 .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.dpn_ard_n_codigoNavigation)
                    .WithMany(p => p.tb_dpn_dependencias)
                    .HasForeignKey(d => d.dpn_ard_n_codigo)
                    .HasConstraintName("FK_tb_dpn_dependencias_tb_ard_arquivoDependencias");

                entity.HasOne(d => d.dpn_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_dpn_dependencias)
                    .HasForeignKey(d => d.dpn_cli_n_codigo)
                    .HasConstraintName("FK_tb_dpn_dependencia_tb_cli_cliente");

                entity.HasOne(d => d.dpn_ftd_n_codigoNavigation)
                    .WithMany(p => p.tb_dpn_dependencias)
                    .HasForeignKey(d => d.dpn_ftd_n_codigo)
                    .HasConstraintName("FK_tb_dpn_dependencias_tb_ftd_fotoDependencia")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<tb_ema_email>(entity =>
            {
                entity.HasKey(e => e.ema_n_codigo);

                entity.Property(e => e.ema_b_enviado).HasDefaultValueSql("((0))");

                entity.Property(e => e.ema_c_anexo).IsUnicode(false);

                entity.Property(e => e.ema_c_assunto)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ema_c_caminhoAnexo).IsUnicode(false);

                entity.Property(e => e.ema_c_copia).IsUnicode(false);

                entity.Property(e => e.ema_c_copiaOculta).IsUnicode(false);

                entity.Property(e => e.ema_c_corpo).IsUnicode(false);

                entity.Property(e => e.ema_c_destinatario).IsUnicode(false);

                entity.Property(e => e.ema_c_remetente).IsUnicode(false);

                entity.Property(e => e.ema_d_data).HasColumnType("datetime");

                entity.Property(e => e.ema_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_emp_empresa>(entity =>
            {
                entity.HasKey(e => e.emp_n_codigo);

                entity.Property(e => e.emp_c_RangePortas).IsUnicode(false);

                entity.Property(e => e.emp_c_RangeRamais).IsUnicode(false);

                entity.Property(e => e.emp_c_bairro).IsUnicode(false);

                entity.Property(e => e.emp_c_celular).IsUnicode(false);

                entity.Property(e => e.emp_c_celular2).IsUnicode(false);

                entity.Property(e => e.emp_c_cep).IsUnicode(false);

                entity.Property(e => e.emp_c_cnpj).IsUnicode(false);

                entity.Property(e => e.emp_c_complemento).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoEmail1).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoEmail2).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoNome1).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoNome2).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoTelefone1).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoTelefone2).IsUnicode(false);

                entity.Property(e => e.emp_c_email).IsUnicode(false);

                entity.Property(e => e.emp_c_email2).IsUnicode(false);

                entity.Property(e => e.emp_c_foneComercial).IsUnicode(false);

                entity.Property(e => e.emp_c_foneComercial2).IsUnicode(false);

                entity.Property(e => e.emp_c_ie).IsUnicode(false);

                entity.Property(e => e.emp_c_nomeFantasia).IsUnicode(false);

                entity.Property(e => e.emp_c_numero).IsUnicode(false);

                entity.Property(e => e.emp_c_observacao).IsUnicode(false);

                entity.Property(e => e.emp_c_pessoaContato).IsUnicode(false);

                entity.Property(e => e.emp_c_ramais).IsUnicode(false);

                entity.Property(e => e.emp_c_razaoSocial).IsUnicode(false);

                entity.Property(e => e.emp_c_rua).IsUnicode(false);

                entity.Property(e => e.emp_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.emp_c_usuario).IsUnicode(false);

                entity.Property(e => e.emp_d_alteracao).HasColumnType("date");

                entity.Property(e => e.emp_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.emp_d_contrato).HasColumnType("datetime");

                entity.Property(e => e.emp_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.emp_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.emp_cid_n_codigoNavigation)
                    .WithMany(p => p.tb_emp_empresa)
                    .HasForeignKey(d => d.emp_cid_n_codigo)
                    .HasConstraintName("FK_tb_emp_empresa_tb_cid_cidade");

                entity.HasOne(d => d.emp_est_n_codigoNavigation)
                    .WithMany(p => p.tb_emp_empresa)
                    .HasForeignKey(d => d.emp_est_n_codigo)
                    .HasConstraintName("FK_tb_emp_empresa_tb_est_estado");

                entity.HasOne(d => d.emp_fem_n_codigoNavigation)
                    .WithMany(p => p.tb_emp_empresa)
                    .HasForeignKey(d => d.emp_fem_n_codigo)
                    .HasConstraintName("FK_tb_emp_empresa_tb_fem_fotoEmpresa");

                entity.HasOne(d => d.emp_mol_n_codigoNavigation)
                    .WithMany(p => p.tb_emp_empresa)
                    .HasForeignKey(d => d.emp_mol_n_codigo)
                    .HasConstraintName("FK_tb_emp_empresa_tb_mol_modulosLiberados");

                entity.HasOne(d => d.tb_dis_distribuidor)
                    .WithMany(p => p.tb_emp_empresa)
                    .HasForeignKey(d => d.emp_dis_n_codigo)
                    .HasConstraintName("FK_tb_emp_empresa_tb_dis_distribuidor")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<tb_dis_distribuidor>(entity =>
            {
                entity.HasKey(e => e.dis_n_codigo);

                entity.Property(e => e.dis_c_bairro).IsUnicode(false);

                entity.Property(e => e.dis_c_celular).IsUnicode(false);

                entity.Property(e => e.dis_c_celular2).IsUnicode(false);

                entity.Property(e => e.dis_c_cep).IsUnicode(false);

                entity.Property(e => e.dis_c_cnpj).IsUnicode(false);

                entity.Property(e => e.dis_c_complemento).IsUnicode(false);

                entity.Property(e => e.dis_c_email).IsUnicode(false);

                entity.Property(e => e.dis_c_email2).IsUnicode(false);

                entity.Property(e => e.dis_c_foneComercial).IsUnicode(false);

                entity.Property(e => e.dis_c_foneComercial2).IsUnicode(false);

                entity.Property(e => e.dis_c_ie).IsUnicode(false);

                entity.Property(e => e.dis_c_nomeFantasia).IsUnicode(false);

                entity.Property(e => e.dis_c_numero).IsUnicode(false);

                entity.Property(e => e.dis_c_observacao).IsUnicode(false);

                entity.Property(e => e.dis_c_pessoaContato).IsUnicode(false);

                entity.Property(e => e.dis_c_razaoSocial).IsUnicode(false);

                entity.Property(e => e.dis_c_rua).IsUnicode(false);

                entity.Property(e => e.dis_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.dis_c_usuario).IsUnicode(false);

                entity.Property(e => e.dis_d_alteracao).HasColumnType("date");

                entity.Property(e => e.dis_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.dis_d_contrato).HasColumnType("datetime");

                entity.Property(e => e.dis_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.dis_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.dis_cid_n_codigoNavigation)
                    .WithMany(p => p.tb_dis_distribuidor)
                    .HasForeignKey(d => d.dis_cid_n_codigo)
                    .HasConstraintName("FK_tb_dis_distribuidor_tb_cid_cidade");

                entity.HasOne(d => d.dis_est_n_codigoNavigation)
                    .WithMany(p => p.tb_dis_distribuidor)
                    .HasForeignKey(d => d.dis_est_n_codigo)
                    .HasConstraintName("FK_tb_dis_distribuidor_tb_est_estado");
            });

            modelBuilder.Entity<tb_eno_envioNotificacao>(entity =>
            {
                entity.HasKey(e => e.eno_n_codigo);

                entity.Property(e => e.eno_c_GruposFamiliares).IsUnicode(false);

                entity.Property(e => e.eno_c_MoradoresGruposFamiliares).IsUnicode(false);

                entity.Property(e => e.eno_c_mensagem).IsUnicode(false);

                entity.Property(e => e.eno_c_titulo).IsUnicode(false);

                entity.Property(e => e.eno_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.eno_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.eno_d_fim).HasColumnType("datetime");

                entity.Property(e => e.eno_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.eno_d_inicio).HasColumnType("datetime");

                entity.HasOne(d => d.eno_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_eno_envioNotificacao)
                    .HasForeignKey(d => d.eno_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_eno_envioNotificacao_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_ent_entidade>(entity =>
            {
                entity.HasKey(e => e.ent_n_codigo);

                entity.Property(e => e.ent_c_chave)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ent_c_nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ent_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ent_c_valorPadrao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ent_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ent_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<tb_eqc_equipamentoCliente>(entity =>
            {
                entity.HasKey(e => e.eqc_n_codigo);

                entity.Property(e => e.eqc_b_apontamentoLocal)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.eqc_c_conta).IsUnicode(false);

                entity.Property(e => e.eqc_c_ip).IsUnicode(false);

                entity.Property(e => e.eqc_c_nomePonto).IsUnicode(false);

                entity.Property(e => e.eqc_c_porta)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.eqc_c_senhaRemota)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.eqc_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.eqc_c_versao)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.eqc_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.eqc_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.eqc_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.eqc_d_ultimoContato).HasColumnType("datetime");

                entity.HasOne(d => d.eqc_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_eqc_equipamentoCliente)
                    .HasForeignKey(d => d.eqc_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_eqc_equipamentoCliente_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_err_erro>(entity =>
            {
                entity.HasKey(e => e.err_n_codigo);

                entity.Property(e => e.err_c_inner).IsUnicode(false);

                entity.Property(e => e.err_c_innerStack).IsUnicode(false);

                entity.Property(e => e.err_c_message).IsUnicode(false);

                entity.Property(e => e.err_c_stack).IsUnicode(false);

                entity.Property(e => e.erro_d_data).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_est_estado>(entity =>
            {
                entity.HasKey(e => e.est_n_codigo)
                    .HasName("pk_tb_est_estado");

                entity.Property(e => e.est_c_descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.est_c_sigla)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.est_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.est_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.est_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<tb_eti_entidadeTipo>(entity =>
            {
                entity.HasKey(e => e.eti_n_codigo);

                entity.Property(e => e.ent_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ent_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ent_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.eti_c_nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.eti_ent_n_codigoNavigation)
                    .WithMany(p => p.tb_eti_entidadeTipo)
                    .HasForeignKey(d => d.eti_ent_n_codigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_eti_entidadeTipo_tb_ent_entidade");

                entity.HasOne(d => d.eti_tlc_n_codigoNavigation)
                    .WithMany(p => p.tb_eti_entidadeTipo)
                    .HasForeignKey(d => d.eti_tlc_n_codigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_eti_entidadeTipo_tb_tcl_tipoCliente");
            });

            modelBuilder.Entity<tb_eva_eventoAcesso>(entity =>
            {
                entity.HasKey(e => e.eva_n_codigo);

                entity.Property(e => e.eva_c_descricao).IsUnicode(false);

                entity.Property(e => e.eva_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.eva_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.eva_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.eva_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_eve_evento>(entity =>
            {
                entity.HasKey(e => e.eve_n_codigo)
                    .HasName("PK_tb_eve_evento_1");

                entity.HasIndex(e => new { e.eve_cli_n_codigo, e.eve_b_lido })
                    .HasName("IX_tb_eve_evento");

                entity.Property(e => e.eve_c_conta).IsUnicode(false);

                entity.Property(e => e.eve_c_evento).IsUnicode(false);

                entity.Property(e => e.eve_c_ip).IsUnicode(false);

                entity.Property(e => e.eve_c_particao).IsUnicode(false);

                entity.Property(e => e.eve_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.eve_c_zona).IsUnicode(false);

                entity.Property(e => e.eve_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.eve_d_inclusao).HasColumnType("datetime");

                entity.Property(e => e.eve_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.eve_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_eve_evento)
                    .HasForeignKey(d => d.eve_cli_n_codigo)
                    .HasConstraintName("FK_tb_eve_evento_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_exc_exclusoes>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.exc_cli_c_unique)
                    .IncludeProperties<tb_exc_exclusoes>(e => new
                    {
                        e.exc_c_tabela,
                        e.exc_c_id,
                        e.exc_d_dataExclusao
                    })
                    .HasName("idx_tb_exc_exclusoes99");

                entity.Property(e => e.exc_d_dataExclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");


                entity.Property(e => e.exc_c_tabela).IsUnicode(false);
            });

            modelBuilder.Entity<tb_fap_fotoApp>(entity =>
            {
                entity.HasKey(e => e.fap_n_codigo);

                entity.Property(e => e.fap_d_atualizado).HasColumnType("datetime");

                entity.Property(e => e.fap_d_inclusao).HasColumnType("datetime");

                entity.Property(e => e.fap_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_fem_fotoEmpresa>(entity =>
            {
                entity.HasKey(e => e.fem_n_codigo);

                entity.Property(e => e.fem_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.fem_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fem_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fem_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_fer_feriado>(entity =>
            {
                entity.HasKey(e => e.fer_n_codigo)
                    .HasName("PK_feriado");

                entity.Property(e => e.fer_c_descricao).IsUnicode(false);

                entity.Property(e => e.fer_c_recorrente)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.fer_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.fer_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fer_d_data)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.fer_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fer_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.fer_n_codigoClienteNavigation)
                    .WithMany(p => p.tb_fer_feriado)
                    .HasForeignKey(d => d.fer_n_codigoCliente)
                    .HasConstraintName("FK_cliente");
            });

            modelBuilder.Entity<tb_fot_foto>(entity =>
            {
                entity.HasKey(e => e.fot_n_codigo);

                entity.Property(e => e.fot_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.fot_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fot_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fot_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.fot_c_url);
            });

            modelBuilder.Entity<tb_ftd_fotoDependencia>(entity =>
            {
                entity.HasKey(e => e.ftd_n_codigo);

                entity.Property(e => e.ftd_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ftd_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ftd_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ftd_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_gpp_grupoPermissaoOperador>(entity =>
            {
                entity.HasKey(e => e.gpp_n_codigo);
                entity.Property(e => e.gpp_c_descricao).IsUnicode(false);
                entity.Property(e => e.gpp_c_unique).HasDefaultValueSql("(newid())");
                entity.Property(e => e.gpp_c_usuario).IsUnicode(false);
                entity.Property(e => e.gpp_d_alteracao).HasColumnType("date");
                entity.Property(e => e.gpp_d_atualizado).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.gpp_d_inclusao).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.gpp_d_modificacao).HasColumnType("datetime");
                entity.Property(e => e.gpp_pta_c_codigo).IsUnicode(false);

                entity.HasOne(d => d.gpp_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_gpp_grupoPermissaoOperador)
                    .HasForeignKey(d => d.gpp_cli_n_codigo)
                    .HasConstraintName("fk_tb_gpp_grupoPermissaoOperador");

                entity.HasOne(d => d.gpp_emp_n_codigoNavigation)
                    .WithMany(p => p.tb_gpp_grupoPermissaoOperador)
                    .HasForeignKey(d => d.gpp_emp_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_gpp_grupoPermissaoOperador_tb_emp_empresa");

                entity.HasOne(d => d.gpp_mol_n_codigoNavigation)
                    .WithMany(p => p.tb_gpp_grupoPermissaoOperador)
                    .HasForeignKey(d => d.gpp_mol_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_gpp_grupoPermissaoOperador_tb_mol_modulosLiberados");
            });

            modelBuilder.Entity<tb_gpv_grupoVagas>(entity =>
            {
                entity.HasKey(e => e.gpv_n_codigo);

                entity.Property(e => e.gpv_c_descricao).IsUnicode(false);

                entity.Property(e => e.gpv_c_perfil).IsUnicode(false);

                entity.Property(e => e.gpv_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.gpv_c_usuario).IsUnicode(false);

                entity.Property(e => e.gpv_d_alteracao).HasColumnType("date");

                entity.Property(e => e.gpv_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.gpv_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.gpv_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.gpv_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_gpv_grupoVagas)
                    .HasForeignKey(d => d.gpv_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_gpv_grupoVagas_tb_cli_cliente");

                entity.HasOne(d => d.gpv_phr_n_codigoNavigation)
                    .WithMany(p => p.tb_gpv_grupoVagas)
                    .HasForeignKey(d => d.gpv_phr_n_codigo)
                    .HasConstraintName("FK_tb_gpv_grupoVagas_tb_phr_perfilhorario");
            });

            modelBuilder.Entity<tb_grf_grupoFamiliar>(entity =>
            {
                entity.HasKey(e => e.grf_n_codigo);

                entity.Property(e => e.grf_c_BlocoQuadra)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.grf_c_LoteApto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.grf_c_autorizacaoPRO).IsUnicode(false);

                entity.Property(e => e.grf_c_celular)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.grf_c_cpf)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.grf_c_email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.grf_c_nomeResponsavel).IsUnicode(false);

                entity.Property(e => e.grf_c_numeroVagas)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.grf_c_observacao).IsUnicode(false);

                entity.Property(e => e.grf_c_rg)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.grf_c_estado);

                entity.Property(e => e.grf_c_senhaApp).IsUnicode(false);

                entity.Property(e => e.grf_c_status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.grf_c_telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.grf_c_tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.grf_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.grf_c_usuario).IsUnicode(false);

                entity.Property(e => e.grf_d_alteracao).HasColumnType("date");

                entity.Property(e => e.grf_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.grf_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.grf_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.grf_b_permiteHomeCare)
                   .HasDefaultValueSql("((0))");

                entity.Property(e => e.grf_c_canal_principal)
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.grf_c_nomeSalaComercial).IsUnicode(false);

                //entity.Property(e => e.grf_c_observacoesHomeCare)
                //   .HasMaxLength(450)
                //   .IsUnicode(false);

                entity.HasOne(d => d.grf_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_grf_grupoFamiliar)
                    .HasForeignKey(d => d.grf_cli_n_codigo)
                    .HasConstraintName("FK_tb_grf_grupoFamiliar_tb_cli_cliente");

                entity.HasOne(d => d.grf_fot_n_codigoNavigation)
                    .WithMany(p => p.tb_grf_grupoFamiliar)
                    .HasForeignKey(d => d.grf_fot_n_codigo)
                    .HasConstraintName("FK_tb_grf_grupoFamiliar_tb_fot_foto");

                entity.HasOne(d => d.grf_ace_n_codigoNavigation)
                  .WithMany(p => p.tb_grf_grupoFamiliar)
                  .HasForeignKey(d => d.grf_ace_n_codigo)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK_tb_grf_grupoFamiliar_tb_ace_acesso");
            });

            modelBuilder.Entity<tb_hdi_historicoDispositivo>(entity =>
            {
                entity.HasKey(e => e.hdi_n_codigo);

                entity.Property(e => e.hdi_c_mensagem).IsUnicode(false);

                entity.Property(e => e.hdi_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.hdi_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.hdi_d_data).HasColumnType("datetime");

                entity.Property(e => e.hdi_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.hdi_con_n_codigoNavigation)
                    .WithMany(p => p.tb_hdi_historicoDispositivo)
                    .HasForeignKey(d => d.hdi_con_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_hdi_historicoDispositivo_tb_con_controladora");
            });

            modelBuilder.Entity<tb_hil_historicoLiberacao>(entity =>
            {
                entity.HasKey(e => e.hil_n_codigo);

                entity.Property(e => e.hil_c_nomeUsuario).IsUnicode(false);

                entity.Property(e => e.hil_c_observacao).IsUnicode(false);

                entity.Property(e => e.hil_c_status).IsUnicode(false);

                entity.Property(e => e.hil_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.hil_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.hil_d_data).HasColumnType("datetime");

                entity.Property(e => e.hil_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.hil_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.hil_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_hil_historicoLiberacao)
                    .HasForeignKey(d => d.hil_mor_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_hil_historicoLiberacao_tb_mor_morador");
            });

            modelBuilder.Entity<tb_hor_horario>(entity =>
            {
                entity.HasKey(e => e.hor_n_codigo);

                entity.Property(e => e.hor_c_diaSemana).IsUnicode(false);

                entity.Property(e => e.hor_c_nome).IsUnicode(false);

                entity.Property(e => e.hor_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.hor_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.hor_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.hor_d_inicia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.hor_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.hor_d_termina)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.hor_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_hor_horario)
                    .HasForeignKey(d => d.hor_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_hor_horario_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_lay_layout>(entity =>
            {
                entity.HasKey(e => e.lay_n_codigo);

                entity.Property(e => e.lay_c_canais).IsUnicode(false);

                entity.Property(e => e.lay_c_exibeLayout).IsUnicode(false);

                entity.Property(e => e.lay_c_nome).IsUnicode(false);

                entity.Property(e => e.lay_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.lay_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lay_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lay_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.lay_cla_n_codigoNavigation)
                    .WithMany(p => p.tb_lay_layout)
                    .HasForeignKey(d => d.lay_cla_n_codigo)
                    .HasConstraintName("FK_tb_lay_layout_tb_cla_cabecalhoLayout");

                entity.HasOne(d => d.lay_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_lay_layout)
                    .HasForeignKey(d => d.lay_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_lay_layout_tb_cli_cliente");

                entity.HasOne(d => d.lay_ddv_n_codigoNavigation)
                    .WithMany(p => p.tb_lay_layout)
                    .HasForeignKey(d => d.lay_ddv_n_codigo)
                    .HasConstraintName("FK_tb_lay_layout_tb_ddv_dispositivoDVRCliente");
            });

            modelBuilder.Entity<tb_lbr_logBackupRestauracao>(entity =>
            {
                entity.HasKey(e => e.lbr_n_codigo);

                entity.Property(e => e.lbr_c_mensagem)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.lbr_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.lbr_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lbr_d_fim).HasColumnType("datetime");

                entity.Property(e => e.lbr_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lbr_d_inicio).HasColumnType("datetime");

                entity.HasOne(d => d.lbr_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_lbr_logBackupRestauracao)
                    .HasForeignKey(d => d.lbr_cli_n_codigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_lbr_logBackupRestauracao_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_lcc_localidadeCliente>(entity =>
            {
                entity.HasKey(e => e.lcc_n_codigo);

                entity.Property(e => e.lcc_c_descricao).IsUnicode(false);

                entity.Property(e => e.lcc_c_tipoLocalidade).IsUnicode(false);

                entity.Property(e => e.lcc_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.lcc_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lcc_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lcc_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.lcc_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_lcc_localidadeCliente)
                    .HasForeignKey(d => d.lcc_cli_n_codigo)
                    .HasConstraintName("FK_tb_lcc_localidadeCliente_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_lcg_localidadeClienteGrupoFamiliar>(entity =>
            {
                entity.HasKey(e => e.lcg_n_codigo);

                entity.Property(e => e.lcg_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.lcg_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lcg_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lcg_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.lcg_n_vagas);

                entity.HasOne(d => d.lcg_grf_n_codigoNavigation)
                    .WithMany(p => p.tb_lcg_localidadeClienteGrupoFamiliar)
                    .HasForeignKey(d => d.lcg_grf_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_lcg_localidadeClienteGrupoFamiliar_tb_grf_GrupoFamiliar");

                entity.HasOne(d => d.lcg_lcc_n_codigoBlocoQuadraNavigation)
                    .WithMany(p => p.tb_lcg_localidadeClienteGrupoFamiliar)
                    .HasForeignKey(d => d.lcg_lcc_n_codigoBlocoQuadra)
                    .HasConstraintName("FK_tb_lcg_localidadeClienteGrupoFamiliar_tb_lcc_localidadeCliente");

                entity.HasOne(d => d.lcg_lcc_n_codigoLoteAptoNavigation)
                   .WithMany(p => p.tb_lcg_localidadeClienteGrupoFamiliarLoteApto)
                   .HasForeignKey(d => d.lcg_lcc_n_codigoLoteApto)
                   .HasConstraintName("FK_tb_lcg_localidadeClienteGrupoFamiliar_tb_lcc_localidadeClienteLoteApto");
            });

            modelBuilder.Entity<tb_lid_liberacaoDelivery>(entity =>
            {
                entity.HasKey(e => e.lid_n_codigo);

                entity.Property(e => e.lid_c_descricao).IsUnicode(false);

                entity.Property(e => e.lid_c_token).IsUnicode(false);

                entity.Property(e => e.lid_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.lid_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lid_d_dataHora).HasColumnType("datetime");

                entity.Property(e => e.lid_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lid_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.lid_c_nomeEmpresa)
                   .HasMaxLength(250)
                   .IsUnicode(false);

                entity.HasOne(d => d.lid_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_lid_liberacaoDelivery)
                    .HasForeignKey(d => d.lid_mor_n_codigo)
                    .HasConstraintName("FK_tb_lid_liberacaoDelivery_tb_mor_Morador");
            });

            modelBuilder.Entity<tb_lip_liberacaoPrestador>(entity =>
            {
                entity.HasKey(e => e.lip_n_codigo);

                entity.Property(e => e.lip_c_celular).IsUnicode(false);

                entity.Property(e => e.lip_c_nome).IsUnicode(false);

                entity.Property(e => e.lip_c_rg).IsUnicode(false);

                entity.Property(e => e.lip_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.lip_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lip_d_dataEntrada).HasColumnType("datetime");

                entity.Property(e => e.lip_d_dataHora).HasColumnType("datetime");

                entity.Property(e => e.lip_d_dataSaida).HasColumnType("datetime");

                entity.Property(e => e.lip_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lip_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.lip_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_lip_liberacaoPrestador)
                    .HasForeignKey(d => d.lip_mor_n_codigo)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_tb_lip_liberacaoPrestador_tb_mor_Morador");
            });

            modelBuilder.Entity<tb_liv_liberacaoVisitante>(entity =>
            {
                entity.HasKey(e => e.liv_n_codigo);

                entity.Property(e => e.liv_c_celular).IsUnicode(false);

                entity.Property(e => e.liv_c_nome).IsUnicode(false);

                entity.Property(e => e.liv_c_rg).IsUnicode(false);

                entity.Property(e => e.liv_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.liv_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.liv_d_dataEntrada).HasColumnType("datetime");

                entity.Property(e => e.liv_d_dataHora).HasColumnType("datetime");

                entity.Property(e => e.liv_d_dataSaida).HasColumnType("datetime");

                entity.Property(e => e.liv_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.liv_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.liv_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_liv_liberacaoVisitante)
                    .HasForeignKey(d => d.liv_mor_n_codigo)
                    .HasConstraintName("FK_tb_liv_liberacaoVisitante_tb_mor_morador");

                entity.HasOne(d => d.liv_vis_n_codigoNavigation)
                    .WithMany(p => p.tb_liv_liberacaoVisitante)
                    .HasForeignKey(d => d.liv_vis_n_codigo)
                    .HasConstraintName("FK_tb_liv_liberacaoVisitante_tb_vis_visitasApp");


                entity.HasOne(d => d.liv_visitante_n_codigoNavigation)
                   .WithMany(p => p.tb_liv_liberacaoVisitante)
                   .HasForeignKey(d => d.liv_visitante_n_codigo)
                   .HasConstraintName("FK_tb_liv_liberacaoVisitante_tb_vis_visitante");
            });

            modelBuilder.Entity<tb_lsm_logSMS>(entity =>
            {
                entity.HasKey(e => e.lsm_n_codigo);

                entity.Property(e => e.lsm_c_nomeContato).IsUnicode(false);

                entity.Property(e => e.lsm_c_numeroContato).IsUnicode(false);

                entity.Property(e => e.lsm_d_data).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_mav_marcaVeiculo>(entity =>
            {
                entity.HasKey(e => e.mav_n_codigo)
                    .HasName("PK_tb_mrv_marcaVeiculo");

                entity.Property(e => e.mav_c_descricao).IsUnicode(false);

                entity.Property(e => e.mav_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.mav_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.mav_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.mav_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_mch_monitoramentoControleAcesso_historico>(entity =>
            {
                entity.HasKey(e => e.mch_n_codigo)
                    .HasName("PK_mch_monitoramentoControleAcesso_historico");

                entity.Property(e => e.mch_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.mch_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.mch_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<tb_moc_motivoOcorrenciaCliente>(entity =>
            {
                entity.HasKey(e => e.moc_n_codigo);

                entity.Property(e => e.moc_c_descricao)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.moc_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.moc_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.moc_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.moc_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.moc_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_moc_motivoOcorrenciaCliente)
                    .HasForeignKey(d => d.moc_cli_n_codigo)
                    .HasConstraintName("FK_tb_moc_motivoOcorrenciaCliente_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_mol_modulosLiberados>(entity =>
            {
                entity.HasKey(e => e.mol_n_codigo).HasName("PK_tb_mod_modulo");
                entity.Property(x => x.mol_b_controleDeAcesso);
                entity.Property(x => x.mol_b_CFTV);
                entity.Property(x => x.mol_b_MonitoriamentoPerimetral);
                entity.Property(x => x.mol_b_OrdemServico);
                entity.Property(x => x.mol_b_connectSolutions);
                entity.Property(x => x.mol_b_connectSync);
                entity.Property(x => x.mol_b_accessView);
                entity.Property(x => x.mol_b_connectPRO);
                entity.Property(x => x.mol_b_connectGaren);
                entity.Property(x => x.mol_b_portariaVirtual);
                entity.Property(x => x.mol_b_comboUsuarioGuard);
                entity.Property(e => e.mol_c_unique).HasDefaultValueSql("(newid())");
                entity.Property(e => e.mol_d_atualizado).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.mol_d_inclusao).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.mol_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_mon_monitoramento>(entity =>
            {
                entity.HasKey(e => e.mon_n_codigo);

                entity.HasIndex(e => new { e.mon_b_exibido, e.mon_d_dataExibicao, e.mon_zoc_n_codigo })
                    .HasName("IX_tb_mon_monitoramento");

                entity.Property(e => e.mon_c_motivo).IsUnicode(false);

                entity.Property(e => e.mon_c_motivoConclusao).IsUnicode(false);

                entity.Property(e => e.mon_c_observacao).IsUnicode(false);

                entity.Property(e => e.mon_c_observacaoConclusao).IsUnicode(false);

                entity.Property(e => e.mon_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.mon_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.mon_d_dataEdicao).HasColumnType("datetime");

                entity.Property(e => e.mon_d_dataEvento).HasColumnType("datetime");

                entity.Property(e => e.mon_d_dataEventoConclusao).HasColumnType("datetime");

                entity.Property(e => e.mon_d_dataExibicao).HasColumnType("datetime");

                entity.Property(e => e.mon_d_dataInsercao).HasColumnType("datetime");

                entity.Property(e => e.mon_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.mon_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.mon_c_pessoa).IsUnicode(false);
                entity.Property(e => e.mon_c_tipoPessoa).IsUnicode(false);
                entity.Property(e => e.mon_n_codigoPessoa);
                entity.Property(e => e.mon_c_pessoaConclusao).IsUnicode(false);
                entity.Property(e => e.mon_c_tipoPessoaConclusao).IsUnicode(false);
                entity.Property(e => e.mon_n_codigoPessoaConclusao);

                entity.HasOne(d => d.mon_cev_n_codigoNavigation)
                    .WithMany(p => p.tb_mon_monitoramento)
                    .HasForeignKey(d => d.mon_cev_n_codigo)
                    .HasConstraintName("FK_tb_mon_monitoramento_tb_cev_categorizacaoEvento");

                entity.HasOne(d => d.mon_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_mon_monitoramento)
                    .HasForeignKey(d => d.mon_cli_n_codigo)
                    .HasConstraintName("FK_tb_mon_monitoramento_tb_cli_cliente");

                entity.HasOne(d => d.mon_eve_n_codigoNavigation)
                    .WithMany(p => p.tb_mon_monitoramento)
                    .HasForeignKey(d => d.mon_eve_n_codigo)
                    .HasConstraintName("FK_tb_mon_monitoramento_tb_eve_evento");

                entity.HasOne(d => d.mon_pec_n_codigoNavigation)
                    .WithMany(p => p.tb_mon_monitoramento)
                    .HasForeignKey(d => d.mon_pec_n_codigo)
                    .HasConstraintName("FK_tb_mon_monitoramento_tb_pec_processoExclusaoCliente");

                entity.HasOne(d => d.mon_stm_n_codigoNavigation)
                    .WithMany(p => p.tb_mon_monitoramento)
                    .HasForeignKey(d => d.mon_stm_n_codigo)
                    .HasConstraintName("FK_tb_mon_monitoramento_tb_stm_statusMonitoramento");

                entity.HasOne(d => d.mon_zoc_n_codigoNavigation)
                    .WithMany(p => p.tb_mon_monitoramento)
                    .HasForeignKey(d => d.mon_zoc_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_mon_monitoramento_tb_eqc_equipamentoCliente");
            });

            modelBuilder.Entity<tb_mor_Morador>(entity =>
            {
                entity.HasKey(e => e.mor_n_codigo)
                    .HasName("pk_tb_mor_morador");

                entity.Property(e => e.mor_c_autorizacao).IsUnicode(false);

                entity.Property(e => e.mor_c_autorizacaoPRO).IsUnicode(false);

                entity.Property(e => e.mor_c_celular).IsUnicode(false);

                entity.Property(e => e.mor_c_contraSenha).IsUnicode(false);

                entity.Property(e => e.mor_c_cpf).IsUnicode(false);

                entity.Property(e => e.mor_c_email).IsUnicode(false);

                entity.Property(e => e.mor_c_nome).IsUnicode(false);

                entity.Property(e => e.mor_c_observacao).IsUnicode(false);

                entity.Property(e => e.mor_c_perfil).IsUnicode(false);

                entity.Property(e => e.mor_c_ramal).IsUnicode(false);

                entity.Property(e => e.mor_c_rg).IsUnicode(false);

                entity.Property(e => e.mor_c_senha).IsUnicode(false);

                entity.Property(e => e.mor_c_senhaAPPPro).IsUnicode(false);

                entity.Property(e => e.mor_c_telefonePermitido).IsUnicode(false);

                entity.Property(e => e.mor_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.mor_c_usuario).IsUnicode(false);

                entity.Property(e => e.mor_d_alteracao).HasColumnType("date");

                entity.Property(e => e.mor_c_estado);

                entity.Property(e => e.mor_vec_n_codigo);

                entity.Property(e => e.mor_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.mor_d_dataEntrada).HasColumnType("datetime");

                entity.Property(e => e.mor_d_dataNascimento).HasColumnType("datetime");

                entity.Property(e => e.mor_d_dataInclusaoIntegracao).HasColumnType("datetime");

                entity.Property(e => e.mor_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.mor_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.mor_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_mor_Morador)
                    .HasForeignKey(d => d.mor_cli_n_codigo)
                    .HasConstraintName("FK_tb_mor_Morador_tb_cli_cliente");

                entity.HasOne(d => d.mor_fot_n_codigoNavigation)
                    .WithMany(p => p.tb_mor_Moradormor_fot_n_codigoNavigation)
                    .HasForeignKey(d => d.mor_fot_n_codigo)
                    .HasConstraintName("FK_tb_mor_Morador_tb_fot_foto");

                entity.HasOne(d => d.mor_fot_n_documentoNavigation)
                    .WithMany(p => p.tb_mor_Moradormor_fot_n_documentoNavigation)
                    .HasForeignKey(d => d.mor_fot_n_documento)
                    .HasConstraintName("FK_tb_mor_morador_tb_fot_foto_doc");

                entity.HasOne(d => d.mor_grf_n_codigoNavigation)
                    .WithMany(p => p.tb_mor_Morador)
                    .HasForeignKey(d => d.mor_grf_n_codigo)
                    .HasConstraintName("FK_tb_mor_Morador_tb_grf_grupoFamiliar");

                entity.HasOne(d => d.mor_vec_n_codigoNavigation)
                    .WithMany(p => p.tb_mor_Morador)
                    .HasForeignKey(d => d.mor_vec_n_codigo)
                    .HasConstraintName("FK_tb_mor_Morador_tb_vec_veiculo");

                entity.HasOne(d => d.mor_fro_n_codigoNavigation)
                    .WithMany(p => p.tb_mor_Morador)
                    .HasForeignKey(d => d.mor_fro_n_codigo)
                    .HasConstraintName("FK_tb_mor_Morador_tb_fro_frota");
            });

            modelBuilder.Entity<tb_mos_moduloOrdemServicoLiberado>(entity =>
            {
                entity.HasKey(e => e.mos_n_codigo);

                entity.Property(e => e.mos_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.mos_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.mos_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.mos_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_mpc_mapeamentoPontoAcesso>(entity =>
            {
                entity.HasKey(e => e.mpc_n_codigo);

                entity.Property(e => e.mpc_c_tempoGravacao).IsUnicode(false);

                entity.HasOne(d => d.mpc_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_mpc_mapeamentoPontoAcesso)
                    .HasForeignKey(d => d.mpc_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_mpc_mapeamentoPontoAcesso_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_not_notificacao>(entity =>
            {
                entity.HasKey(e => e.not_n_codigo);

                entity.Property(e => e.not_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.not_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.not_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.not_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.not_avi_n_codigoNavigation)
                    .WithMany(p => p.tb_not_notificacao)
                    .HasForeignKey(d => d.not_avi_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_not_notificacao_tb_avi_aviso");

                entity.HasOne(d => d.not_avi_n_codigoEmpresaNavigation)
                    .WithMany(p => p.tb_not_notificacao)
                    .HasForeignKey(d => d.not_avi_n_codigoEmpresa)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_not_notificacao_tb_avi_avisoEmpresa");

                entity.HasOne(d => d.not_ope_n_codigoNavigation)
                    .WithMany(p => p.tb_not_notificacao)
                    .HasForeignKey(d => d.not_ope_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_not_notificacao_tb_ope_operador");
            });

            modelBuilder.Entity<tb_not_notificacaoApp>(entity =>
            {
                entity.HasKey(e => e.not_n_codigo);

                entity.Property(e => e.not_c_cor).IsUnicode(false);

                entity.Property(e => e.not_c_mensagem).IsUnicode(false);

                entity.Property(e => e.not_c_origem).IsUnicode(false);

                entity.Property(e => e.not_c_retornoPush).IsUnicode(false);

                entity.Property(e => e.not_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.not_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.not_d_data).HasColumnType("datetime");

                entity.Property(e => e.not_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.not_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.not_b_lido)
                  .HasDefaultValueSql("((0))");

                entity.Property(e => e.not_b_tocado)
           .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.not_eno_n_codigoNavigation)
                    .WithMany(p => p.tb_not_notificacaoApp)
                    .HasForeignKey(d => d.not_eno_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_not_notificacaoApp_tb_eno_envioNotificacao");

                entity.HasOne(d => d.not_zec_n_codigoNavigation)
                    .WithMany(p => p.tb_not_notificacaoApp)
                    .HasForeignKey(d => d.not_zec_n_codigo)
                    .HasConstraintName("FK_tb_not_notificacaoApp_tb_zec_zeladorCliente");
            });

            modelBuilder.Entity<tb_ope_operador>(entity =>
            {
                entity.HasKey(e => e.ope_n_codigo);

                entity.Property(e => e.ope_c_bairro).IsUnicode(false);

                entity.Property(e => e.ope_c_cargo).IsUnicode(false);

                entity.Property(e => e.ope_c_celular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ope_c_cep)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ope_c_complemento).IsUnicode(false);

                entity.Property(e => e.ope_c_cpf)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.ope_c_email).IsUnicode(false);

                entity.Property(e => e.ope_c_email2).IsUnicode(false);

                entity.Property(e => e.ope_c_nome).IsUnicode(false);

                entity.Property(e => e.ope_c_numero).IsUnicode(false);

                entity.Property(e => e.ope_c_observacao).IsUnicode(false);

                entity.Property(e => e.ope_c_rg)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ope_c_rua).IsUnicode(false);

                entity.Property(e => e.ope_c_telefone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ope_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ope_c_usuario).IsUnicode(false);

                entity.Property(e => e.ope_d_alteracao).HasColumnType("date");

                entity.Property(e => e.ope_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ope_d_dataNascimento).HasColumnType("datetime");

                entity.Property(e => e.ope_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ope_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.ope_d_ultimoContato).HasColumnType("datetime");

                entity.HasOne(d => d.ope_ace_n_codigoNavigation)
                    .WithMany(p => p.tb_ope_operador)
                    .HasForeignKey(d => d.ope_ace_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_ope_operador_tb_ace_acesso");

                entity.HasOne(d => d.ope_cid_n_codigoNavigation)
                    .WithMany(p => p.tb_ope_operador)
                    .HasForeignKey(d => d.ope_cid_n_codigo)
                    .HasConstraintName("FK_tb_ope_operador_tb_cid_cidade");

                entity.HasOne(d => d.ope_emp_n_codigoNavigation)
                    .WithMany(p => p.tb_ope_operador)
                    .HasForeignKey(d => d.ope_emp_n_codigo)
                    .HasConstraintName("FK_tb_ope_operador_tb_emp_empresa");

                entity.HasOne(d => d.ope_est_n_codigoNavigation)
                    .WithMany(p => p.tb_ope_operador)
                    .HasForeignKey(d => d.ope_est_n_codigo)
                    .HasConstraintName("FK_tb_ope_operador_tb_est_estado");

                entity.HasOne(d => d.ope_mol_n_codigoNavigation)
                    .WithMany(p => p.tb_ope_operador)
                    .HasForeignKey(d => d.ope_mol_n_codigo)
                    .HasConstraintName("FK_tb_ope_operador_tb_mol_modulosLiberados");

                entity.HasOne(d => d.ope_pop_n_codigoNavigation)
                    .WithMany(p => p.tb_ope_operador)
                    .HasForeignKey(d => d.ope_pop_n_codigo)
                    .HasConstraintName("FK_tb_ope_operador_tb_pop_perfilOperador");
            });

            modelBuilder.Entity<tb_opl_operadorLocal>(entity =>
            {
                entity.HasKey(e => e.opl_n_codigo);

                entity.Property(e => e.opl_c_login).IsUnicode(false);

                entity.Property(e => e.opl_c_nome).IsUnicode(false);

                entity.Property(e => e.opl_c_senha).IsUnicode(false);

                entity.Property(e => e.opl_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.opl_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.opl_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.opl_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.opl_d_ultimoContato).HasColumnType("datetime");

                entity.Property(e => e.opl_c_rg);

                entity.Property(e => e.opl_c_cpf);

                entity.Property(e => e.opl_c_telefone);

                entity.Property(e => e.opl_c_email);

                entity.HasOne(d => d.opl_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_opl_operadorLocal)
                    .HasForeignKey(d => d.opl_cli_n_codigo)
                    .HasConstraintName("FK_tb_opl_operadorLocal_tb_cli_cliente");

                entity.HasOne(d => d.opl_gpp_n_codigoNavigation)
                    .WithMany(p => p.tb_opl_operadorLocal)
                    .HasForeignKey(d => d.opl_gpp_n_codigo)
                    .HasConstraintName("FK_tb_opl_operadorLocal_tb_gpp_grupoPermissaoOperador");
            });

            modelBuilder.Entity<tb_opo_operadorOnline>(entity =>
            {
                entity.HasKey(e => e.opo_n_codigo);

                entity.HasOne(d => d.opo_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_opo_operadorOnline)
                    .HasForeignKey(d => d.opo_cli_n_codigo)
                    .HasConstraintName("FK_tb_opo_operadorOnline_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_pan_panicoApp>(entity =>
            {
                entity.HasKey(e => e.pan_n_codigo);

                entity.Property(e => e.pan_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.pan_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pan_d_dataPanico).HasColumnType("datetime");

                entity.Property(e => e.pan_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.pan_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_pan_panicoApp)
                    .HasForeignKey(d => d.pan_mor_n_codigo)
                    .HasConstraintName("FK_tb_pan_panicoApp_tb_mor_Morador");
            });

            modelBuilder.Entity<tb_par_parametros>(entity =>
            {
                entity.HasKey(e => e.par_n_codigo);

                entity.Property(e => e.par_c_aba)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.par_c_chave)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.par_c_descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.par_c_titulo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.par_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.par_c_valor).IsUnicode(false);

                entity.Property(e => e.par_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.par_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.par_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_par_parametrosEmpresa>(entity =>
            {
                entity.HasKey(e => e.par_n_codigo)
                    .HasName("PK_tb_par_parametrosEmpresaz");

                entity.Property(e => e.par_c_aba)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.par_c_chave)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.par_c_descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.par_c_titulo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.par_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.par_c_valor).IsUnicode(false);

                entity.Property(e => e.par_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.par_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.par_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.par_emp_n_codigoNavigation)
                    .WithMany(p => p.tb_par_parametrosEmpresa)
                    .HasForeignKey(d => d.par_emp_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_par_parametrosEmpresa_tb_emp_empresa");
            });

            modelBuilder.Entity<tb_pec_permissaoCliente>(entity =>
            {
                entity.HasKey(e => e.pec_n_codigo);

                entity.Property(e => e.pec_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.pec_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pec_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pec_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.pec_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_pec_permissaoCliente)
                    .HasForeignKey(d => d.pec_cli_n_codigo)
                    .HasConstraintName("FK_tb_pec_permissaoCliente_tb_cli_cliente");

                entity.HasOne(d => d.pec_ope_n_codigoNavigation)
                    .WithMany(p => p.tb_pec_permissaoCliente)
                    .HasForeignKey(d => d.pec_ope_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_pec_permissaoCliente_tb_ope_operador");
            });

            modelBuilder.Entity<tb_pec_processoExclusaoCliente>(entity =>
            {
                entity.HasKey(e => e.pec_n_codigo)
                    .HasName("PK_Tb_pec_processoExclusaoCliente");

                entity.Property(e => e.pec_c_observacao).IsUnicode(false);

                entity.Property(e => e.pec_c_tipo).IsUnicode(false);

                entity.Property(e => e.pec_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.pec_c_usuario).IsUnicode(false);

                entity.Property(e => e.pec_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pec_d_data).HasColumnType("datetime");

                entity.Property(e => e.pec_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<tb_per_perfil>(entity =>
            {
                entity.HasKey(e => e.per_n_codigo)
                    .HasName("PK_tb_per_perfis");

                entity.Property(e => e.per_c_nome).IsUnicode(false);

                entity.Property(e => e.per_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.per_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.per_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.per_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_per_permissoes>(entity =>
            {
                entity.HasKey(e => e.per_n_codigo);

                entity.Property(e => e.per_c_descricao).IsUnicode(false);
            });

            modelBuilder.Entity<tb_pet_pet>(entity =>
            {
                entity.HasKey(e => e.pet_n_codigo)
                    .HasName("PK_tb_vec_veiculo");

                entity.Property(e => e.pet_c_caracteristicas).IsUnicode(false);

                entity.Property(e => e.pet_c_cor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pet_c_nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pet_c_pelagem)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pet_c_porte)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pet_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.pet_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pet_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pet_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.pet_fot_n_codigoNavigation)
                    .WithMany(p => p.tb_pet_pet)
                    .HasForeignKey(d => d.pet_fot_n_codigo)
                    .HasConstraintName("FK_tb_pet_pet_tb_fot_foto");

                entity.HasOne(d => d.pet_grf_n_codigoNavigation)
                    .WithMany(p => p.tb_pet_pet)
                    .HasForeignKey(d => d.pet_grf_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_pet_pet_tb_grf_grupoFamiliar");

                entity.HasOne(d => d.pet_rac_n_codigoNavigation)
                    .WithMany(p => p.tb_pet_pet)
                    .HasForeignKey(d => d.pet_rac_n_codigo)
                    .HasConstraintName("FK_tb_pet_pet_tb_rac_raca");
            });

            modelBuilder.Entity<tb_pgc_pgmCliente>(entity =>
            {
                entity.HasKey(e => e.pgc_n_codigo);

                entity.HasIndex(e => new { e.pgc_eqc_n_codigo, e.pgc_cpg_n_codigo })
                    .HasName("IX_tb_pgc_pgmCliente")
                    .IsUnique();

                entity.Property(e => e.pgc_c_nome)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.pgc_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.pgc_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pgc_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.pgc_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_pgc_pgmCliente)
                    .HasForeignKey(d => d.pgc_cli_n_codigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_pgc_pgmCliente_tb_cli_cliente");

                entity.HasOne(d => d.pgc_cpg_n_codigoNavigation)
                    .WithMany(p => p.tb_pgc_pgmCliente)
                    .HasForeignKey(d => d.pgc_cpg_n_codigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_pgc_pgmCliente_tb_cpg_comandoPGM");

                entity.HasOne(d => d.pgc_eqc_n_codigoNavigation)
                    .WithMany(p => p.tb_pgc_pgmCliente)
                    .HasForeignKey(d => d.pgc_eqc_n_codigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_pgc_pgmCliente_tb_eqc_equipamentoCliente");
            });

            modelBuilder.Entity<tb_pgp_permissoesGrupo>(entity =>
            {
                entity.HasKey(e => e.pgp_n_codigo);

                entity.Property(e => e.pgp_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.pgp_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pgp_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pgp_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.pgp_gpp_n_codigoNavigation)
                    .WithMany(p => p.tb_pgp_permissoesGrupo)
                    .HasForeignKey(d => d.pgp_gpp_n_codigo)
                    .HasConstraintName("FK_tb_pgp_permissoesGrupo_tb_gpp_grupoPermissaoOperador");

                entity.HasOne(d => d.pgp_top_n_codigoNavigation)
                    .WithMany(p => p.tb_pgp_permissoesGrupo)
                    .HasForeignKey(d => d.pgp_top_n_codigo)
                    .HasConstraintName("FK_tb_pgp_permissoesGrupo_tb_top_tipoPermissaoOperador");
            });

            modelBuilder.Entity<tb_phr_perfilHorario>(entity =>
            {
                entity.HasKey(e => e.phr_n_codigo);

                entity.Property(e => e.phr_c_nome).IsUnicode(false);

                entity.Property(e => e.phr_c_pontoAcesso).IsUnicode(false);

                entity.Property(e => e.phr_c_status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.phr_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.phr_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.phr_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.phr_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.phr_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_phr_perfilHorario)
                    .HasForeignKey(d => d.phr_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_phr_perfilHorario_tb_cli_cliente");

                entity.HasOne(d => d.phr_hor_n_codigoNavigation)
                    .WithMany(p => p.tb_phr_perfilHorario)
                    .HasForeignKey(d => d.phr_hor_n_codigo)
                    .HasConstraintName("FK_tb_phr_perfilHorario_tb_hor_horario");
            });

            modelBuilder.Entity<tb_plc_pontoLayoutCliente>(entity =>
            {
                entity.HasKey(e => e.plc_n_codigo);

                entity.Property(e => e.plc_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.plc_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.plc_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.plc_cla_n_codigoNavigation)
                    .WithMany(p => p.tb_plc_pontoLayoutCliente)
                    .HasForeignKey(d => d.plc_cla_n_codigo)
                    .HasConstraintName("FK_tb_plc_pontoLayoutCliente_tb_cla_cabecalhoLayout");

                entity.HasOne(d => d.plc_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_plc_pontoLayoutCliente)
                    .HasForeignKey(d => d.plc_cli_n_codigo)
                    .HasConstraintName("FK_tb_plc_pontoLayoutCliente_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_poa_portaAlarme>(entity =>
            {
                entity.HasKey(e => e.poa_n_codigo)
                    .HasName("PK_tb_par_porta");

                entity.Property(e => e.poa_c_porta).IsUnicode(false);

                entity.Property(e => e.poa_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.poa_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.poa_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.poa_emp_n_codigoNavigation)
                    .WithMany(p => p.tb_poa_portaAlarme)
                    .HasForeignKey(d => d.poa_emp_n_codigo)
                    .HasConstraintName("FK_tb_poa_portaAlarme_tb_emp_empresa");
            });

            modelBuilder.Entity<tb_por_portasStream>(entity =>
            {
                entity.HasKey(e => e.por_n_codigo);

                entity.Property(e => e.por_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.por_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.por_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.por_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_por_portasStream)
                    .HasForeignKey(d => d.por_cli_n_codigo)
                    .HasConstraintName("FK_tb_por_portasStream_tb_por_portasStream");
            });

            modelBuilder.Entity<tb_pro_proprietario>(entity =>
            {
                entity.HasKey(e => e.pro_n_codigo);

                entity.Property(e => e.pro_c_bairro).IsUnicode(false);

                entity.Property(e => e.pro_c_cargo).IsUnicode(false);

                entity.Property(e => e.pro_c_celular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_cep)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_complemento).IsUnicode(false);

                entity.Property(e => e.pro_c_cpf)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_email).IsUnicode(false);

                entity.Property(e => e.pro_c_email2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_nome).IsUnicode(false);

                entity.Property(e => e.pro_c_numero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_observacao).IsUnicode(false);

                entity.Property(e => e.pro_c_rg)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_rua).IsUnicode(false);

                entity.Property(e => e.pro_c_telefone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.pro_c_usuario).IsUnicode(false);

                entity.Property(e => e.pro_d_alteracao).HasColumnType("date");

                entity.Property(e => e.pro_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pro_d_dataNascimento).HasColumnType("datetime");

                entity.Property(e => e.pro_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pro_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.pro_ace_n_codigoNavigation)
                    .WithMany(p => p.tb_pro_proprietario)
                    .HasForeignKey(d => d.pro_ace_n_codigo)
                    .HasConstraintName("FK_tb_pro_proprietario_tb_ace_acesso");

                entity.HasOne(d => d.pro_cid_n_codigoNavigation)
                    .WithMany(p => p.tb_pro_proprietario)
                    .HasForeignKey(d => d.pro_cid_n_codigo)
                    .HasConstraintName("FK_tb_pro_proprietario_tb_cid_cidade");

                entity.HasOne(d => d.pro_est_n_codigoNavigation)
                    .WithMany(p => p.tb_pro_proprietario)
                    .HasForeignKey(d => d.pro_est_n_codigo)
                    .HasConstraintName("FK_tb_pro_proprietario_tb_est_estado");
            });

            modelBuilder.Entity<tb_pse_prestadorServico>(entity =>
            {
                entity.HasKey(e => e.pse_n_codigo);

                entity.Property(e => e.pse_c_celular).IsUnicode(false);

                entity.Property(e => e.pse_c_corVeiculo).IsUnicode(false);

                entity.Property(e => e.pse_c_cpf).IsUnicode(false);

                entity.Property(e => e.pse_c_email).IsUnicode(false);

                entity.Property(e => e.pse_c_localizacao).IsUnicode(false);

                entity.Property(e => e.pse_c_modeloVeiculo).IsUnicode(false);

                entity.Property(e => e.pse_c_nome).IsUnicode(false);

                entity.Property(e => e.pse_c_numeroCartao).IsUnicode(false);

                entity.Property(e => e.pse_c_observacao).IsUnicode(false);

                entity.Property(e => e.pse_c_perfil).IsUnicode(false);

                entity.Property(e => e.pse_c_placaVeiculo).IsUnicode(false);

                entity.Property(e => e.pse_c_rg).IsUnicode(false);

                entity.Property(e => e.pse_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.pse_c_usuario).IsUnicode(false);

                entity.Property(e => e.pse_d_alteracao).HasColumnType("date");

                entity.Property(e => e.pse_c_estado);

                entity.Property(e => e.pse_c_codExternoPrestador);

                entity.Property(e => e.pse_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pse_d_dataEntrada).HasColumnType("datetime");

                entity.Property(e => e.pse_d_dataExpriracao).HasColumnType("datetime");

                entity.Property(e => e.pse_d_dataSaidaManual).HasColumnType("datetime");

                entity.Property(e => e.pse_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pse_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.pse_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_pse_prestadorServico)
                    .HasForeignKey(d => d.pse_cli_n_codigo)
                    .HasConstraintName("FK_tb_pse_prestadorServico_tb_cli_cliente");

                entity.HasOne(d => d.pse_fot_n_codigoNavigation)
                    .WithMany(p => p.tb_pse_prestadorServicopse_fot_n_codigoNavigation)
                    .HasForeignKey(d => d.pse_fot_n_codigo)
                    .HasConstraintName("FK_tb_pse_prestadorServico_tb_fot_foto");

                entity.HasOne(d => d.pse_fot_n_documentoNavigation)
                    .WithMany(p => p.tb_pse_prestadorServicopse_fot_n_documentoNavigation)
                    .HasForeignKey(d => d.pse_fot_n_documento)
                    .HasConstraintName("FK_tb_pse_prestadorServico_tb_fot_foto_documento");

                entity.HasOne(d => d.pse_gpv_n_codigoNavigation)
                    .WithMany(p => p.tb_pse_prestadorServico)
                    .HasForeignKey(d => d.pse_gpv_n_codigo)
                    .HasConstraintName("FK_tb_pse_prestadorServico_tb_gpv_grupovagas");
            });

            modelBuilder.Entity<tb_pta_pontosAcesso>(entity =>
            {
                entity.HasKey(e => e.pta_n_codigo);

                entity.Property(e => e.pta_c_fluxo).IsUnicode(false);

                entity.Property(e => e.pta_c_nomePonto).IsUnicode(false);

                entity.Property(e => e.pta_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.pta_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pta_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pta_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.pta_b_exibirEventosReleAuxiliar)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.pta_c_descricaoReleAuxiliar)
                    .HasMaxLength(100);

                entity.Property(e => e.pta_c_periodoMonitoramentoDe)
                    .HasMaxLength(5);

                entity.Property(e => e.pta_c_periodoMonitoramentoAte)
                    .HasMaxLength(5);


                entity.HasOne(d => d.pta_cla_n_codigoNavigation)
                    .WithMany(p => p.tb_pta_pontosAcesso)
                    .HasForeignKey(d => d.pta_cla_n_codigo)
                    .HasConstraintName("FK_tb_pta_pontosAcesso_tb_cla_cabecalhoLayout");

                entity.HasOne(d => d.pta_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_pta_pontosAcesso)
                    .HasForeignKey(d => d.pta_cli_n_codigo)
                    .HasConstraintName("FK_tb_pta_pontosAcesso_tb_cli_cliente");

                entity.HasOne(d => d.pta_con_n_codigoNavigation)
                    .WithMany(p => p.tb_pta_pontosAcesso)
                    .HasForeignKey(d => d.pta_con_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_pta_pontosAcesso_tb_con_controladora");

                entity.HasOne(d => d.pta_lay_n_codigoNavigation)
                    .WithMany(p => p.tb_pta_pontosAcesso)
                    .HasForeignKey(d => d.pta_lay_n_codigo)
                    .HasConstraintName("FK_tb_pta_pontosAcesso_tb_lay_layout");
            });

            modelBuilder.Entity<tb_rac_raca>(entity =>
            {
                entity.HasKey(e => e.rac_n_codigo);

                entity.Property(e => e.rac_c_nome).IsUnicode(false);

                entity.Property(e => e.rac_c_tipo).IsUnicode(false);

                entity.Property(e => e.rac_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.rac_c_usuario).IsUnicode(false);

                entity.Property(e => e.rac_d_alteracao).HasColumnType("date");

                entity.Property(e => e.rac_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.rac_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.rac_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_ral_ramalLayout>(entity =>
            {
                entity.HasKey(e => e.ral_n_codigo);

                entity.Property(e => e.ral_c_ramal).IsUnicode(false);

                entity.Property(e => e.ral_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ral_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ral_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ral_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.ral_cla_n_codigoNavigation)
                    .WithMany(p => p.tb_ral_ramalLayout)
                    .HasForeignKey(d => d.ral_cla_n_codigo)
                    .HasConstraintName("FK_tb_ral_ramalLayout_tB_cla_cabecalhoLayout");

                entity.HasOne(d => d.ral_lay_n_codigoNavigation)
                    .WithMany(p => p.tb_ral_ramalLayout)
                    .HasForeignKey(d => d.ral_lay_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_ral_ramalLayout_tb_lay_layout");
            });

            modelBuilder.Entity<tb_rel_responsavelLocacaoSaloes>(entity =>
            {
                entity.HasKey(e => e.rel_n_codigo);

                entity.Property(e => e.rel_c_email).IsUnicode(false);

                entity.Property(e => e.rel_c_login).IsUnicode(false);

                entity.Property(e => e.rel_c_nome).IsUnicode(false);

                entity.Property(e => e.rel_c_origem).IsUnicode(false);

                entity.Property(e => e.rel_c_permissao).IsUnicode(false);

                entity.Property(e => e.rel_c_rg).IsUnicode(false);

                entity.Property(e => e.rel_c_senha).IsUnicode(false);

                entity.Property(e => e.rel_c_sobreNome).IsUnicode(false);

                entity.Property(e => e.rel_c_telefone).IsUnicode(false);

                entity.Property(e => e.rel_c_tipo).IsUnicode(false);

                entity.Property(e => e.rel_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.rel_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.rel_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.rel_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_rel_responsavelLocacaoSaloes)
                    .HasForeignKey(d => d.rel_cli_n_codigo)
                    .HasConstraintName("FK_tb_rel_responsavelLocacaoSaloes_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_res_registroSalao>(entity =>
            {
                entity.HasKey(e => e.res_n_codigo);

                entity.Property(e => e.res_c_observacao).IsUnicode(false);

                entity.Property(e => e.res_c_periodo).IsUnicode(false);

                entity.Property(e => e.res_c_status).IsUnicode(false);

                entity.Property(e => e.res_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.res_n_inUsuarioId).HasDefaultValueSql(null);

                entity.Property(e => e.res_c_inTabelaUsuario).HasDefaultValueSql(null);

                entity.Property(e => e.res_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.res_d_dataSolicitacao).HasColumnType("datetime");

                entity.Property(e => e.res_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.res_b_lido)
                  .HasDefaultValueSql("((0))");

                entity.Property(e => e.res_b_tocado)
                 .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.res_dpn_n_codigoNavigation)
                    .WithMany(p => p.tb_res_registroSalao)
                    .HasForeignKey(d => d.res_dpn_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_res_registroSalao_tb_dpn_dependencias");

                entity.HasOne(d => d.res_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_res_registroSalao)
                    .HasForeignKey(d => d.res_mor_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_res_registroSalao_tb_mor_Morador");
            });

            modelBuilder.Entity<tb_rop_ramalOperador>(entity =>
            {
                entity.HasKey(e => e.rop_n_codigo);

                entity.Property(e => e.rop_c_ramal).IsUnicode(false);

                entity.Property(e => e.rop_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.rop_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.rop_d_data).HasColumnType("datetime");

                entity.Property(e => e.rop_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.rop_ope_n_codigoNavigation)
                    .WithMany(p => p.tb_rop_ramalOperador)
                    .HasForeignKey(d => d.rop_ope_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_rop_ramalOperador_tb_ope_operador");
            });

            modelBuilder.Entity<tb_seb_serviceBroker>(entity =>
            {
                entity.HasKey(e => e.seb_n_codigo);

                entity.Property(e => e.seb_c_ramaldestino)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.seb_c_ramalorigem)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.seb_c_tabelaOrigem)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.seb_c_tipoUsuario)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.seb_c_usuarios)
                    .HasMaxLength(5000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<tb_sin_sincronizacaoOffline>(entity =>
            {
                entity.HasKey(e => e.sin_n_codigo);

                entity.Property(e => e.sin_d_data)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<tb_sin_sincronizacaoPlacas>(entity =>
            {
                entity.HasKey(e => e.sin_n_codigo);

                entity.Property(e => e.sin_c_controladoras).IsUnicode(false);

                entity.Property(e => e.sin_c_erro).IsUnicode(false);

                entity.Property(e => e.sin_c_status).IsUnicode(false);

                entity.Property(e => e.sin_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.sin_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.sin_d_dataFim).HasColumnType("datetime");

                entity.Property(e => e.sin_d_dataInicio).HasColumnType("datetime");

                entity.Property(e => e.sin_d_dataSolicitacao).HasColumnType("datetime");

                entity.Property(e => e.sin_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.sin_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.sin_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_sin_sincronizacaoPlacas)
                    .HasForeignKey(d => d.sin_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_tb_sin_sincronizacaoPlacas_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_sol_solicitacaoAberturaRemota>(entity =>
            {
                entity.HasKey(e => e.sol_n_codigo);

                entity.Property(e => e.sol_c_tipoUsuario).IsUnicode(false);

                entity.Property(e => e.sol_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.sol_c_usuarioSolicitou).IsUnicode(false);

                entity.Property(e => e.sol_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.sol_d_data).HasColumnType("datetime");

                entity.Property(e => e.sol_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.sol_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_soz_solicitarZelador>(entity =>
            {
                entity.HasKey(e => e.soz_n_codigo);

                entity.Property(e => e.soz_c_descricao).IsUnicode(false);

                entity.Property(e => e.soz_c_resposta).IsUnicode(false);

                entity.Property(e => e.soz_c_status).IsUnicode(false);

                entity.Property(e => e.soz_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.soz_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.soz_d_dataSolicitacao).HasColumnType("datetime");

                entity.Property(e => e.soz_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.soz_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.soz_c_tipo)
               .HasMaxLength(50)
               .IsUnicode(false);

                entity.HasOne(d => d.soz_fap_n_codigoNavigation)
                    .WithMany(p => p.tb_soz_solicitarZelador)
                    .HasForeignKey(d => d.soz_fap_n_codigo)
                    .HasConstraintName("FK_tb_soz_solicitarZelador_tb_fap_fotoApp");

                entity.HasOne(d => d.soz_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_soz_solicitarZelador)
                    .HasForeignKey(d => d.soz_mor_n_codigo)
                    .HasConstraintName("FK_tb_soz_solicitarZelador_tb_mor_Morador");
            });

            modelBuilder.Entity<tb_stm_statusMonitoramento>(entity =>
            {
                entity.HasKey(e => e.stm_n_codigo);

                entity.Property(e => e.stm_c_descricao).IsUnicode(false);

                entity.Property(e => e.stm_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.stm_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.stm_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.stm_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_tcl_tipoCliente>(entity =>
            {
                entity.HasKey(e => e.tcl_n_codigo);

                entity.Property(e => e.tcl_b_ativo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.tcl_c_nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.tcl_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.tcl_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.tcl_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<tb_top_tipoPermissaoOperador>(entity =>
            {
                entity.HasKey(e => e.top_n_codigo);

                entity.Property(e => e.top_c_chave).IsUnicode(false);

                entity.Property(e => e.top_c_descricao).IsUnicode(false);

                entity.Property(e => e.top_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.top_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.top_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.top_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_tpa_tipoAtendimento>(entity =>
            {
                entity.HasKey(e => e.tpa_n_codigo);

                entity.Property(e => e.tpa_c_descricao).IsUnicode(false);

                entity.Property(e => e.tpa_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.tpa_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.tpa_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.tpa_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<tb_upe_usuarioAPPpermissao>(entity =>
            {
                entity.HasKey(e => e.upe_n_codigo);

                entity.Property(e => e.upe_b_acessa).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.upe_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_upe_usuarioAPPpermissao)
                    .HasForeignKey(d => d.upe_mor_n_codigo)
                    .HasConstraintName("FK_tb_upe_usuarioAPPpermissao_tb_mor_Morador");

                entity.HasOne(d => d.upe_per_n_codigoNavigation)
                    .WithMany(p => p.tb_upe_usuarioAPPpermissao)
                    .HasForeignKey(d => d.upe_per_n_codigo)
                    .HasConstraintName("FK_tb_upe_usuarioAPPpermissao_tb_per_permissoes");
            });

            modelBuilder.Entity<tb_usu_UsuarioApp>(entity =>
            {
                entity.HasKey(e => e.usu_n_codigo);

                entity.Property(e => e.usu_b_liberado).HasDefaultValueSql("((0))");

                entity.Property(e => e.usu_c_condominio).IsUnicode(false);

                entity.Property(e => e.usu_c_email).IsUnicode(false);

                entity.Property(e => e.usu_c_nome).IsUnicode(false);

                entity.Property(e => e.usu_c_rg).IsUnicode(false);

                entity.Property(e => e.usu_c_senha).IsUnicode(false);

                entity.Property(e => e.usu_c_telefone).IsUnicode(false);

                entity.Property(e => e.usu_c_codigoRecuperacao).IsUnicode(false);

                entity.Property(e => e.usu_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.usu_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.usu_d_dataInclusao).HasColumnType("datetime");

                entity.Property(e => e.usu_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.usu_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.usu_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_usu_UsuarioApp)
                    .HasForeignKey(d => d.usu_mor_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_usu_UsuarioApp_tb_mor_Morador");
            });

            modelBuilder.Entity<tb_vap_versaoApp>(entity =>
            {
                entity.HasKey(e => e.vap_n_codigo)
                    .HasName("PK_tb_vap_versaoApp");


                entity.Property(e => e.vap_c_numeroVersao)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<tb_vec_veiculo>(entity =>
            {
                entity.HasKey(e => e.vec_n_codigo)
                    .HasName("PK_tb_vec_veiculo_1");

                entity.Property(e => e.vec_c_caracteristicas).IsUnicode(false);

                entity.Property(e => e.vec_c_cor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.vec_c_modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.vec_c_placa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.vec_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.vec_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.vec_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.vec_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.vec_grf_n_codigoNavigation)
                    .WithMany(p => p.tb_vec_veiculo)
                    .HasForeignKey(d => d.vec_grf_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_vec_veiculo_tb_grf_grupoFamiliar");

                entity.HasOne(d => d.vec_mav_n_codigoNavigation)
                    .WithMany(p => p.tb_vec_veiculo)
                    .HasForeignKey(d => d.vec_mav_n_codigo)
                    .HasConstraintName("FK_tb_vec_veiculo_tb_mav_marcaVeiculo");
            });

            modelBuilder.Entity<tb_vic_vigilanteCliente>(entity =>
            {
                entity.HasKey(e => e.vic_n_codigo);

                entity.Property(e => e.vic_c_celular).IsUnicode(false);

                entity.Property(e => e.vic_c_nome).IsUnicode(false);

                entity.Property(e => e.vic_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.vic_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.vic_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.vic_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.vic_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_vic_vigilanteCliente)
                    .HasForeignKey(d => d.vic_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_vic_vigilanteCliente_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_vid_video>(entity =>
            {
                entity.HasKey(e => e.vid_n_codigo);

                entity.Property(e => e.vid_c_link).IsUnicode(false);

                entity.Property(e => e.vid_c_status).IsUnicode(false);

                entity.HasOne(d => d.vid_con_n_codigoNavigation)
                    .WithMany(p => p.tb_vid_video)
                    .HasForeignKey(d => d.vid_con_n_codigo)
                    .HasConstraintName("FK_tb_vid_video_tb_con_monitoramentoControleAcesso");
            });

            modelBuilder.Entity<tb_vis_visitante>(entity =>
            {

                entity.HasKey(e => e.vis_n_codigo);

                entity.Property(e => e.vis_c_celular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.vis_c_corVeiculo).IsUnicode(false);

                entity.Property(e => e.vis_c_cpf)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.vis_c_email).IsUnicode(false);

                entity.Property(e => e.vis_c_localizacao).IsUnicode(false);

                entity.Property(e => e.vis_c_modeloVeiculo).IsUnicode(false);

                entity.Property(e => e.vis_c_nome).IsUnicode(false);

                entity.Property(e => e.vis_c_numeroCartao)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.vis_c_observacao).IsUnicode(false);

                entity.Property(e => e.vis_c_perfil)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.vis_c_placaVeiculo).IsUnicode(false);

                entity.Property(e => e.vis_c_rg)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.vis_c_estado);

                entity.Property(e => e.vis_c_codExternoVisitante);

                entity.Property(e => e.vis_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.vis_c_usuario).IsUnicode(false);

                entity.Property(e => e.vis_d_alteracao).HasColumnType("date");

                entity.Property(e => e.vis_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.vis_d_dataEntrada).HasColumnType("datetime");

                entity.Property(e => e.vis_d_dataExpriracao).HasColumnType("datetime");

                entity.Property(e => e.vis_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.vis_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.vis_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_vis_visitante)
                    .HasForeignKey(d => d.vis_cli_n_codigo)
                    .HasConstraintName("FK_tb_vis_visitante_tb_cli_cliente");

                entity.HasOne(d => d.vis_fot_n_codigoNavigation)
                    .WithMany(p => p.tb_vis_visitantevis_fot_n_codigoNavigation)
                    .HasForeignKey(d => d.vis_fot_n_codigo)
                    .HasConstraintName("FK_tb_vis_visitante_tb_fot_foto");

                entity.HasOne(d => d.vis_fot_n_documentoNavigation)
                    .WithMany(p => p.tb_vis_visitantevis_fot_n_documentoNavigation)
                    .HasForeignKey(d => d.vis_fot_n_documento)
                    .HasConstraintName("FK_tb_vis_visitante_tb_fot_foto_documento");

                entity.HasOne(d => d.vis_gpv_n_codigoNavigation)
                    .WithMany(p => p.tb_vis_visitante)
                    .HasForeignKey(d => d.vis_gpv_n_codigo)
                    .HasConstraintName("FK_tb_vis_visitante_tb_gpv_grupovagas");
            });

            modelBuilder.Entity<tb_vis_visitasApp>(entity =>
            {
                entity.HasKey(e => e.vis_n_codigo);

                entity.Property(e => e.vis_c_descricao).IsUnicode(false);

                entity.Property(e => e.vis_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.vis_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.vis_d_dataHora).HasColumnType("datetime");

                entity.Property(e => e.vis_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.vis_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.vis_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_vis_visitasApp)
                    .HasForeignKey(d => d.vis_mor_n_codigo)
                    .HasConstraintName("FK_tb_vis_visitasApp_tb_mor_Morador");

                entity.HasOne(d => d.vis_cab_n_codigoNavigation)
                    .WithMany(p => p.tb_vis_visitasApp)
                    .HasForeignKey(d => d.vis_cev_n_codigo)
                    .HasConstraintName("FK_tb_vis_visitasApp_tb_cab_cabecalhoEvento")
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.vis_age_n_codigoNavigation)
                    .WithMany(p => p.tb_vis_visitasApp)
                    .HasForeignKey(d => d.vis_age_n_codigo)
                    .HasConstraintName("FK_tb_vis_visitasApp_tb_age_agenda");
            });

            modelBuilder.Entity<tb_voi_voip>(entity =>
            {
                entity.HasKey(e => e.voi_n_codigo);

                entity.Property(e => e.voi_b_pendente).HasDefaultValueSql("((1))");

                entity.Property(e => e.voi_c_json).IsUnicode(false);

                entity.Property(e => e.voi_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.voi_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.voi_d_data)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.voi_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<tb_zec_zeladorCliente>(entity =>
            {
                entity.HasKey(e => e.zec_n_codigo);

                entity.Property(e => e.zec_c_autorizacao).IsUnicode(false);

                entity.Property(e => e.zec_c_email).IsUnicode(false);

                entity.Property(e => e.zec_c_nome).IsUnicode(false);

                entity.Property(e => e.zec_c_perfil).IsUnicode(false);

                entity.Property(e => e.zec_c_rg).IsUnicode(false);

                entity.Property(e => e.zec_c_telefone).IsUnicode(false);

                entity.Property(e => e.zec_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.zec_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.zec_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.zec_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.zec_ace_n_codigoNavigation)
                    .WithMany(p => p.tb_zec_zeladorCliente)
                    .HasForeignKey(d => d.zec_ace_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_zec_zeladorCliente_tb_ace_acesso");

                entity.HasOne(d => d.zec_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_zec_zeladorCliente)
                    .HasForeignKey(d => d.zec_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_zec_zeladorCliente_tb_cli_cliente");

                entity.HasOne(d => d.zec_mol_n_codigoNavigation)
                    .WithMany(p => p.tb_zec_zeladorCliente)
                    .HasForeignKey(d => d.zec_mol_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_zec_zeladorCliente_tb_mol_modulosLiberados");

                entity.HasOne(d => d.zec_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_zec_zeladorCliente)
                    .HasForeignKey(d => d.zec_mor_n_codigo)
                    .HasConstraintName("FK_tb_zec_zeladorCliente_tb_mor_Morador");

                entity.HasOne(d => d.zec_mos_n_codigoNavigation)
                    .WithMany(p => p.tb_zec_zeladorCliente)
                    .HasForeignKey(d => d.zec_mos_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_zec_zeladorCliente_tb_mos_moduloOrdemServicoLiberado");
            });

            modelBuilder.Entity<tb_zoc_zoneamentoCliente>(entity =>
            {
                entity.HasKey(e => e.zoc_n_codigo);


                entity.Property(e => e.zoc_c_nomePonto).IsUnicode(false);

                entity.Property(e => e.zoc_c_tipoSensor).IsUnicode(false);

                entity.Property(e => e.zoc_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.zoc_c_zona).IsUnicode(false);

                entity.Property(e => e.zoc_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.zoc_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.zoc_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.zoc_cla_n_codigoNavigation)
                    .WithMany(p => p.tb_zoc_zoneamentoCliente)
                    .HasForeignKey(d => d.zoc_cla_n_codigo)
                    .HasConstraintName("FK_tb_zoc_zoneamentoCliente_tb_cla_cabecalhoLayout");

                entity.HasOne(d => d.zoc_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_zoc_zoneamentoCliente)
                    .HasForeignKey(d => d.zoc_cli_n_codigo)
                    .HasConstraintName("FK_tb_zoc_zoneamentoCliente_tb_cli_cliente");

                entity.HasOne(d => d.zoc_eqc_n_codigoNavigation)
                    .WithMany(p => p.tb_zoc_zoneamentoCliente)
                    .HasForeignKey(d => d.zoc_eqc_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_zoc_zoneamentoCliente_tb_eqc_equipamentoCliente");

                entity.HasOne(d => d.zoc_lay_n_codigoNavigation)
                    .WithMany(p => p.tb_zoc_zoneamentoCliente)
                    .HasForeignKey(d => d.zoc_lay_n_codigo)
                    .HasConstraintName("FK_tb_zoc_zoneamentoCliente_tb_lay_layout");
            });

            modelBuilder.Entity<vw_aviso>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aviso");

                entity.Property(e => e.avi_c_descricao).IsUnicode(false);

                entity.Property(e => e.avi_c_status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.avi_c_titulo).IsUnicode(false);

                entity.Property(e => e.avi_c_usuario).IsUnicode(false);

                entity.Property(e => e.avi_d_alteracao).HasColumnType("date");

                entity.Property(e => e.avi_d_fim).HasColumnType("date");

                entity.Property(e => e.avi_d_inicio).HasColumnType("date");

                entity.Property(e => e.avi_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.avi_ope_c_enviarPara).IsUnicode(false);

                entity.Property(e => e.emp_c_nomeFantasia).IsUnicode(false);

                entity.Property(e => e.emp_c_razaoSocial).IsUnicode(false);

                entity.Property(e => e.status)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<vw_avisoEmpresa>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_avisoEmpresa");

                entity.Property(e => e.avi_c_descricao).IsUnicode(false);

                entity.Property(e => e.avi_c_titulo).IsUnicode(false);

                entity.Property(e => e.avi_d_fim).HasColumnType("date");

                entity.Property(e => e.avi_d_inicio).HasColumnType("date");

                entity.Property(e => e.avi_emp_c_enviarPara).IsUnicode(false);

                entity.Property(e => e.avi_n_codigo).ValueGeneratedOnAdd();

                entity.Property(e => e.status)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<vw_cliente>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_cliente");

                entity.Property(e => e.cid_c_estado)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.cid_c_nome)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.cid_n_ibge).IsUnicode(false);

                entity.Property(e => e.cli_c_bairro).IsUnicode(false);

                entity.Property(e => e.cli_c_celular).IsUnicode(false);

                entity.Property(e => e.cli_c_celular2).IsUnicode(false);

                entity.Property(e => e.cli_c_celularAdministradora).IsUnicode(false);

                entity.Property(e => e.cli_c_centralVoip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.cli_c_cep).IsUnicode(false);

                entity.Property(e => e.cli_c_chave)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.cli_c_cnpj).IsUnicode(false);

                entity.Property(e => e.cli_c_codigoReferencia)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.cli_c_complemento).IsUnicode(false);

                entity.Property(e => e.cli_c_contraSenha).IsUnicode(false);

                entity.Property(e => e.cli_c_dominio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.cli_c_email).IsUnicode(false);

                entity.Property(e => e.cli_c_email2).IsUnicode(false);

                entity.Property(e => e.cli_c_emailAdministradora).IsUnicode(false);

                entity.Property(e => e.cli_c_fantasiaAdministradora).IsUnicode(false);

                entity.Property(e => e.cli_c_ie).IsUnicode(false);

                entity.Property(e => e.cli_c_ip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.cli_c_nomeFantasia).IsUnicode(false);

                entity.Property(e => e.cli_c_numero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.cli_c_observacao).IsUnicode(false);

                entity.Property(e => e.cli_c_pessoaContato).IsUnicode(false);

                entity.Property(e => e.cli_c_pessoaContatoAdministradora).IsUnicode(false);

                entity.Property(e => e.cli_c_porta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.cli_c_ramais).IsUnicode(false);

                entity.Property(e => e.cli_c_ramal).IsUnicode(false);

                entity.Property(e => e.cli_c_razaoSocial).IsUnicode(false);

                entity.Property(e => e.cli_c_rua).IsUnicode(false);

                entity.Property(e => e.cli_c_senha).IsUnicode(false);

                entity.Property(e => e.cli_c_telefoneAdministradora).IsUnicode(false);

                entity.Property(e => e.cli_c_telefoneComercial).IsUnicode(false);

                entity.Property(e => e.cli_c_telefoneComercial2).IsUnicode(false);

                entity.Property(e => e.cli_c_tipoRede)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.cli_c_usuario).IsUnicode(false);

                entity.Property(e => e.cli_c_zona).IsUnicode(false);

                entity.Property(e => e.cli_d_alteracao).HasColumnType("date");

                entity.Property(e => e.cli_d_dataVencimentoLicenca).HasColumnType("datetime");

                entity.Property(e => e.cli_d_inicioContrato).HasColumnType("datetime");

                entity.Property(e => e.cli_d_inicioLicenca).HasColumnType("datetime");

                entity.Property(e => e.cli_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.cli_n_valorLicenca).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.emp_c_nomeFantasia).IsUnicode(false);

                entity.Property(e => e.est_c_descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.est_c_sigla)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<vw_connectGuard>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_connectGuard");

                entity.Property(e => e.cev_c_cor).IsUnicode(false);

                entity.Property(e => e.eve_d_inclusao).HasColumnType("datetime");

                entity.Property(e => e.mon_c_data).IsUnicode(false);

                entity.Property(e => e.mon_c_nomeSetorCentral).IsUnicode(false);

                entity.Property(e => e.mon_c_tipoEvento).IsUnicode(false);
            });

            modelBuilder.Entity<vw_consultaMaximosPessoas>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_consultaMaximosPessoas");

                entity.Property(e => e.PSE_D_HORARIOFIM)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pse_c_nome).IsUnicode(false);

                entity.Property(e => e.pse_d_dataEntrada).HasColumnType("datetime");

                entity.Property(e => e.pse_n_codigo).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<vw_empresa>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_empresa");

                entity.Property(e => e.cid_c_estado)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.cid_c_nome)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.cid_n_ibge).IsUnicode(false);

                entity.Property(e => e.emp_c_RangeRamais).IsUnicode(false);

                entity.Property(e => e.emp_c_bairro).IsUnicode(false);

                entity.Property(e => e.emp_c_celular).IsUnicode(false);

                entity.Property(e => e.emp_c_celular2).IsUnicode(false);

                entity.Property(e => e.emp_c_cep).IsUnicode(false);

                entity.Property(e => e.emp_c_cnpj).IsUnicode(false);

                entity.Property(e => e.emp_c_complemento).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoEmail1).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoEmail2).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoNome1).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoNome2).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoTelefone1).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoTelefone2).IsUnicode(false);

                entity.Property(e => e.emp_c_email).IsUnicode(false);

                entity.Property(e => e.emp_c_email2).IsUnicode(false);

                entity.Property(e => e.emp_c_foneComercial).IsUnicode(false);

                entity.Property(e => e.emp_c_foneComercial2).IsUnicode(false);

                entity.Property(e => e.emp_c_ie).IsUnicode(false);

                entity.Property(e => e.emp_c_nomeFantasia).IsUnicode(false);

                entity.Property(e => e.emp_c_numero).IsUnicode(false);

                entity.Property(e => e.emp_c_observacao).IsUnicode(false);

                entity.Property(e => e.emp_c_pessoaContato).IsUnicode(false);

                entity.Property(e => e.emp_c_ramais).IsUnicode(false);

                entity.Property(e => e.emp_c_razaoSocial).IsUnicode(false);

                entity.Property(e => e.emp_c_rua).IsUnicode(false);

                entity.Property(e => e.emp_c_usuario).IsUnicode(false);

                entity.Property(e => e.emp_d_alteracao).HasColumnType("date");

                entity.Property(e => e.emp_d_contrato).HasColumnType("datetime");

                entity.Property(e => e.emp_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.est_c_descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.est_c_sigla)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<vw_licencas>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_licencas");

                entity.Property(e => e.ProxVenc).HasColumnType("datetime");

                entity.Property(e => e.ValorLicencas).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.emp_c_bairro).IsUnicode(false);

                entity.Property(e => e.emp_c_celular).IsUnicode(false);

                entity.Property(e => e.emp_c_celular2).IsUnicode(false);

                entity.Property(e => e.emp_c_cep).IsUnicode(false);

                entity.Property(e => e.emp_c_cnpj).IsUnicode(false);

                entity.Property(e => e.emp_c_complemento).IsUnicode(false);

                entity.Property(e => e.emp_c_email).IsUnicode(false);

                entity.Property(e => e.emp_c_email2).IsUnicode(false);

                entity.Property(e => e.emp_c_foneComercial).IsUnicode(false);

                entity.Property(e => e.emp_c_foneComercial2).IsUnicode(false);

                entity.Property(e => e.emp_c_ie).IsUnicode(false);

                entity.Property(e => e.emp_c_nomeFantasia).IsUnicode(false);

                entity.Property(e => e.emp_c_numero).IsUnicode(false);

                entity.Property(e => e.emp_c_observacao).IsUnicode(false);

                entity.Property(e => e.emp_c_pessoaContato).IsUnicode(false);

                entity.Property(e => e.emp_c_razaoSocial).IsUnicode(false);

                entity.Property(e => e.emp_c_rua).IsUnicode(false);

                entity.Property(e => e.emp_d_contrato).HasColumnType("datetime");

                entity.Property(e => e.emp_n_codigo).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<vw_notificacaoApp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_notificacaoApp");

                entity.Property(e => e.cli_c_nomeFantasia).IsUnicode(false);

                entity.Property(e => e.eno_c_GruposFamiliares).IsUnicode(false);

                entity.Property(e => e.eno_c_mensagem).IsUnicode(false);

                entity.Property(e => e.eno_c_titulo).IsUnicode(false);

                entity.Property(e => e.eno_d_fim).HasColumnType("datetime");

                entity.Property(e => e.eno_d_inicio).HasColumnType("datetime");

                entity.Property(e => e.status)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<vw_notificacaoAppGaren>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_notificacaoAppGaren");

                entity.Property(e => e.cli_c_nomeFantasia).IsUnicode(false);

                entity.Property(e => e.eno_c_GruposFamiliares).IsUnicode(false);

                entity.Property(e => e.eno_c_mensagem).IsUnicode(false);

                entity.Property(e => e.eno_c_titulo).IsUnicode(false);

                entity.Property(e => e.eno_d_fim).HasColumnType("datetime");

                entity.Property(e => e.eno_d_inicio).HasColumnType("datetime");

                entity.Property(e => e.status)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<vw_operador>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_operador");

                entity.Property(e => e.cid_c_nome)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.emp_c_RangeRamais).IsUnicode(false);

                entity.Property(e => e.emp_c_bairro).IsUnicode(false);

                entity.Property(e => e.emp_c_celular).IsUnicode(false);

                entity.Property(e => e.emp_c_celular2).IsUnicode(false);

                entity.Property(e => e.emp_c_cep).IsUnicode(false);

                entity.Property(e => e.emp_c_cnpj).IsUnicode(false);

                entity.Property(e => e.emp_c_complemento).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoEmail1).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoEmail2).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoNome1).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoNome2).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoTelefone1).IsUnicode(false);

                entity.Property(e => e.emp_c_contatoTelefone2).IsUnicode(false);

                entity.Property(e => e.emp_c_email).IsUnicode(false);

                entity.Property(e => e.emp_c_email2).IsUnicode(false);

                entity.Property(e => e.emp_c_foneComercial).IsUnicode(false);

                entity.Property(e => e.emp_c_foneComercial2).IsUnicode(false);

                entity.Property(e => e.emp_c_ie).IsUnicode(false);

                entity.Property(e => e.emp_c_nomeFantasia).IsUnicode(false);

                entity.Property(e => e.emp_c_numero).IsUnicode(false);

                entity.Property(e => e.emp_c_observacao).IsUnicode(false);

                entity.Property(e => e.emp_c_pessoaContato).IsUnicode(false);

                entity.Property(e => e.emp_c_ramais).IsUnicode(false);

                entity.Property(e => e.emp_c_razaoSocial).IsUnicode(false);

                entity.Property(e => e.emp_c_rua).IsUnicode(false);

                entity.Property(e => e.emp_c_usuario).IsUnicode(false);

                entity.Property(e => e.emp_d_alteracao).HasColumnType("date");

                entity.Property(e => e.emp_d_contrato).HasColumnType("datetime");

                entity.Property(e => e.emp_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.est_c_descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.est_c_sigla)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ope_c_bairro).IsUnicode(false);

                entity.Property(e => e.ope_c_cargo).IsUnicode(false);

                entity.Property(e => e.ope_c_celular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ope_c_cep)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ope_c_complemento).IsUnicode(false);

                entity.Property(e => e.ope_c_cpf)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.ope_c_email).IsUnicode(false);

                entity.Property(e => e.ope_c_email2).IsUnicode(false);

                entity.Property(e => e.ope_c_nome).IsUnicode(false);

                entity.Property(e => e.ope_c_numero).IsUnicode(false);

                entity.Property(e => e.ope_c_observacao).IsUnicode(false);

                entity.Property(e => e.ope_c_rg)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ope_c_rua).IsUnicode(false);

                entity.Property(e => e.ope_c_telefone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ope_c_usuario).IsUnicode(false);

                entity.Property(e => e.ope_d_alteracao).HasColumnType("date");

                entity.Property(e => e.ope_d_dataNascimento).HasColumnType("datetime");

                entity.Property(e => e.ope_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.ope_d_ultimoContato).HasColumnType("datetime");
            });

            modelBuilder.Entity<vw_pessoa>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_pessoa");

                entity.Property(e => e.CPF).IsUnicode(false);

                entity.Property(e => e.DATA).HasColumnType("datetime");

                entity.Property(e => e.EMAIL).IsUnicode(false);

                entity.Property(e => e.NOME).IsUnicode(false);

                entity.Property(e => e.RAMAL).IsUnicode(false);

                entity.Property(e => e.RG).IsUnicode(false);

                entity.Property(e => e.TELEFONE).IsUnicode(false);

                entity.Property(e => e.TIPO)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.cli_c_nomeFantasia).IsUnicode(false);
            });
            modelBuilder.Entity<vw_grupo_familiar>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_grupo_familiar");

                entity.Property(e => e.grf_n_codigo).IsUnicode(false);

                entity.Property(e => e.grf_cli_n_codigo).IsUnicode(false);

                entity.Property(e => e.LOCALIZACAO).IsUnicode(false);

            });
            modelBuilder.Entity<vw_pessoasRecinto>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_pessoasRecinto");

                entity.Property(e => e.DATA).HasColumnType("datetime");

                entity.Property(e => e.DATA_SAIDA_MANUAL).HasColumnType("datetime");

                entity.Property(e => e.LOCALIZACAO).IsUnicode(false);

                entity.Property(e => e.NOME).IsUnicode(false);

                entity.Property(e => e.NOMECLIENTE).IsUnicode(false);

                entity.Property(e => e.PERFIL).IsUnicode(false);

                entity.Property(e => e.PSE_D_HORARIOFIM)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TELEFONE).IsUnicode(false);

                entity.Property(e => e.TIPO)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<vw_proprietario>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_proprietario");

                entity.Property(e => e.cid_c_estado)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.cid_c_nome)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.cid_n_ibge).IsUnicode(false);

                entity.Property(e => e.est_c_descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.est_c_sigla)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_bairro).IsUnicode(false);

                entity.Property(e => e.pro_c_cargo).IsUnicode(false);

                entity.Property(e => e.pro_c_celular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_cep)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_complemento).IsUnicode(false);

                entity.Property(e => e.pro_c_cpf)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_email).IsUnicode(false);

                entity.Property(e => e.pro_c_email2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_nome).IsUnicode(false);

                entity.Property(e => e.pro_c_numero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_observacao).IsUnicode(false);

                entity.Property(e => e.pro_c_rg)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_rua).IsUnicode(false);

                entity.Property(e => e.pro_c_telefone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pro_c_usuario).IsUnicode(false);

                entity.Property(e => e.pro_d_alteracao).HasColumnType("date");

                entity.Property(e => e.pro_d_dataNascimento).HasColumnType("datetime");

                entity.Property(e => e.pro_d_modificacao).HasColumnType("datetime");
            });

            modelBuilder.Entity<vw_relatorioControleAcesso>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_relatorioControleAcesso");

                entity.Property(e => e.GrupoFamiliar).IsUnicode(false);

                entity.Property(e => e.RG).IsUnicode(false);

                entity.Property(e => e.cin_c_tipoEventoMotivo).IsUnicode(false);

                entity.Property(e => e.con_c_acao).IsUnicode(false);

                entity.Property(e => e.con_c_cardNumber).IsUnicode(false);

                entity.Property(e => e.con_c_destino).IsUnicode(false);

                entity.Property(e => e.con_c_doorId).IsUnicode(false);

                entity.Property(e => e.con_c_obsTratamentoPanico).IsUnicode(false);

                entity.Property(e => e.con_c_pin).IsUnicode(false);

                entity.Property(e => e.con_c_pontoAcesso).IsUnicode(false);

                entity.Property(e => e.con_c_status).IsUnicode(false);

                entity.Property(e => e.con_c_tipoPessoa).IsUnicode(false);

                entity.Property(e => e.con_c_usuario).IsUnicode(false);

                entity.Property(e => e.con_d_dataTratamentoPanico).HasColumnType("datetime");

                entity.Property(e => e.con_d_evento).HasColumnType("datetime");

                entity.Property(e => e.con_d_modificacao).HasColumnType("datetime");

                entity.Property(e => e.vid_c_link).IsUnicode(false);
            });

            modelBuilder.Entity<vw_relatorio_pessoa>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_relatorio_pessoa");

                entity.Property(e => e.CPF).IsUnicode(false);

                entity.Property(e => e.DATA).HasColumnType("datetime");

                entity.Property(e => e.EMAIL).IsUnicode(false);

                entity.Property(e => e.LOCALIZACAO).IsUnicode(false);

                entity.Property(e => e.NOME).IsUnicode(false);

                entity.Property(e => e.RAMAL).IsUnicode(false);

                entity.Property(e => e.RG).IsUnicode(false);

                entity.Property(e => e.TELEFONE).IsUnicode(false);

                entity.Property(e => e.TIPO)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.cli_c_nomeFantasia).IsUnicode(false);
            });

            modelBuilder.Entity<tb_fro_frota>(entity =>
            {
                entity.HasKey(e => e.fro_n_codigo)
                    .HasName("PK_tb_fro_frota");

                entity.Property(e => e.fro_c_caracteristicas).IsUnicode(false);

                entity.Property(e => e.fro_c_cor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.fro_c_codigoVeiculo)
                .IsUnicode(false);

                entity.Property(e => e.fro_b_ativo)
                .HasDefaultValueSql("((1))");

                entity.Property(e => e.fro_c_modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.fro_c_ano)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.fro_c_placa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.fro_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.fro_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fro_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fro_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.fro_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_fro_frota)
                    .HasForeignKey(d => d.fro_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_fro_veiculo_tb_cli_cliente");

                entity.HasOne(d => d.fro_mav_n_codigoNavigation)
                    .WithMany(p => p.tb_fro_frota)
                    .HasForeignKey(d => d.fro_mav_n_codigo)
                    .HasConstraintName("FK_tb_fro_frota_tb_mav_marcaVeiculo");
            });

            modelBuilder.Entity<tb_pre_precos>(entity =>
            {
                entity.HasKey(e => e.pre_n_codigo)
                   .HasName("PK_tb_pre_precos");

                entity.Property(e => e.pre_mol_c_nome);

                entity.Property(e => e.pre_n_preco);

                entity.Property(e => e.pre_n_precoDist);

                entity.Property(e => e.pre_n_precoEmp);

                entity.Property(e => e.pre_n_precoCli);
            });

            modelBuilder.Entity<tb_inc_informacoesCliente>(entity =>
            {
                entity.HasKey(e => e.inc_n_codigo)
                    .HasName("PK_inc_n_codigo");

                entity.Property(e => e.inc_cli_n_codigo)
                .IsUnicode(false);

                entity.Property(e => e.inc_c_titulo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.inc_c_descricao)
                .IsUnicode(false);

                entity.Property(e => e.inc_n_ordem)
                .HasDefaultValueSql("((1))");

                entity.Property(e => e.inc_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.inc_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.inc_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.inc_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_inc_informacoesCliente)
                    .HasForeignKey(d => d.inc_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_inc_informacoesCliente_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_nod_notificacaoDocumento>(entity =>
            {
                entity.HasKey(e => e.nod_n_codigo)
                    .HasName("PK_nod_n_codigo");

                entity.Property(e => e.nod_b_processado)
                .HasDefaultValueSql("((0))");

                entity.Property(e => e.nod_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.nod_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.nod_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<tb_dva_duvidasApp>(entity =>
            {
                entity.HasKey(e => e.dva_n_codigo)
                    .HasName("PK_dva_n_codigo");

                entity.Property(e => e.dva_c_unique)
                .HasDefaultValueSql("(newid())");

                entity.Property(e => e.dva_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.dva_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.dva_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_dva_duvidasApp)
                    .HasForeignKey(d => d.dva_cli_n_codigo)
                    .HasConstraintName("FK_tb_dva_duvidasApp_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_dow_downloads_arquivos>(entity =>
            {
                entity.HasKey(e => e.dow_n_codigo)
                    .HasName("[PK_tb_dow_downloads_arquivos");

                entity.HasOne(d => d.dow_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_dow_downloads_arquivos)
                    .HasForeignKey(d => d.dow_cli_n_codigo)
                    .HasConstraintName("FK_tb_dow_downloads_arquivos_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_mve_movimentacaoVeiculo>(entity =>
            {
                entity.HasKey(e => e.mve_n_codigo)
                    .HasName("PK_tb_mve_movimentacaoVeiculo");

                entity.Property(e => e.mve_b_registroAutomatico)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.mve_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.mve_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.mve_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.mve_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.mve_fro_n_codigoNavigation)
                    .WithMany(p => p.tb_mve_movimentacaoVeiculo)
                    .HasForeignKey(d => d.mve_fro_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_mve_movimentacaoVeiculo_tb_fro_frota");

                entity.HasOne(d => d.mve_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_mve_movimentacaoVeiculo)
                    .HasForeignKey(d => d.mve_mor_n_codigo)
                    .HasConstraintName("FK_tb_mve_movimentacaoVeiculo_tb_mor_Morador");
            });

            modelBuilder.Entity<tb_doc_documento>(entity =>
            {
                entity.HasKey(e => e.doc_n_codigo)
                    .HasName("PK_tb_doc_documento");

                entity.Property(e => e.doc_c_nomeDocumento).IsUnicode(false);

                entity.Property(e => e.doc_b_preNotificacao)
                .HasDefaultValueSql("((0))");

                entity.Property(e => e.doc_b_notificacaoAcesso)
                .HasDefaultValueSql("((0))");


                entity.Property(e => e.doc_b_notificacaoVencimento)
                .HasDefaultValueSql("((0))");

                entity.Property(e => e.doc_n_diasNotificacao).IsUnicode(false);

                entity.Property(e => e.doc_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.doc_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.doc_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.doc_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.doc_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_doc_documento)
                    .HasForeignKey(d => d.doc_cli_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_doc_documento_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_dmo_documentoMorador>(entity =>
            {
                entity.HasKey(e => e.dmo_n_codigo)
                    .HasName("PK_tb_dmo_documentoMorador");

                entity.Property(e => e.dmo_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.dmo_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.dmo_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.dmo_doc_n_codigoNavigation)
                    .WithMany(p => p.tb_dmo_documentoMorador)
                    .HasForeignKey(d => d.dmo_doc_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_dmo_documentoMorador_tb_doc_documento");

                entity.HasOne(d => d.dmo_mor_n_codigoNavigation)
                    .WithMany(p => p.tb_dmo_documentoMorador)
                    .HasForeignKey(d => d.dmo_mor_n_codigo)
                    .HasConstraintName("FK_tb_dmo_documentoMorador_tb_mor_Morador");
            });

            modelBuilder.Entity<tb_per_perguntas>(entity =>
            {
                entity.HasKey(e => e.per_n_codigo)
                .HasName("PK_per_n_codigo");

                entity.HasOne(d => d.per_cli_n_codigoNavigation)
                    .WithMany(p => p.tb_per_perguntas)
                    .HasForeignKey(d => d.per_cli_n_codigo)
                    .HasConstraintName("FK_tb_per_perguntas_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_fen_foto_entrega>(entity =>
            {
                entity.HasKey(e => e.fen_n_codigo)
                .HasName("PK_fen_n_codigo");

                entity.Property(e => e.fen_c_unique)
              .HasDefaultValueSql("(newid())");

                entity.Property(e => e.fen_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

            });

            modelBuilder.Entity<tb_cde_cadastro_entregas>(entity =>
            {
                entity.HasKey(e => e.cde_n_codigo)
                .HasName("PK_cde_n_codigo");

                entity.HasOne(d => d.cde_fen_n_codigoNavigation)
                    .WithMany(p => p.tb_cde_cadastro_entregas)
                    .HasForeignKey(d => d.cde_fen_n_codigo)
                    .HasConstraintName("FK_tb_cde_cadastro_entregas_tb_fen_foto_entrega");

                entity.HasOne(d => d.cde_grf_n_codigoNavigation)
                    .WithMany(p => p.tb_cde_cadastro_entregas)
                    .HasForeignKey(d => d.cde_grf_n_codigo)
                    .HasConstraintName("FK_tb_cde_cadastro_entregas_tb_grf_grupoFamiliar");
            });

            modelBuilder.Entity<tb_cat_categoriaCatalogo>(entity =>
            {
                entity.HasKey(e => e.cat_n_codigo);
                entity.Property(e => e.cat_b_ativo);
                entity.Property(e => e.cat_b_tipoLink);
                entity.Property(e => e.cat_b_solicitarEspecialidade);
                entity.Property(e => e.cat_c_descricao).HasMaxLength(500).IsUnicode(false);
                entity.Property(e => e.cat_c_imagem).IsUnicode(false);
                entity.Property(e => e.cat_c_link).IsUnicode(false);
                entity.Property(e => e.cat_c_nome).IsUnicode(false);
                entity.Property(e => e.cat_c_unique).HasDefaultValueSql("(newid())");
                entity.Property(e => e.cat_d_atualizado).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.cat_d_inclusao).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

                entity.HasOne(x => x.cat_cli_n_codigoNavigation)
                      .WithMany(x => x.tb_cat_categoriaCatalogo)
                      .HasForeignKey(x => x.cat_cli_n_codigo)
                      .HasConstraintName("FK_tb_cat_categoriaCatalogo_tb_cli_cliente");

            });

            modelBuilder.Entity<tb_scc_subCategoriaCatalogo>(entity =>
            {
                entity.HasKey(e => e.scc_n_codigo);
                entity.Property(e => e.scc_cat_n_codigo);
                entity.Property(e => e.scc_b_ativo);
                entity.Property(e => e.scc_c_nome).IsUnicode(false);
                entity.Property(e => e.scc_c_imagem).IsUnicode(false);
                entity.Property(e => e.scc_c_unique).HasDefaultValueSql("(newid())");
                entity.Property(e => e.scc_d_atualizado).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.scc_d_inclusao).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

                entity.HasOne(x => x.scc_cat_n_codigoNavigation)
                      .WithMany(x => x.tb_scc_subCategoriaCatalogo)
                      .HasForeignKey(x => x.scc_cat_n_codigo)
                      .HasConstraintName("FK_tb_scc_subCategoriaCatalogo_tb_cat_categoriaCatalogo");
            });

            modelBuilder.Entity<tb_cal_catalogo>(entity =>
            {
                entity.HasKey(e => e.cal_n_codigo);
                entity.Property(e => e.cal_scc_n_codigo);
                entity.Property(e => e.cal_cat_n_codigo);
                entity.Property(e => e.cal_lcc_n_codigoTorre).HasDefaultValueSql(null);
                entity.Property(e => e.cal_lcc_n_codigoNumero).HasDefaultValueSql(null);
                entity.Property(e => e.cal_b_ativo);
                entity.Property(e => e.cal_c_nome);
                entity.Property(e => e.cal_c_descricao);
                entity.Property(e => e.cal_c_capa);
                entity.Property(e => e.cal_c_logoMarca);
                entity.Property(e => e.cal_c_especialidade);
                entity.Property(e => e.cal_c_telefonePrincipal);
                entity.Property(e => e.cal_c_telefoneSecundario);
                entity.Property(e => e.cal_c_email);
                entity.Property(e => e.cal_c_website);
                entity.Property(e => e.cal_c_redeSocial1);
                entity.Property(e => e.cal_c_redeSocial2);
                entity.Property(e => e.cal_c_unique).HasDefaultValueSql("(newid())");
                entity.Property(e => e.cal_d_atualizado).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.cal_d_inclusao).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.cal_c_status);
                entity.Property(e => e.cal_c_descricaoReprovado);
                entity.Property(e => e.cal_n_especialista);

                entity.HasOne(x => x.cal_scc_n_codigoNavigation)
                      .WithMany(x => x.tb_cal_catalogo)
                      .HasForeignKey(x => x.cal_scc_n_codigo)
                      .HasConstraintName("FK_tb_cal_catalogo_tb_scc_subCategoriaCatalogo");

                entity.HasOne(d => d.cal_grf_n_codigoNavigation)
                   .WithMany(p => p.tb_cal_catalogo)
                   .HasForeignKey(d => d.cal_grf_n_codigo)
                   .HasConstraintName("FK_tb_cal_catalogo_tb_grf_grupoFamiliar");

                entity.HasOne(x => x.cal_fot_n_codigoNavigation)
                   .WithOne(x => x.tb_cal_catalogo)
                   .HasForeignKey<tb_cal_catalogo>(x => x.cal_fot_n_codigo)
                   .HasConstraintName("FK_tb_cal_catalogo_tb_fot_foto")
                   .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(x => x.cal_n_especialistaNavigation)
                     .WithMany(x => x.tb_cal_catalogo)
                     .HasForeignKey(x => x.cal_n_especialista)
                     .HasConstraintName("FK_tb_cal_catalogo_tb_mor_Morador");

                entity.HasOne(x => x.cal_logo_n_codigoNavigation)
                .WithOne(x => x.tb_cal_catalogoLogo)
                .HasForeignKey<tb_cal_catalogo>(x => x.cal_logo_n_codigo)
                .HasConstraintName("FK_tb_cal_catalogoLogo_tb_fot_foto");
            });

            modelBuilder.Entity<tb_lca_localidadeCatalogo>(entity =>
            {
                entity.HasKey(e => e.lca_n_codigo);

                entity.Property(e => e.lca_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.lca_d_atualizado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lca_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lca_d_modificacao).HasColumnType("datetime");

                entity.HasOne(d => d.lac_cal_n_codigoNavigation)
                    .WithMany(p => p.tb_lca_localidadeCatalogo)
                    .HasForeignKey(d => d.lca_cal_n_codigo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tb_lca_localidadeCatalogo_tb_cal_catalogo");

                entity.HasOne(d => d.lac_lcc_n_codigoNavigation)
                    .WithMany(p => p.tb_lca_localidadeCatalogo)
                    .HasForeignKey(d => d.lca_lcc_n_codigo)
                    .HasConstraintName("FK_tb_lca_localidadeCatalogo_tb_lcc_localidadeCliente");
            });

            modelBuilder.Entity<tb_csr_connectionSignalR>(entity =>
            {
                entity.HasKey(x => x.csr_n_codigo);
                entity.HasIndex(x => x.csr_c_connectionId);
                entity.Property(x => x.csr_n_id);
                entity.Property(x => x.csr_n_hub);
                entity.Property(x => x.csr_b_conectado);
                entity.Property(x => x.csr_n_usuarioId);
                entity.Property(x => x.csr_n_perfil);
                entity.Property(x => x.csr_d_dataInclusao);
                entity.Property(x => x.csr_d_dataAlteracao);
            });

            modelBuilder.Entity<tb_vpp_visitanteApp>(entity =>
            {
                entity.HasKey(x => x.vpp_n_codigo);
                entity.Property(x => x.vpp_c_email);
                entity.Property(x => x.vpp_c_senha);
                entity.Property(x => x.vpp_c_codigoRecuperacao);
                entity.HasIndex(x => x.vpp_c_visitanteGuid);

                entity.HasOne(x => x.tb_vis_visitante)
                .WithOne(x => x.tb_vpp_visitanteApp)
                .HasForeignKey<tb_vis_visitante>(x => x.vis_vpp_n_codigo)
                .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<tb_ref_refeicao>(entity =>
            {
                entity.HasKey(x => x.ref_n_codigo);
                entity.Property(x => x.ref_c_nomeRefeicao);
                entity.Property(x => x.ref_d_inicio).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(x => x.ref_d_fim).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(x => x.ref_d_valor);
                entity.Property(x => x.ref_cli_n_codigo);

                entity.HasOne(x => x.ref_cli_n_codigoNavigation)
                      .WithMany(x => x.tb_ref_refeicao)
                      .HasForeignKey(x => x.ref_cli_n_codigo)
                      .HasConstraintName("FK_tb_ref_refeicao_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_age_agenda>(entity =>
            {
                entity.HasKey(e => e.age_n_codigo);
                entity.Property(e => e.age_c_horarioInicio).IsUnicode(false);
                entity.Property(e => e.age_c_horarioFim).IsUnicode(false);
                entity.Property(e => e.age_c_usuario).IsUnicode(false);
                entity.Property(x => x.age_d_dataAgendamento);
                entity.Property(e => e.age_c_unique).HasDefaultValueSql("(newid())");
                entity.Property(x => x.age_mor_n_codigo);

                entity.Property(e => e.age_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.age_grf_n_codigoNavigation)
                      .WithMany(p => p.tb_age_agenda)
                      .HasForeignKey(d => d.age_grf_n_codigo)
                      .HasConstraintName("FK_tb_age_agenda_tb_grf_grupoFamiliar");

                entity.HasOne(d => d.age_vis_n_codigoNavigation)
                   .WithMany(p => p.tb_age_agenda)
                   .HasForeignKey(d => d.age_vis_n_codigo)
                   .HasConstraintName("FK_tb_age_agenda_tb_vis_visitante");

                entity.HasOne(d => d.age_cal_n_codigoNavigation)
               .WithMany(p => p.tb_age_agenda)
               .HasForeignKey(d => d.age_cal_n_codigo)
               .HasConstraintName("FK_tb_age_agenda_tb_cal_catalogo");

                entity.HasOne(d => d.age_mor_n_codigoNavigation)
                 .WithMany(p => p.tb_age_agenda)
                 .HasForeignKey(d => d.age_mor_n_codigo)
                 .HasConstraintName("FK_tb_age_agenda_tb_mor_Morador");
            });

            modelBuilder.Entity<tb_aco_acompanhante>(entity =>
            {
                entity.HasKey(e => e.aco_n_codigo);
                entity.Property(e => e.aco_c_unique).HasDefaultValueSql("(newid())");
                entity.Property(e => e.aco_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.aco_age_n_codigoNavigation)
                      .WithMany(p => p.tb_aco_acompanhante)
                      .HasForeignKey(d => d.aco_age_n_codigo)
                      .HasConstraintName("FK_tb_aco_acompanhante_tb_age_agenda");

                entity.HasOne(d => d.aco_vis_n_codigoNavigation)
                   .WithMany(p => p.tb_aco_acompanhante)
                   .HasForeignKey(d => d.aco_vis_n_codigo)
                   .HasConstraintName("FK_tb_aco_acompanhante_tb_vis_visitante");
            });

            modelBuilder.Entity<tb_usc_usuarioSalaComercial>(entity =>
            {
                entity.HasKey(e => e.usc_n_codigo);
                entity.Property(e => e.usc_c_perfil).IsUnicode(false);
                entity.Property(e => e.usc_c_nome).IsUnicode(false);
                entity.Property(e => e.usc_c_cpf).IsUnicode(false);
                entity.Property(e => e.usc_c_usuario).IsUnicode(false);


                entity.Property(e => e.usc_c_unique).HasDefaultValueSql("(newid())");

                entity.Property(e => e.usc_d_inclusao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.usc_grf_n_codigoNavigation)
                      .WithMany(p => p.tb_usc_usuarioSalaComercial)
                      .HasForeignKey(d => d.usc_grf_n_codigo)
                      .HasConstraintName("FK_tb_usc_usuarioSalaComercial_tb_grf_grupoFamiliar");

                entity.HasOne(d => d.usc_mor_n_codigoNavigation)
                   .WithMany(p => p.tb_usc_usuarioSalaComercial)
                   .HasForeignKey(d => d.usc_mor_n_codigo)
                   .HasConstraintName("FK_tb_usc_usuarioSalaComercial_tb_mor_Morador");

                entity.HasOne(d => d.usc_ace_n_codigoNavigation)
               .WithMany(p => p.tb_usc_usuarioSalaComercial)
               .HasForeignKey(d => d.usc_ace_n_codigo)
               .HasConstraintName("FK_tb_usc_usuarioSalaComercial_tb_ace_acesso");
            });

            modelBuilder.Entity<tb_dev_device>(entity =>
            {
                entity.HasKey(x => x.dev_c_uuid);
                entity.HasIndex(x => x.dev_c_fcmToken);
                entity.Property(x => x.dev_c_plataforma);
                entity.Property(x => x.dev_c_versaoApp);
                entity.Property(x => x.dev_c_versaoSO);
                entity.Property(x => x.dev_d_dataInclusao);
                entity.Property(x => x.dev_d_dataModificacao);

                entity.HasOne(x => x.tb_vpp_visitanteApp)
                .WithMany(x => x.tb_dev_device)
                .HasForeignKey(x => x.dev_vpp_n_visitanteApp)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<tb_age_agenteComercial>(entity =>
            {
                entity.HasKey(x => x.age_n_codigo);
                entity.Property(x => x.age_c_nome);
                entity.Property(x => x.age_c_rg);
                entity.Property(x => x.age_c_email);
                entity.Property(x => x.age_c_celular);
                entity.Property(x => x.age_ace_n_codigo);

                entity.HasOne(x => x.age_ace_n_codigoNavigation)
                      .WithMany(x => x.tb_age_agenteComercial)
                      .HasForeignKey(x => x.age_ace_n_codigo)
                      .HasConstraintName("FK_tb_age_agenteComercial_tb_ace_acesso");
            });

            modelBuilder.Entity<tb_fzk_tabelaHorarioFacialZK>(entity =>
            {
                entity.HasKey(x => x.fzk_n_codigo);
                entity.Property(x => x.fzk_con_n_codigo);
                entity.Property(x => x.fzk_disp_n_codigo);
                entity.Property(x => x.fzk_hor_n_codigo);
                entity.Property(x => x.fzk_d_modificacao);
                entity.Property(x => x.fzk_c_unique);
                entity.Property(x => x.fzk_d_atualizado);
                entity.Property(x => x.fzk_d_inclusao);

                entity.HasOne(x => x.fzk_hor_n_codigoNavigation)
                      .WithMany(x => x.tb_fzk_tabelaHorarioFacialZK)
                      .HasForeignKey(x => x.fzk_hor_n_codigo)
                      .HasConstraintName("FK_tb_fzk_tabelaHorarioFacialZK_tb_hor_horario");

                entity.HasOne(x => x.fzk_con_n_codigoNavigation)
                      .WithMany(x => x.tb_fzk_tabelaHorarioFacialZK)
                      .HasForeignKey(x => x.fzk_con_n_codigo)
                      .HasConstraintName("FK_tb_fzk_tabelaHorarioFacialZK_tb_con_controladora");
            });

            modelBuilder.Entity<tb_gzk_grupoTabelaHorarioFacialZK>(entity =>
            {
                entity.HasKey(x => x.gzk_n_codigo);
                entity.Property(x => x.gzk_phr_n_codigo);
                entity.Property(x => x.gzk_grupo_n_codigo);
                entity.Property(x => x.gzk_con_n_codigo);
                entity.Property(x => x.gzk_d_modificacao);
                entity.Property(x => x.gzk_c_unique);
                entity.Property(x => x.gzk_d_atualizado);
                entity.Property(x => x.gzk_d_inclusao);

                entity.HasOne(x => x.gzk_phr_n_codigoNavigation)
                    .WithMany(x => x.tb_gzk_grupoTabelaHorarioFacialZK)
                    .HasForeignKey(x => x.gzk_phr_n_codigo)
                    .HasConstraintName("FK_tb_gzk_grupoTabelaHorarioFacialZK_tb_phr_perfilHorario");

                entity.HasOne(x => x.gzk_con_n_codigoNavigation)
                     .WithMany(x => x.tb_gzk_grupoTabelaHorarioFacialZK)
                     .HasForeignKey(x => x.gzk_con_n_codigo)
                     .HasConstraintName("FK_tb_gzk_grupoTabelaHorarioFacialZK_tb_con_controladora");
            });

            modelBuilder.Entity<tb_fac_face>(entity =>
            {
                entity.HasKey(e => e.fac_n_codigo);
                entity.Property(e => e.fac_cli_n_codigo);
                entity.Property(e => e.fac_c_imagem).HasColumnType("image");
                entity.Property(e => e.fac_c_status);
                entity.Property(e => e.fac_c_template);
                entity.Property(e => e.fac_n_tamanho);
                entity.Property(e => e.fac_c_unique).HasDefaultValueSql("(newid())");
                entity.Property(e => e.fac_d_atualizado).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.fac_d_dataSolicitacao).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.fac_d_inclusao).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.fac_usu_n_codigo);

                entity.HasOne(x => x.fac_cli_n_codigoNavigation)
                  .WithMany(x => x.tb_fac_face)
                  .HasForeignKey(x => x.fac_cli_n_codigo)
                  .HasConstraintName("FK_tb_fac_face_tb_cli_cliente");
            });

            modelBuilder.Entity<tb_cab_cabecalhoEvento>(entity =>
            {
                entity.HasKey(x => x.cab_n_codigo);
                entity.Property(x => x.cab_c_nome);
                entity.Property(x => x.cab_c_descricao);
            });

            modelBuilder.Entity<tb_sca_salaComercialCatalogo>(entity =>
            {
                entity.HasKey(e => e.sca_n_codigo);
                entity.Property(e => e.sca_grf_n_codigo);
                entity.Property(e => e.sca_cal_n_codigo);
                entity.Property(e => e.sca_c_unique).HasDefaultValueSql("(newid())");
                entity.Property(e => e.sca_d_atualizado).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.sca_d_inclusao).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

                entity.HasOne(x => x.cal_n_codigoNavigation)
                  .WithMany(x => x.tb_sca_salaComercialCatalogo)
                  .HasForeignKey(x => x.sca_cal_n_codigo)
                  .HasConstraintName("FK_tb_sca_salaComercialCatalogo_tb_cal_catalogo");

                entity.HasOne(x => x.grf_n_codigoNavigation)
                  .WithMany(x => x.tb_sca_salaComercialCatalogo)
                  .HasForeignKey(x => x.sca_grf_n_codigo)
                  .HasConstraintName("FK_tb_sca_salaComercialCatalogo_tb_grf_grupoFamiliar");
            });

            modelBuilder.Entity<tb_ocp_ocorrenciasOperador>(entity =>
            {
                entity.HasKey(e => e.ocp_n_codigo);
                entity.Property(e => e.ocp_cli_n_codigo);
                entity.Property(e => e.ocp_c_descricao);
                entity.Property(e => e.ocp_c_data);
                entity.Property(e => e.ocp_ope_n_cadastrou);
                entity.Property(e => e.ocp_ope_n_modificou);
                entity.Property(e => e.ocp_c_unique).HasDefaultValueSql("(newid())");
                entity.Property(e => e.ocp_d_atualizado).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ocp_d_inclusao).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ocp_c_status);

                entity.HasOne(x => x.ocp_ope_n_cadastrouNavigation)
                  .WithMany(x => x.tb_ocp_ocorrenciasOperadorCadastrou)
                  .HasForeignKey(x => x.ocp_ope_n_cadastrou)
                  .IsRequired(false)
                  .HasConstraintName("FK_tb_ocp_ocorrenciasOperador_tb_ope_operadorCadastrou");

                entity.HasOne(x => x.ocp_ope_n_modificouNavigation)
                  .WithMany(x => x.tb_ocp_ocorrenciasOperadorModificou)
                  .HasForeignKey(x => x.ocp_ope_n_modificou)
                  .OnDelete(DeleteBehavior.SetNull)
                  .HasConstraintName("FK_tb_ocp_ocorrenciasOperador_tb_ope_operadorModificou");

                entity.HasOne(x => x.ocp_cli_n_codigoNavigation)
                  .WithMany(x => x.tb_ocp_ocorrenciasOperador)
                  .HasForeignKey(x => x.ocp_cli_n_codigo)
                  .HasConstraintName("FK_tb_ocp_ocorrenciasOperador_tb_cli_cliente");

            });

            modelBuilder.Entity<tb_ajd_ajuda>(entity =>
            {
                entity.HasKey(e => e.ajd_n_codigo);
                entity.Property(e => e.ajd_cli_n_codigo);
                entity.Property(e => e.ajd_tpc_n_codigo);
                entity.Property(e => e.ajd_c_duvida);
                entity.Property(e => e.ajd_c_descricao);
                entity.Property(e => e.ajd_c_unique).HasDefaultValueSql("(newid())");
                entity.Property(e => e.ajd_d_inclusao);
                entity.Property(e => e.ajd_d_atualizado);
                entity.Property(e => e.ajd_c_link);

                entity.HasOne(x => x.ajd_cli_n_codigoNavigation)
                  .WithMany(x => x.tb_ajd_ajuda)
                  .HasForeignKey(x => x.ajd_cli_n_codigo)
                  .HasConstraintName("FK_tb_ajd_ajuda_tb_cli_cliente");

                entity.HasOne(x => x.ajd_tpc_n_codigoNavigation)
                  .WithMany(x => x.tb_ajd_ajuda)
                  .HasForeignKey(x => x.ajd_tpc_n_codigo)
                  .HasConstraintName("FK_tb_ajd_ajuda_tb_tpc_topicos");
            });

            modelBuilder.Entity<tb_tpc_topicos>(entity =>
            {
                entity.HasKey(e => e.tpc_n_codigo);
                entity.Property(e => e.tpc_c_descricao);
                entity.Property(e => e.tpc_c_unique).HasDefaultValueSql("(newid())");
                entity.Property(e => e.tpc_d_inclusao);
                entity.Property(e => e.tpc_d_atualizado);
                entity.Property(e => e.tpc_d_modificacao);
            });
        }
    }
}
