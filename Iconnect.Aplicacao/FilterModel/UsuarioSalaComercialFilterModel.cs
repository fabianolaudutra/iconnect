using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;


namespace Iconnect.Aplicacao.FilterModel
{
    public class UsuarioSalaComercialFilterModel : Paginacao
    {
        public string usc_n_codigo_filter { get; set; }
        public string usc_c_nome_filter { get; set; }
        public string usc_c_perfil_filter { get; set; }
        public string usc_grf_n_codigo_filter { get; set; }
    }
}
