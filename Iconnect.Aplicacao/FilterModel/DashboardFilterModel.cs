using Iconnect.Aplicacao.ViewModels;
using System;

namespace Iconnect.Aplicacao.FilterModel
{
    public class DashboardFilterModel : Paginacao
    {
        public string cli_n_codigo { get; set; }
        public string periodo { get; set; }

        public int? codCliente { get; set; }
        public DateTime dtDe { get; set; }
        public DateTime dtAte { get; set; }
        public DateTime dtDeAnterior { get; set; }
        public DateTime dtAteAnterior { get; set; }
        public Boolean processarPeriodoAnterior { get; set; }
    }
}