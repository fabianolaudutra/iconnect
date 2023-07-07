using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public class tb_lca_localidadeCatalogo
    {
        public int lca_n_codigo { get; set; }

        public int? lca_lcc_n_codigo { get; set; }
        public int? lca_cal_n_codigo { get; set; }

        public DateTime? lca_d_modificacao { get; set; }
        public Guid lca_c_unique { get; set; }
        public DateTime lca_d_atualizado { get; set; }
        public DateTime lca_d_inclusao { get; set; }

        public virtual tb_cal_catalogo lac_cal_n_codigoNavigation { get; set; }
        public virtual tb_lcc_localidadeCliente lac_lcc_n_codigoNavigation { get; set; }
    }
}
