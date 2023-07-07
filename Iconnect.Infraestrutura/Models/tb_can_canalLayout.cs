using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_can_canalLayout
    {
        public tb_can_canalLayout()
        {
            tb_cli_cliente = new HashSet<tb_cli_cliente>();
        }

        public int can_n_codigo { get; set; }
        public int? can_lay_n_codigo { get; set; }
        public bool? can_b_check { get; set; }
        public int? can_n_index { get; set; }
        public string can_c_nome { get; set; }
        public DateTime? can_d_modificacao { get; set; }
        public Guid can_c_unique { get; set; }
        public DateTime can_d_atualizado { get; set; }
        public DateTime can_d_inclusao { get; set; }

        public virtual tb_lay_layout can_lay_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_cli_cliente> tb_cli_cliente { get; set; }
    }
}
