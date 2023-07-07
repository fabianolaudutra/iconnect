using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_pse_prestadorServico
    {
        public tb_pse_prestadorServico()
        {
            tb_avp_avisoPrestador = new HashSet<tb_avp_avisoPrestador>();
            tb_cac_controleAcesso = new HashSet<tb_cac_controleAcesso>();
        }

        public int pse_n_codigo { get; set; }
        public string pse_c_nome { get; set; }
        public string pse_c_rg { get; set; }
        public string pse_c_cpf { get; set; }
        public string pse_c_celular { get; set; }
        public string pse_c_email { get; set; }
        public string pse_c_perfil { get; set; }
        public DateTime? pse_d_dataExpriracao { get; set; }
        public string pse_c_numeroCartao { get; set; }
        public string pse_c_localizacao { get; set; }
        public string pse_c_observacao { get; set; }
        public int? pse_fot_n_codigo { get; set; }
        public int? pse_cli_n_codigo { get; set; }
        public DateTime? pse_d_alteracao { get; set; }
        public string pse_c_usuario { get; set; }
        public int? pse_gpv_n_codigo { get; set; }
        public string pse_c_placaVeiculo { get; set; }
        public string pse_c_modeloVeiculo { get; set; }
        public string pse_c_corVeiculo { get; set; }
        public DateTime? pse_d_modificacao { get; set; }
        public bool? pse_b_ativoInativo { get; set; }
        public bool? pse_b_liberadoAntPassBack { get; set; }
        public int? pse_fot_n_documento { get; set; }
        public Guid pse_c_unique { get; set; }
        public DateTime pse_d_atualizado { get; set; }
        public DateTime pse_d_inclusao { get; set; }
        public bool pse_b_inOut { get; set; }
        public DateTime? pse_d_dataEntrada { get; set; }
        public DateTime? pse_d_dataSaidaManual { get; set; }
        public bool? pse_b_panicoTratado { get; set; }
        public int? pse_n_horarioAdicional { get; set; }
        public bool pse_b_gerou_atendimento { get; set; }
        public string pse_c_estado { get; set; }
        public string pse_c_codExternoPrestador { get; set; }

        public virtual tb_cli_cliente pse_cli_n_codigoNavigation { get; set; }
        public virtual tb_fot_foto pse_fot_n_codigoNavigation { get; set; }
        public virtual tb_fot_foto pse_fot_n_documentoNavigation { get; set; }
        public virtual tb_gpv_grupoVagas pse_gpv_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_avp_avisoPrestador> tb_avp_avisoPrestador { get; set; }
        public virtual ICollection<tb_cac_controleAcesso> tb_cac_controleAcesso { get; set; }
    }
}
