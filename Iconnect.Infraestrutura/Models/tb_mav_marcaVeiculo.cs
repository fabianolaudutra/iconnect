using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_mav_marcaVeiculo
    {
        public tb_mav_marcaVeiculo()
        {
            tb_vec_veiculo = new HashSet<tb_vec_veiculo>();
            tb_fro_frota = new HashSet<tb_fro_frota>();
        }

        public int mav_n_codigo { get; set; }
        public string mav_c_descricao { get; set; }
        public DateTime? mav_d_modificacao { get; set; }
        public Guid mav_c_unique { get; set; }
        public DateTime mav_d_atualizado { get; set; }
        public DateTime mav_d_inclusao { get; set; }

        public virtual ICollection<tb_vec_veiculo> tb_vec_veiculo { get; set; }
        public virtual ICollection<tb_fro_frota> tb_fro_frota { get; set; }
    }
}
