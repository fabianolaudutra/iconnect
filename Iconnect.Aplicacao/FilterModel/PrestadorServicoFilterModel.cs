using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class PrestadorServicoFilterModel : Paginacao
    {
        public string pse_cli_n_codigo_filter { get; set; }
        public string pse_c_nome_filter { get; set; }
        public string pse_c_cpf_filter { get; set; }
        public string pse_c_rg_filter { get; set; }
        public string pse_c_celular_filter { get; set; }
        public string pse_d_dataSaidaManual_filter { get; set; }
        public string pse_d_dataEntrada_filter { get; set; }
        public string pse_n_codigo_filter { get; set; }
        public string pse_c_localizacao_filter { get; set; }
        public string pse_c_placaVeiculo_filter { get; set; }
    }
}