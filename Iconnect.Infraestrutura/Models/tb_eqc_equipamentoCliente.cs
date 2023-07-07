using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_eqc_equipamentoCliente
    {
        public tb_eqc_equipamentoCliente()
        {
            tb_dpg_disparoPGM = new HashSet<tb_dpg_disparoPGM>();
            tb_pgc_pgmCliente = new HashSet<tb_pgc_pgmCliente>();
            tb_zoc_zoneamentoCliente = new HashSet<tb_zoc_zoneamentoCliente>();
        }

        public int eqc_n_codigo { get; set; }
        public int? eqc_cli_n_codigo { get; set; }
        public int? eqc_n_modelo { get; set; }
        public string eqc_c_nomePonto { get; set; }
        public string eqc_c_conta { get; set; }
        public string eqc_c_ip { get; set; }
        public string eqc_c_porta { get; set; }
        public int? eqc_usu_n_codigo { get; set; }
        public DateTime? eqc_d_modificacao { get; set; }
        public DateTime? eqc_d_ultimoContato { get; set; }
        public Guid eqc_c_unique { get; set; }
        public DateTime eqc_d_atualizado { get; set; }
        public DateTime eqc_d_inclusao { get; set; }
        public bool? eqc_b_apontamentoLocal { get; set; }
        public string eqc_c_senhaRemota { get; set; }
        public string eqc_c_versao { get; set; }

        public virtual tb_cli_cliente eqc_cli_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_dpg_disparoPGM> tb_dpg_disparoPGM { get; set; }
        public virtual ICollection<tb_pgc_pgmCliente> tb_pgc_pgmCliente { get; set; }
        public virtual ICollection<tb_zoc_zoneamentoCliente> tb_zoc_zoneamentoCliente { get; set; }
    }
}
