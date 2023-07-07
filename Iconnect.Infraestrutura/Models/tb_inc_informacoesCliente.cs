using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_inc_informacoesCliente
    {
        [Key]
        public int inc_n_codigo { get; set; }
        public int inc_cli_n_codigo { get; set; }
        public string inc_c_titulo { get; set; }
        public string inc_c_descricao { get; set; }
        public int inc_n_ordem { get; set; }
        public Guid inc_c_unique { get; set; }
        public DateTime inc_d_atualizado { get; set; }
        public DateTime inc_d_inclusao { get; set; }

        public virtual tb_cli_cliente inc_cli_n_codigoNavigation { get; set; }
    }
}
