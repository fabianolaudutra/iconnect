using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_lsm_logSMS
    {
        public int lsm_n_codigo { get; set; }
        public int? lsm_mor_n_codigo { get; set; }
        public int? lsm_cli_n_codigo { get; set; }
        public DateTime? lsm_d_data { get; set; }
        public string lsm_c_nomeContato { get; set; }
        public string lsm_c_numeroContato { get; set; }
    }
}
