using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class TopicosFilterModel : Paginacao
    {
        public string tpc_n_codigo_filter { get; set; }
        public string tpc_c_descricao_filter { get; set; }
    }
}
