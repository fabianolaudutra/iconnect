using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_csi_configuracaoSincronizacao
    {
        public int csi_n_codigo { get; set; }
        public string csi_c_tabela { get; set; }
        public string csi_c_prefixo { get; set; }
        public bool? csi_b_sobe { get; set; }
        public bool? csi_b_desce { get; set; }
        public bool? csi_b_ativo { get; set; }
        public int? csi_n_importancia { get; set; }
        public int? csi_n_ordem { get; set; }
        public string csi_c_where { get; set; }
    }
}
