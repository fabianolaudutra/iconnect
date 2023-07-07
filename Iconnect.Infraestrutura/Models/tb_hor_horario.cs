using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_hor_horario
    {
        public tb_hor_horario()
        {
            tb_phr_perfilHorario = new HashSet<tb_phr_perfilHorario>();
        }

        public int hor_n_codigo { get; set; }
        public string hor_c_nome { get; set; }
        public string hor_d_termina { get; set; }
        public string hor_c_diaSemana { get; set; }
        public string hor_d_inicia { get; set; }
        public int? hor_cli_n_codigo { get; set; }
        public bool? hor_b_referenciaApp { get; set; }
        public DateTime? hor_d_modificacao { get; set; }
        public int? hor_n_codigoLinear { get; set; }
        public Guid hor_c_unique { get; set; }
        public DateTime hor_d_atualizado { get; set; }
        public DateTime hor_d_inclusao { get; set; }

        public virtual tb_cli_cliente hor_cli_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_phr_perfilHorario> tb_phr_perfilHorario { get; set; }
        public virtual ICollection<tb_fzk_tabelaHorarioFacialZK> tb_fzk_tabelaHorarioFacialZK { get; set; }
    }
}
