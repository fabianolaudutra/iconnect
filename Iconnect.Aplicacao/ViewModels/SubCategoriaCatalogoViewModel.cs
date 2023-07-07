using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class SubCategoriaCatalogoViewModel
    {
        public string scc_n_codigo { get; set; }
        public string scc_cat_n_codigo { get; set; }
        public string scc_cli_n_codigo { get; set; }
        public string scc_b_ativo { get; set; }
        public string scc_c_nome { get; set; }
        public string scc_cat_c_nome { get; set; }
        public string scc_c_imagem { get; set; }
        public Guid scc_c_unique { get; set; }
        public DateTime scc_d_atualizado { get; set; }
        public DateTime scc_d_inclusao { get; set; }
        
    }
}
