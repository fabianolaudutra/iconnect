using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_vec_veiculo
    {
        public int vec_n_codigo { get; set; }
        public string vec_c_modelo { get; set; }
        public string vec_c_cor { get; set; }
        public string vec_c_placa { get; set; }
        public string vec_c_caracteristicas { get; set; }
        public int? vec_grf_n_codigo { get; set; }
        public DateTime? vec_d_modificacao { get; set; }
        public int? vec_mav_n_codigo { get; set; }
        public Guid vec_c_unique { get; set; }
        public DateTime vec_d_atualizado { get; set; }
        public DateTime vec_d_inclusao { get; set; }

        public virtual tb_grf_grupoFamiliar vec_grf_n_codigoNavigation { get; set; }
        public virtual tb_mav_marcaVeiculo vec_mav_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_mor_Morador> tb_mor_Morador { get; set; }
    }
}
