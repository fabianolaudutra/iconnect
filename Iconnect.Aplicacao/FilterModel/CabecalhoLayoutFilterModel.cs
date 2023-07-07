using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class CabecalhoLayoutFilterModel : Paginacao
    {

        public string cla_n_codigo_filter { get; set; }
        public string cla_cli_n_codigo_filter { get; set; }
        public string cla_c_nome_filter { get; set; }
        public string cla_c_exibirem_filter { get; set; }

    }
}
