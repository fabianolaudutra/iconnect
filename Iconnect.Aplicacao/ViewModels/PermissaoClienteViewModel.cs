using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class PermissaoClienteViewModel
    {
        public string pec_n_codigo { get; set; }
        public string pec_cli_n_codigo { get; set; }
        public string pec_ope_n_codigo { get; set; }
        public string pec_b_editaInformacoes { get; set; }
        public string pec_usu_n_codigo { get; set; }
        public string pec_d_modificacao { get; set; }
        public string pec_c_unique { get; set; }
        public string pec_d_atualizado { get; set; }
        public string pec_d_inclusao { get; set; }
        public string cli_c_nomeFantasia { get; set; }
        public string emp_c_nomeFantasia { get; set; }
        public List<string> lstCliente { get; set; }
    }
}