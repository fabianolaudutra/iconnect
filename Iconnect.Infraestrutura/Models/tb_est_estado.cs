using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_est_estado
    {
        public tb_est_estado()
        {
            tb_cid_cidade = new HashSet<tb_cid_cidade>();
            tb_cli_cliente = new HashSet<tb_cli_cliente>();
            tb_emp_empresa = new HashSet<tb_emp_empresa>();
            tb_ope_operador = new HashSet<tb_ope_operador>();
            tb_pro_proprietario = new HashSet<tb_pro_proprietario>();
        }

        public int est_n_codigo { get; set; }
        public string est_c_descricao { get; set; }
        public string est_c_sigla { get; set; }
        public Guid est_c_unique { get; set; }
        public DateTime est_d_atualizado { get; set; }
        public DateTime est_d_inclusao { get; set; }

        public virtual ICollection<tb_cid_cidade> tb_cid_cidade { get; set; }
        public virtual ICollection<tb_cli_cliente> tb_cli_cliente { get; set; }
        public virtual ICollection<tb_emp_empresa> tb_emp_empresa { get; set; }
        public virtual ICollection<tb_dis_distribuidor> tb_dis_distribuidor { get; set; }
        public virtual ICollection<tb_ope_operador> tb_ope_operador { get; set; }
        public virtual ICollection<tb_pro_proprietario> tb_pro_proprietario { get; set; }
    }
}
