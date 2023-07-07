using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
   public class HistoricoLiberacaoViewModel
    {
        public int hil_n_codigo { get; set; }
        public string hil_c_nomeUsuario { get; set; }
        public string hil_d_data { get; set; }
        public int? hil_mor_n_codigo { get; set; }
        public string hil_c_status { get; set; }
        public string hil_c_observacao { get; set; }
        public string hil_d_modificacao { get; set; }
       
        public string hil_d_atualizado { get; set; }
        public string hil_d_inclusao { get; set; }
    }
}
