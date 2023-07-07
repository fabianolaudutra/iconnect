using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class MonitoramentoFilterModel : Paginacao
    {
        public string mon_stm_n_codigo_filter { get; set; }
        public string mon_cli_n_codigo_filter { get; set; }
    }
}
