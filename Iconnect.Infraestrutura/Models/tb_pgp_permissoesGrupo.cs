using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_pgp_permissoesGrupo
    {
        public int pgp_n_codigo { get; set; }
        public bool? pgp_b_checado { get; set; }
        public int pgp_gpp_n_codigo { get; set; }
        public int? pgp_top_n_codigo { get; set; }
        public DateTime? pgp_d_modificacao { get; set; }
        public Guid pgp_c_unique { get; set; }
        public DateTime pgp_d_atualizado { get; set; }
        public DateTime pgp_d_inclusao { get; set; }

        public virtual tb_gpp_grupoPermissaoOperador pgp_gpp_n_codigoNavigation { get; set; }
        public virtual tb_top_tipoPermissaoOperador pgp_top_n_codigoNavigation { get; set; }
    }
}
