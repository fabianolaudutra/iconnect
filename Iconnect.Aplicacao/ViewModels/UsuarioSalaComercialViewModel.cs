using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class UsuarioSalaComercialViewModel
    {
        public string usc_n_codigo { get; set; }
        public string usc_grf_n_codigo { get; set; }
        public string usc_mor_n_codigo { get; set; }
        public string usc_ace_n_codigo { get; set; }
        public string usc_c_perfil { get; set; }
        public string usc_c_nome { get; set; }
        public string usc_c_cpf { get; set; }
        public string usc_c_usuario { get; set; }
        public Guid usc_c_unique { get; set; }
        public DateTime? usc_d_inclusao { get; set; }

        public AcessoViewModel Acesso { get; set; }
    }
}
