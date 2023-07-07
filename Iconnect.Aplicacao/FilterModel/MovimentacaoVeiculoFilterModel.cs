using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class MovimentacaoVeiculoFilterModel : Paginacao
    {
        public string mve_n_codigo_filter { get; set; }
        public string mve_fro_n_codigo_filter { get; set; }
        public string mve_mor_n_codigo_filter { get; set; }
        public string mve_c_fluxo_filter_filter { get; set; }
        public string mve_n_quilometragem_filter { get; set; }
        public string mve_d_dataRegistro_filter { get; set; }
        public string mve_c_usuarioLogado_filter { get; set; }
    }
}
