using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_exc_exclusoes
    {
        public string exc_c_tabela { get; set; }
        public Guid? exc_c_id { get; set; }
        public Guid? exc_cli_c_unique { get; set; }
        public DateTime exc_d_dataExclusao { get; set; }
    }
}
