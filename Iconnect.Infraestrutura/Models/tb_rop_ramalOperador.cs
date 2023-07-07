using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_rop_ramalOperador
    {
        public int rop_n_codigo { get; set; }
        public DateTime? rop_d_data { get; set; }
        public string rop_c_ramal { get; set; }
        public int? rop_ope_n_codigo { get; set; }
        public Guid rop_c_unique { get; set; }
        public DateTime rop_d_atualizado { get; set; }
        public DateTime rop_d_inclusao { get; set; }

        public virtual tb_ope_operador rop_ope_n_codigoNavigation { get; set; }
    }
}
