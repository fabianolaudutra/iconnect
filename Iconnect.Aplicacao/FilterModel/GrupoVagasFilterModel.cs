using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class GrupoVagasFilterModel : Paginacao
    {
        public string cliente_filter { get; set; }
        public string descricao_filter { get; set; }
        public string numeroVagas_filter { get; set; }
        public string buscaSimples_filter { get; set; }
        public string idsClientes { get; set; }
    }
}
