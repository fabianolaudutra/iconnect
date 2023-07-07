using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_avv_avisoVisitante
    {
        public int avv_n_codigo { get; set; }
        public int? avv_cav_n_codigo { get; set; }
        public bool? avv_b_lidoNaoLido { get; set; }
        public int? avv_vis_n_codigo { get; set; }
        public string avv_c_descricao { get; set; }
        public DateTime? avv_d_modificacao { get; set; }
        public Guid avv_c_unique { get; set; }
        public DateTime avv_d_atualizado { get; set; }
        public DateTime avv_d_inclusao { get; set; }

        public virtual tb_cav_categorizacaoAviso avv_cav_n_codigoNavigation { get; set; }
        public virtual tb_vis_visitante avv_vis_n_codigoNavigation { get; set; }
    }
}
