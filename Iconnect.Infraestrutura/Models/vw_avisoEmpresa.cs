using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class vw_avisoEmpresa
    {
        public int avi_n_codigo { get; set; }
        public string avi_c_titulo { get; set; }
        public string avi_c_descricao { get; set; }
        public DateTime? avi_d_inicio { get; set; }
        public DateTime? avi_d_fim { get; set; }
        public string avi_emp_c_enviarPara { get; set; }
        public string status { get; set; }
    }
}
