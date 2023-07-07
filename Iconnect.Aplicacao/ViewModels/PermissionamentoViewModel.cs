using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class PermissionamentoViewModel
    {
        public Guid per_u_codigo { get; set; }
        public string per_c_chave { get; set; }
        public bool per_b_ativo { get; set; }
        public  List<AcessoViewModel> Acessos { get; set;}
        public  List<PerfilViewModel> Perfis { get; set;}
    }
}
