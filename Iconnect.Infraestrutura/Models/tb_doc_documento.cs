using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_doc_documento
    {
        public tb_doc_documento()
        {
            tb_dmo_documentoMorador = new HashSet<tb_dmo_documentoMorador>();
        }

        [Key]
        public int doc_n_codigo { get; set; }
        public int doc_cli_n_codigo { get; set; }
        public string doc_c_nomeDocumento { get; set; }
        public bool doc_b_ativarMonitoramento { get; set; }
        public bool doc_b_bloquearAcesso { get; set; }
        public bool doc_b_preNotificacao { get; set; }
        public bool doc_b_notificacaoAcesso { get; set; }
        public bool doc_b_notificacaoVencimento { get; set; }
        public int doc_n_diasNotificacao { get; set; }
        public DateTime? doc_d_modificacao { get; set; }
        public Guid doc_c_unique { get; set; }
        public DateTime doc_d_atualizado { get; set; }
        public DateTime doc_d_inclusao { get; set; }
        public virtual tb_cli_cliente doc_cli_n_codigoNavigation { get; set; }

        public virtual ICollection<tb_dmo_documentoMorador> tb_dmo_documentoMorador { get; set; }

    }
}
