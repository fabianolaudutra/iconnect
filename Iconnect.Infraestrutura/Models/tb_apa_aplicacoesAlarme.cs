using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_apa_aplicacoesAlarme
    {
        public int apa_n_codigo { get; set; }
        public string apa_c_processo { get; set; }
        public string apa_c_tipo { get; set; }
        public int? apa_emp_n_codigo { get; set; }
        public Guid apa_c_unique { get; set; }
        public DateTime apa_d_atualizado { get; set; }
        public DateTime apa_d_inclusao { get; set; }

        public virtual tb_emp_empresa tb_emp_empresa { get; set; }
    }
}
