using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_afa_afastamento
    {
        [Key]
        public int afa_n_codigo { get; set; }
        public int afa_mor_n_codigo { get; set; }
        public string afa_c_descricao { get; set; }
        public DateTime afa_d_inicio { get; set; }
        public DateTime afa_d_fim { get; set; }
        public bool afa_b_sincronizado { get; set; }
        public bool afa_b_expirado { get; set; }
        public DateTime? afa_d_modificacao { get; set; }
        public Guid afa_c_unique { get; set; }
        public DateTime afa_d_atualizado { get; set; }
        public DateTime afa_d_inclusao { get; set; }
        public virtual tb_mor_Morador afa_mor_n_codigoNavigation { get; set; }
    }
}
