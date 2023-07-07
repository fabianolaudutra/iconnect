using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_per_perfil
    {
        public int per_n_codigo { get; set; }
        public string per_c_nome { get; set; }
        public DateTime? per_d_modificacao { get; set; }
        public Guid per_c_unique { get; set; }
        public DateTime per_d_atualizado { get; set; }
        public DateTime per_d_inclusao { get; set; }

        public virtual ICollection<tb_ace_acesso> tb_ace_acesso { get; set; }
    }
}
