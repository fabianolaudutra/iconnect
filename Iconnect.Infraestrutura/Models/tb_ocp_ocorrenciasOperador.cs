using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public class tb_ocp_ocorrenciasOperador
    {
        public int ocp_n_codigo { get; set; }
        public int ocp_cli_n_codigo { get; set; }
        public string ocp_c_descricao { get; set; }
        public DateTime ocp_c_data { get; set; }
        public int ocp_ope_n_cadastrou { get; set; }
        public int? ocp_ope_n_modificou { get; set; }
        public Guid ocp_c_unique { get; set; }
        public DateTime ocp_d_atualizado { get; set; }
        public DateTime ocp_d_inclusao { get; set; }
        public string ocp_c_status { get; set; }


        public virtual tb_cli_cliente ocp_cli_n_codigoNavigation { get; set; }
        public virtual tb_ope_operador ocp_ope_n_cadastrouNavigation { get; set; }
        public virtual tb_ope_operador ocp_ope_n_modificouNavigation { get; set; }
    }
}
