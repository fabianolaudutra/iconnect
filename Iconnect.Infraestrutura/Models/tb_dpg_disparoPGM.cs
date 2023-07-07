using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_dpg_disparoPGM
    {
        public int dpg_n_codigo { get; set; }
        public int dpg_eqc_n_codigo { get; set; }
        public int dpg_cgp_n_codigo { get; set; }
        public bool dpg_b_pendente { get; set; }
        public DateTime dpg_d_modificacao { get; set; }
        public string dpg_c_usuario { get; set; }
        public Guid dpg_c_unique { get; set; }
        public DateTime dpg_d_atualizado { get; set; }
        public DateTime dpg_d_inclusao { get; set; }
        public int dpg_cli_n_codigo { get; set; }

        public virtual tb_cpg_comandoPGM dpg_cgp_n_codigoNavigation { get; set; }
        public virtual tb_eqc_equipamentoCliente dpg_eqc_n_codigoNavigation { get; set; }
    }
}
