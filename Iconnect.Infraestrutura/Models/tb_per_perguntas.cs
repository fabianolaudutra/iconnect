using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_per_perguntas
    {
        public int per_n_codigo { get; set; }
        public int? per_cli_n_codigo { get; set; }
        public string per_c_pergunta { get; set; }
        public string per_c_link { get; set; }
        public string per_c_titulo { get; set; }
        public string per_c_resposta { get; set; }
        public DateTime per_d_data { get; set; }

        public virtual tb_cli_cliente per_cli_n_codigoNavigation { get; set; }
    }

}
