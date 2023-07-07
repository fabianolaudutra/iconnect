using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_eve_evento
    {
        public tb_eve_evento()
        {
            tb_mon_monitoramento = new HashSet<tb_mon_monitoramento>();
        }

        public int eve_n_codigo { get; set; }
        public string eve_c_evento { get; set; }
        public string eve_c_conta { get; set; }
        public string eve_c_particao { get; set; }
        public DateTime? eve_d_inclusao { get; set; }
        public string eve_c_zona { get; set; }
        public string eve_c_ip { get; set; }
        public bool? eve_b_lido { get; set; }
        public int? eve_cli_n_codigo { get; set; }
        public DateTime? eve_d_modificacao { get; set; }
        public Guid eve_c_unique { get; set; }
        public DateTime eve_d_atualizado { get; set; }

        public virtual tb_cli_cliente eve_cli_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_mon_monitoramento> tb_mon_monitoramento { get; set; }
    }
}
