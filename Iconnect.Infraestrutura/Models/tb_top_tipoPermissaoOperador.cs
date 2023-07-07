using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_top_tipoPermissaoOperador
    {
        public tb_top_tipoPermissaoOperador()
        {
            tb_pgp_permissoesGrupo = new HashSet<tb_pgp_permissoesGrupo>();
        }

        public int top_n_codigo { get; set; }
        public string top_c_descricao { get; set; }
        public DateTime? top_d_modificacao { get; set; }
        public Guid top_c_unique { get; set; }
        public DateTime top_d_atualizado { get; set; }
        public DateTime top_d_inclusao { get; set; }
        public string top_c_chave { get; set; }

        public virtual ICollection<tb_pgp_permissoesGrupo> tb_pgp_permissoesGrupo { get; set; }
    }
}
