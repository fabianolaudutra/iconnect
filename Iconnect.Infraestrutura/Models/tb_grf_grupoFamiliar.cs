using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_grf_grupoFamiliar
    {
        public tb_grf_grupoFamiliar()
        {
            tb_avg_avisoGrupoFamiliar = new HashSet<tb_avg_avisoGrupoFamiliar>();
            tb_lcg_localidadeClienteGrupoFamiliar = new HashSet<tb_lcg_localidadeClienteGrupoFamiliar>();
            tb_mor_Morador = new HashSet<tb_mor_Morador>();
            tb_pet_pet = new HashSet<tb_pet_pet>();
            tb_vec_veiculo = new HashSet<tb_vec_veiculo>();
            tb_cde_cadastro_entregas = new HashSet<tb_cde_cadastro_entregas>();
        }

        public int grf_n_codigo { get; set; }
        public string grf_c_status { get; set; }
        public string grf_c_tipo { get; set; }
        public string grf_c_nomeResponsavel { get; set; }
        public string grf_c_rg { get; set; }
        public string grf_c_cpf { get; set; }
        public string grf_c_telefone { get; set; }
        public string grf_c_email { get; set; }
        public string grf_c_numeroVagas { get; set; }
        public string grf_c_BlocoQuadra { get; set; }
        public string grf_c_LoteApto { get; set; }
        public string grf_c_observacao { get; set; }
        public string grf_c_celular { get; set; }
        public int? grf_fot_n_codigo { get; set; }
        public int? grf_cli_n_codigo { get; set; }
        public DateTime? grf_d_alteracao { get; set; }
        public string grf_c_usuario { get; set; }
        public DateTime? grf_d_modificacao { get; set; }
        public Guid grf_c_unique { get; set; }
        public DateTime grf_d_atualizado { get; set; }
        public DateTime grf_d_inclusao { get; set; }
        public string grf_c_senhaApp { get; set; }
        public int? grf_n_ramal { get; set; }
        public string grf_c_autorizacaoPRO { get; set; }
        public bool? grf_b_permiteHomeCare { get; set; }
        public string grf_c_canal_principal { get; set; }
        public string grf_c_observacoesHomeCare { get; set; }
        public int? grf_ace_n_codigo { get; set; }
        public string grf_c_nomeSalaComercial { get; set; }
        public string grf_c_estado { get; set; }

        public virtual tb_ace_acesso grf_ace_n_codigoNavigation { get; set; }
        public virtual tb_cli_cliente grf_cli_n_codigoNavigation { get; set; }
        public virtual tb_fot_foto grf_fot_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_avg_avisoGrupoFamiliar> tb_avg_avisoGrupoFamiliar { get; set; }
        public virtual ICollection<tb_lcg_localidadeClienteGrupoFamiliar> tb_lcg_localidadeClienteGrupoFamiliar { get; set; }
        public virtual ICollection<tb_mor_Morador> tb_mor_Morador { get; set; }
        public virtual ICollection<tb_pet_pet> tb_pet_pet { get; set; }
        public virtual ICollection<tb_vec_veiculo> tb_vec_veiculo { get; set; }
        public virtual ICollection<tb_cde_cadastro_entregas> tb_cde_cadastro_entregas { get; set; }
        public virtual ICollection<tb_cal_catalogo> tb_cal_catalogo { get; set; }
        public virtual ICollection<tb_age_agenda> tb_age_agenda { get; set; }
        public virtual ICollection<tb_usc_usuarioSalaComercial> tb_usc_usuarioSalaComercial { get; set; }
        public virtual ICollection<tb_sca_salaComercialCatalogo> tb_sca_salaComercialCatalogo { get; set; }
    }
}
