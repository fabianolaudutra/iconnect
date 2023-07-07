using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_ddv_dispositivoDVRCliente
    {
        public tb_ddv_dispositivoDVRCliente()
        {
            tb_lay_layout = new HashSet<tb_lay_layout>();
        }

        public int ddv_n_codigo { get; set; }
        public int? ddv_fab_n_codigo { get; set; }
        public int? ddv_mod_n_codigo { get; set; }
        public int? ddv_n_canais { get; set; }
        public string ddv_c_ip { get; set; }
        public string ddv_c_porta { get; set; }
        public string ddv_c_usuario { get; set; }
        public string ddv_c_senha { get; set; }
        public int? ddv_cli_n_codigo { get; set; }
        public string ddv_c_portaServico { get; set; }
        public string ddv_c_portaHTTP { get; set; }
        public DateTime? ddv_d_modificacao { get; set; }
        public string ddv_c_nome { get; set; }
        public Guid ddv_c_unique { get; set; }
        public DateTime ddv_d_atualizado { get; set; }
        public DateTime ddv_d_inclusao { get; set; }

        public virtual tb_cli_cliente ddv_cli_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_lay_layout> tb_lay_layout { get; set; }
    }
}
