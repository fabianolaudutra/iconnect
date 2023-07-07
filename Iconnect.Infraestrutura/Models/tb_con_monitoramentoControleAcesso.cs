using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_con_monitoramentoControleAcesso
    {
        public tb_con_monitoramentoControleAcesso()
        {
            tb_vid_video = new HashSet<tb_vid_video>();
        }

        public int con_n_codigo { get; set; }
        public DateTime? con_d_evento { get; set; }
        public string con_c_pin { get; set; }
        public int? con_cli_n_codigo { get; set; }
        public string con_c_cardNumber { get; set; }
        public string con_c_doorId { get; set; }
        public string con_c_tipoPessoa { get; set; }
        public string con_c_usuario { get; set; }
        public string con_c_pontoAcesso { get; set; }
        public string con_c_acao { get; set; }
        public string con_c_status { get; set; }
        public string cin_c_tipoEventoMotivo { get; set; }
        public int? con_usu_n_codigo { get; set; }
        public int? con_fot_n_codigo { get; set; }
        public bool? con_b_inOut { get; set; }
        public bool? con_b_panico { get; set; }
        public int? con_ate_n_codigo { get; set; }
        public bool? con_b_precisaAtendimento { get; set; }
        public int? con_n_h { get; set; }
        public DateTime? con_d_modificacao { get; set; }
        public bool? con_b_LimparEvento { get; set; }
        public bool? con_b_panicoTratado { get; set; }
        public DateTime? con_d_dataTratamentoPanico { get; set; }
        public string con_c_obsTratamentoPanico { get; set; }
        public string con_c_UsuarioTratamentoPanico { get; set; }
        public bool? con_b_tipoPanico { get; set; }
        public int? con_pec_n_codigo { get; set; }
        public bool? con_b_pendenteVideo { get; set; }
        public string con_c_destino { get; set; }
        public Guid con_c_unique { get; set; }
        public DateTime con_d_atualizado { get; set; }
        public DateTime con_d_inclusao { get; set; }
        public string con_c_tipoAcesso { get; set; }
        public string? con_ref_c_nomeRefeicao { get; set; }
        public decimal? con_ref_d_valor { get; set; }

        public virtual tb_cli_cliente con_cli_n_codigoNavigation { get; set; }
        public virtual tb_pec_processoExclusaoCliente con_pec_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_vid_video> tb_vid_video { get; set; }
    }
}
