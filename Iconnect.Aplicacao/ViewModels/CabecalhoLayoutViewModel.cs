using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class CabecalhoLayoutViewModel
    {
        public string cla_n_codigo { get; set; }
        public string cla_cli_n_codigo { get; set; }
        public string cla_c_nome { get; set; }
        public string cla_c_exibirem { get; set; }
        public string cla_usu_n_codigo { get; set; }
        public string cla_c_unique { get; set; }
        public string cla_d_atualizado { get; set; }
        public string cla_d_inclusao { get; set; }
        public string lay_ddv_n_codigo { get; set; }
        public string lay_n_codigo { get; set; }
        public string lay_c_nome { get; set; }
        public string can_n_index { get; set; }
        public string cla_id_video { get; set; }
        public LayoutViewModel Layout { get; set; }
        public string porta { get; set; }
    }
}
