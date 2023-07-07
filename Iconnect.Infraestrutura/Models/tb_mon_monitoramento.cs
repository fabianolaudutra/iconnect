using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_mon_monitoramento
    {
        public int mon_n_codigo { get; set; }
        public int? mon_cli_n_codigo { get; set; }
        public int? mon_eve_n_codigo { get; set; }
        public int? mon_cev_n_codigo { get; set; }
        public DateTime? mon_d_dataInsercao { get; set; }
        public DateTime? mon_d_dataEdicao { get; set; }
        public int? mon_stm_n_codigo { get; set; }
        public int? mon_zoc_n_codigo { get; set; }
        public string mon_c_observacao { get; set; }
        public int? mon_n_responsavel { get; set; }
        public DateTime? mon_d_dataEvento { get; set; }
        public string mon_c_motivo { get; set; }
        public int? mon_ate_n_codigo { get; set; }
        public bool? mon_b_precisaAtendimento { get; set; }
        public string mon_c_motivoConclusao { get; set; }
        public int? mon_n_responsavelConclusao { get; set; }
        public string mon_c_observacaoConclusao { get; set; }
        public DateTime? mon_d_dataEventoConclusao { get; set; }
        public DateTime? mon_d_modificacao { get; set; }
        public DateTime? mon_d_dataExibicao { get; set; }
        public bool? mon_b_exibido { get; set; }
        public bool? mon_b_limpaEvento { get; set; }
        public int? mon_pec_n_codigo { get; set; }
        public Guid mon_c_unique { get; set; }
        public DateTime mon_d_atualizado { get; set; }
        public DateTime mon_d_inclusao { get; set; }

        public string mon_c_pessoa { get; set; }
        public string mon_c_tipoPessoa { get; set; }
        public int mon_n_codigoPessoa { get; set; }
        public string mon_c_pessoaConclusao { get; set; }
        public string mon_c_tipoPessoaConclusao { get; set; }
        public int mon_n_codigoPessoaConclusao { get; set; }

        public virtual tb_cev_categorizacaoEvento mon_cev_n_codigoNavigation { get; set; }
        public virtual tb_cli_cliente mon_cli_n_codigoNavigation { get; set; }
        public virtual tb_eve_evento mon_eve_n_codigoNavigation { get; set; }
        public virtual tb_pec_processoExclusaoCliente mon_pec_n_codigoNavigation { get; set; }
        public virtual tb_stm_statusMonitoramento mon_stm_n_codigoNavigation { get; set; }
        public virtual tb_zoc_zoneamentoCliente mon_zoc_n_codigoNavigation { get; set; }
    }
}
