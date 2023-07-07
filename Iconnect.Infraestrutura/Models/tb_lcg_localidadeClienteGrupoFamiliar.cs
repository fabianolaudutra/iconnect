using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_lcg_localidadeClienteGrupoFamiliar
    {
        public int lcg_n_codigo { get; set; }
        public int? lcg_lcc_n_codigoBlocoQuadra { get; set; }
        public int? lcg_grf_n_codigo { get; set; }
        public DateTime? lcg_d_modificacao { get; set; }
        public Guid lcg_c_unique { get; set; }
        public DateTime lcg_d_atualizado { get; set; }
        public DateTime lcg_d_inclusao { get; set; }
        public int? lcg_lcc_n_codigoLoteApto { get; set; }
        public int lcg_n_vagas { get; set; }

        public virtual tb_grf_grupoFamiliar lcg_grf_n_codigoNavigation { get; set; }
        public virtual tb_lcc_localidadeCliente lcg_lcc_n_codigoBlocoQuadraNavigation { get; set; }
        public virtual tb_lcc_localidadeCliente lcg_lcc_n_codigoLoteAptoNavigation { get; set; }
    }
}
