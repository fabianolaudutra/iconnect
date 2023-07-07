using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class MarcaVeiculoViewModel
    {
        public string mav_n_codigo { get; set; }
        public string mav_c_descricao { get; set; }
        public DateTime? mav_d_modificacao { get; set; }
        public Guid mav_c_unique { get; set; }
        public DateTime mav_d_atualizado { get; set; }
        public DateTime mav_d_inclusao { get; set; }
    }
}
