using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_sol_solicitacaoAberturaRemota
    {
        public int sol_n_codigo { get; set; }
        public int sol_cli_n_codigo { get; set; }
        public string sol_c_usuarioSolicitou { get; set; }
        public DateTime? sol_d_data { get; set; }
        public string sol_c_tipoUsuario { get; set; }
        public int? sol_usu_n_codigo { get; set; }
        public DateTime? sol_d_modificacao { get; set; }
        public int? sol_pta_n_codigo { get; set; }
        public Guid sol_c_unique { get; set; }
        public DateTime sol_d_atualizado { get; set; }
        public DateTime sol_d_inclusao { get; set; }
    }
}
