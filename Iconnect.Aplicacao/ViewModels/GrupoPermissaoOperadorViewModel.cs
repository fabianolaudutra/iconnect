using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class GrupoPermissaoOperadorViewModel
    {
        public string gpp_n_codigo { get; set; }
        public string gpp_c_descricao { get; set; }
        public string gpp_emp_n_codigo { get; set; }
        public string gpp_d_alteracao { get; set; }
        public string gpp_c_usuario { get; set; }
        public string gpp_cli_n_codigo { get; set; }
        public string gpp_d_modificacao { get; set; }
        public string gpp_c_unique { get; set; }
        public string gpp_d_atualizado { get; set; }
        public string gpp_d_inclusao { get; set; }
        public string gpp_mol_n_codigo { get; set; }
        public string EmpresaDescricao { get; set; }
        public string ClienteDescricao { get; set; }
        public string Permissoes { get; set; }
        public string buscaSimples { get; set; }
        public ModuloViewModel Modulo { get; set; }

    }
}
