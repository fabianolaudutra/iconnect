using System;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_res_registroSalao
    {
        public int res_n_codigo { get; set; }
        public int? res_mor_n_codigo { get; set; }
        public int? res_dpn_n_codigo { get; set; }
        public DateTime? res_d_dataSolicitacao { get; set; }
        public string res_c_periodo { get; set; }
        public string res_c_status { get; set; }
        public string res_c_observacao { get; set; }
        public Guid res_c_unique { get; set; }
        public DateTime res_d_atualizado { get; set; }
        public DateTime res_d_inclusao { get; set; }

        public int? res_n_inUsuarioId { get; set; }
        public string res_c_inTabelaUsuario { get; set; }
        public bool res_b_lido { get; set; }
        public bool res_b_tocado { get; set; }

        public virtual tb_dpn_dependencias res_dpn_n_codigoNavigation { get; set; }
        public virtual tb_mor_Morador res_mor_n_codigoNavigation { get; set; }
    }
}
