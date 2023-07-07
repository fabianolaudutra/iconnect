using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_moc_motivoOcorrenciaCliente
    {
        public int moc_n_codigo { get; set; }
        public string moc_c_descricao { get; set; }
        public int? moc_cli_n_codigo { get; set; }
        public DateTime? moc_d_modificacao { get; set; }
        public Guid moc_c_unique { get; set; }
        public DateTime moc_d_atualizado { get; set; }
        public DateTime moc_d_inclusao { get; set; }
        public bool? moc_b_encerrar { get; set; }
    public virtual tb_cli_cliente moc_cli_n_codigoNavigation { get; set; }
    }
}
