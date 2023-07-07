using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class AcessoFilterModel : Paginacao
    {
        public string ace_n_codigo_filter { get; set; }
        public string ace_c_login_filter { get; set; }
        public string ace_emp_n_codigo_filter { get; set; }
        public string ace_dis_n_codigo_filter { get; set; }
    }
}
