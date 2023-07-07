using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_err_erro
    {
        public int err_n_codigo { get; set; }
        public string err_c_message { get; set; }
        public string err_c_stack { get; set; }
        public string err_c_inner { get; set; }
        public string err_c_innerStack { get; set; }
        public DateTime? erro_d_data { get; set; }
    }
}
