using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_fzk_tabelaHorarioFacialZK
    {
        public int fzk_n_codigo { get; set; }
        public int fzk_con_n_codigo { get; set; }
        public int fzk_disp_n_codigo { get; set; }
        public int fzk_hor_n_codigo { get; set; }
        public DateTime? fzk_d_modificacao { get; set; }
        public Guid fzk_c_unique { get; set; }
        public DateTime fzk_d_atualizado { get; set; }
        public DateTime fzk_d_inclusao { get; set; }

        public virtual tb_hor_horario fzk_hor_n_codigoNavigation { get; set; }
        public virtual tb_con_controladora fzk_con_n_codigoNavigation { get; set; }
    }
}
