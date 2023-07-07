using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class RacaFilterModel : Paginacao
    {
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string buscaSimples_filter { get; set; }
    }
}
