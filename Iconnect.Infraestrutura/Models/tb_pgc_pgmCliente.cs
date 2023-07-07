using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_pgc_pgmCliente
    {
        public int pgc_n_codigo { get; set; }
        public int pgc_eqc_n_codigo { get; set; }
        public string pgc_c_nome { get; set; }
        public int pgc_cpg_n_codigo { get; set; }
        public int pgc_cli_n_codigo { get; set; }
        public int pgc_usu_n_codigo { get; set; }
        public Guid pgc_c_unique { get; set; }
        public DateTime pgc_d_atualizado { get; set; }
        public DateTime pgc_d_inclusao { get; set; }

        public virtual tb_cli_cliente pgc_cli_n_codigoNavigation { get; set; }
        public virtual tb_cpg_comandoPGM pgc_cpg_n_codigoNavigation { get; set; }
        public virtual tb_eqc_equipamentoCliente pgc_eqc_n_codigoNavigation { get; set; }
    }
}
