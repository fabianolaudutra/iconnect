using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_rac_raca
    {
        public tb_rac_raca()
        {
            tb_pet_pet = new HashSet<tb_pet_pet>();
        }

        public int rac_n_codigo { get; set; }
        public string rac_c_nome { get; set; }
        public DateTime? rac_d_alteracao { get; set; }
        public string rac_c_usuario { get; set; }
        public string rac_c_tipo { get; set; }
        public DateTime? rac_d_modificacao { get; set; }
        public Guid rac_c_unique { get; set; }
        public DateTime rac_d_atualizado { get; set; }
        public DateTime rac_d_inclusao { get; set; }

        public virtual ICollection<tb_pet_pet> tb_pet_pet { get; set; }
    }
}
