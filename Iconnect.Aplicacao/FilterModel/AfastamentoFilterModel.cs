using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class AfastamentoFilterModel : Paginacao
    {
        public string afa_n_codigo_filter { get; set; }
        public string afa_mor_n_codigo_filter { get; set; }
        public string codeGrupoFamiliar_filter { get; set; }

    }
}
