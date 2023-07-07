using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_vid_video
    {
        public int vid_n_codigo { get; set; }
        public int? vid_con_n_codigo { get; set; }
        public string vid_c_link { get; set; }
        public string vid_c_status { get; set; }

        public virtual tb_con_monitoramentoControleAcesso vid_con_n_codigoNavigation { get; set; }
    }
}
