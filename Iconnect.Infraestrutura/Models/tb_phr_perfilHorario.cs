using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_phr_perfilHorario
    {
        public tb_phr_perfilHorario()
        {
            tb_gpv_grupoVagas = new HashSet<tb_gpv_grupoVagas>();
        }

        public int phr_n_codigo { get; set; }
        public string phr_c_status { get; set; }
        public string phr_c_nome { get; set; }
        public string phr_c_pontoAcesso { get; set; }
        public int? phr_hor_n_codigo { get; set; }
        public bool? phr_b_visitante { get; set; }
        public int? phr_cli_n_codigo { get; set; }
        public bool? phr_b_antipassback { get; set; }
        public DateTime? phr_d_modificacao { get; set; }
        public bool? phr_b_servico { get; set; }
        public Guid phr_c_unique { get; set; }
        public DateTime phr_d_atualizado { get; set; }
        public DateTime phr_d_inclusao { get; set; }

        public virtual tb_cli_cliente phr_cli_n_codigoNavigation { get; set; }
        public virtual tb_hor_horario phr_hor_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_gpv_grupoVagas> tb_gpv_grupoVagas { get; set; }
        public virtual ICollection<tb_gzk_grupoTabelaHorarioFacialZK> tb_gzk_grupoTabelaHorarioFacialZK { get; set; }
    }
}
