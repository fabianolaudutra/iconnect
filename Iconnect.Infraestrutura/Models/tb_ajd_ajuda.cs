using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public class tb_ajd_ajuda
    {
        public int ajd_n_codigo { get; set; }
        public int ajd_cli_n_codigo { get; set; }
        public int ajd_tpc_n_codigo { get; set; }
        public string ajd_c_duvida { get; set; }
        public string ajd_c_descricao { get; set; }
        public Guid ajd_c_unique { get; set; }
        public DateTime? ajd_d_inclusao { get; set; }
        public DateTime? ajd_d_atualizado { get; set; }
        public string ajd_c_link { get; set; }

        public virtual tb_cli_cliente ajd_cli_n_codigoNavigation { get; set; }
        public virtual tb_tpc_topicos ajd_tpc_n_codigoNavigation { get; set; }
    }
}
