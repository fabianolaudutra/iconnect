using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class OperadorLocalViewModel
    {
        public string Cliente { get; set; }
        public string Descricao { get; set; }
        public int opl_n_codigo { get; set; }
        public string opl_c_nome { get; set; }
        public string opl_cli_n_codigo { get; set; }
        public string opl_gpp_n_codigo { get; set; }
        public string opl_c_login { get; set; }
        public string opl_c_senha { get; set; }
        public DateTime? opl_d_modificacao { get; set; }
        public Guid opl_c_unique { get; set; }
        public DateTime opl_d_atualizado { get; set; }
        public DateTime opl_d_inclusao { get; set; }
        public DateTime? opl_d_ultimoContato { get; set; }
        public string buscaSimples { get; set; }
        public string opl_c_rg { get; set; }
        public string opl_c_cpf { get; set; }
        public string opl_c_telefone { get; set; }
        public string opl_c_email { get; set; }
    }
}
