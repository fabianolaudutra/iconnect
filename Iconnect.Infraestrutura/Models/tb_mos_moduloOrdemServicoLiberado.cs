using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_mos_moduloOrdemServicoLiberado
    {
        public tb_mos_moduloOrdemServicoLiberado()
        {
            tb_zec_zeladorCliente = new HashSet<tb_zec_zeladorCliente>();
        }

        public int mos_n_codigo { get; set; }
        public bool mos_b_abirOS { get; set; }
        public bool mos_b_fecharOS { get; set; }
        public bool mos_b_AcompanharOS { get; set; }
        public DateTime? mos_d_modificacao { get; set; }
        public Guid mos_c_unique { get; set; }
        public DateTime mos_d_atualizado { get; set; }
        public DateTime mos_d_inclusao { get; set; }

        public virtual ICollection<tb_zec_zeladorCliente> tb_zec_zeladorCliente { get; set; }
    }
}
