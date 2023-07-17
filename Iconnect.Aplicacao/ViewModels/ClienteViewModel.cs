﻿using System;

namespace Iconnect.Aplicacao.ViewModels
{
    public class ClienteViewModel
    {

        public string cli_n_codigo { get; set; }
        public string cli_c_razaoSocial { get; set; }
        public string cli_c_nomeFantasia { get; set; }
        public string cli_d_inicioContrato { get; set; }
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
        public string cli_cid_n_codigo { get; set; }
        public string cli_est_n_codigo { get; set; }
        public string cli_emp_n_codigo { get; set; }
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
        public string cli_mol_n_codigo { get; set; }
        public string cli_c_senha { get; set; }
        public string cli_c_contraSenha { get; set; }
        public string cli_c_chave { get; set; }
        public string cli_c_zona { get; set; }
        public string cli_c_ramal { get; set; }
        public string cli_n_valorLicenca { get; set; }
        public string cli_d_dataVencimentoLicenca { get; set; }
        public bool? cli_b_licencaAtiva { get; set; }
        public bool? cli_b_controleAcesso { get; set; }
        public string cli_n_diaVencimento { get; set; }
        public string cli_d_inicioLicenca { get; set; }
        public string cli_b_ativo { get; set; }
        public DateTime? cli_d_alteracao { get; set; }
        public string cli_c_usuario { get; set; }
        public string cli_can_n_panoramica { get; set; }
        public string cli_n_horasExpiracaoTokenDelivery { get; set; }
        public string cli_c_senhaAppGarenConnect { get; set; }
        public bool cli_b_free { get; set; }
        public bool cli_b_freeLicença { get; set; }
        public DateTime? cli_d_modificacao { get; set; }
        public string cli_b_disparoSMS { get; set; }
        public string cli_c_ramais { get; set; }
        public int? cli_n_tempoGravacaoGoogleDrive { get; set; }
        public string cli_c_codigoReferencia { get; set; }
        public int? cli_can_n_access { get; set; }
        public Guid cli_c_unique { get; set; }
        public DateTime cli_d_atualizado { get; set; }
        public string cli_d_inclusao { get; set; }
        public int? cli_lay_n_codigo { get; set; }
        public string cli_c_codInstalacaoOffline { get; set; }
        public string cli_n_numDiasExpiracao { get; set; }
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
        public string cli_tcl_n_codigo { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Empresa { get; set; }
        public string Status { get; set; }
        public string emp_rangeRamais { get; set; }
        public string cli_smsEnviados { get; set; }
        public ModuloViewModel Modulo { get; set; }
        public string mol_b_controleDeAcesso { get; set; }
        public string mol_b_MonitoriamentoPerimetral { get; set; }
        public string mol_b_CFTV { get; set; }
        public string mol_b_OrdemServico { get; set; }
        public string mol_b_connectSync { get; set; }
        public string mol_b_accessView { get; set; }
        public bool mol_b_connectGaren { get; set; }
        public string mol_b_connectSolutions { get; set; }
        public string tipoGaren { get; set; }
        public string tipoCliente { get; set; }
        public string buscaSimples { get; set; }
        public string cli_c_emailSegTrabalho { get; set; }
        public DateTime? data_inicio { get; set; }
        public DateTime? data_fim { get; set; }
        public string attGuard { get; set; }
        public string attAccess { get; set; }
        public string attVoip { get; set; }
        public string attTotal { get; set; }
        public string statusAtt { get; set; }
        public string statusSolution { get; set; }
        public string cli_c_ramalPortaria { get; set; }
        public string cli_c_tituloInstitucional { get; set; }
        public string cli_c_descricaoInstitucional { get; set; }
        public string emp_n_codigo { get; set; }
        public string cli_ref_pta_n_codigo { get; set; }
        public string cli_fot_fachada_n_codigo { get; set; }
        public string fot_d_upload { get; set; }
    }
}