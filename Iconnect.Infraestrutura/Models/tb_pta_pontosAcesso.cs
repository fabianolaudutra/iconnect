using System;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_pta_pontosAcesso
    {
        public int pta_n_codigo { get; set; }
        public int? pta_con_n_codigo { get; set; }
        public bool? pta_b_status { get; set; }
        public bool? pta_b_visitante { get; set; }
        public bool? pta_b_servico { get; set; }
        public string pta_c_nomePonto { get; set; }
        public string pta_c_fluxo { get; set; }
        public int? pta_n_indexPorta { get; set; }
        public DateTime? pta_d_modificacao { get; set; }
        public bool? pta_b_desabilitaVisitante { get; set; }
        public bool? pta_b_desabilitaPrestador { get; set; }
        public int? pta_lay_n_codigo { get; set; }
        public int? pta_cli_n_codigo { get; set; }
        public int? pta_cla_n_codigo { get; set; }
        public Guid pta_c_unique { get; set; }
        public DateTime pta_d_atualizado { get; set; }
        public DateTime pta_d_inclusao { get; set; }
        public bool pta_b_connectProGaren { get; set; }
        public bool pta_b_exibirEventosReleAuxiliar { get; set; }
        public string pta_c_descricaoReleAuxiliar { get; set; }
        public string pta_c_periodoMonitoramentoDe { get; set; }
        public string pta_c_periodoMonitoramentoAte { get; set; }
        public bool pta_b_refeicao { get; set; }

        public virtual tb_cla_cabecalhoLayout pta_cla_n_codigoNavigation { get; set; }
        public virtual tb_cli_cliente pta_cli_n_codigoNavigation { get; set; }
        public virtual tb_con_controladora pta_con_n_codigoNavigation { get; set; }
        public virtual tb_lay_layout pta_lay_n_codigoNavigation { get; set; }
    }
}
