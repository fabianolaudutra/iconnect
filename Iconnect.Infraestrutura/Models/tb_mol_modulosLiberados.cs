using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_mol_modulosLiberados
    {
        public tb_mol_modulosLiberados()
        {
            tb_cli_cliente = new HashSet<tb_cli_cliente>();
            tb_emp_empresa = new HashSet<tb_emp_empresa>();
            tb_gpp_grupoPermissaoOperador = new HashSet<tb_gpp_grupoPermissaoOperador>();
            tb_ope_operador = new HashSet<tb_ope_operador>();
            tb_zec_zeladorCliente = new HashSet<tb_zec_zeladorCliente>();
        }

        public int mol_n_codigo { get; set; }
        public bool mol_b_controleDeAcesso { get; set; }
        public bool mol_b_CFTV { get; set; }
        public bool mol_b_MonitoriamentoPerimetral { get; set; }
        public bool mol_b_OrdemServico { get; set; }
        public DateTime? mol_d_modificacao { get; set; }
        public bool mol_b_connectSolutions { get; set; }
        public Guid mol_c_unique { get; set; }
        public DateTime mol_d_atualizado { get; set; }
        public DateTime mol_d_inclusao { get; set; }
        public bool mol_b_connectSync { get; set; }
        public bool mol_b_accessView { get; set; }
        public bool mol_b_connectPRO { get; set; }
        public bool mol_b_connectGaren { get; set; }
        public bool mol_b_portariaVirtual { get; set; }
        public bool mol_b_comboUsuarioGuard { get; set; }
        

        public virtual ICollection<tb_cli_cliente> tb_cli_cliente { get; set; }
        public virtual ICollection<tb_emp_empresa> tb_emp_empresa { get; set; }
        public virtual ICollection<tb_gpp_grupoPermissaoOperador> tb_gpp_grupoPermissaoOperador { get; set; }
        public virtual ICollection<tb_ope_operador> tb_ope_operador { get; set; }
        public virtual ICollection<tb_zec_zeladorCliente> tb_zec_zeladorCliente { get; set; }
    }
}
