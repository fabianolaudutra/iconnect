using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class vw_operador
    {
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
        public int? emp_n_codigo { get; set; }
        public string emp_c_razaoSocial { get; set; }
        public string emp_c_nomeFantasia { get; set; }
        public DateTime? emp_d_contrato { get; set; }
        public string emp_c_cnpj { get; set; }
        public string emp_c_ie { get; set; }
        public string emp_c_pessoaContato { get; set; }
        public string emp_c_email { get; set; }
        public string emp_c_email2 { get; set; }
        public string emp_c_foneComercial { get; set; }
        public string emp_c_foneComercial2 { get; set; }
        public string emp_c_celular { get; set; }
        public string emp_c_celular2 { get; set; }
        public string emp_c_rua { get; set; }
        public string emp_c_numero { get; set; }
        public string emp_c_complemento { get; set; }
        public string emp_c_bairro { get; set; }
        public string emp_c_cep { get; set; }
        public int? emp_cid_n_codigo { get; set; }
        public int? emp_est_n_codigo { get; set; }
        public string emp_c_observacao { get; set; }
        public int? emp_mol_n_codigo { get; set; }
        public DateTime? emp_d_alteracao { get; set; }
        public string emp_c_usuario { get; set; }
        public DateTime? emp_d_modificacao { get; set; }
        public string emp_c_RangeRamais { get; set; }
        public string emp_c_ramais { get; set; }
        public bool? emp_b_ativo { get; set; }
        public int? emp_fem_n_codigo { get; set; }
        public string emp_c_contatoNome1 { get; set; }
        public string emp_c_contatoEmail1 { get; set; }
        public string emp_c_contatoTelefone1 { get; set; }
        public string emp_c_contatoNome2 { get; set; }
        public string emp_c_contatoEmail2 { get; set; }
        public string emp_c_contatoTelefone2 { get; set; }
        public int cid_n_codigo { get; set; }
        public string cid_c_nome { get; set; }
        public int est_n_codigo { get; set; }
        public string est_c_descricao { get; set; }
        public string est_c_sigla { get; set; }
    }
}
