using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class VisitasAppViewModel
    {
        public int vis_n_codigo { get; set; }
        public string vis_c_descricao { get; set; }
        public int? vis_n_quantidade { get; set; }
        public int? vis_n_duracao { get; set; }
        public DateTime? vis_d_dataHora { get; set; }
        public int? vis_mor_n_codigo { get; set; }
        public DateTime? vis_d_modificacao { get; set; }
        public int? vis_n_duracaoAntes { get; set; }
        public Guid vis_c_unique { get; set; }
        public DateTime vis_d_atualizado { get; set; }
        public DateTime vis_d_inclusao { get; set; }
        public int? vis_age_n_codigo { get; set; }
        public string vis_c_hora { get; set; }
    }
}
