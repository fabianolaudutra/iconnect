using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class vw_aviso
    {
        public int avi_n_codigo { get; set; }
        public string avi_c_titulo { get; set; }
        public string avi_c_descricao { get; set; }
        public DateTime? avi_d_inicio { get; set; }
        public DateTime? avi_d_fim { get; set; }
        public int? avi_ace_n_codigo { get; set; }
        public int? avi_emp_n_codigo { get; set; }
        public string avi_ope_c_enviarPara { get; set; }
        public string status { get; set; }
        public string emp_c_razaoSocial { get; set; }
        public string emp_c_nomeFantasia { get; set; }
        public int emp_n_codigo { get; set; }
        public string avi_c_status { get; set; }
        public string avi_c_usuario { get; set; }
        public DateTime? avi_d_alteracao { get; set; }
        public DateTime? avi_d_modificacao { get; set; }
    }
}
