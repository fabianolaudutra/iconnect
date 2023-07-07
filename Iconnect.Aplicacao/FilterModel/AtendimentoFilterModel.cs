using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class AtendimentoFilterModel : Paginacao
    {
        public string status_filter { get; set; }
        public string usuario_filter { get; set; }
        public string perfil_filter { get; set; }
    }
}