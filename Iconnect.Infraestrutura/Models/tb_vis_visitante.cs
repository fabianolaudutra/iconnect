using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_vis_visitante
    {
        public tb_vis_visitante()
        {
            tb_avv_avisoVisitante = new HashSet<tb_avv_avisoVisitante>();
            tb_cac_controleAcesso = new HashSet<tb_cac_controleAcesso>();
        }

        public int vis_n_codigo { get; set; }
        public string vis_c_nome { get; set; }
        public string vis_c_rg { get; set; }
        public string vis_c_cpf { get; set; }
        public string vis_c_celular { get; set; }
        public string vis_c_email { get; set; }
        public string vis_c_perfil { get; set; }
        public DateTime? vis_d_dataExpriracao { get; set; }
        public string vis_c_numeroCartao { get; set; }
        public string vis_c_observacao { get; set; }
        public int? vis_fot_n_codigo { get; set; }
        public int? vis_cli_n_codigo { get; set; }
        public string vis_c_localizacao { get; set; }
        public DateTime? vis_d_alteracao { get; set; }
        public string vis_c_usuario { get; set; }
        public int? vis_gpv_n_codigo { get; set; }
        public string vis_c_placaVeiculo { get; set; }
        public string vis_c_modeloVeiculo { get; set; }
        public string vis_c_corVeiculo { get; set; }
        public DateTime? vis_d_modificacao { get; set; }
        public bool? vis_b_ativoInativo { get; set; }
        public bool? vis_b_liberadoAntPassBack { get; set; }
        public int? vis_fot_n_documento { get; set; }
        public Guid vis_c_unique { get; set; }
        public DateTime vis_d_atualizado { get; set; }
        public DateTime vis_d_inclusao { get; set; }
        public bool vis_b_inOut { get; set; }
        public DateTime? vis_d_dataEntrada { get; set; }
        public int? vis_vpp_n_codigo { get; set; }
        public string vis_c_estado { get; set; }
        public string vis_c_codExternoVisitante { get; set; }

        public virtual tb_cli_cliente vis_cli_n_codigoNavigation { get; set; }
        public virtual tb_fot_foto vis_fot_n_codigoNavigation { get; set; }
        public virtual tb_fot_foto vis_fot_n_documentoNavigation { get; set; }
        public virtual tb_gpv_grupoVagas vis_gpv_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_avv_avisoVisitante> tb_avv_avisoVisitante { get; set; }
        public virtual ICollection<tb_cac_controleAcesso> tb_cac_controleAcesso { get; set; }
        public virtual tb_vpp_visitanteApp tb_vpp_visitanteApp { get; set; }
        public virtual ICollection<tb_age_agenda> tb_age_agenda { get; set; }
        public virtual ICollection<tb_aco_acompanhante> tb_aco_acompanhante { get; set; }
        public virtual ICollection<tb_liv_liberacaoVisitante> tb_liv_liberacaoVisitante { get; set; }
    }
}
