using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_avi_avisoEmpresa
    {
        public tb_avi_avisoEmpresa()
        {
            tb_not_notificacao = new HashSet<tb_not_notificacao>();
        }

        public int avi_n_codigo { get; set; }
        public string avi_c_titulo { get; set; }
        public string avi_c_descricao { get; set; }
        public DateTime? avi_d_inicio { get; set; }
        public DateTime? avi_d_fim { get; set; }
        public string avi_emp_c_enviarPara { get; set; }
        public string avi_c_status { get; set; }
        public DateTime? avi_d_alteracao { get; set; }
        public string avi_c_usuario { get; set; }
        public DateTime? avi_d_modificacao { get; set; }
        public Guid avi_c_unique { get; set; }
        public DateTime avi_d_atualizado { get; set; }
        public DateTime avi_d_inclusao { get; set; }

        public virtual ICollection<tb_not_notificacao> tb_not_notificacao { get; set; }
    }
}
