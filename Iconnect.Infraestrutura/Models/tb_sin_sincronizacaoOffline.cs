using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_sin_sincronizacaoOffline
    {
        public int sin_n_codigo { get; set; }
        public DateTime sin_d_data { get; set; }
        public bool? sin_b_concluida { get; set; }
        public int? SIN_CLI_N_CODIGO { get; set; }
        public bool sin_b_sincronizacaoRestauracao { get; set; }
    }
}
