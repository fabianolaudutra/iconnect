using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class CatalogoFilterModel : Paginacao
    {
        public int cal_cli_n_codigo_filter { get; set; }
        public int cal_grf_n_codigo_filter { get; set; }
    }
}
