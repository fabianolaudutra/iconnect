using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_fac_face
    {
        public int fac_n_codigo { get; set; }
        public string fac_c_status { get; set; }
        public int fac_cli_n_codigo { get; set; }
        public string fac_c_template { get; set; }
        public byte[]? fac_c_imagem { get; set; }
        public DateTime fac_d_dataSolicitacao { get; set; }
        public Guid fac_c_unique { get; set; }
        public DateTime fac_d_atualizado { get; set; }
        public DateTime fac_d_inclusao { get; set; }
        public int fac_n_tamanho { get; set; }
        public int fac_usu_n_codigo { get; set; }

        public virtual tb_cli_cliente fac_cli_n_codigoNavigation { get; set; }
    }
}
