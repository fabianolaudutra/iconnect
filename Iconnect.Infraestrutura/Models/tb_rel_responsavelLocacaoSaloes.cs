using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_rel_responsavelLocacaoSaloes
    {
        public int rel_n_codigo { get; set; }
        public string rel_c_tipo { get; set; }
        public string rel_c_nome { get; set; }
        public string rel_c_sobreNome { get; set; }
        public string rel_c_rg { get; set; }
        public string rel_c_login { get; set; }
        public string rel_c_senha { get; set; }
        public string rel_c_telefone { get; set; }
        public string rel_c_permissao { get; set; }
        public int? rel_usu_n_responsavel { get; set; }
        public int? rel_cli_n_codigo { get; set; }
        public string rel_c_origem { get; set; }
        public Guid rel_c_unique { get; set; }
        public DateTime rel_d_atualizado { get; set; }
        public DateTime rel_d_inclusao { get; set; }
        public string rel_c_email { get; set; }

        public virtual tb_cli_cliente rel_cli_n_codigoNavigation { get; set; }
    }
}
