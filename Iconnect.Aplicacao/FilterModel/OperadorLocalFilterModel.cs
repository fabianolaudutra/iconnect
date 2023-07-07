using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
   public class OperadorLocalFilterModel : Paginacao
    {
        public string opl_c_nome_filter { get; set; }
        public string cliente_filter { get; set; }
        public string descricao_filter { get; set; }
        public string buscaSimples_filter { get; set; }
        public string idEmp { get; set; }
        public string opl_c_rg_filter { get; set; }
        public string opl_c_cpf_filter { get; set; }
        public string opl_c_telefone_filter { get; set; }
        public string opl_c_email_filter { get; set; }
        public string opl_cli_n_codigo { get; set; }
    }
}
