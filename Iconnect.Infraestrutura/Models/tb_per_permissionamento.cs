using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_per_permissionamento
    {
        public tb_per_permissionamento()
        {
            tb_per_per_perfilPermissionamento = new HashSet<tb_per_per_perfilPermissionamento>();
            tb_ace_per_acessoPermissionamento = new HashSet<tb_ace_per_acessoPermissionamento>();
        }
        [Key]
        public Guid per_u_codigo { get; set; }
        public bool per_b_ativo { get; set; }
        public string per_c_chave { get; set; }
        public virtual ICollection<tb_per_per_perfilPermissionamento> tb_per_per_perfilPermissionamento { get; set; }
        public virtual ICollection<tb_ace_per_acessoPermissionamento> tb_ace_per_acessoPermissionamento { get; set; }
    }
}
