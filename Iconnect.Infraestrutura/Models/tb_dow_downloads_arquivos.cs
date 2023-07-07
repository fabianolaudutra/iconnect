using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_dow_downloads_arquivos
    {
        public int dow_n_codigo { get; set; }
        public string dow_c_descricao { get; set; }
        public DateTime dow_d_data { get; set; }
        public byte[] dow_c_arquivo { get; set; }
        public int dow_cli_n_codigo { get; set; }
        public string dow_c_titulo { get; set; }

        public virtual tb_cli_cliente dow_cli_n_codigoNavigation { get; set; }
    }
}