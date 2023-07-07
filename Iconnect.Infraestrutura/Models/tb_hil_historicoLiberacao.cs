using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_hil_historicoLiberacao
    {
        public int hil_n_codigo { get; set; }
        public string hil_c_nomeUsuario { get; set; }
        public DateTime? hil_d_data { get; set; }
        public int? hil_mor_n_codigo { get; set; }
        public string hil_c_status { get; set; }
        public string hil_c_observacao { get; set; }
        public DateTime? hil_d_modificacao { get; set; }
        public Guid hil_c_unique { get; set; }
        public DateTime hil_d_atualizado { get; set; }
        public DateTime hil_d_inclusao { get; set; }

        public virtual tb_mor_Morador hil_mor_n_codigoNavigation { get; set; }
    }
}
