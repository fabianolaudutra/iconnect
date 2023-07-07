using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_stm_statusMonitoramento
    {
        public tb_stm_statusMonitoramento()
        {
            tb_mon_monitoramento = new HashSet<tb_mon_monitoramento>();
        }

        public int stm_n_codigo { get; set; }
        public string stm_c_descricao { get; set; }
        public DateTime? stm_d_modificacao { get; set; }
        public Guid stm_c_unique { get; set; }
        public DateTime stm_d_atualizado { get; set; }
        public DateTime stm_d_inclusao { get; set; }

        public virtual ICollection<tb_mon_monitoramento> tb_mon_monitoramento { get; set; }
    }
}
