using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_cid_cidade
    {
        public tb_cid_cidade()
        {
            tb_cli_cliente = new HashSet<tb_cli_cliente>();
            tb_emp_empresa = new HashSet<tb_emp_empresa>();
            tb_ope_operador = new HashSet<tb_ope_operador>();
            tb_pro_proprietario = new HashSet<tb_pro_proprietario>();
        }

        public int cid_n_codigo { get; set; }
        public string cid_n_ibge { get; set; }
        public string cid_c_nome { get; set; }
        public string cid_c_estado { get; set; }
        public int? cid_est_n_codigo { get; set; }
        public Guid cid_c_unique { get; set; }
        public DateTime cid_d_atualizado { get; set; }
        public DateTime cid_d_inclusao { get; set; }

        public virtual tb_est_estado cid_est_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_cli_cliente> tb_cli_cliente { get; set; }
        public virtual ICollection<tb_emp_empresa> tb_emp_empresa { get; set; }
        public virtual ICollection<tb_dis_distribuidor> tb_dis_distribuidor { get; set; }
        public virtual ICollection<tb_ope_operador> tb_ope_operador { get; set; }
        public virtual ICollection<tb_pro_proprietario> tb_pro_proprietario { get; set; }
    }
}
