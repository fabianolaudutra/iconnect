using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_mor_Morador
    {
        public tb_mor_Morador()
        {
            tb_avi_avisoMorador = new HashSet<tb_avi_avisoMorador>();
            tb_cac_controleAcesso = new HashSet<tb_cac_controleAcesso>();
            tb_hil_historicoLiberacao = new HashSet<tb_hil_historicoLiberacao>();
            tb_lid_liberacaoDelivery = new HashSet<tb_lid_liberacaoDelivery>();
            tb_lip_liberacaoPrestador = new HashSet<tb_lip_liberacaoPrestador>();
            tb_liv_liberacaoVisitante = new HashSet<tb_liv_liberacaoVisitante>();
            tb_pan_panicoApp = new HashSet<tb_pan_panicoApp>();
            tb_res_registroSalao = new HashSet<tb_res_registroSalao>();
            tb_soz_solicitarZelador = new HashSet<tb_soz_solicitarZelador>();
            tb_upe_usuarioAPPpermissao = new HashSet<tb_upe_usuarioAPPpermissao>();
            tb_usu_UsuarioApp = new HashSet<tb_usu_UsuarioApp>();
            tb_vis_visitasApp = new HashSet<tb_vis_visitasApp>();
            tb_zec_zeladorCliente = new HashSet<tb_zec_zeladorCliente>();
            tb_afa_afastamento = new HashSet<tb_afa_afastamento>();
            tb_mve_movimentacaoVeiculo = new HashSet<tb_mve_movimentacaoVeiculo>();
            tb_dmo_documentoMorador = new HashSet<tb_dmo_documentoMorador>();
        }

        public int mor_n_codigo { get; set; }
        public string mor_c_nome { get; set; }
        public string mor_c_rg { get; set; }
        public string mor_c_cpf { get; set; }
        public DateTime? mor_d_dataNascimento { get; set; }
        public string mor_c_email { get; set; }
        public string mor_c_telefonePermitido { get; set; }
        public string mor_c_celular { get; set; }
        public string mor_c_ramal { get; set; }
        public string mor_c_perfil { get; set; }
        public string mor_c_observacao { get; set; }
        public bool? mor_b_ativoInativo { get; set; }
        public int? mor_fot_n_codigo { get; set; }
        public int? mor_cli_n_codigo { get; set; }
        public int? mor_grf_n_codigo { get; set; }
        public bool? mor_b_antpassback { get; set; }
        public DateTime? mor_d_alteracao { get; set; }
        public string mor_c_usuario { get; set; }
        public string mor_c_autorizacao { get; set; }
        public DateTime? mor_d_modificacao { get; set; }
        public bool? mor_b_notificacao { get; set; }
        public bool? mor_b_liberadoAntPassBack { get; set; }
        public string mor_c_senha { get; set; }
        public string mor_c_contraSenha { get; set; }
        public int? mor_fot_n_documento { get; set; }
        public Guid mor_c_unique { get; set; }
        public DateTime mor_d_atualizado { get; set; }
        public DateTime mor_d_inclusao { get; set; }
        public bool? mor_b_sindico { get; set; }
        public string mor_c_senhaAPPPro { get; set; }
        public string mor_c_autorizacaoPRO { get; set; }
        public bool mor_b_inOut { get; set; }
        public DateTime? mor_d_dataEntrada { get; set; }
        public string mor_c_codExternoFuncionario { get; set; }
        public DateTime? mor_d_dataInclusaoIntegracao { get; set; }
        public string mor_c_estado { get; set; }
        public int? mor_vec_n_codigo { get; set; }
        public int? mor_fro_n_codigo { get; set; }

        public virtual tb_cli_cliente mor_cli_n_codigoNavigation { get; set; }
        public virtual tb_fot_foto mor_fot_n_codigoNavigation { get; set; }
        public virtual tb_fot_foto mor_fot_n_documentoNavigation { get; set; }
        public virtual tb_grf_grupoFamiliar mor_grf_n_codigoNavigation { get; set; }
        public virtual tb_vec_veiculo mor_vec_n_codigoNavigation { get; set; }
        public virtual tb_fro_frota mor_fro_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_avi_avisoMorador> tb_avi_avisoMorador { get; set; }
        public virtual ICollection<tb_cac_controleAcesso> tb_cac_controleAcesso { get; set; }
        public virtual ICollection<tb_hil_historicoLiberacao> tb_hil_historicoLiberacao { get; set; }
        public virtual ICollection<tb_lid_liberacaoDelivery> tb_lid_liberacaoDelivery { get; set; }
        public virtual ICollection<tb_lip_liberacaoPrestador> tb_lip_liberacaoPrestador { get; set; }
        public virtual ICollection<tb_liv_liberacaoVisitante> tb_liv_liberacaoVisitante { get; set; }
        public virtual ICollection<tb_pan_panicoApp> tb_pan_panicoApp { get; set; }
        public virtual ICollection<tb_res_registroSalao> tb_res_registroSalao { get; set; }
        public virtual ICollection<tb_soz_solicitarZelador> tb_soz_solicitarZelador { get; set; }
        public virtual ICollection<tb_upe_usuarioAPPpermissao> tb_upe_usuarioAPPpermissao { get; set; }
        public virtual ICollection<tb_usu_UsuarioApp> tb_usu_UsuarioApp { get; set; }
        public virtual ICollection<tb_vis_visitasApp> tb_vis_visitasApp { get; set; }
        public virtual ICollection<tb_zec_zeladorCliente> tb_zec_zeladorCliente { get; set; }
        public virtual ICollection<tb_afa_afastamento> tb_afa_afastamento { get; set; }
        public virtual ICollection<tb_mve_movimentacaoVeiculo> tb_mve_movimentacaoVeiculo { get; set; }
        public virtual ICollection<tb_dmo_documentoMorador> tb_dmo_documentoMorador { get; set; }
        public virtual ICollection<tb_usc_usuarioSalaComercial> tb_usc_usuarioSalaComercial { get; set; }
        public virtual ICollection<tb_age_agenda> tb_age_agenda { get; set; }
        public virtual ICollection<tb_cal_catalogo> tb_cal_catalogo { get; set; }
    }
}
