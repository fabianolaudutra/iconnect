using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_usu_UsuarioApp
    {
        public int usu_n_codigo { get; set; }
        public string usu_c_email { get; set; }
        public string usu_c_rg { get; set; }
        public string usu_c_telefone { get; set; }
        public string usu_c_senha { get; set; }
        public int? usu_mor_n_codigo { get; set; }
        public string usu_c_nome { get; set; }
        public bool? usu_b_liberado { get; set; }
        public string usu_c_condominio { get; set; }
        public DateTime? usu_d_dataInclusao { get; set; }
        public DateTime? usu_d_modificacao { get; set; }
        public Guid usu_c_unique { get; set; }
        public DateTime usu_d_atualizado { get; set; }
        public DateTime usu_d_inclusao { get; set; }
        public string usu_c_codigoRecuperacao { get; set; }

        public virtual tb_mor_Morador usu_mor_n_codigoNavigation { get; set; }
    }
}
