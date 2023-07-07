using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_avi_avisoMorador
    {
        public int avm_n_codigo { get; set; }
        public int? avm_cav_n_codigo { get; set; }
        public bool? avm_b_lidoNaoLido { get; set; }
        public int? avm_mor_n_codigo { get; set; }
        public string avm_c_descricao { get; set; }
        public int? avm_ace_n_codigo { get; set; }
        public DateTime? avm_d_modificacao { get; set; }
        public Guid avm_c_unique { get; set; }
        public DateTime avm_d_atualizado { get; set; }
        public DateTime avm_d_inclusao { get; set; }
        public Guid avi_c_unique { get; set; }
        public DateTime avi_d_atualizado { get; set; }
        public DateTime avi_d_inclusao { get; set; }

        public virtual tb_ace_acesso avm_ace_n_codigoNavigation { get; set; }
        public virtual tb_cav_categorizacaoAviso avm_cav_n_codigoNavigation { get; set; }
        public virtual tb_mor_Morador avm_mor_n_codigoNavigation { get; set; }
    }
}
