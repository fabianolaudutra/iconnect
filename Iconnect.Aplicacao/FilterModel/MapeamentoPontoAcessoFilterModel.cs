using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
namespace Iconnect.Aplicacao.FilterModel
{
    public class MapeamentoPontoAcessoFilterModel : Paginacao
    {
        public string mpc_n_codigo_filter { get; set; }
        public string mpc_cli_n_codigo_filter { get; set; }
    }
}
