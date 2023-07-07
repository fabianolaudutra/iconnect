using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class AgendaViewModel
    {
        public int age_n_codigo { get; set; }
        public int age_grf_n_codigo { get; set; }
        public int age_vis_n_codigo { get; set; }
        public int? age_cal_n_codigo { get; set; }
        public DateTime? age_d_dataAgendamento { get; set; }
        public string age_c_horarioInicio { get; set; }
        public string age_c_horarioFim { get; set; }
        public string age_c_usuario { get; set; }
        public Guid age_c_unique { get; set; }
        public DateTime? age_d_inclusao { get; set; }
        public string titulo { get; set; }
        public string nomeVisitante { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }
        public string age_mor_n_codigo { get; set; }
        public string rg { get; set; }

        public VisitanteViewModel visitante { get; set; }
        public VisitasAppViewModel visitasApp { get; set; }
    }
}
