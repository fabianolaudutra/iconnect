using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_pan_panicoApp
    {
        public int pan_n_codigo { get; set; }
        public DateTime? pan_d_dataPanico { get; set; }
        public int pan_mor_n_codigo { get; set; }
        public bool? pan_b_pendente { get; set; }
        public Guid pan_c_unique { get; set; }
        public DateTime pan_d_atualizado { get; set; }
        public DateTime pan_d_inclusao { get; set; }
        public bool pan_b_app_pro { get; set; }        

        public virtual tb_mor_Morador pan_mor_n_codigoNavigation { get; set; }
    }
}
