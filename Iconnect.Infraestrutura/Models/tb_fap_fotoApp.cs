using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_fap_fotoApp
    {
        public tb_fap_fotoApp()
        {
            tb_soz_solicitarZelador = new HashSet<tb_soz_solicitarZelador>();
        }

        public int fap_n_codigo { get; set; }
        public byte[] fap_c_imagem { get; set; }
        public DateTime? fap_d_modificacao { get; set; }
        public Guid fap_c_unique { get; set; }
        public DateTime fap_d_atualizado { get; set; }
        public DateTime fap_d_inclusao { get; set; }

        public virtual ICollection<tb_soz_solicitarZelador> tb_soz_solicitarZelador { get; set; }
    }
}
