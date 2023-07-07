using System;

namespace Iconnect.Infraestrutura.Models
{
    public class tb_dev_device
    {
        public string dev_c_uuid { get; set; }
        public string dev_c_fcmToken { get; set; }
        public string dev_c_plataforma { get; set; }
        public string dev_c_versaoApp { get; set; }
        public string dev_c_versaoSO { get; set; }
        public int dev_vpp_n_visitanteApp { get; set; }
        public DateTime dev_d_dataInclusao { get; set; }
        public DateTime dev_d_dataModificacao { get; set; }

        public virtual tb_vpp_visitanteApp tb_vpp_visitanteApp { get; set; }
    }
}
