using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public class tb_cal_catalogo
    {
        public tb_cal_catalogo()
        {
            tb_lca_localidadeCatalogo = new HashSet<tb_lca_localidadeCatalogo>();
        }
                
        public int cal_n_codigo { get; set; }
        public int cal_scc_n_codigo { get; set; }
        public int cal_cat_n_codigo { get; set; }
        public int cal_cli_n_codigo { get; set; }
        public int? cal_lcc_n_codigoTorre { get; set; }
        public int? cal_lcc_n_codigoNumero { get; set; }
        public bool cal_b_ativo { get; set; }
        public string cal_c_nome { get; set; }
        public string cal_c_descricao { get; set; }
        public string cal_c_logoMarca { get; set; }
        public string cal_c_capa { get; set; } 
        public string cal_c_especialidade { get; set; }
        public string cal_c_telefonePrincipal { get; set; }
        public string cal_c_telefoneSecundario { get; set; }
        public string cal_c_email { get; set; }
        public string cal_c_website { get; set; }
        public string cal_c_redeSocial1 { get; set; }
        public string cal_c_redeSocial2 { get; set; }
        public Guid cal_c_unique { get; set; }
        public DateTime cal_d_atualizado { get; set; }
        public DateTime cal_d_inclusao { get; set; }
        public int? cal_grf_n_codigo { get; set; }
        public string cal_c_status { get; set; }
        public string cal_c_descricaoReprovado { get; set; }
        public int? cal_fot_n_codigo { get; set; }
        public int? cal_n_especialista { get; set; }
        public int? cal_logo_n_codigo { get; set; }

        public virtual tb_scc_subCategoriaCatalogo cal_scc_n_codigoNavigation  { get; set; }
        public virtual tb_grf_grupoFamiliar cal_grf_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_lca_localidadeCatalogo> tb_lca_localidadeCatalogo { get; set; }
        public virtual ICollection<tb_age_agenda> tb_age_agenda { get; set; }
        public virtual tb_fot_foto cal_fot_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_sca_salaComercialCatalogo> tb_sca_salaComercialCatalogo { get; set; }
        public virtual tb_mor_Morador cal_n_especialistaNavigation { get; set; }
        public virtual tb_fot_foto cal_logo_n_codigoNavigation { get; set; }
    }
}
