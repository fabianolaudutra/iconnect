using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class ZeladorClienteViewModel
    {
        public string zec_n_codigo { get; set; }
        public string zec_cli_n_codigo { get; set; }
        public string zec_c_perfil { get; set; }
        public string zec_c_nome { get; set; }
        public string zec_c_rg { get; set; }
        public string zec_c_telefone { get; set; }
        public string zec_mos_n_codigo { get; set; }
        public string zec_mol_n_codigo { get; set; }
        public string zec_ace_n_codigo { get; set; }
        public string zec_c_autorizacao { get; set; }
        public string zec_d_modificacao { get; set; }
        public string zec_b_notificacao { get; set; }
        public string zec_c_unique { get; set; }
        public string zec_d_atualizado { get; set; }
        public string zec_d_inclusao { get; set; }
        public string zec_mor_n_codigo { get; set; }
        public string zec_c_email { get; set; }

        public ModuloViewModel Modulo { get; set; }
        public AcessoViewModel Acesso { get; set; }
        public GrupoFamiliarViewModel GrupoFamiliar { get; set; }
    }
}
