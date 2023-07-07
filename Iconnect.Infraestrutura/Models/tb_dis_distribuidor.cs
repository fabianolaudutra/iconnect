using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_dis_distribuidor
    {
        public tb_dis_distribuidor()
        {
            tb_emp_empresa = new HashSet<tb_emp_empresa>();
        }

        public int dis_n_codigo { get; set; }
        public string dis_c_razaoSocial { get; set; }
        public string dis_c_nomeFantasia { get; set; }
        public DateTime? dis_d_contrato { get; set; }
        public string dis_c_cnpj { get; set; }
        public string dis_c_ie { get; set; }
        public string dis_c_pessoaContato { get; set; }
        public string dis_c_email { get; set; }
        public string dis_c_email2 { get; set; }
        public string dis_c_foneComercial { get; set; }
        public string dis_c_foneComercial2 { get; set; }
        public string dis_c_celular { get; set; }
        public string dis_c_celular2 { get; set; }
        public string dis_c_rua { get; set; }
        public string dis_c_numero { get; set; }
        public string dis_c_complemento { get; set; }
        public string dis_c_bairro { get; set; }
        public string dis_c_cep { get; set; }
        public int? dis_cid_n_codigo { get; set; }
        public int? dis_est_n_codigo { get; set; }
        public string dis_c_observacao { get; set; }
        public DateTime? dis_d_alteracao { get; set; }
        public string dis_c_usuario { get; set; }
        public DateTime? dis_d_modificacao { get; set; }
        public bool? dis_b_ativo { get; set; }
        public Guid dis_c_unique { get; set; }
        public DateTime dis_d_atualizado { get; set; }
        public DateTime dis_d_inclusao { get; set; }

        public virtual tb_cid_cidade dis_cid_n_codigoNavigation { get; set; }
        public virtual tb_est_estado dis_est_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_emp_empresa> tb_emp_empresa { get; set; }
        public virtual ICollection<tb_ace_acesso> tb_ace_acesso { get; set; }
    }
}
