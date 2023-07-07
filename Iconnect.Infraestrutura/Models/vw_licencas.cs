using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class vw_licencas
    {
        public int emp_n_codigo { get; set; }
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
        public int? QtdLicencas { get; set; }
        public decimal? ValorLicencas { get; set; }
        public DateTime? ProxVenc { get; set; }
        public int? QtdAtivos { get; set; }
        public int? QtdInativos { get; set; }
        public int? ControlAcess { get; set; }
        public int? MonitPC { get; set; }
        public int? MonitCFTV { get; set; }
        public int? OS { get; set; }
        public int? Sync { get; set; }
        public int? accessView { get; set; }
    }
}
