using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_vis_visitasApp
    {
        public tb_vis_visitasApp()
        {
            tb_liv_liberacaoVisitante = new HashSet<tb_liv_liberacaoVisitante>();
        }

        public int vis_n_codigo { get; set; }
        public string vis_c_descricao { get; set; }
        public int? vis_n_quantidade { get; set; }
        public int? vis_n_duracao { get; set; }
        public DateTime? vis_d_dataHora { get; set; }
        public int? vis_mor_n_codigo { get; set; }
        public DateTime? vis_d_modificacao { get; set; }
        public int? vis_n_duracaoAntes { get; set; }
        public Guid vis_c_unique { get; set; }
        public DateTime vis_d_atualizado { get; set; }
        public DateTime vis_d_inclusao { get; set; }
        public int? vis_age_n_codigo { get; set; }
        public int? vis_cev_n_codigo { get; set; }

        public virtual tb_mor_Morador vis_mor_n_codigoNavigation { get; set; }
        public virtual tb_age_agenda vis_age_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_liv_liberacaoVisitante> tb_liv_liberacaoVisitante { get; set; }
        public virtual tb_cab_cabecalhoEvento vis_cab_n_codigoNavigation { get; set; }
    }
}
