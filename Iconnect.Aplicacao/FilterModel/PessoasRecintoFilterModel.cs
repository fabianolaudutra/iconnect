using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class PessoasRecintoFilterModel : Paginacao
    {
        public string buscaSimples_filter { get; set; }
        public string NOME_filter { get; set; }
        public string TIPO_filter { get; set; }
        public string TELEFONE_filter { get; set; }
        public string LOCALIZACAO_filter { get; set; }
        public string DATA_filter { get; set; }
        public string CODCLIENTE_filter { get; set; }
        public string LOCALIZACAONOME_filter { get; set; }
    }
}