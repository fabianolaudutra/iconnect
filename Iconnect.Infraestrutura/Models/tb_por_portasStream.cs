using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_por_portasStream
    {
        public int por_n_codigo { get; set; }
        public int? por_n_porta { get; set; }
        public int? por_cli_n_codigo { get; set; }
        public int? pro_n_process { get; set; }
        public Guid por_c_unique { get; set; }
        public DateTime por_d_atualizado { get; set; }
        public DateTime por_d_inclusao { get; set; }

        public virtual tb_cli_cliente por_cli_n_codigoNavigation { get; set; }
    }
}
