using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class PermissoesGrupoViewModel
    {
        public string pgp_n_codigo { get; set; }
        public string pgp_b_checado { get; set; }
        public string pgp_gpp_n_codigo { get; set; }
        public string pgp_top_n_codigo { get; set; }
        public string pgp_d_modificacao { get; set; }
        public Guid pgp_c_unique { get; set; }
        public DateTime pgp_d_atualizado { get; set; }
        public DateTime pgp_d_inclusao { get; set; }
    }
}
