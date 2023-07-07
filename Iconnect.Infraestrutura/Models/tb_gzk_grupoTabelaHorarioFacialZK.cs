using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_gzk_grupoTabelaHorarioFacialZK
    {
        public int gzk_n_codigo { get; set; }
        public int gzk_phr_n_codigo { get; set; }
        public int gzk_grupo_n_codigo { get; set; }
        public int gzk_con_n_codigo { get; set; }
        public DateTime? gzk_d_modificacao { get; set; }
        public Guid gzk_c_unique { get; set; }
        public DateTime gzk_d_atualizado { get; set; }
        public DateTime gzk_d_inclusao { get; set; }

        public virtual tb_phr_perfilHorario gzk_phr_n_codigoNavigation { get; set; }
        public virtual tb_con_controladora gzk_con_n_codigoNavigation { get; set; }
    }
}
