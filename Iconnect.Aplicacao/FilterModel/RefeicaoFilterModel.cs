using System;
using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.FilterModel
{
    public class RefeicaoFilterModel : Paginacao
    {
        public string ref_n_codigo_filter { get; set; }
        public string ref_c_nomeRefeicao_filter { get; set; }
        public string ref_d_inicio_filter { get; set; }
        public string ref_d_fim_filter { get; set; }
        public string ref_d_valor_filter { get; set; }
        public string ref_cli_n_codigo_filter { get; set; }
    }
}
