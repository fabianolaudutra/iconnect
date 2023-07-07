using System;

namespace Iconnect.Aplicacao.ViewModels
{
    public class SoliciacaoZeladorSignalRViewModel
    {
        public string soz_n_codigo { get; set; }
        public string soz_c_descricao { get; set; }
        public string soz_mor_n_codigo { get; set; }
        public string soz_c_status { get; set; }
        public string soz_d_dataSolicitacao { get; set; }
        public string NomeMorador { get; set; }
        public string NomeCliente { get; set; }
        public DateTime dateOrder { get; set; }
        public int cli_n_codigo { get; set; }
    }
}
