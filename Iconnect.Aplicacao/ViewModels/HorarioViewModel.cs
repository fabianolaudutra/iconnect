using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class HorarioViewModel
    {
        public string hor_n_codigo { get; set; }
        public string hor_c_nome { get; set; }
        public string hor_d_termina { get; set; }
        public string hor_c_diaSemana { get; set; }
        public string hor_d_inicia { get; set; }
        public string hor_cli_n_codigo { get; set; }
        public string hor_b_referenciaApp { get; set; }
        public string hor_d_modificacao { get; set; }
        public string hor_n_codigoLinear { get; set; }
        public string hor_c_unique { get; set; }
        public string hor_d_atualizado { get; set; }
        public string hor_d_inclusao { get; set; }
    }
}
