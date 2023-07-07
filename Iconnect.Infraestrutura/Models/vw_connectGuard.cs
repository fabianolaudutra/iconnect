using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class vw_connectGuard
    {
        public string mon_c_nomeSetorCentral { get; set; }
        public string mon_c_tipoEvento { get; set; }
        public string mon_c_data { get; set; }
        public DateTime? eve_d_inclusao { get; set; }
        public int mon_n_codigo { get; set; }
        public int? mon_cli_n_codigo { get; set; }
        public int? mon_stm_n_codigo { get; set; }
        public string cev_c_cor { get; set; }
    }
}
