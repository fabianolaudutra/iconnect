using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class ControladoraFilterModel : Paginacao
    {
        public string con_cli_n_codigo_filter { get; set; }
        public string buscaSimples_filter { get; set; }
        public string con_c_nome_filter { get; set; }
        public string con_b_ativo_filter { get; set; }
        public string con_c_modelo_filter { get; set; }
        public string idsClientes { get; set; }
    }
}