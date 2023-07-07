using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class AgendaFilterModel : Paginacao
    {
        public string buscaSimples_filter { get; set; }
        public string age_n_codigo_filter { get; set; }
        public string age_c_nome_filter { get; set; }
        public string age_vis_n_codigo_filter { get; set; }
    }
}
