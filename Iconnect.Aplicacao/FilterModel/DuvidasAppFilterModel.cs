using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public  class DuvidasAppFilterModel : Paginacao
    {
        public string dva_n_codigo_filter { get; set; }
        public string dva_cli_n_codigo_filter { get; set; }
        public string dva_c_duvida_filter { get; set; }
        public string dva_c_resposta_filter { get; set; }
        public string dva_c_link_filter { get; set; }
        
    }
}
