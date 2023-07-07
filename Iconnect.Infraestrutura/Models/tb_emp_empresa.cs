using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_emp_empresa
    {
        public tb_emp_empresa()
        {
            tb_avi_aviso = new HashSet<tb_avi_aviso>();
            tb_cli_cliente = new HashSet<tb_cli_cliente>();
            tb_gpp_grupoPermissaoOperador = new HashSet<tb_gpp_grupoPermissaoOperador>();
            tb_ope_operador = new HashSet<tb_ope_operador>();
            tb_par_parametrosEmpresa = new HashSet<tb_par_parametrosEmpresa>();
            tb_poa_portaAlarme = new HashSet<tb_poa_portaAlarme>();
        }

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
        public Guid emp_c_unique { get; set; }
        public DateTime emp_d_atualizado { get; set; }
        public DateTime emp_d_inclusao { get; set; }
        public string emp_c_RangePortas { get; set; }
        public bool? emp_b_tipoGaren { get; set; }
        public int? emp_dis_n_codigo { get; set; }

        public virtual ICollection<tb_ace_acesso> tb_ace_acesso { get; set; }
        public virtual tb_cid_cidade emp_cid_n_codigoNavigation { get; set; }
        public virtual tb_est_estado emp_est_n_codigoNavigation { get; set; }
        public virtual tb_fem_fotoEmpresa emp_fem_n_codigoNavigation { get; set; }
        public virtual tb_mol_modulosLiberados emp_mol_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_avi_aviso> tb_avi_aviso { get; set; }
        public virtual ICollection<tb_cli_cliente> tb_cli_cliente { get; set; }
        public virtual ICollection<tb_gpp_grupoPermissaoOperador> tb_gpp_grupoPermissaoOperador { get; set; }
        public virtual ICollection<tb_ope_operador> tb_ope_operador { get; set; }
        public virtual ICollection<tb_par_parametrosEmpresa> tb_par_parametrosEmpresa { get; set; }
        public virtual ICollection<tb_poa_portaAlarme> tb_poa_portaAlarme { get; set; }
        public virtual ICollection<tb_apa_aplicacoesAlarme> tb_apa_aplicacoesAlarme { get; set; }
        public virtual tb_dis_distribuidor tb_dis_distribuidor { get; set; }
    }
}
