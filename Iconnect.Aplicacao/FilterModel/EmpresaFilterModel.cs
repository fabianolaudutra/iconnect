using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class EmpresaFilterModel : Paginacao
    {
        
        public string emp_n_codigo_filter { get; set; }
        public string Ie { get; set; }
        public string razaoSocial { get; set; }
        public string sortDir { get; set; }
        public string sortColumn { get; set; }
        public string emp_c_razaoSocial_filter { get; set; }
        public string emp_c_nomeFantasia_filter { get; set; }
        public string emp_c_cnpj_filter { get; set; }
        public string emp_c_ie_filter { get; set; }
        public string Cidade_filter { get; set; }
        public string Estado_filter { get; set; }
        public string QtdLicencas_filter { get; set; }
        public string ValorLicencas_filter { get; set; }
        public string ProxVenc_filter { get; set; }
        public string QtdAtivos_filter { get; set; }
        public string QtdInativos_filter { get; set; }
        public string ControlAcess_filter { get; set; }
        public string MonitPC_filter { get; set; }
        public string MonitCFTV_filter { get; set; }
        public string OS_filter { get; set; }
        public string Sync_filter { get; set; }
        public string accessView_filter { get; set; }
        public string buscaSimples_filter { get; set; }
        public string emp_dis_n_codigo_filter { get; set; }

    }
}
