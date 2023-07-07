
using Iconnect.Aplicacao.ViewModels;


namespace Iconnect.Aplicacao.FilterModel
{
    public class FrotaFilterModel: Paginacao
    {
        public string fro_n_codigo_filter { get; set; }
        public string fro_cli_n_codigo_filter { get; set; }
        public string fro_mav_n_codigo_filter { get; set; }
        public string fro_c_modelo_filter { get; set; }
        public string fro_c_ano_filter { get; set; }
        public string fro_c_cor_filter { get; set; }
        public string fro_c_placa_filter { get; set; }
        public string fro_c_caracteristicas_filter { get; set; }
        public string buscaSimples_filter { get; set; }
        public string fro_b_ativos_filter { get; set; }

    }
}
