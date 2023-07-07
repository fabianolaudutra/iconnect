using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class ControleAcessoFilterModel : Paginacao
    {
        public string cac_mor_n_codigo_filter { get; set; }
        public string cac_vis_n_codigo_filter { get; set; }
        public string cac_pse_n_codigo_filter { get; set; }
    }
}