using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_eti_entidadeTipo
    {
        public int eti_n_codigo { get; set; }
        public int eti_tlc_n_codigo { get; set; }
        public int eti_ent_n_codigo { get; set; }
        public string eti_c_nome { get; set; }
        public Guid ent_c_unique { get; set; }
        public DateTime ent_d_atualizado { get; set; }
        public DateTime ent_d_inclusao { get; set; }

        public virtual tb_ent_entidade eti_ent_n_codigoNavigation { get; set; }
        public virtual tb_tcl_tipoCliente eti_tlc_n_codigoNavigation { get; set; }
    }
}
