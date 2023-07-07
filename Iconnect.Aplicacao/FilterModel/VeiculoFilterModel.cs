using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class VeiculoFilterModel : Paginacao
    {
        public string vec_grf_n_codigo_filter { get; set; }
        public string vec_c_placa { get; set; }
        public string vec_grf_blocoQuadra { get; set; }
        public string vec_grf_loteApto { get; set; }
        public string vec_grf_cli_n_codigo { get; set; }
    }
}