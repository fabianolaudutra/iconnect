using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_dva_duvidasApp
    {
        [Key]
        public int dva_n_codigo { get; set; }
        public int? dva_cli_n_codigo { get; set; }
        public string dva_c_duvida { get; set; }
        public string dva_c_resposta { get; set; }
        public string dva_c_link { get; set; }
        public Guid dva_c_unique { get; set; }
        public DateTime dva_d_atualizado { get; set; }
        public DateTime dva_d_inclusao { get; set; }

        public virtual tb_cli_cliente dva_cli_n_codigoNavigation { get; set; }
    }
}