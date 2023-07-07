using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class ClienteFilterModel : Paginacao
    {
        public string cli_c_razaoSocial_filter { get; set; }
        public string sortDir { get; set; }
        public string sortColumn { get; set; }
        public string cli_c_nomeFantasia_filter { get; set; }
        public string cli_c_cnpj_filter { get; set; }
        public string empresa_filter { get; set; }
        public string estado_filter { get; set; }
        public string cidade_filter { get; set; }
        public string status_filter { get; set; }
        public string cli_b_ativo_filter { get; set; }
        public string cli_emp_n_codigo_filter { get; set; }
        public string cli_d_inicioLicenca_filter { get; set; }
        public string cli_n_diaVencimento_filter { get; set; }
        public string cli_d_dataVencimentoLicenca_filter { get; set; }
        public string cli_n_valorLicenca_filter { get; set; }
        public string mol_b_controleDeAcesso_filter { get; set; }
        public string mol_b_MonitoriamentoPerimetral_filter { get; set; }
        public string mol_b_CFTVl_b_CFTV_filter { get; set; }
        public string mol_b_OrdemServico_filter { get; set; }
        public string mol_b_connectSync_filter { get; set; }
        public string mol_b_accessView_filter { get; set; }
        public string buscaSimples_filter { get; set; }
        public string idsClientes { get; set; }

    }
}
