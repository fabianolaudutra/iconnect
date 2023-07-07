using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class CatalogoViewModel
    {
        public string cal_n_codigo { get; set; }
        public string cal_scc_n_codigo { get; set; }
        public string cal_cat_n_codigo { get; set; }
        public string cal_cli_n_codigo { get; set; }
        public string cal_cat_b_solicitarEspecialidade { get; set; }
        public string cal_cat_c_nome { get; set; }       
        public string cal_scc_c_nome { get; set; }
        public string cal_lcc_n_codigoTorre { get; set; }
        public string cal_lcc_n_torre_nome { get; set; }
        public string cal_lcc_n_sala_nome { get; set; }
        public string cal_lcc_n_codigoNumero { get; set; }        
        public string cal_b_ativo { get; set; }
        public string cal_c_nome { get; set; }
        public string cal_c_descricao { get; set; }
        public string cal_c_capa { get; set; }
        public string cal_c_logoMarca { get; set; }
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
        public string Torre { get; set; }
        public string Sala { get; set; }
        public string cal_grf_n_codigo { get; set; }
        public bool exibeEspecialidade { get; set; }
        public string cal_c_status { get; set; }
        public string cal_c_descricaoReprovado { get; set; }
        public int? cal_fot_n_codigo { get; set; }
        public string cal_n_especialista { get; set; }
        public string cal_c_nomeEspecialista { get; set; }
        public string cal_logo_n_codigo { get; set; }
    }
}
