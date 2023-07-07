using System;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_ref_refeicao
    {
        public int ref_n_codigo { get; set; }
        public string ref_c_nomeRefeicao { get; set; }
        public DateTime ref_d_inicio { get; set; }
        public DateTime ref_d_fim { get; set; }
        public decimal ref_d_valor { get; set; }
        public int ref_cli_n_codigo { get; set; }
        public virtual tb_cli_cliente ref_cli_n_codigoNavigation { get; set; }
    }
}
