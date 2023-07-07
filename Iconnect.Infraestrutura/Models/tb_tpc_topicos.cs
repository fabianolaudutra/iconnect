using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public class tb_tpc_topicos
    {
        public int tpc_n_codigo { get; set; }
        public string tpc_c_descricao { get; set; }
        public DateTime? tpc_d_modificacao { get; set; }
        public Guid tpc_c_unique { get; set; }
        public DateTime tpc_d_atualizado { get; set; }
        public DateTime tpc_d_inclusao { get; set; }

        public virtual ICollection<tb_ajd_ajuda> tb_ajd_ajuda { get; set; }
    }
}
