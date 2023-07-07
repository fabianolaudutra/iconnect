using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class DocumentoViewModel
    {
        public string doc_n_codigo { get; set; }
        public string doc_cli_n_codigo { get; set; }
        public string doc_c_nomeDocumento { get; set; }
        public string doc_cli_c_nomeFantasia { get; set; }
        public string doc_mor_c_nome { get; set; }
        public string doc_b_bloquearAcesso { get; set; }
        public string doc_b_preNotificacao { get; set; }
        public string doc_b_notificacaoAcesso { get; set; }
        public string doc_b_notificacaoVencimento { get; set; }
        public string doc_b_ativarMonitoramento { get; set; }
        public string doc_n_diasNotificacao { get; set; }
        public DateTime? doc_d_modificacao { get; set; }
        public Guid doc_c_unique { get; set; }
        public DateTime doc_d_atualizado { get; set; }
        public DateTime doc_d_inclusao { get; set; }

        public string dataVencimento { get; set; }

        public string documentoVencido { get; set; }

        public string documentoValido { get; set; }

        public string documentoQuaseVencendo { get; set; }
        public string status { get; set; }

    }
}
