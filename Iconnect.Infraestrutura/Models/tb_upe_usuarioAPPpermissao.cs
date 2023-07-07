using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_upe_usuarioAPPpermissao
    {
        public int upe_n_codigo { get; set; }
        public int? upe_per_n_codigo { get; set; }
        public int? upe_mor_n_codigo { get; set; }
        public bool? upe_b_acessa { get; set; }

        public virtual tb_mor_Morador upe_mor_n_codigoNavigation { get; set; }
        public virtual tb_per_permissoes upe_per_n_codigoNavigation { get; set; }
    }
}
