using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_pet_pet
    {
        public int pet_n_codigo { get; set; }
        public bool? pet_c_foto { get; set; }
        public string pet_c_nome { get; set; }
        public string pet_c_cor { get; set; }
        public int? pet_rac_n_codigo { get; set; }
        public string pet_c_porte { get; set; }
        public string pet_c_pelagem { get; set; }
        public string pet_c_caracteristicas { get; set; }
        public int? pet_grf_n_codigo { get; set; }
        public int? pet_fot_n_codigo { get; set; }
        public DateTime? pet_d_modificacao { get; set; }
        public Guid pet_c_unique { get; set; }
        public DateTime pet_d_atualizado { get; set; }
        public DateTime pet_d_inclusao { get; set; }

        public virtual tb_fot_foto pet_fot_n_codigoNavigation { get; set; }
        public virtual tb_grf_grupoFamiliar pet_grf_n_codigoNavigation { get; set; }
        public virtual tb_rac_raca pet_rac_n_codigoNavigation { get; set; }
    }
}
