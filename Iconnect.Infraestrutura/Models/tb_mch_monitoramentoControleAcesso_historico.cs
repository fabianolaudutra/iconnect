using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_mch_monitoramentoControleAcesso_historico
    {
        public int mch_n_codigo { get; set; }
        public int mch_con_n_codigo { get; set; }
        public DateTime mch_d_evento { get; set; }
        public string mch_c_pin { get; set; }
        public int mch_cli_n_codigo { get; set; }
        public string mch_c_cardNumber { get; set; }
        public string mch_c_doorId { get; set; }
        public string mch_c_tipoPessoa { get; set; }
        public string mch_c_usuario { get; set; }
        public string mch_c_pontoAcesso { get; set; }
        public string mch_c_acao { get; set; }
        public string mch_c_status { get; set; }
        public string mch_c_tipoEventoMotivo { get; set; }
        public int mch_usu_n_codigo { get; set; }
        public int mch_fot_n_codigo { get; set; }
        public bool mch_b_inOut { get; set; }
        public bool mch_b_panico { get; set; }
        public int mch_ate_n_codigo { get; set; }
        public bool mch_b_precisaAtendimento { get; set; }
        public int mch_n_h { get; set; }
        public DateTime mch_d_modificacao { get; set; }
        public bool mch_b_LimparEvento { get; set; }
        public bool mch_b_panicoTratado { get; set; }
        public DateTime mch_d_dataTratamentoPanico { get; set; }
        public string mch_c_obsTratamentoPanico { get; set; }
        public string mch_c_UsuarioTratamentoPanico { get; set; }
        public bool mch_b_tipoPanico { get; set; }
        public int mch_pec_n_codigo { get; set; }
        public bool mch_b_pendenteVideo { get; set; }
        public string mch_c_destino { get; set; }
        public Guid mch_c_unique { get; set; }
        public DateTime mch_d_atualizado { get; set; }
        public DateTime mch_d_inclusao { get; set; }
    }
}
