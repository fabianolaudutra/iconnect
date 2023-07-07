using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_cae_controleAcessoExcluido
    {
        public int cae_n_codigo { get; set; }
        public int cae_cac_n_codigo { get; set; }
        public int? cae_mor_n_codigo { get; set; }
        public string cae_c_descricao { get; set; }
        public string cae_c_numeroCartao { get; set; }
        public bool? cae_b_ativo { get; set; }
        public bool? cae_b_panico { get; set; }
        public string cae_c_tipo { get; set; }
        public string cae_c_tipoAcesso { get; set; }
        public string cae_c_senha { get; set; }
        public int? cae_vis_n_codigo { get; set; }
        public int? cae_pse_n_codigo { get; set; }
        public string cae_c_numeroChave { get; set; }
        public int? cae_usu_n_codigo { get; set; }
        public DateTime? cae_d_modificacao { get; set; }
        public bool cae_b_sincronizado { get; set; }
        public Guid cae_c_unique { get; set; }
        public DateTime cae_d_atualizado { get; set; }
        public DateTime cae_d_inclusao { get; set; }
        public int? cae_con_n_codigo { get; set; }

        public virtual tb_con_controladora cae_con_n_codigoNavigation { get; set; }
    }
}
