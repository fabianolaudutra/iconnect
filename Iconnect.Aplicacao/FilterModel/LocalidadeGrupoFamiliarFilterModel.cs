using System;
using System.Collections.Generic;
using System.Text;
using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class LocalidadeGrupoFamiliarFilterModel : Paginacao
    {
        public string lcg_n_codigo_filter { get; set; }
        public string lcg_grf_n_codigo_filter { get; set; }
        public string lcg_lcc_n_codigoBlocoQuadra_filter { get; set; }
        public string lcg_lcc_n_codigoLoteApto_filter { get; set; }
        public string lcg_n_vagas_filter { get; set; }
        public string idCliente_filter { get; set; }
    }
}
