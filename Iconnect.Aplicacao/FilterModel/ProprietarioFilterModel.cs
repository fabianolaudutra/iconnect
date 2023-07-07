using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class ProprietarioFilterModel : Paginacao
    {
        public string pro_c_nome_filter { get; set; }
        public string pro_c_cpf_filter { get; set; }
        public string pro_c_telefone_filter { get; set; }
        public string pro_c_celular_filter { get; set; }
        public string pro_c_email_filter { get; set; }
        public string pro_nomeEstado_filter { get; set; }
        public string pro_nomeCidade_filter { get; set; }
        public string buscaSimples_filter { get; set; }


    }
}
