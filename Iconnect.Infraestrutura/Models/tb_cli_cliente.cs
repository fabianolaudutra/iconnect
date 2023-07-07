using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_cli_cliente
    {
        public tb_cli_cliente()
        {
            tb_cla_cabecalhoLayout = new HashSet<tb_cla_cabecalhoLayout>();
            tb_con_controladora = new HashSet<tb_con_controladora>();
            tb_con_monitoramentoControleAcesso = new HashSet<tb_con_monitoramentoControleAcesso>();
            tb_ddv_dispositivoDVRCliente = new HashSet<tb_ddv_dispositivoDVRCliente>();
            tb_dpn_dependencias = new HashSet<tb_dpn_dependencias>();
            tb_eno_envioNotificacao = new HashSet<tb_eno_envioNotificacao>();
            tb_eqc_equipamentoCliente = new HashSet<tb_eqc_equipamentoCliente>();
            tb_eve_evento = new HashSet<tb_eve_evento>();
            tb_fer_feriado = new HashSet<tb_fer_feriado>();
            tb_gpp_grupoPermissaoOperador = new HashSet<tb_gpp_grupoPermissaoOperador>();
            tb_gpv_grupoVagas = new HashSet<tb_gpv_grupoVagas>();
            tb_grf_grupoFamiliar = new HashSet<tb_grf_grupoFamiliar>();
            tb_hor_horario = new HashSet<tb_hor_horario>();
            tb_lay_layout = new HashSet<tb_lay_layout>();
            tb_lbr_logBackupRestauracao = new HashSet<tb_lbr_logBackupRestauracao>();
            tb_lcc_localidadeCliente = new HashSet<tb_lcc_localidadeCliente>();
            tb_moc_motivoOcorrenciaCliente = new HashSet<tb_moc_motivoOcorrenciaCliente>();
            tb_mon_monitoramento = new HashSet<tb_mon_monitoramento>();
            tb_mor_Morador = new HashSet<tb_mor_Morador>();
            tb_mpc_mapeamentoPontoAcesso = new HashSet<tb_mpc_mapeamentoPontoAcesso>();
            tb_opl_operadorLocal = new HashSet<tb_opl_operadorLocal>();
            tb_opo_operadorOnline = new HashSet<tb_opo_operadorOnline>();
            tb_pec_permissaoCliente = new HashSet<tb_pec_permissaoCliente>();
            tb_pgc_pgmCliente = new HashSet<tb_pgc_pgmCliente>();
            tb_phr_perfilHorario = new HashSet<tb_phr_perfilHorario>();
            tb_plc_pontoLayoutCliente = new HashSet<tb_plc_pontoLayoutCliente>();
            tb_por_portasStream = new HashSet<tb_por_portasStream>();
            tb_pse_prestadorServico = new HashSet<tb_pse_prestadorServico>();
            tb_pta_pontosAcesso = new HashSet<tb_pta_pontosAcesso>();
            tb_rel_responsavelLocacaoSaloes = new HashSet<tb_rel_responsavelLocacaoSaloes>();
            tb_sin_sincronizacaoPlacas = new HashSet<tb_sin_sincronizacaoPlacas>();
            tb_vic_vigilanteCliente = new HashSet<tb_vic_vigilanteCliente>();
            tb_vis_visitante = new HashSet<tb_vis_visitante>();
            tb_zec_zeladorCliente = new HashSet<tb_zec_zeladorCliente>();
            tb_zoc_zoneamentoCliente = new HashSet<tb_zoc_zoneamentoCliente>();
            tb_fro_frota = new HashSet<tb_fro_frota>();
            tb_doc_documento = new HashSet<tb_doc_documento>();
            tb_inc_informacoesCliente = new HashSet<tb_inc_informacoesCliente>();
            tb_dva_duvidasApp = new HashSet<tb_dva_duvidasApp>();
            tb_ref_refeicao = new HashSet<tb_ref_refeicao>();
        }

        public int cli_n_codigo { get; set; }
        public string cli_c_razaoSocial { get; set; }
        public string cli_c_nomeFantasia { get; set; }
        public DateTime? cli_d_inicioContrato { get; set; }
        public string cli_c_cnpj { get; set; }
        public string cli_c_ie { get; set; }
        public string cli_c_pessoaContato { get; set; }
        public string cli_c_email { get; set; }
        public string cli_c_email2 { get; set; }
        public string cli_c_telefoneComercial { get; set; }
        public string cli_c_telefoneComercial2 { get; set; }
        public string cli_c_celular { get; set; }
        public string cli_c_celular2 { get; set; }
        public string cli_c_rua { get; set; }
        public string cli_c_complemento { get; set; }
        public string cli_c_bairro { get; set; }
        public string cli_c_cep { get; set; }
        public int? cli_cid_n_codigo { get; set; }
        public int? cli_est_n_codigo { get; set; }
        public int? cli_emp_n_codigo { get; set; }
        public string cli_c_observacao { get; set; }
        public string cli_c_fantasiaAdministradora { get; set; }
        public string cli_c_pessoaContatoAdministradora { get; set; }
        public string cli_c_emailAdministradora { get; set; }
        public string cli_c_telefoneAdministradora { get; set; }
        public string cli_c_celularAdministradora { get; set; }
        public string cli_c_numero { get; set; }
        public string cli_c_tipoRede { get; set; }
        public string cli_c_ip { get; set; }
        public string cli_c_dominio { get; set; }
        public string cli_c_porta { get; set; }
        public string cli_c_centralVoip { get; set; }
        public int? cli_mol_n_codigo { get; set; }
        public string cli_c_senha { get; set; }
        public string cli_c_contraSenha { get; set; }
        public string cli_c_chave { get; set; }
        public string cli_c_zona { get; set; }
        public string cli_c_ramal { get; set; }
        public decimal? cli_n_valorLicenca { get; set; }
        public DateTime? cli_d_dataVencimentoLicenca { get; set; }
        public bool? cli_b_licencaAtiva { get; set; }
        public bool? cli_b_controleAcesso { get; set; }
        public int? cli_n_diaVencimento { get; set; }
        public DateTime? cli_d_inicioLicenca { get; set; }
        public bool? cli_b_ativo { get; set; }
        public DateTime? cli_d_alteracao { get; set; }
        public string cli_c_usuario { get; set; }
        public int? cli_can_n_panoramica { get; set; }
        public int? cli_n_horasExpiracaoTokenDelivery { get; set; }
        public string cli_c_senhaAppGarenConnect { get; set; }
        public bool cli_b_free { get; set; }
        public DateTime? cli_d_modificacao { get; set; }
        public bool? cli_b_disparoSMS { get; set; }
        public string cli_c_ramais { get; set; }
        public int? cli_n_tempoGravacaoGoogleDrive { get; set; }
        public string cli_c_codigoReferencia { get; set; }
        public int? cli_can_n_access { get; set; }
        public Guid cli_c_unique { get; set; }
        public DateTime cli_d_atualizado { get; set; }
        public DateTime? cli_d_inclusao { get; set; }
        public int? cli_lay_n_codigo { get; set; }
        public string cli_c_codInstalacaoOffline { get; set; }
        public int? cli_n_numDiasExpiracao { get; set; }
        public string cli_c_serial { get; set; }
        public DateTime? cli_d_dataCriacao { get; set; }
        public DateTime? cli_d_dataExpiracao { get; set; }
        public string cli_c_codInstalacaoRenovacao { get; set; }
        public string cli_c_dominioSIP { get; set; }
        public string cli_c_senhaSIP { get; set; }
        public string cli_c_portaSIP { get; set; }
        public DateTime? cli_d_dataUltimaSincronizacaoCloud { get; set; }
        public string cli_c_range_periodo_aplicadorTicket { get; set; }
        public DateTime? cli_d_ultimoContatoSolution { get; set; }
        public int? cli_tcl_n_codigo { get; set; }
        public string cli_c_emailSegTrabalho { get; set; }
        public string cli_c_ramalPortaria { get; set; }
        public string cli_c_tituloInstitucional { get; set; }
        public string cli_c_descricaoInstitucional { get; set; } 
        public int? cli_fot_fachada_n_codigo { get; set; }

        public virtual tb_can_canalLayout cli_can_n_accessNavigation { get; set; }
        public virtual tb_cid_cidade cli_cid_n_codigoNavigation { get; set; }
        public virtual tb_emp_empresa cli_emp_n_codigoNavigation { get; set; }
        public virtual tb_est_estado cli_est_n_codigoNavigation { get; set; }
        public virtual tb_mol_modulosLiberados cli_mol_n_codigoNavigation { get; set; }
        public virtual tb_tcl_tipoCliente cli_tcl_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_cla_cabecalhoLayout> tb_cla_cabecalhoLayout { get; set; }
        public virtual ICollection<tb_con_controladora> tb_con_controladora { get; set; }
        public virtual ICollection<tb_con_monitoramentoControleAcesso> tb_con_monitoramentoControleAcesso { get; set; }
        public virtual ICollection<tb_ddv_dispositivoDVRCliente> tb_ddv_dispositivoDVRCliente { get; set; }
        public virtual ICollection<tb_dpn_dependencias> tb_dpn_dependencias { get; set; }
        public virtual ICollection<tb_eno_envioNotificacao> tb_eno_envioNotificacao { get; set; }
        public virtual ICollection<tb_eqc_equipamentoCliente> tb_eqc_equipamentoCliente { get; set; }
        public virtual ICollection<tb_eve_evento> tb_eve_evento { get; set; }
        public virtual ICollection<tb_fer_feriado> tb_fer_feriado { get; set; }
        public virtual ICollection<tb_gpp_grupoPermissaoOperador> tb_gpp_grupoPermissaoOperador { get; set; }
        public virtual ICollection<tb_gpv_grupoVagas> tb_gpv_grupoVagas { get; set; }
        public virtual ICollection<tb_grf_grupoFamiliar> tb_grf_grupoFamiliar { get; set; }
        public virtual ICollection<tb_hor_horario> tb_hor_horario { get; set; }
        public virtual ICollection<tb_lay_layout> tb_lay_layout { get; set; }
        public virtual ICollection<tb_lbr_logBackupRestauracao> tb_lbr_logBackupRestauracao { get; set; }
        public virtual ICollection<tb_lcc_localidadeCliente> tb_lcc_localidadeCliente { get; set; }
        public virtual ICollection<tb_moc_motivoOcorrenciaCliente> tb_moc_motivoOcorrenciaCliente { get; set; }
        public virtual ICollection<tb_mon_monitoramento> tb_mon_monitoramento { get; set; }
        public virtual ICollection<tb_mor_Morador> tb_mor_Morador { get; set; }
        public virtual ICollection<tb_mpc_mapeamentoPontoAcesso> tb_mpc_mapeamentoPontoAcesso { get; set; }
        public virtual ICollection<tb_opl_operadorLocal> tb_opl_operadorLocal { get; set; }
        public virtual ICollection<tb_opo_operadorOnline> tb_opo_operadorOnline { get; set; }
        public virtual ICollection<tb_pec_permissaoCliente> tb_pec_permissaoCliente { get; set; }
        public virtual ICollection<tb_pgc_pgmCliente> tb_pgc_pgmCliente { get; set; }
        public virtual ICollection<tb_phr_perfilHorario> tb_phr_perfilHorario { get; set; }
        public virtual ICollection<tb_plc_pontoLayoutCliente> tb_plc_pontoLayoutCliente { get; set; }
        public virtual ICollection<tb_por_portasStream> tb_por_portasStream { get; set; }
        public virtual ICollection<tb_pse_prestadorServico> tb_pse_prestadorServico { get; set; }
        public virtual ICollection<tb_pta_pontosAcesso> tb_pta_pontosAcesso { get; set; }
        public virtual ICollection<tb_rel_responsavelLocacaoSaloes> tb_rel_responsavelLocacaoSaloes { get; set; }
        public virtual ICollection<tb_sin_sincronizacaoPlacas> tb_sin_sincronizacaoPlacas { get; set; }
        public virtual ICollection<tb_vic_vigilanteCliente> tb_vic_vigilanteCliente { get; set; }
        public virtual ICollection<tb_vis_visitante> tb_vis_visitante { get; set; }
        public virtual ICollection<tb_zec_zeladorCliente> tb_zec_zeladorCliente { get; set; }
        public virtual ICollection<tb_zoc_zoneamentoCliente> tb_zoc_zoneamentoCliente { get; set; }
        public virtual ICollection<tb_fro_frota> tb_fro_frota { get; set; }
        public virtual ICollection<tb_doc_documento> tb_doc_documento { get; set; }
        public virtual ICollection<tb_inc_informacoesCliente> tb_inc_informacoesCliente { get; set; }
        public virtual ICollection<tb_dva_duvidasApp> tb_dva_duvidasApp { get; set; }
        public virtual ICollection<tb_per_perguntas> tb_per_perguntas { get; set; }
        public virtual ICollection<tb_bio_biometria> tb_bio_biometria { get; set; }
        public virtual ICollection<tb_aba_agendaBackupAutomatico> tb_aba_agendaBackupAutomatico { get; set; }
        public virtual ICollection<tb_ate_atendimento> tb_ate_atendimento { get; set; }
        public virtual ICollection<tb_dow_downloads_arquivos> tb_dow_downloads_arquivos { get; set; }
        public virtual ICollection<tb_cat_categoriaCatalogo> tb_cat_categoriaCatalogo { get; set; }
        public virtual ICollection<tb_ref_refeicao> tb_ref_refeicao { get; set; }
        public virtual ICollection<tb_fac_face> tb_fac_face { get; set; }
        public virtual tb_fot_foto cli_fot_fachada_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_ocp_ocorrenciasOperador> tb_ocp_ocorrenciasOperador { get; set; }
        public virtual ICollection<tb_ajd_ajuda> tb_ajd_ajuda { get; set; }
    }
}
