using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_mpc_mapeamentoPontoAcesso
    {
        public int mpc_n_codigo { get; set; }
        public int? mpc_cli_n_codigo { get; set; }
        public int? mpc_pta_n_codigo { get; set; }
        public int? mpc_can_n_codigo { get; set; }
        public string mpc_c_tempoGravacao { get; set; }

        public virtual tb_cli_cliente mpc_cli_n_codigoNavigation { get; set; }
    }
}
