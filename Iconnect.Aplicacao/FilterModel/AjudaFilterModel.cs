using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class AjudaFilterModel : Paginacao
    {
        public string ajd_n_codigo_filter { get; set; }
        public string ajd_cli_n_codigo_filter { get; set; }
        public string buscaSimples_filter { get; set; }
        public string idsClientes { get; set; }
        public string ajd_tpc_n_codigo_filter { get; set; }
    }
}
