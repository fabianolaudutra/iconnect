using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_nod_notificacaoDocumento
    {
        public int nod_n_codigo { get; set; }
        public string nod_c_assunto { get; set; }
        public string nod_c_nomeDocumento { get; set; }
        public string nod_c_nomeFuncionario { get; set; }
        public string nod_c_dataVencimento { get; set; }
        public string nod_c_email { get; set; }
        public bool nod_b_processado { get; set; }
        public Guid nod_c_unique { get; set; }
        public DateTime nod_d_atualizado { get; set; }
        public DateTime nod_d_inclusao { get; set; }
    }
}
