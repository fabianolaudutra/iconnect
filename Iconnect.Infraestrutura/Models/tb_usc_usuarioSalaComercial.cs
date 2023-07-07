using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_usc_usuarioSalaComercial
    {
        public int usc_n_codigo { get; set; }
        public int? usc_grf_n_codigo { get; set; }
        public int? usc_mor_n_codigo { get; set; }
        public int usc_ace_n_codigo { get; set; }
        public string usc_c_perfil { get; set; }
        public string usc_c_nome { get; set; }
        public string usc_c_cpf { get; set; }
        public string usc_c_usuario { get; set; }
        public Guid usc_c_unique { get; set; }
        public DateTime? usc_d_inclusao { get; set; }

        public virtual tb_grf_grupoFamiliar usc_grf_n_codigoNavigation { get; set; }
        public virtual tb_mor_Morador usc_mor_n_codigoNavigation { get; set; }
        public virtual tb_ace_acesso usc_ace_n_codigoNavigation { get; set; }
    }
}
