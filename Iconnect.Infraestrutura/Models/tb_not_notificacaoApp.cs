using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_not_notificacaoApp
    {
        public int not_n_codigo { get; set; }
        public int? not_zec_n_codigo { get; set; }
        public bool? not_b_pendente { get; set; }
        public DateTime? not_d_data { get; set; }
        public string not_c_mensagem { get; set; }
        public bool? not_b_excluido { get; set; }
        public string not_c_cor { get; set; }
        public string not_c_retornoPush { get; set; }
        public int? not_mor_n_codigo { get; set; }
        public string not_c_origem { get; set; }
        public DateTime? not_d_modificacao { get; set; }
        public int? not_eno_n_codigo { get; set; }
        public Guid not_c_unique { get; set; }
        public DateTime not_d_atualizado { get; set; }
        public DateTime not_d_inclusao { get; set; }
        public int? not_grf_n_codigo { get; set; }
        public bool? not_b_enviar_app_pro { get; set; }
        public bool not_b_lido { get; set; }
        public bool not_b_tocado { get; set; }

        public virtual tb_eno_envioNotificacao not_eno_n_codigoNavigation { get; set; }
        public virtual tb_zec_zeladorCliente not_zec_n_codigoNavigation { get; set; }
    }
}
