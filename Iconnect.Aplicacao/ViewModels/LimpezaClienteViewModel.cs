using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
   public class LimpezaClienteViewModel
    {
        public int pec_n_codigo { get; set; }
        public string pec_cli_n_codigo { get; set; }
        public string  pec_d_data { get; set; }
        public string pec_c_usuario { get; set; }
        public string pec_c_tipo { get; set; }
        public string pec_c_observacao { get; set; }
        public string  pec_b_panico { get; set; }
        public Guid pec_c_unique { get; set; }
        public DateTime pec_d_atualizado { get; set; }
        public DateTime pec_d_inclusao { get; set; }
        public string cli_c_nomeFantasia { get; set; }
        public string nomeEmpresa { get; set; }
    }
}
