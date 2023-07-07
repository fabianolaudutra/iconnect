using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_cpg_comandoPGM
    {
        public tb_cpg_comandoPGM()
        {
            tb_dpg_disparoPGM = new HashSet<tb_dpg_disparoPGM>();
            tb_pgc_pgmCliente = new HashSet<tb_pgc_pgmCliente>();
        }

        public int cgp_n_codigo { get; set; }
        public string cgp_c_descricao { get; set; }
        public int cgp_n_modelo { get; set; }
        public string cgp_c_comando { get; set; }
        public bool cgp_b_sirene { get; set; }
        public Guid cgp_c_unique { get; set; }
        public DateTime cgp_d_atualizado { get; set; }
        public DateTime cgp_d_inclusao { get; set; }

        public virtual ICollection<tb_dpg_disparoPGM> tb_dpg_disparoPGM { get; set; }
        public virtual ICollection<tb_pgc_pgmCliente> tb_pgc_pgmCliente { get; set; }
    }
}
