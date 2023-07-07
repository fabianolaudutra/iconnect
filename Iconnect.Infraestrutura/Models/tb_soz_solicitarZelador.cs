using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_soz_solicitarZelador
    {
        public int soz_n_codigo { get; set; }
        public string soz_c_descricao { get; set; }
        public int? soz_mor_n_codigo { get; set; }
        public int? soz_n_fila { get; set; }
        public string soz_c_status { get; set; }
        public DateTime? soz_d_dataSolicitacao { get; set; }
        public string soz_c_resposta { get; set; }
        public DateTime? soz_d_modificacao { get; set; }
        public Guid soz_c_unique { get; set; }
        public DateTime soz_d_atualizado { get; set; }
        public DateTime soz_d_inclusao { get; set; }
        public int? soz_fap_n_codigo { get; set; }
        public string soz_c_tipo { get; set; }

        public virtual tb_fap_fotoApp soz_fap_n_codigoNavigation { get; set; }
        public virtual tb_mor_Morador soz_mor_n_codigoNavigation { get; set; }
    }
}
