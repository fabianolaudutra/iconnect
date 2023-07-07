using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_cav_categorizacaoAviso
    {
        public tb_cav_categorizacaoAviso()
        {
            tb_avg_avisoGrupoFamiliar = new HashSet<tb_avg_avisoGrupoFamiliar>();
            tb_avi_avisoMorador = new HashSet<tb_avi_avisoMorador>();
            tb_avp_avisoPrestador = new HashSet<tb_avp_avisoPrestador>();
            tb_avv_avisoVisitante = new HashSet<tb_avv_avisoVisitante>();
        }

        public int cav_n_codigo { get; set; }
        public string cav_c_descricao { get; set; }
        public string cav_c_cor { get; set; }
        public DateTime? cav_d_alteracao { get; set; }
        public string cav_c_usuario { get; set; }
        public DateTime? cav_d_modificacao { get; set; }
        public Guid cav_c_unique { get; set; }
        public DateTime cav_d_atualizado { get; set; }
        public DateTime cav_d_inclusao { get; set; }

        public virtual ICollection<tb_avg_avisoGrupoFamiliar> tb_avg_avisoGrupoFamiliar { get; set; }
        public virtual ICollection<tb_avi_avisoMorador> tb_avi_avisoMorador { get; set; }
        public virtual ICollection<tb_avp_avisoPrestador> tb_avp_avisoPrestador { get; set; }
        public virtual ICollection<tb_avv_avisoVisitante> tb_avv_avisoVisitante { get; set; }
    }
}
