using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_precos
    {
        public int id { get; set; }
        public string mol_nome { get; set; }
        public int? preco { get; set; }
        public int? preco_dist { get; set; }
        public int? preco_emp { get; set; }
        public int? preco_cli { get; set; }
    }
}
