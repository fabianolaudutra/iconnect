using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_cev_categorizacaoEvento
    {
        public tb_cev_categorizacaoEvento()
        {
            Inversecev_cev_n_temporizadorNavigation = new HashSet<tb_cev_categorizacaoEvento>();
            tb_mon_monitoramento = new HashSet<tb_mon_monitoramento>();
        }

        public int cev_n_codigo { get; set; }
        public string cev_c_codigoEvento { get; set; }
        public string cev_c_descricao { get; set; }
        public string cev_c_cor { get; set; }
        public DateTime? cev_d_alteracao { get; set; }
        public string cev_c_usuario { get; set; }
        public bool? cev_b_geraAtendimento { get; set; }
        public DateTime? cev_d_modificacao { get; set; }
        public bool? cev_b_utilizaTemporizador { get; set; }
        public int? cev_cev_n_temporizador { get; set; }
        public Guid cev_c_unique { get; set; }
        public DateTime cev_d_atualizado { get; set; }
        public DateTime cev_d_inclusao { get; set; }

        public virtual tb_cev_categorizacaoEvento cev_cev_n_temporizadorNavigation { get; set; }
        public virtual ICollection<tb_cev_categorizacaoEvento> Inversecev_cev_n_temporizadorNavigation { get; set; }
        public virtual ICollection<tb_mon_monitoramento> tb_mon_monitoramento { get; set; }
    }
}
