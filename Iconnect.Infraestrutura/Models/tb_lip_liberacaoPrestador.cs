using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_lip_liberacaoPrestador
    {
        public tb_lip_liberacaoPrestador()
        {
            tb_cha_chavesDeAcesso = new HashSet<tb_cha_chavesDeAcesso>();
        }

        public int lip_n_codigo { get; set; }
        public string lip_c_nome { get; set; }
        public string lip_c_celular { get; set; }
        public string lip_c_rg { get; set; }
        public DateTime? lip_d_dataHora { get; set; }
        public bool? lip_b_pendente { get; set; }
        public int lip_mor_n_codigo { get; set; }
        public int? lip_n_duracao { get; set; }
        public DateTime? lip_d_modificacao { get; set; }
        public int? lip_n_duracaoAntes { get; set; }
        public Guid lip_c_unique { get; set; }
        public DateTime lip_d_atualizado { get; set; }
        public DateTime lip_d_inclusao { get; set; }
        public bool lip_b_entrou { get; set; }
        public bool lip_b_saiu { get; set; }
        public DateTime? lip_d_dataEntrada { get; set; }
        public DateTime? lip_d_dataSaida { get; set; }
        public int lip_cac_n_codigo { get; set; }

        public virtual tb_mor_Morador lip_mor_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_cha_chavesDeAcesso> tb_cha_chavesDeAcesso { get; set; }
    }
}
