using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_vap_versaoApp
    {
        public int vap_n_codigo { get; set; }
        public byte[] vap_c_apk { get; set; }
        public string vap_c_numeroVersao { get; set; }
        public DateTime vap_d_dataInclusao { get; set; }
    }
}