using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class RamalLayoutFilterModel : Paginacao
    {
        public string ral_n_codigo_filter { get; set; }
        public string ral_cla_n_codigo_filter { get; set; }
        public string ral_cli_codigo_filter { get; set; }
    }
}
