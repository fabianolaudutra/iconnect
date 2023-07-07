using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_ard_arquivoDependencias
    {
        public tb_ard_arquivoDependencias()
        {
            tb_dpn_dependencias = new HashSet<tb_dpn_dependencias>();
        }

        public int ard_n_codigo { get; set; }
        public int? ard_usu_n_codigo { get; set; }
        public byte[] ard_blob_PDFImagem { get; set; }
        public DateTime? ard_d_modificacao { get; set; }
        public string ard_c_nomePDFImagem { get; set; }
        public Guid ard_c_unique { get; set; }
        public DateTime ard_d_atualizado { get; set; }
        public DateTime ard_d_inclusao { get; set; }

        public virtual ICollection<tb_dpn_dependencias> tb_dpn_dependencias { get; set; }
    }
}
