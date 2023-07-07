using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_seb_serviceBroker
    {
        public int seb_n_codigo { get; set; }
        public int? seb_cli_n_codigo { get; set; }
        public string seb_c_usuarios { get; set; }
        public string seb_c_tipoUsuario { get; set; }
        public string seb_c_tabelaOrigem { get; set; }
        public string seb_c_ramalorigem { get; set; }
        public string seb_c_ramaldestino { get; set; }
    }
}
