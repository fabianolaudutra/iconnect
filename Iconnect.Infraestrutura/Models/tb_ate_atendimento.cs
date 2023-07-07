using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_ate_atendimento
    {
        public int ate_n_codigo { get; set; }
        public int? ate_cli_n_codigo { get; set; }
        public int? ate_tpa_n_codigo { get; set; }
        public string ate_c_status { get; set; }
        public int? ate_ope_n_preferencial { get; set; }
        public DateTime? ate_d_data { get; set; }
        public string ate_c_descricao { get; set; }
        public DateTime? ate_d_dataFinalizacao { get; set; }
        public DateTime? ate_d_modificacao { get; set; }
        public string ate_c_identificacaoVOIP { get; set; }
        public bool? ate_b_voipAbandonada { get; set; }
        public string ate_c_from { get; set; }
        public string ate_c_ramalAtendeu { get; set; }
        public bool? ate_b_LimparEvento { get; set; }
        public int? ate_pec_n_codigo { get; set; }
        public Guid ate_c_unique { get; set; }
        public DateTime ate_d_atualizado { get; set; }
        public DateTime ate_d_inclusao { get; set; }

        public virtual tb_cli_cliente tb_cli_cliente { get; set; }
        public virtual tb_ope_operador ate_ope_n_preferencialNavigation { get; set; }
        public virtual tb_pec_processoExclusaoCliente ate_pec_n_codigoNavigation { get; set; }
        public virtual tb_tpa_tipoAtendimento ate_tpa_n_codigoNavigation { get; set; }
    }
}
