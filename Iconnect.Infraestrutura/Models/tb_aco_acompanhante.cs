using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_aco_acompanhante
    {
        public int aco_n_codigo { get; set; }
        public int? aco_age_n_codigo { get; set; }
        public int? aco_vis_n_codigo { get; set; }
        public Guid aco_c_unique { get; set; }
        public DateTime? aco_d_inclusao { get; set; }

        public virtual tb_age_agenda aco_age_n_codigoNavigation { get; set; }
        public virtual tb_vis_visitante aco_vis_n_codigoNavigation { get; set; }
    }
}
