using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_lay_layout
    {
        public tb_lay_layout()
        {
            tb_can_canalLayout = new HashSet<tb_can_canalLayout>();
            tb_pta_pontosAcesso = new HashSet<tb_pta_pontosAcesso>();
            tb_ral_ramalLayout = new HashSet<tb_ral_ramalLayout>();
            tb_zoc_zoneamentoCliente = new HashSet<tb_zoc_zoneamentoCliente>();
        }

        public int lay_n_codigo { get; set; }
        public int? lay_ddv_n_codigo { get; set; }
        public int? lay_cli_n_codigo { get; set; }
        public string lay_c_nome { get; set; }
        public string lay_c_exibeLayout { get; set; }
        public string lay_c_canais { get; set; }
        public int? lay_usu_n_codigo { get; set; }
        public DateTime? lay_d_modificacao { get; set; }
        public int? lay_cla_n_codigo { get; set; }
        public Guid lay_c_unique { get; set; }
        public DateTime lay_d_atualizado { get; set; }
        public DateTime lay_d_inclusao { get; set; }

        public virtual tb_cla_cabecalhoLayout lay_cla_n_codigoNavigation { get; set; }
        public virtual tb_cli_cliente lay_cli_n_codigoNavigation { get; set; }
        public virtual tb_ddv_dispositivoDVRCliente lay_ddv_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_can_canalLayout> tb_can_canalLayout { get; set; }
        public virtual ICollection<tb_pta_pontosAcesso> tb_pta_pontosAcesso { get; set; }
        public virtual ICollection<tb_ral_ramalLayout> tb_ral_ramalLayout { get; set; }
        public virtual ICollection<tb_zoc_zoneamentoCliente> tb_zoc_zoneamentoCliente { get; set; }
    }
}
