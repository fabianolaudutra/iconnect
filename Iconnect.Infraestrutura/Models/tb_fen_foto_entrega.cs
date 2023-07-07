using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_fen_foto_entrega
    {
        public int fen_n_codigo { get; set; }
        public byte[] fen_c_imagem { get; set; }
        public Guid fen_c_unique { get; set; }
        public DateTime fen_d_inclusao { get; set; }

        public virtual ICollection<tb_cde_cadastro_entregas> tb_cde_cadastro_entregas { get; set; }
    }
}
