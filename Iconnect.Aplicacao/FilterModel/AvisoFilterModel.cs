using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class AvisoFilterModel : Paginacao
    {
        public string Titulo { get; set; }
        public string EmpresaId { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public string Status { get; set; }
        public string buscaSimples_filter { get; set; }
        public string idEmp { get; set; }
    }
}