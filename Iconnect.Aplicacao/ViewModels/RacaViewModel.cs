using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class RacaViewModel
    {
        public int rac_n_codigo { get; set; }
        public string rac_c_nome { get; set; }
        public DateTime? rac_d_alteracao { get; set; }
        public string rac_c_usuario { get; set; }
        public string rac_c_tipo { get; set; }
        public DateTime? rac_d_modificacao { get; set; }
        public Guid rac_c_unique { get; set; }
        public DateTime rac_d_atualizado { get; set; }
        public DateTime rac_d_inclusao { get; set; }
        public string buscaSimples { get; set; }
    }
}
