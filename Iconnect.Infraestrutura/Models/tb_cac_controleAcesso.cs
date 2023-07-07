using System;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_cac_controleAcesso
    {
        public int cac_n_codigo { get; set; }
        public string cac_c_descricao { get; set; }
        public string cac_c_numeroCartao { get; set; }
        public bool? cac_b_ativo { get; set; }
        public bool? cac_b_panico { get; set; }
        public string cac_c_tipo { get; set; }
        public string cac_c_tipoAcesso { get; set; }
        public string cac_c_senha { get; set; }
        public string cac_c_numeroChave { get; set; }
        public int? cac_usu_n_codigo { get; set; }
        public DateTime? cac_d_modificacao { get; set; }
        public Guid cac_c_unique { get; set; }
        public DateTime cac_d_atualizado { get; set; }
        public DateTime cac_d_inclusao { get; set; }
        public string cac_c_biometria { get; set; }

        public virtual tb_mor_Morador cac_mor_n_codigoNavigation { get; set; }
        public int? cac_mor_n_codigo { get; set; }

        public virtual tb_pse_prestadorServico cac_pse_n_codigoNavigation { get; set; }
        public int? cac_pse_n_codigo { get; set; }

        public virtual tb_vis_visitante cac_vis_n_codigoNavigation { get; set; }
        public int? cac_vis_n_codigo { get; set; }
    }
}
