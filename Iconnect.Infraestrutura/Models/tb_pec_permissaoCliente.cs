using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_pec_permissaoCliente
    {
        public int pec_n_codigo { get; set; }
        public int? pec_cli_n_codigo { get; set; }
        public int? pec_ope_n_codigo { get; set; }
        public bool? pec_b_editaInformacoes { get; set; }
        public int? pec_usu_n_codigo { get; set; }
        public DateTime? pec_d_modificacao { get; set; }
        public Guid pec_c_unique { get; set; }
        public DateTime pec_d_atualizado { get; set; }
        public DateTime pec_d_inclusao { get; set; }

        public virtual tb_cli_cliente pec_cli_n_codigoNavigation { get; set; }
        public virtual tb_ope_operador pec_ope_n_codigoNavigation { get; set; }
    }
}
