using Iconnect.Infraestrutura.Enums;
using System;

namespace Iconnect.Infraestrutura.Models
{
    public class tb_csr_connectionSignalR
    {
        public long csr_n_codigo { get; set; }
        public string csr_c_connectionId { get; set; }
        public bool csr_b_conectado { get; set; }
        public EnumHubs csr_n_hub { get; set; }
        public int csr_n_id { get; set; }
        public int csr_n_usuarioId { get; set; }
        public int csr_n_perfil { get; set; }
        public DateTime csr_d_dataInclusao { get; set; }
        public DateTime csr_d_dataAlteracao { get; set; }
    }
}
