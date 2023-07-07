using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_gpp_grupoPermissaoOperador
    {
        public tb_gpp_grupoPermissaoOperador()
        {
            tb_opl_operadorLocal = new HashSet<tb_opl_operadorLocal>();
            tb_pgp_permissoesGrupo = new HashSet<tb_pgp_permissoesGrupo>();
        }

        public int gpp_n_codigo { get; set; }
        public string gpp_c_descricao { get; set; }
        public int? gpp_emp_n_codigo { get; set; }
        public DateTime? gpp_d_alteracao { get; set; }
        public string gpp_c_usuario { get; set; }
        public int? gpp_cli_n_codigo { get; set; }
        public DateTime? gpp_d_modificacao { get; set; }
        public Guid gpp_c_unique { get; set; }
        public DateTime gpp_d_atualizado { get; set; }
        public DateTime gpp_d_inclusao { get; set; }
        public int? gpp_mol_n_codigo { get; set; }
        public string gpp_pta_c_codigo { get; set; }

        public virtual tb_cli_cliente gpp_cli_n_codigoNavigation { get; set; }
        public virtual tb_emp_empresa gpp_emp_n_codigoNavigation { get; set; }
        public virtual tb_mol_modulosLiberados gpp_mol_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_opl_operadorLocal> tb_opl_operadorLocal { get; set; }
        public virtual ICollection<tb_pgp_permissoesGrupo> tb_pgp_permissoesGrupo { get; set; }
    }
}
