using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class ResponsavelLocacaoViewModel
    {
        public string rel_n_codigo { get; set; }
        public string rel_c_tipo { get; set; }
        public string rel_c_nome { get; set; }
        public string rel_c_sobreNome { get; set; }
        public string rel_c_rg { get; set; }
        public string rel_c_login { get; set; }
        public string rel_c_senha { get; set; }
        public string rel_c_telefone { get; set; }
        public string rel_c_permissao { get; set; }
        public string rel_usu_n_responsavel { get; set; }
        public string rel_cli_n_codigo { get; set; }
        public string rel_c_origem { get; set; }
        public Guid rel_c_unique { get; set; }
        public DateTime rel_d_atualizado { get; set; }
        public DateTime rel_d_inclusao { get; set; }
        public string rel_c_email { get; set; }
    }
}
