using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_con_controladora
    {
        public tb_con_controladora()
        {
            tb_bio_biometria = new HashSet<tb_bio_biometria>();
            tb_cac_controleAplicacoesCliente = new HashSet<tb_cac_controleAplicacoesCliente>();
            tb_cae_controleAcessoExcluido = new HashSet<tb_cae_controleAcessoExcluido>();
            tb_hdi_historicoDispositivo = new HashSet<tb_hdi_historicoDispositivo>();
            tb_pta_pontosAcesso = new HashSet<tb_pta_pontosAcesso>();
        }

        public int con_n_codigo { get; set; }
        public string con_c_nome { get; set; }
        public string con_c_modelo { get; set; }
        public string con_c_ip { get; set; }
        public string con_c_porta { get; set; }
        public string con_c_dominioDDNS { get; set; }
        public string con_c_usuario { get; set; }
        public string con_c_senha { get; set; }
        public int? con_cli_n_codigo { get; set; }
        public DateTime? con_d_ultimoContato { get; set; }
        public DateTime? con_d_alteracao { get; set; }
        public string con_c_usuarioAlteracao { get; set; }
        public int? con_n_h { get; set; }
        public DateTime? con_d_modificacao { get; set; }
        public bool? con_b_online { get; set; }
        public Guid con_c_unique { get; set; }
        public DateTime con_d_atualizado { get; set; }
        public DateTime con_d_inclusao { get; set; }
        public string con_c_perfis { get; set; }
        public bool? con_b_ativo { get; set; }
        public bool con_b_gerouAtendimento { get; set; }
        public int? con_n_quantidadePortas { get; set; }
        public int? con_pta_n_codigo { get; set; }

        public virtual tb_cli_cliente con_cli_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_bio_biometria> tb_bio_biometria { get; set; }
        public virtual ICollection<tb_cac_controleAplicacoesCliente> tb_cac_controleAplicacoesCliente { get; set; }
        public virtual ICollection<tb_cae_controleAcessoExcluido> tb_cae_controleAcessoExcluido { get; set; }
        public virtual ICollection<tb_hdi_historicoDispositivo> tb_hdi_historicoDispositivo { get; set; }
        public virtual ICollection<tb_pta_pontosAcesso> tb_pta_pontosAcesso { get; set; }
        public virtual ICollection<tb_fzk_tabelaHorarioFacialZK> tb_fzk_tabelaHorarioFacialZK { get; set; }
        public virtual ICollection<tb_gzk_grupoTabelaHorarioFacialZK> tb_gzk_grupoTabelaHorarioFacialZK { get; set; }
    }
}
