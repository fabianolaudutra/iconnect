using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_pre_precos
    {
        public int pre_n_codigo { get; set; }
        public string pre_mol_c_nome { get; set; }
        public decimal pre_n_preco { get; set; }
        public decimal pre_n_precoDist { get; set; }
        public decimal pre_n_precoEmp { get; set; }
        public decimal pre_n_precoCli { get; set; }
        public int pre_n_porcentDist { get; set; }
        public int pre_n_porcentEmp { get; set; }
        public int pre_n_porcentCli { get; set; }
    }
}
