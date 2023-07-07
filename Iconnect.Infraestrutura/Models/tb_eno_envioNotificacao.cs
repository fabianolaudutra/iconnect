using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_eno_envioNotificacao
    {
        public tb_eno_envioNotificacao()
        {
            tb_not_notificacaoApp = new HashSet<tb_not_notificacaoApp>();
        }

        public int eno_n_codigo { get; set; }
        public string eno_c_titulo { get; set; }
        public string eno_c_mensagem { get; set; }
        public int? eno_cli_n_codigo { get; set; }
        public string eno_c_GruposFamiliares { get; set; }
        public DateTime? eno_d_inicio { get; set; }
        public DateTime? eno_d_fim { get; set; }
        public string eno_c_MoradoresGruposFamiliares { get; set; }
        public Guid eno_c_unique { get; set; }
        public DateTime eno_d_atualizado { get; set; }
        public DateTime eno_d_inclusao { get; set; }

        public virtual tb_cli_cliente eno_cli_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_not_notificacaoApp> tb_not_notificacaoApp { get; set; }
    }
}
