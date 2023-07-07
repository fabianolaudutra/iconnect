using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_fro_frota
    {
        public tb_fro_frota()
        {
            tb_mve_movimentacaoVeiculo = new HashSet<tb_mve_movimentacaoVeiculo>();
        }

        public int fro_n_codigo { get; set; }
        public int fro_cli_n_codigo { get; set; }
        public int fro_mav_n_codigo { get; set; }
        public string fro_c_codigoVeiculo { get; set; }
        public bool fro_b_ativo { get; set; }
        public string fro_c_modelo { get; set; }
        public string fro_c_ano { get; set; }
        public string fro_c_cor { get; set; }
        public string fro_c_placa { get; set; }
        public string fro_c_caracteristicas { get; set; }
        public DateTime? fro_d_modificacao { get; set; }
        public Guid fro_c_unique { get; set; }
        public DateTime fro_d_atualizado { get; set; }
        public DateTime fro_d_inclusao { get; set; }

        public virtual tb_cli_cliente fro_cli_n_codigoNavigation { get; set; }
        public virtual tb_mav_marcaVeiculo fro_mav_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_mve_movimentacaoVeiculo> tb_mve_movimentacaoVeiculo { get; set; }
        public virtual ICollection<tb_mor_Morador> tb_mor_Morador { get; set; }
    }
}
