using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_avp_avisoPrestador
    {
        public int avp_n_codigo { get; set; }
        public int? avp_cav_n_codigo { get; set; }
        public bool? avp_b_lidoNaoLido { get; set; }
        public int? avp_pse_n_codigo { get; set; }
        public string avp_c_descricao { get; set; }
        public DateTime? avp_d_modificacao { get; set; }
        public Guid avp_c_unique { get; set; }
        public DateTime avp_d_atualizado { get; set; }
        public DateTime avp_d_inclusao { get; set; }

        public virtual tb_cav_categorizacaoAviso avp_cav_n_codigoNavigation { get; set; }
        public virtual tb_pse_prestadorServico avp_pse_n_codigoNavigation { get; set; }
    }
}
