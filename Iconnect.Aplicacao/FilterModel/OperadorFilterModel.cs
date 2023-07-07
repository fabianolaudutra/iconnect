using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class OperadorFilterModel : Paginacao
    {
        public string buscaSimples_filter { get; set; }

        public string status_filter { get; set; }

        public string ope_c_nome_filter { get; set; }
        public string nome_empresa_filter { get; set; }
        public string ope_c_cpf_filter { get; set; }
        public string ope_c_telefone_filter { get; set; }
        public string ope_c_celular_filter { get; set; }
        public string ope_c_email_filter { get; set; }
        public string idEmp { get; set; }
    }
}