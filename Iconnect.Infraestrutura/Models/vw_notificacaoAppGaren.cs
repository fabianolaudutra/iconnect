using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class vw_notificacaoAppGaren
    {
        public int eno_n_codigo { get; set; }
        public int? eno_cli_n_codigo { get; set; }
        public string eno_c_titulo { get; set; }
        public string eno_c_mensagem { get; set; }
        public string cli_c_nomeFantasia { get; set; }
        public int cli_n_codigo { get; set; }
        public bool? emp_b_tipoGaren { get; set; }
        public string eno_c_GruposFamiliares { get; set; }
        public DateTime? eno_d_inicio { get; set; }
        public DateTime? eno_d_fim { get; set; }
        public string status { get; set; }
    }
}
