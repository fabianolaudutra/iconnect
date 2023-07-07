using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
   public class ChavesDeAcessoViewModel
    {
        public int cha_n_codigo { get; set; }
        public string cha_c_chave { get; set; }
        public int? cha_liv_n_codigo { get; set; }
        public int? cha_lid_n_codigo { get; set; }
        public int? cha_lip_n_codigo { get; set; }
        public DateTime? cha_d_modificacao { get; set; }
        public Guid cha_c_unique { get; set; }
        public DateTime cha_d_atualizado { get; set; }
        public DateTime cha_d_inclusao { get; set; }
    }
}
