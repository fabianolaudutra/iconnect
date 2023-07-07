using Iconnect.Aplicacao.ViewModels;
namespace Iconnect.Aplicacao.FilterModel
{
    public class RegistroSalaoFilterModel : Paginacao
    {
        public string res_n_codigo_filter { get; set; }
        public string res_dpn_n_codigo_filter { get; set; }
        public string buscaSimples_filter { get; set; }
        public string nomeMorador_filter { get; set; }
        public string codigo_cliente_filter { get; set; }
        public string nomeDependencia_filter { get; set; }
        public string res_d_dataSolicitacao_filter { get; set; }
        public string res_c_periodo_filter { get; set; }
        public string res_c_status_filter { get; set; }
    }
}
