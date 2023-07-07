using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class SubCategoriaCatalogoFilterModel : Paginacao
    {
        public int scc_cat_n_codigo_filter { get; set; }
        public int scc_cli_n_codigo_filter { get; set; }
    }
}
