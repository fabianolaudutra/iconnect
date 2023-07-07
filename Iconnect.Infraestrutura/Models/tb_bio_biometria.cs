using System;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_bio_biometria
    {
        public int bio_n_codigo { get; set; }
        public string bio_c_status { get; set; }
        public int bio_cli_n_codigo { get; set; }
        public string bio_c_template { get; set; }
        public byte[] bio_c_imagem { get; set; }
        public DateTime bio_d_dataSolicitacao { get; set; }
        public Guid bio_c_unique { get; set; }
        public DateTime bio_d_atualizado { get; set; }
        public DateTime bio_d_inclusao { get; set; }
        public int? bio_con_n_codigo { get; set; }
        public int bio_n_altura { get; set; }
        public int bio_n_largura { get; set; }

        public virtual tb_con_controladora bio_con_n_codigoNavigation { get; set; }
        public virtual tb_cli_cliente bio_cli_n_codigoNavigation { get; set; }
    }
}
