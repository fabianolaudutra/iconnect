using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_dmo_documentoMorador
    {
        public int dmo_n_codigo { get; set; }
        public int dmo_mor_n_codigo { get; set; }
        public int dmo_doc_n_codigo { get; set; }
        public DateTime dmo_d_vencimento { get; set; }
        public DateTime? dmo_d_modificacao { get; set; }
        public Guid dmo_c_unique { get; set; }
        public DateTime dmo_d_atualizado { get; set; }
        public DateTime dmo_d_inclusao { get; set; }

        public virtual tb_mor_Morador dmo_mor_n_codigoNavigation { get; set; }
        public virtual tb_doc_documento dmo_doc_n_codigoNavigation { get; set; }

    }
}
