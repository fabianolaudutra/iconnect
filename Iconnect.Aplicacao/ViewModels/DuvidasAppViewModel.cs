using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class DuvidasAppViewModel
    {
        public string dva_n_codigo { get; set; }
        public string dva_cli_n_codigo { get; set; }
        public string dva_c_duvida { get; set; }
        public string dva_c_resposta { get; set; }
        public string dva_c_link { get; set; }
        public Guid dva_c_unique { get; set; }
        public DateTime dva_d_atualizado { get; set; }
        public DateTime dva_d_inclusao { get; set; }

    }
}
