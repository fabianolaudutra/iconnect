using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_ent_entidade
    {
        public tb_ent_entidade()
        {
            tb_eti_entidadeTipo = new HashSet<tb_eti_entidadeTipo>();
        }

        public int ent_n_codigo { get; set; }
        public string ent_c_nome { get; set; }
        public string ent_c_chave { get; set; }
        public string ent_c_valorPadrao { get; set; }
        public Guid ent_c_unique { get; set; }
        public DateTime ent_d_atualizado { get; set; }
        public DateTime ent_d_inclusao { get; set; }

        public virtual ICollection<tb_eti_entidadeTipo> tb_eti_entidadeTipo { get; set; }
    }
}
