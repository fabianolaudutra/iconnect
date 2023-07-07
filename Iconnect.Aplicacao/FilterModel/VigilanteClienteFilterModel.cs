using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class VigilanteClienteFilterModel : Paginacao
    {
        public string vic_n_codigo_filter { get; set; }
        public string vic_cli_n_codigo_filter { get; set; }
        public string vic_c_nome_filter { get; set; }
        public string vic_c_celular_filter { get; set; }
    }
}
