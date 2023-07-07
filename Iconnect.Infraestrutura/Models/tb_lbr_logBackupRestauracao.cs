using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_lbr_logBackupRestauracao
    {
        public int lbr_n_codigo { get; set; }
        public int lbr_cli_n_codigo { get; set; }
        public bool lbr_b_status { get; set; }
        public DateTime lbr_d_inicio { get; set; }
        public DateTime lbr_d_fim { get; set; }
        public string lbr_c_mensagem { get; set; }
        public Guid lbr_c_unique { get; set; }
        public DateTime lbr_d_atualizado { get; set; }
        public DateTime lbr_d_inclusao { get; set; }

        public virtual tb_cli_cliente lbr_cli_n_codigoNavigation { get; set; }
    }
}
