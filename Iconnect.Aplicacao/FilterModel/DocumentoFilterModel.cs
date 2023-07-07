using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class DocumentoFilterModel : Paginacao
    {
        public string doc_n_codigo_filter { get; set; }
        public string doc_cli_n_codigo_filter { get; set; }
        public string doc_c_nomeDocumento_filter { get; set; }
        public string doc_b_bloquearAcesso_filter { get; set; }
        public string doc_b_preNotificacao_filter { get; set; }
        public string doc_b_notificacaoAcesso_filter { get; set; }
        public string doc_b_notificacaoVencimento_filter { get; set; }
        public string doc_n_diasNotificacao_filter { get; set; }
        public string doc_d_modificacao_filter { get; set; }
        public string mor_n_codigo_filter { get; set; }
        public string status { get; set; }
    }
}