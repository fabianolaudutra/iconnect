using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_hdi_historicoDispositivo
    {
        public int hdi_n_codigo { get; set; }
        public int? hdi_con_n_codigo { get; set; }
        public DateTime? hdi_d_data { get; set; }
        public string hdi_c_mensagem { get; set; }
        public Guid hdi_c_unique { get; set; }
        public DateTime hdi_d_atualizado { get; set; }
        public DateTime hdi_d_inclusao { get; set; }

        public virtual tb_con_controladora hdi_con_n_codigoNavigation { get; set; }
    }
}
