using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_lcc_localidadeCliente
    {
        public tb_lcc_localidadeCliente()
        {
            tb_lcg_localidadeClienteGrupoFamiliar = new HashSet<tb_lcg_localidadeClienteGrupoFamiliar>();
            tb_lcg_localidadeClienteGrupoFamiliarLoteApto = new HashSet<tb_lcg_localidadeClienteGrupoFamiliar>();
            tb_lca_localidadeCatalogo = new HashSet<tb_lca_localidadeCatalogo>();
        }

        public int lcc_n_codigo { get; set; }
        public string lcc_c_tipoLocalidade { get; set; }
        public string lcc_c_descricao { get; set; }
        public int? lcc_cli_n_codigo { get; set; }
        public DateTime? lcc_d_modificacao { get; set; }
        public int? lcc_usu_n_codigo { get; set; }
        public Guid lcc_c_unique { get; set; }
        public DateTime lcc_d_atualizado { get; set; }
        public DateTime lcc_d_inclusao { get; set; }
        public string lcc_c_tipoLayout { get; set; }

        public virtual tb_cli_cliente lcc_cli_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_lcg_localidadeClienteGrupoFamiliar> tb_lcg_localidadeClienteGrupoFamiliar { get; set; }
        public virtual ICollection<tb_lcg_localidadeClienteGrupoFamiliar> tb_lcg_localidadeClienteGrupoFamiliarLoteApto { get; set; }
        public virtual ICollection<tb_lca_localidadeCatalogo> tb_lca_localidadeCatalogo { get; set; }

    }
}
