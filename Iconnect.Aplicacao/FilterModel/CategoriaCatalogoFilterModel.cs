using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class CategoriaCatalogoFilterModel : Paginacao
    {
        public int cat_cli_n_codigo_filter { get; set; }
        public int cat_grf_n_codigo_filter { get; set; }
    }
}
