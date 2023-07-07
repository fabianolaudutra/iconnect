using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_zec_zeladorCliente
    {
        public tb_zec_zeladorCliente()
        {
            tb_not_notificacaoApp = new HashSet<tb_not_notificacaoApp>();
        }

        public int zec_n_codigo { get; set; }
        public int? zec_cli_n_codigo { get; set; }
        public string zec_c_perfil { get; set; }
        public string zec_c_nome { get; set; }
        public string zec_c_rg { get; set; }
        public string zec_c_telefone { get; set; }
        public int? zec_mos_n_codigo { get; set; }
        public int? zec_mol_n_codigo { get; set; }
        public int? zec_ace_n_codigo { get; set; }
        public string zec_c_autorizacao { get; set; }
        public DateTime? zec_d_modificacao { get; set; }
        public bool? zec_b_notificacao { get; set; }
        public Guid zec_c_unique { get; set; }
        public DateTime zec_d_atualizado { get; set; }
        public DateTime zec_d_inclusao { get; set; }
        public int? zec_mor_n_codigo { get; set; }
        public string zec_c_email { get; set; }

        public virtual tb_ace_acesso zec_ace_n_codigoNavigation { get; set; }
        public virtual tb_cli_cliente zec_cli_n_codigoNavigation { get; set; }
        public virtual tb_mol_modulosLiberados zec_mol_n_codigoNavigation { get; set; }
        public virtual tb_mor_Morador zec_mor_n_codigoNavigation { get; set; }
        public virtual tb_mos_moduloOrdemServicoLiberado zec_mos_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_not_notificacaoApp> tb_not_notificacaoApp { get; set; }
    }
}
