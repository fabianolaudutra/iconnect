using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_per_per_perfilPermissionamento
    {
        public tb_per_per_perfilPermissionamento()
        {
            tb_per_perfil = new tb_per_perfil();
            tb_per_permissionamento = new tb_per_permissionamento();
        }
        [Key]
        public Guid per_per_u_codigo { get; set; }
        public Guid per_u_n_codigo { get; set; }
        public int per_n_codigo { get; set; }
        public virtual tb_per_perfil tb_per_perfil { get; set; }
        public virtual tb_per_permissionamento tb_per_permissionamento { get; set; }
    }
}
