using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class PerfilViewModel
    {
        public int per_n_codigo { get; set; }
        public string per_c_nome { get; set; }
        public DateTime? per_d_modificacao { get; set; }
        public Guid per_c_unique { get; set; }
        public DateTime per_d_atualizado { get; set; }
        public DateTime per_d_inclusao { get; set; }
    }
}
