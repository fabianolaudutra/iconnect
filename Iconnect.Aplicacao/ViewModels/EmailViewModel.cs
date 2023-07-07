using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class EmailViewModel
    {
        public int ema_n_codigo { get; set; }
        public DateTime? ema_d_data { get; set; }
        public string ema_c_assunto { get; set; }
        public string ema_c_corpo { get; set; }
        public bool? ema_b_enviado { get; set; }
        public string ema_c_remetente { get; set; }
        public string ema_c_destinatario { get; set; }
        public string ema_c_copia { get; set; }
        public string ema_c_copiaOculta { get; set; }
        public string ema_c_caminhoAnexo { get; set; }
        public string ema_c_anexo { get; set; }
        public DateTime? ema_d_modificacao { get; set; }
    }
}
