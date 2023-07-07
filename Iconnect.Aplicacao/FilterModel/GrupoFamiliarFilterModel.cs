using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class GrupoFamiliarFilterModel : Paginacao
    {
        public string grf_cli_n_codigo_filter { get; set; }
        public string grf_c_nomeResponsavel_filter { get; set; }
        public string grf_c_cpf_filter { get; set; }
        public string grf_c_rg_filter { get; set; }
        public string grf_c_telefone_filter { get; set; }
        public string grf_c_status_filter { get; set; }
        public string buscaSimples_filter { get; set; }
        public string buscaSimplesSala_filter { get; set; }
        public string idsClientes { get; set; }
        public string TELEFONE_filter { get; internal set; }
        public string adm_salaComercial_filter { get; set; }
        public string grf_cli_tcl_n_codigo { get; set; }
        public string grf_c_nomeSalaComercial_filter { get; set; }
        public string grf_c_numeroVagas_filter { get; set; }
        public string grf_c_BlocoQuadra_filter { get; set; }
        public string grf_c_LoteApto_filter { get; set; }
        public string grf_n_codigo { get; set; }
        public string grf_vec_c_placaVeiculo_filter { get; set; }
    }
}