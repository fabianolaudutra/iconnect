using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class EnvioNotificacaoFilterModel : Paginacao
    {
        public string Titulo { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public string ClienteId { get; set; }
        public string Status { get; set; }
        public string buscaSimples_filter { get; set; }
        public string idEmp { get; set; }
    }
}