using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_age_agenteComercial
    {
        public int age_n_codigo { get; set; }
        public string age_c_nome { get; set; }
        public string age_c_rg { get; set; }
        public string age_c_email { get; set; }
        public string age_c_celular { get; set; }
        public int? age_ace_n_codigo { get; set; }

        public virtual tb_ace_acesso age_ace_n_codigoNavigation { get; set; }
    }
}
