using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_fer_feriado
    {
        public int fer_n_codigo { get; set; }
        public string fer_c_descricao { get; set; }
        public string fer_c_recorrente { get; set; }
        public string fer_d_data { get; set; }
        public int fer_n_codigoCliente { get; set; }
        public DateTime? fer_d_modificacao { get; set; }
        public Guid fer_c_unique { get; set; }
        public DateTime fer_d_atualizado { get; set; }
        public DateTime fer_d_inclusao { get; set; }

        public virtual tb_cli_cliente fer_n_codigoClienteNavigation { get; set; }
    }
}
