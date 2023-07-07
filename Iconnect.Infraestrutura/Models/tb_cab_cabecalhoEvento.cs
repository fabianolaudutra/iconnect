using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public class tb_cab_cabecalhoEvento
    {
        public int cab_n_codigo { get; set; }
        public string cab_c_nome { get; set; }
        public string cab_c_descricao { get; set; }
        public DateTime cab_d_inclusao { get; set; }

        public virtual ICollection<tb_vis_visitasApp> tb_vis_visitasApp { get; set; }
    }
}
