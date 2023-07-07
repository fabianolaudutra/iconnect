using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class CategorizacaoAvisoViewModel
    {
        public int cav_n_codigo { get; set; }
        public string cav_c_descricao { get; set; }
        public string cav_c_cor { get; set; }
        public DateTime? cav_d_alteracao { get; set; }
        public string cav_c_usuario { get; set; }
        public DateTime? cav_d_modificacao { get; set; }
        public Guid cav_c_unique { get; set; }
        public DateTime cav_d_atualizado { get; set; }
        public DateTime cav_d_inclusao { get; set; }
    }
}
