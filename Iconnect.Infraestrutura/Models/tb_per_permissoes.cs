using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_per_permissoes
    {
        public tb_per_permissoes()
        {
            tb_upe_usuarioAPPpermissao = new HashSet<tb_upe_usuarioAPPpermissao>();
        }

        public int per_n_codigo { get; set; }
        public string per_c_descricao { get; set; }

        public virtual ICollection<tb_upe_usuarioAPPpermissao> tb_upe_usuarioAPPpermissao { get; set; }
    }
}
