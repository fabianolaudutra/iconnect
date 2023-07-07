using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_ral_ramalLayout
    {
        public int ral_n_codigo { get; set; }
        public string ral_c_ramal { get; set; }
        public int? ral_lay_n_codigo { get; set; }
        public DateTime? ral_d_modificacao { get; set; }
        public int? ral_cla_n_codigo { get; set; }
        public Guid ral_c_unique { get; set; }
        public DateTime ral_d_atualizado { get; set; }
        public DateTime ral_d_inclusao { get; set; }

        public virtual tb_cla_cabecalhoLayout ral_cla_n_codigoNavigation { get; set; }
        public virtual tb_lay_layout ral_lay_n_codigoNavigation { get; set; }
    }
}
