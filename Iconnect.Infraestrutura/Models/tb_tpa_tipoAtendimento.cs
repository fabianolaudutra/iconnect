using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_tpa_tipoAtendimento
    {
        public tb_tpa_tipoAtendimento()
        {
            tb_ate_atendimento = new HashSet<tb_ate_atendimento>();
        }

        public int tpa_n_codigo { get; set; }
        public string tpa_c_descricao { get; set; }
        public int? tpa_n_prioridade { get; set; }
        public DateTime? tpa_d_modificacao { get; set; }
        public Guid tpa_c_unique { get; set; }
        public DateTime tpa_d_atualizado { get; set; }
        public DateTime tpa_d_inclusao { get; set; }

        public virtual ICollection<tb_ate_atendimento> tb_ate_atendimento { get; set; }
    }
}
