using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_voi_voip
    {
        public int voi_n_codigo { get; set; }
        public string voi_c_json { get; set; }
        public bool? voi_b_pendente { get; set; }
        public DateTime? voi_d_data { get; set; }
        public Guid voi_c_unique { get; set; }
        public DateTime voi_d_atualizado { get; set; }
        public DateTime voi_d_inclusao { get; set; }
    }
}
