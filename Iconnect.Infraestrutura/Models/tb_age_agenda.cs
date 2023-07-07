using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_age_agenda
    {
        public int age_n_codigo { get; set; }
        public int age_grf_n_codigo { get; set; }
        public int age_vis_n_codigo { get; set; }
        public int? age_cal_n_codigo { get; set; }
        public DateTime? age_d_dataAgendamento { get; set; }
        public string age_c_horarioInicio { get; set; }
        public string age_c_horarioFim { get; set; }
        public string age_c_usuario { get; set; }
        public Guid age_c_unique { get; set; }
        public DateTime? age_d_inclusao { get; set; }
        public int? age_mor_n_codigo { get; set; }

        public virtual tb_grf_grupoFamiliar age_grf_n_codigoNavigation { get; set; }
        public virtual tb_vis_visitante age_vis_n_codigoNavigation { get; set; }
        public virtual tb_cal_catalogo age_cal_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_vis_visitasApp> tb_vis_visitasApp { get; set; }
        public virtual ICollection<tb_aco_acompanhante> tb_aco_acompanhante { get; set; }
        public virtual tb_mor_Morador age_mor_n_codigoNavigation { get; set; }

    }
}
