using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class PgcFiltermodel : Paginacao
    {
        public string pgc_pgmDescricao_filter { get; set; }
        public string pgc_centralDescricao_filter { get; set; }
        public string pgc_c_nome_filter { get; set; }
        public string pgc_cli_n_codigo_filter { get; set; }

    }
}
