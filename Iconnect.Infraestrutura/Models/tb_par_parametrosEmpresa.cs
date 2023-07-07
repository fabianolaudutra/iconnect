using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_par_parametrosEmpresa
    {
        public int par_n_codigo { get; set; }
        public string par_c_descricao { get; set; }
        public string par_c_chave { get; set; }
        public string par_c_valor { get; set; }
        public string par_c_titulo { get; set; }
        public bool? par_b_interno { get; set; }
        public string par_c_aba { get; set; }
        public int? par_emp_n_codigo { get; set; }
        public DateTime? par_d_modificacao { get; set; }
        public Guid par_c_unique { get; set; }
        public DateTime par_d_atualizado { get; set; }
        public DateTime par_d_inclusao { get; set; }

        public virtual tb_emp_empresa par_emp_n_codigoNavigation { get; set; }
    }
}
