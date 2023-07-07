using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class vw_cliente
    {
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
        public DateTime? cli_d_modificacao { get; set; }
        public bool? cli_b_disparoSMS { get; set; }
        public string cli_c_ramais { get; set; }
        public int? cli_n_tempoGravacaoGoogleDrive { get; set; }
        public string cli_c_codigoReferencia { get; set; }
        public int cid_n_codigo { get; set; }
        public string cid_n_ibge { get; set; }
        public string cid_c_nome { get; set; }
        public string cid_c_estado { get; set; }
        public int? cid_est_n_codigo { get; set; }
        public int est_n_codigo { get; set; }
        public string est_c_descricao { get; set; }
        public string est_c_sigla { get; set; }
        public string emp_c_nomeFantasia { get; set; }
    }
}
