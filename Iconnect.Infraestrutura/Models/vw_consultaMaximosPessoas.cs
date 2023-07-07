using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class vw_consultaMaximosPessoas
    {
        public int pse_n_codigo { get; set; }
        public string pse_c_nome { get; set; }
        public int? pse_cli_n_codigo { get; set; }
        public bool pse_b_inOut { get; set; }
        public DateTime? pse_d_dataEntrada { get; set; }
        public string PSE_D_HORARIOFIM { get; set; }
    }
}
