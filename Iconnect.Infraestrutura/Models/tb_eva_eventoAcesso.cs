using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_eva_eventoAcesso
    {
        public int eva_n_codigo { get; set; }
        public int? eva_n_chave { get; set; }
        public string eva_c_descricao { get; set; }
        public DateTime? eva_d_modificacao { get; set; }
        public Guid eva_c_unique { get; set; }
        public DateTime eva_d_atualizado { get; set; }
        public DateTime eva_d_inclusao { get; set; }
    }
}
