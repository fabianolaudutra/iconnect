using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_plc_pontoLayoutCliente
    {
        public int plc_n_codigo { get; set; }
        public int? plc_cli_n_codigo { get; set; }
        public int? plc_cla_n_codigo { get; set; }
        public Guid plc_c_unique { get; set; }
        public DateTime plc_d_atualizado { get; set; }
        public DateTime plc_d_inclusao { get; set; }

        public virtual tb_cla_cabecalhoLayout plc_cla_n_codigoNavigation { get; set; }
        public virtual tb_cli_cliente plc_cli_n_codigoNavigation { get; set; }
    }
}
