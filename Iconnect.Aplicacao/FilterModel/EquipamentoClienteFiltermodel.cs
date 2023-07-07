using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class EquipamentoClienteFiltermodel : Paginacao
    {
        public string eqc_n_codigo_filter { get; set; }
        public string eqc_c_nomePonto { get; set; }
        public string eqc_n_modelo { get; set; }
        public string eqc_b_apontamentoLocal { get; set; }
        public string eqc_c_conta { get; set; }
        public string eqc_c_ip { get; set; }
        public string eqc_c_porta { get; set; }
        public string eqc_c_senhaRemota { get; set; }
        public string eqc_cli_n_codigo_filter { get; set; }
    }
}
