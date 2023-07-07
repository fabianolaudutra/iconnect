using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_ace_acesso
    {
        public tb_ace_acesso()
        {
            tb_avi_aviso = new HashSet<tb_avi_aviso>();
            tb_avi_avisoMorador = new HashSet<tb_avi_avisoMorador>();
            tb_ope_operador = new HashSet<tb_ope_operador>();
            tb_pro_proprietario = new HashSet<tb_pro_proprietario>();
            tb_zec_zeladorCliente = new HashSet<tb_zec_zeladorCliente>();
            tb_age_agenteComercial = new HashSet<tb_age_agenteComercial>();
        }

        [Key]
        public int ace_n_codigo { get; set; }
        public string ace_c_login { get; set; }
        public string ace_c_senha { get; set; }
        public bool? ace_b_bloqueado { get; set; }
        public int? ace_per_n_codigo { get; set; }
        public int? ace_emp_n_codigo { get; set; }
        public int? ace_dis_n_codigo { get; set; }
        public bool? ace_b_relacional { get; set; }
        public bool? ace_b_relacionalDist { get; set; }
        public DateTime? ace_d_modificacao { get; set; }
        public Guid ace_c_unique { get; set; }
        public DateTime ace_d_atualizado { get; set; }
        public DateTime ace_d_inclusao { get; set; }

        public virtual tb_emp_empresa tb_emp_empresa { get; set; }
        public virtual tb_dis_distribuidor tb_dis_distribuidor { get; set; }
        public virtual tb_per_perfil tb_per_perfil { get; set; }
        public virtual ICollection<tb_avi_aviso> tb_avi_aviso { get; set; }
        public virtual ICollection<tb_avi_avisoMorador> tb_avi_avisoMorador { get; set; }
        public virtual ICollection<tb_ope_operador> tb_ope_operador { get; set; }
        public virtual ICollection<tb_pro_proprietario> tb_pro_proprietario { get; set; }
        public virtual ICollection<tb_zec_zeladorCliente> tb_zec_zeladorCliente { get; set; }
        public virtual ICollection<tb_grf_grupoFamiliar> tb_grf_grupoFamiliar { get; set; }
        public virtual ICollection<tb_usc_usuarioSalaComercial> tb_usc_usuarioSalaComercial { get; set; }
        public virtual ICollection<tb_age_agenteComercial> tb_age_agenteComercial { get; set; }
    }
}
