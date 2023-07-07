using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_not_notificacao
    {
        public int not_n_codigo { get; set; }
        public int? not_ope_n_codigo { get; set; }
        public int? not_avi_n_codigo { get; set; }
        public bool? not_b_lido { get; set; }
        public int? not_emp_n_codigo { get; set; }
        public int? not_avi_n_codigoEmpresa { get; set; }
        public DateTime? not_d_modificacao { get; set; }
        public Guid not_c_unique { get; set; }
        public DateTime not_d_atualizado { get; set; }
        public DateTime not_d_inclusao { get; set; }

        public virtual tb_avi_avisoEmpresa not_avi_n_codigoEmpresaNavigation { get; set; }
        public virtual tb_avi_aviso not_avi_n_codigoNavigation { get; set; }
        public virtual tb_ope_operador not_ope_n_codigoNavigation { get; set; }
    }
}
