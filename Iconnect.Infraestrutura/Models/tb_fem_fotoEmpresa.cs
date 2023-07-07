using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_fem_fotoEmpresa
    {
        public tb_fem_fotoEmpresa()
        {
            tb_emp_empresa = new HashSet<tb_emp_empresa>();
        }

        public int fem_n_codigo { get; set; }
        public byte[] fem_c_imagem { get; set; }
        public DateTime? fem_d_modificacao { get; set; }
        public Guid fem_c_unique { get; set; }
        public DateTime fem_d_atualizado { get; set; }
        public DateTime fem_d_inclusao { get; set; }

        public virtual ICollection<tb_emp_empresa> tb_emp_empresa { get; set; }
    }
}
