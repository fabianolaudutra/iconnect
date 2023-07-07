using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_pec_processoExclusaoCliente
    {
        public tb_pec_processoExclusaoCliente()
        {
            tb_ate_atendimento = new HashSet<tb_ate_atendimento>();
            tb_con_monitoramentoControleAcesso = new HashSet<tb_con_monitoramentoControleAcesso>();
            tb_mon_monitoramento = new HashSet<tb_mon_monitoramento>();
        }

        public int pec_n_codigo { get; set; }
        public int? pec_cli_n_codigo { get; set; }
        public DateTime? pec_d_data { get; set; }
        public string pec_c_usuario { get; set; }
        public string pec_c_tipo { get; set; }
        public string pec_c_observacao { get; set; }
        public bool? pec_b_panico { get; set; }
        public Guid pec_c_unique { get; set; }
        public DateTime pec_d_atualizado { get; set; }
        public DateTime pec_d_inclusao { get; set; }

        public virtual ICollection<tb_ate_atendimento> tb_ate_atendimento { get; set; }
        public virtual ICollection<tb_con_monitoramentoControleAcesso> tb_con_monitoramentoControleAcesso { get; set; }
        public virtual ICollection<tb_mon_monitoramento> tb_mon_monitoramento { get; set; }
    }
}
