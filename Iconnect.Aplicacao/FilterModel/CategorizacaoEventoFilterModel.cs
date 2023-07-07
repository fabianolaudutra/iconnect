using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class CategorizacaoEventoFilterModel : Paginacao
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string buscaSimples_filter { get; set; }
    }
}
