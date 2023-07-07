using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class ZeladorClienteFilterModel : Paginacao
    {
        public string zec_n_codigo_filter { get; set; }
        public string zec_c_nome_filter { get; set; }
        public string zec_c_perfil_filter { get; set; }
        public string zec_c_rg_filter { get; set; }
        public string zec_c_telefone_filter { get; set; }
        public string zec_cli_n_codigo_filter { get; set; }

    }
}
