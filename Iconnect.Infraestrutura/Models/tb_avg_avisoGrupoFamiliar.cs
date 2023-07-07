using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_avg_avisoGrupoFamiliar
    {
        public int avg_n_codigo { get; set; }
        public int? avg_cav_n_codigo { get; set; }
        public bool? avg_b_lidoNaoLido { get; set; }
        public int? avg_grf_n_codigo { get; set; }
        public string avg_c_descricao { get; set; }
        public DateTime? avg_d_modificacao { get; set; }
        public Guid avg_c_unique { get; set; }
        public DateTime avg_d_atualizado { get; set; }
        public DateTime avg_d_inclusao { get; set; }

        public virtual tb_cav_categorizacaoAviso avg_cav_n_codigoNavigation { get; set; }
        public virtual tb_grf_grupoFamiliar avg_grf_n_codigoNavigation { get; set; }
    }
}
