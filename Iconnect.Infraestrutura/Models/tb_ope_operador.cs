using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_ope_operador
    {
        public tb_ope_operador()
        {
            tb_ate_atendimento = new HashSet<tb_ate_atendimento>();
            tb_not_notificacao = new HashSet<tb_not_notificacao>();
            tb_pec_permissaoCliente = new HashSet<tb_pec_permissaoCliente>();
            tb_rop_ramalOperador = new HashSet<tb_rop_ramalOperador>();
        }
        [Key]
        public int ope_n_codigo { get; set; }
        public string ope_c_nome { get; set; }
        public DateTime? ope_d_dataNascimento { get; set; }
        public string ope_c_rg { get; set; }
        public string ope_c_cpf { get; set; }
        public string ope_c_telefone { get; set; }
        public string ope_c_celular { get; set; }
        public string ope_c_email { get; set; }
        public string ope_c_email2 { get; set; }
        public string ope_c_rua { get; set; }
        public string ope_c_numero { get; set; }
        public string ope_c_complemento { get; set; }
        public string ope_c_bairro { get; set; }
        public string ope_c_cep { get; set; }
        public int? ope_cid_n_codigo { get; set; }
        public int? ope_est_n_codigo { get; set; }
        public string ope_c_observacao { get; set; }
        public int? ope_ace_n_codigo { get; set; }
        public int? ope_emp_n_codigo { get; set; }
        public bool? ope_b_ativoInativo { get; set; }
        public int? ope_mol_n_codigo { get; set; }
        public int? ope_cli_n_atendimento { get; set; }
        public int? ope_gpp_n_codigo { get; set; }
        public DateTime? ope_d_alteracao { get; set; }
        public string ope_c_usuario { get; set; }
        public bool? ope_b_todosClientes { get; set; }
        public DateTime? ope_d_modificacao { get; set; }
        public string ope_c_cargo { get; set; }
        public DateTime? ope_d_ultimoContato { get; set; }
        public Guid ope_c_unique { get; set; }
        public DateTime ope_d_atualizado { get; set; }
        public DateTime ope_d_inclusao { get; set; }
        public bool? ope_b_solicitaRamal { get; set; }
        public bool? ope_b_admIconnect { get; set; }
        public int? ope_emp_n_codigo_ramal { get; set; }
        public int? ope_pop_n_codigo { get; set; }


        public virtual tb_ace_acesso ope_ace_n_codigoNavigation { get; set; }
        public virtual tb_cid_cidade ope_cid_n_codigoNavigation { get; set; }
        public virtual tb_emp_empresa ope_emp_n_codigoNavigation { get; set; }
        public virtual tb_est_estado ope_est_n_codigoNavigation { get; set; }
        public virtual tb_mol_modulosLiberados ope_mol_n_codigoNavigation { get; set; }
        public virtual tb_pop_perfilOperador ope_pop_n_codigoNavigation { get; set; }

        public virtual ICollection<tb_ate_atendimento> tb_ate_atendimento { get; set; }
        public virtual ICollection<tb_not_notificacao> tb_not_notificacao { get; set; }
        public virtual ICollection<tb_pec_permissaoCliente> tb_pec_permissaoCliente { get; set; }
        public virtual ICollection<tb_rop_ramalOperador> tb_rop_ramalOperador { get; set; }
        public virtual ICollection<tb_ocp_ocorrenciasOperador> tb_ocp_ocorrenciasOperadorCadastrou { get; set; }
        public virtual ICollection<tb_ocp_ocorrenciasOperador> tb_ocp_ocorrenciasOperadorModificou { get; set; }

    }
}
