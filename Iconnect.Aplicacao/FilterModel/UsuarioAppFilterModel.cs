using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class UsuarioAppFilterModel : Paginacao
    {
        public string usu_mor_n_codigo_filter { get; set; }
        public string usu_n_codigo_filter { get; set; }
        public string usu_b_liberado_filter { get; set; }
        public string cli_n_codigo_filter { get; set; }
        public string idsClientes { get; set; }
    }
}
