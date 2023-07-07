using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class EmpresaViewModel
    {
        public string Cidade { get; set; }        
        public string Estado { get; set; }
        public string count_cliente { get; set; }
        public string emp_n_codigo { get; set; }
        public string emp_c_razaoSocial { get; set; }
        public string emp_c_nomeFantasia { get; set; }
        public string emp_d_contrato { get; set; }
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
        public string emp_cid_n_codigo { get; set; }
        public string emp_est_n_codigo { get; set; }
        public string emp_c_observacao { get; set; }
        public string emp_mol_n_codigo { get; set; }
        public string emp_d_alteracao { get; set; }
        public string emp_c_usuario { get; set; }
        public string emp_d_modificacao { get; set; }
        public string emp_c_RangeRamais { get; set; }
        public string emp_c_ramais { get; set; }
        public string emp_b_ativo { get; set; }
        public string emp_fem_n_codigo { get; set; }
        public string emp_c_contatoNome1 { get; set; }
        public string emp_c_contatoEmail1 { get; set; }
        public string emp_c_contatoTelefone1 { get; set; }
        public string emp_c_contatoNome2 { get; set; }
        public string emp_c_contatoEmail2 { get; set; }
        public string emp_c_contatoTelefone2 { get; set; }
        public string emp_c_unique { get; set; }
        public string emp_d_atualizado { get; set; }
        public string emp_d_inclusao { get; set; }
        public string emp_c_RangePortas { get; set; }
        public string emp_b_tipoGaren { get; set; }
        public string emp_ace_n_codigo { get; set; }
        public string emp_ace_senha { get; set; }
        public string emp_ace_login { get; set; }
        public string emp_mol_connectSolutions { get; set; }
        public string emp_mol_connectWork { get; set; }
        public string emp_mol_connectAccess { get; set; }
        public string emp_mol_connectGuard { get; set; }
        public string emp_mol_connectView { get; set; }
        public string emp_mol_connectSync { get; set; }
        public string emp_mol_connectPro { get; set; }
        public string emp_mol_connectViewAccess { get; set; }
        public string buscaSimples { get; set; }
        public string[] listaIds { get; set; }
        public ModuloViewModel Modulo { get; set; }
        public string emp_dis_n_codigo { get; set; }


        #region Licensas
        public string QtdLicencas { get; set; }
        public string ValorLicencas { get; set; }
        public string ProxVenc { get; set; }
        public string QtdAtivos { get; set; }
        public string QtdInativos { get; set; }
        public string ControlAcess { get; set; }
        public string MonitPC { get; set; }
        public string MonitCFTV { get; set; }
        public string OS { get; set; }
        public string Sync { get; set; }
        public string accessView { get; set; }
        #endregion

    }
}
