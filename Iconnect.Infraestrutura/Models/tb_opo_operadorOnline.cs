using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_opo_operadorOnline
    {
        public int opo_n_codigo { get; set; }
        public int? opo_cli_n_codigo { get; set; }
        public int? opo_opr_n_codigo { get; set; }
        public bool? opo_b_online { get; set; }

        public virtual tb_cli_cliente opo_cli_n_codigoNavigation { get; set; }
    }
}
