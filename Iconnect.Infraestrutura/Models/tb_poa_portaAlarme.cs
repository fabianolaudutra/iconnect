using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_poa_portaAlarme
    {
        public int poa_n_codigo { get; set; }
        public string poa_c_porta { get; set; }
        public int? poa_emp_n_codigo { get; set; }
        public Guid poa_c_unique { get; set; }
        public DateTime poa_d_atualizado { get; set; }
        public DateTime poa_d_inclusao { get; set; }

        public virtual tb_emp_empresa poa_emp_n_codigoNavigation { get; set; }
    }
}
