using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_sca_salaComercialCatalogo
    {
        public int sca_n_codigo { get; set; }
        public int sca_grf_n_codigo { get; set; }
        public int sca_cal_n_codigo { get; set; }
        public Guid sca_c_unique { get; set; }
        public DateTime sca_d_atualizado { get; set; }
        public DateTime sca_d_inclusao { get; set; }

        public virtual tb_cal_catalogo cal_n_codigoNavigation { get; set; }
        public virtual tb_grf_grupoFamiliar grf_n_codigoNavigation { get; set; }
    }
}
