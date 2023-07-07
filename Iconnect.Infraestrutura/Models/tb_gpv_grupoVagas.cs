using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_gpv_grupoVagas
    {
        public tb_gpv_grupoVagas()
        {
            tb_pse_prestadorServico = new HashSet<tb_pse_prestadorServico>();
            tb_vis_visitante = new HashSet<tb_vis_visitante>();
        }

        public int gpv_n_codigo { get; set; }
        public string gpv_c_descricao { get; set; }
        public int? gpv_n_numeroVagas { get; set; }
        public string gpv_c_perfil { get; set; }
        public int? gpv_cli_n_codigo { get; set; }
        public int? gpv_phr_n_codigo { get; set; }
        public DateTime? gpv_d_alteracao { get; set; }
        public string gpv_c_usuario { get; set; }
        public int? gpv_n_vagasUtilizadas { get; set; }
        public int? gpv_n_vagasRestantes { get; set; }
        public DateTime? gpv_d_modificacao { get; set; }
        public Guid gpv_c_unique { get; set; }
        public DateTime gpv_d_atualizado { get; set; }
        public DateTime gpv_d_inclusao { get; set; }

        public virtual tb_cli_cliente gpv_cli_n_codigoNavigation { get; set; }
        public virtual tb_phr_perfilHorario gpv_phr_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_pse_prestadorServico> tb_pse_prestadorServico { get; set; }
        public virtual ICollection<tb_vis_visitante> tb_vis_visitante { get; set; }
    }
}
