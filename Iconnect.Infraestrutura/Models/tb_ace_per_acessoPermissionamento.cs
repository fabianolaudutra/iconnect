using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_ace_per_acessoPermissionamento
    {
        public tb_ace_per_acessoPermissionamento()
        {
            tb_ace_acesso = new tb_ace_acesso();
            tb_per_permissionamento = new tb_per_permissionamento();
        }
        [Key]
        public Guid ace_per_u_codigo { get; set; }
        public Guid per_u_n_codigo { get; set; }
        public int per_ace_n_codigo { get; set; }
        public virtual tb_ace_acesso tb_ace_acesso { get; set; }
        public virtual tb_per_permissionamento tb_per_permissionamento { get; set; }
    }
}
