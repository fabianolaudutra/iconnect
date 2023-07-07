using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_lid_liberacaoDelivery
    {
        public tb_lid_liberacaoDelivery()
        {
            tb_cha_chavesDeAcesso = new HashSet<tb_cha_chavesDeAcesso>();
        }

        public int lid_n_codigo { get; set; }
        public string lid_c_descricao { get; set; }
        public string lid_c_token { get; set; }
        public DateTime? lid_d_dataHora { get; set; }
        public bool? lid_b_pendente { get; set; }
        public int lid_mor_n_codigo { get; set; }
        public DateTime? lid_d_modificacao { get; set; }
        public Guid lid_c_unique { get; set; }
        public DateTime lid_d_atualizado { get; set; }
        public DateTime lid_d_inclusao { get; set; }
        public int lid_cac_n_codigo { get; set; }
        public string lid_c_nomeEmpresa { get; set; }

        public virtual tb_mor_Morador lid_mor_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_cha_chavesDeAcesso> tb_cha_chavesDeAcesso { get; set; }
    }
}
