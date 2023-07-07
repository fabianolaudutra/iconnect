using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public class tb_vpp_visitanteApp
    {
        public int vpp_n_codigo { get; set; }
        public string vpp_c_email { get; set; }
        public string vpp_c_senha { get; set; }
        public string vpp_c_codigoRecuperacao { get; set; }
        public Guid? vpp_c_visitanteGuid { get; set; }

        public virtual tb_vis_visitante tb_vis_visitante { get; set; }
        public virtual ICollection<tb_dev_device> tb_dev_device { get; set; }
    }
}
