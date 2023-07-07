using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class VisitanteFilterModel : Paginacao
    {
        public string vis_cli_n_codigo_filter { get; set; }
        public string vis_c_nome_filter { get; set; }
        public string vis_c_cpf_filter { get; set; }
        public string vis_c_rg_filter { get; set; }
        public string vis_c_celular_filter { get; set; }
        public string vis_c_localizacao_filter { get; set; }
        public string vis_c_placaVeiculo_filter { get; set; }
    }
}