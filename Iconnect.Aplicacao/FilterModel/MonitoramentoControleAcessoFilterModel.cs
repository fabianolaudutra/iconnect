using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class MonitoramentoControleAcessoFilterModel : Paginacao
    {
        public string con_cli_n_codigo_filter { get; set; }
        public string qtdBlocos { get; set; }
        public string IdsClientes { get; set; }
        public string con_usu_n_codigo { get; set; }
        public string con_c_tipoPessoa { get; set; }
    }
}