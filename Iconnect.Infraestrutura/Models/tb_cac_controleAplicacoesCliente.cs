using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_cac_controleAplicacoesCliente
    {
        public int cac_n_codigo { get; set; }
        public string cac_c_processo { get; set; }
        public int? cac_con_n_codigo { get; set; }
        public Guid cac_c_unique { get; set; }
        public DateTime cac_d_atualizado { get; set; }
        public DateTime cac_d_inclusao { get; set; }

        public virtual tb_con_controladora cac_con_n_codigoNavigation { get; set; }
    }
}
