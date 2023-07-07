using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class OcorrenciasOperadorFilterModel : Paginacao
    {
        public string ocp_n_codigo { get; set; }
        public string ocp_cli_n_codigo { get; set; }
        public string ocp_c_descricao { get; set; }
        public string ocp_c_data { get; set; }
        public string ocp_c_status { get; set; }
        public string ocp_ope_n_cadastrou { get; set; }
        public string ocp_ope_n_modificou { get; set; }
        public string ocp_c_unique { get; set; }
        public string ocp_d_atualizado { get; set; }
        public string ocp_d_inclusao { get; set; }
    }
}
