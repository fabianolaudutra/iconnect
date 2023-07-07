using System;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_cde_cadastro_entregas
    {
        public int cde_n_codigo { get; set; }
        public int? cde_fen_n_codigo { get; set; }
        public int? cde_grf_n_codigo { get; set; }
        public DateTime cde_d_dataInclusao { get; set; }
        public string cde_c_descricao { get; set; }
        public string cde_c_codigoRastreio { get; set; }
        public bool? cde_b_entregue { get; set; }
        public DateTime cde_d_dataBaixa { get; set; }
        public string cde_c_recebidoPor { get; set; }
        public string cde_c_obsEntrega { get; set; }

        public virtual tb_fen_foto_entrega cde_fen_n_codigoNavigation { get; set; }
        public virtual tb_grf_grupoFamiliar cde_grf_n_codigoNavigation { get; set; }
    }
}
