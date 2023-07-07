using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_vic_vigilanteCliente
    {
        public int vic_n_codigo { get; set; }
        public int? vic_cli_n_codigo { get; set; }
        public string vic_c_nome { get; set; }
        public string vic_c_celular { get; set; }
        public DateTime? vic_d_modificacao { get; set; }
        public Guid vic_c_unique { get; set; }
        public DateTime vic_d_atualizado { get; set; }
        public DateTime vic_d_inclusao { get; set; }

        public virtual tb_cli_cliente vic_cli_n_codigoNavigation { get; set; }
    }
}
