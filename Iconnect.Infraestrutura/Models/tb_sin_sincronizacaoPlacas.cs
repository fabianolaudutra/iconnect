using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_sin_sincronizacaoPlacas
    {
        public int sin_n_codigo { get; set; }
        public int? sin_cli_n_codigo { get; set; }
        public string sin_c_status { get; set; }
        public DateTime? sin_d_dataSolicitacao { get; set; }
        public DateTime? sin_d_dataInicio { get; set; }
        public DateTime? sin_d_dataFim { get; set; }
        public DateTime? sin_d_modificacao { get; set; }
        public string sin_c_erro { get; set; }
        public bool? sin_b_interno { get; set; }
        public int? sin_ace_n_codigo { get; set; }
        public string sin_c_controladoras { get; set; }
        public Guid sin_c_unique { get; set; }
        public DateTime sin_d_atualizado { get; set; }
        public DateTime sin_d_inclusao { get; set; }

        public virtual tb_cli_cliente sin_cli_n_codigoNavigation { get; set; }
    }
}
