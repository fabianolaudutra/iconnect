using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class PessoaFilterModel : Paginacao
    {
        public string buscaSimples_filter { get; set; }
        public string NOME_filter { get; set; }
        public string RG_filter { get; set; }
        public string CPF_filter { get; set; }
        public string TIPO_filter { get; set; }
        public string CODCLIENTE_filter { get; set;}
        public string TELEFONE_filter { get; set; }
        public string ATIVO_INATIVO_filter { get; set; }
        public string IdsClientes { get; set; }
        public string CELULAR_filter { get; set; }

    }
}