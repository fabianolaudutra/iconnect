using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_liv_liberacaoVisitante
    {
        public tb_liv_liberacaoVisitante()
        {
            tb_cha_chavesDeAcesso = new HashSet<tb_cha_chavesDeAcesso>();
        }

        public int liv_n_codigo { get; set; }
        public string liv_c_nome { get; set; }
        public string liv_c_celular { get; set; }
        public string liv_c_rg { get; set; }
        public DateTime? liv_d_dataHora { get; set; }
        public bool? liv_b_pendente { get; set; }
        public int? liv_mor_n_codigo { get; set; }
        public int? liv_vis_n_codigo { get; set; }
        public DateTime? liv_d_modificacao { get; set; }
        public Guid liv_c_unique { get; set; }
        public DateTime liv_d_atualizado { get; set; }
        public DateTime liv_d_inclusao { get; set; }
        public bool liv_b_entrou { get; set; }
        public bool liv_b_saiu { get; set; }
        public DateTime? liv_d_dataEntrada { get; set; }
        public DateTime? liv_d_dataSaida { get; set; }
        public int liv_cac_n_codigo { get; set; }
        public int? liv_visitante_n_codigo { get; set; }

        public virtual tb_mor_Morador liv_mor_n_codigoNavigation { get; set; }
        public virtual tb_vis_visitasApp liv_vis_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_cha_chavesDeAcesso> tb_cha_chavesDeAcesso { get; set; }
        public virtual tb_vis_visitante liv_visitante_n_codigoNavigation { get; set; }
    }
}
