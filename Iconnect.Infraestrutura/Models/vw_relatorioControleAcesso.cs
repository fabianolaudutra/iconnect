using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class vw_relatorioControleAcesso
    {
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
        public string cin_c_tipoEventoMotivo { get; set; }
        public int? con_usu_n_codigo { get; set; }
        public int? con_fot_n_codigo { get; set; }
        public bool? con_b_inOut { get; set; }
        public bool? con_b_panico { get; set; }
        public int? con_ate_n_codigo { get; set; }
        public bool? con_b_precisaAtendimento { get; set; }
        public int? con_n_h { get; set; }
        public DateTime? con_d_modificacao { get; set; }
        public string GrupoFamiliar { get; set; }
        public int? grf_n_codigo { get; set; }
        public string RG { get; set; }
        public string con_c_status { get; set; }
        public DateTime? con_d_dataTratamentoPanico { get; set; }
        public string con_c_obsTratamentoPanico { get; set; }
        public bool? con_b_tipoPanico { get; set; }
        public string vid_c_link { get; set; }
        public string con_c_destino { get; set; }
        public string perfil { get; set; }
        public int? TIPOCLIENTE { get; set; }
    }
}
