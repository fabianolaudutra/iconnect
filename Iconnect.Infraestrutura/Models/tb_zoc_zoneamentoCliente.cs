using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_zoc_zoneamentoCliente
    {
        public tb_zoc_zoneamentoCliente()
        {
            tb_mon_monitoramento = new HashSet<tb_mon_monitoramento>();
        }
        public int zoc_n_codigo { get; set; }
        public int? zoc_cli_n_codigo { get; set; }
        public int? zoc_eqc_n_codigo { get; set; }
        public string zoc_c_tipoSensor { get; set; }
        public string zoc_c_nomePonto { get; set; }
        public string zoc_c_zona { get; set; }
        public int? zoc_n_TemporizadorDisparo { get; set; }
        public int? zoc_lay_n_codigo { get; set; }
        public DateTime? zoc_d_modificacao { get; set; }
        public int? zoc_cla_n_codigo { get; set; }
        public Guid zoc_c_unique { get; set; }
        public DateTime zoc_d_atualizado { get; set; }
        public DateTime zoc_d_inclusao { get; set; }

        public virtual tb_cla_cabecalhoLayout zoc_cla_n_codigoNavigation { get; set; }
        public virtual tb_cli_cliente zoc_cli_n_codigoNavigation { get; set; }
        public virtual tb_eqc_equipamentoCliente zoc_eqc_n_codigoNavigation { get; set; }
        public virtual tb_lay_layout zoc_lay_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_mon_monitoramento> tb_mon_monitoramento { get; set; }
    }
}
