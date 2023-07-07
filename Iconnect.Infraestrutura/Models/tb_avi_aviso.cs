using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_avi_aviso
    {
        public tb_avi_aviso()
        {
            tb_not_notificacao = new HashSet<tb_not_notificacao>();
        }

        public int avi_n_codigo { get; set; }
        public string avi_c_titulo { get; set; }
        public string avi_c_descricao { get; set; }
        public DateTime? avi_d_inicio { get; set; }
        public DateTime? avi_d_fim { get; set; }
        public int? avi_ace_n_codigo { get; set; }
        public int? avi_emp_n_codigo { get; set; }
        public string avi_ope_c_enviarPara { get; set; }
        public string avi_c_status { get; set; }
        public DateTime? avi_d_alteracao { get; set; }
        public string avi_c_usuario { get; set; }
        public DateTime? avi_d_modificacao { get; set; }
        public Guid avi_c_unique { get; set; }
        public DateTime avi_d_atualizado { get; set; }
        public DateTime avi_d_inclusao { get; set; }

        public virtual tb_ace_acesso avi_ace_n_codigoNavigation { get; set; }
        public virtual tb_emp_empresa avi_emp_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_not_notificacao> tb_not_notificacao { get; set; }
    }
}
