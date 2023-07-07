using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
   public class UploadAPK
    {
        public int upa_n_codigo { get; set; }
        public byte[] upa_c_arquivo { get; set; }
        public string upa_n_versaoName { get; set; }
        public Nullable<int> upa_n_versaoCode { get; set; }
        public string upa_c_nome { get; set; }
        public string upa_d_inclusao { get; set; }
        public Nullable<System.Guid> upa_c_unique { get; set; }
        public string upa_c_usuario { get; set; }
    }
}
