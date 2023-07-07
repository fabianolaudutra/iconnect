using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_tcl_tipoCliente
    {
        public tb_tcl_tipoCliente()
        {
            tb_cli_cliente = new HashSet<tb_cli_cliente>();
            tb_eti_entidadeTipo = new HashSet<tb_eti_entidadeTipo>();
        }

        public int tcl_n_codigo { get; set; }
        public string tcl_c_nome { get; set; }
        public bool? tcl_b_ativo { get; set; }
        public Guid tcl_c_unique { get; set; }
        public DateTime tcl_d_atualizado { get; set; }
        public DateTime tcl_d_inclusao { get; set; }

        public virtual ICollection<tb_cli_cliente> tb_cli_cliente { get; set; }
        public virtual ICollection<tb_eti_entidadeTipo> tb_eti_entidadeTipo { get; set; }
    }
}
