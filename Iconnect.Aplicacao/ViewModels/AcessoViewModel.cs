using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class AcessoViewModel
    {
        public AcessoViewModel()
        {
            tb_avi_aviso = new HashSet<tb_avi_aviso>();
            tb_avi_avisoMorador = new HashSet<tb_avi_avisoMorador>();
            tb_ope_operador = new HashSet<tb_ope_operador>();
            tb_pro_proprietario = new HashSet<tb_pro_proprietario>();
            tb_zec_zeladorCliente = new HashSet<tb_zec_zeladorCliente>();
        }
        public int ace_n_codigo { get; set; }
        public string ace_c_login { get; set; }
        public string ace_c_senha { get; set; }
        public string ace_c_codigo { get; set; }
        public bool? ace_b_bloqueado { get; set; }
        public int ace_per_n_codigo { get; set; }
        public int? ace_emp_n_codigo { get; set; }
        public int? ace_dis_n_codigo { get; set; }
        public bool ace_b_relacional { get; set; }
        public bool ace_b_relacionalDist { get; set; }
        public DateTime? ace_d_modificacao { get; set; }
        public Guid ace_c_unique { get; set; }
        public DateTime ace_d_atualizado { get; set; }
        public DateTime ace_d_inclusao { get; set; }
        public virtual ICollection<tb_avi_aviso> tb_avi_aviso { get; set; }
        public virtual ICollection<tb_avi_avisoMorador> tb_avi_avisoMorador { get; set; }
        public virtual ICollection<tb_ope_operador> tb_ope_operador { get; set; }
        public virtual ICollection<tb_pro_proprietario> tb_pro_proprietario { get; set; }
        public virtual ICollection<tb_zec_zeladorCliente> tb_zec_zeladorCliente { get; set; }
    }
}
