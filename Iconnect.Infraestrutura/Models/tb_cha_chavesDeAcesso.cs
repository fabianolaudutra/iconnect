using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_cha_chavesDeAcesso
    {
        public int cha_n_codigo { get; set; }
        public string cha_c_chave { get; set; }
        public int? cha_liv_n_codigo { get; set; }
        public int? cha_lid_n_codigo { get; set; }
        public int? cha_lip_n_codigo { get; set; }
        public DateTime? cha_d_modificacao { get; set; }
        public Guid cha_c_unique { get; set; }
        public DateTime cha_d_atualizado { get; set; }
        public DateTime cha_d_inclusao { get; set; }

        public virtual tb_lid_liberacaoDelivery cha_lid_n_codigoNavigation { get; set; }
        public virtual tb_lip_liberacaoPrestador cha_lip_n_codigoNavigation { get; set; }
        public virtual tb_liv_liberacaoVisitante cha_liv_n_codigoNavigation { get; set; }
    }
}
