using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_pop_perfilOperador
    {
        public tb_pop_perfilOperador()
        {
            tb_ope_operador = new HashSet<tb_ope_operador>();
        }

        [Key]
        public int pop_n_codigo { get; set; }
        public string pop_c_nome { get; set; }
        public DateTime? pop_d_modificacao { get; set; }
        public Guid pop_c_unique { get; set; }
        public DateTime pop_d_atualizado { get; set; }
        public DateTime pop_d_inclusao { get; set; }

        public virtual ICollection<tb_ope_operador> tb_ope_operador { get; set; }

    }
}
