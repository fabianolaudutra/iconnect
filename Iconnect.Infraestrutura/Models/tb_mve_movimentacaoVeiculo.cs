using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_mve_movimentacaoVeiculo
    {
        public int mve_n_codigo { get; set; }
        public int mve_fro_n_codigo { get; set; }
        public int mve_mor_n_codigo { get; set; }
        public string mve_c_fluxo { get; set; }
        public int mve_n_quilometragem { get; set; }
        public DateTime mve_d_dataRegistro { get; set; }
        public string mve_c_usuarioLogado { get; set; }
        public bool mve_b_registroAutomatico { get; set; }
        public DateTime? mve_d_modificacao { get; set; }
        public Guid mve_c_unique { get; set; }
        public DateTime mve_d_atualizado { get; set; }
        public DateTime mve_d_inclusao { get; set; }

        public virtual tb_fro_frota mve_fro_n_codigoNavigation { get; set; }
        public virtual tb_mor_Morador mve_mor_n_codigoNavigation { get; set; }
    }
}
