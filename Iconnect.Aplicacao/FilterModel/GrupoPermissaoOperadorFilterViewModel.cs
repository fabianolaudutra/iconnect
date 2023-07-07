using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class GrupoPermissaoOperadorFilterViewModel : Paginacao
    {
        public string buscaSimples_filter { get; set; }
        public string gpp_n_codigo_filter { get; set; }
        public string gpp_cli_n_codigo_filter { get; set; }
        public string gpp_emp_n_codigo_filter { get; set; }
        public string gpp_c_descricao_filter { get; set; }
        public string idEmp { get; set; }
    }
}
