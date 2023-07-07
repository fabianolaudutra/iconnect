using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class SolicitarZeladorFilterModel : Paginacao
    {
        public string soz_mor_n_codigo_filter { get; set; }
        public string soz_c_status_filter { get; set; }
        public string cli_n_codigo_filter { get; set; }
        public string idsClientes { get; set; }
    }
}