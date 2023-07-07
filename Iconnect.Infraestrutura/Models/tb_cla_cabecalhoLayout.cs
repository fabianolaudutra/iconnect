using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_cla_cabecalhoLayout
    {
        public tb_cla_cabecalhoLayout()
        {
            tb_lay_layout = new HashSet<tb_lay_layout>();
            tb_plc_pontoLayoutCliente = new HashSet<tb_plc_pontoLayoutCliente>();
            tb_pta_pontosAcesso = new HashSet<tb_pta_pontosAcesso>();
            tb_ral_ramalLayout = new HashSet<tb_ral_ramalLayout>();
            tb_zoc_zoneamentoCliente = new HashSet<tb_zoc_zoneamentoCliente>();
        }

        public int cla_n_codigo { get; set; }
        public int? cla_cli_n_codigo { get; set; }
        public string cla_c_nome { get; set; }
        public string cla_c_exibirem { get; set; }
        public int? cla_usu_n_codigo { get; set; }
        public Guid cla_c_unique { get; set; }
        public DateTime cla_d_atualizado { get; set; }
        public DateTime cla_d_inclusao { get; set; }

        public virtual tb_cli_cliente cla_cli_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_lay_layout> tb_lay_layout { get; set; }
        public virtual ICollection<tb_plc_pontoLayoutCliente> tb_plc_pontoLayoutCliente { get; set; }
        public virtual ICollection<tb_pta_pontosAcesso> tb_pta_pontosAcesso { get; set; }
        public virtual ICollection<tb_ral_ramalLayout> tb_ral_ramalLayout { get; set; }
        public virtual ICollection<tb_zoc_zoneamentoCliente> tb_zoc_zoneamentoCliente { get; set; }
    }
}
