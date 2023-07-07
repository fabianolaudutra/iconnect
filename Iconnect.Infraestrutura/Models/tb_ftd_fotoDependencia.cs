using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_ftd_fotoDependencia
    {
        public tb_ftd_fotoDependencia()
        {
            tb_dpn_dependencias = new HashSet<tb_dpn_dependencias>();
        }

        public int ftd_n_codigo { get; set; }
        public byte[] ftd_c_imagem { get; set; }
        public DateTime? ftd_d_modificacao { get; set; }
        public Guid ftd_c_unique { get; set; }
        public DateTime ftd_d_atualizado { get; set; }
        public DateTime ftd_d_inclusao { get; set; }

        public virtual ICollection<tb_dpn_dependencias> tb_dpn_dependencias { get; set; }
    }
}
