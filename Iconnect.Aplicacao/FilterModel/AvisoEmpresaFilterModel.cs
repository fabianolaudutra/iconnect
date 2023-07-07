using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class AvisoEmpresaFilterModel : Paginacao
    {
        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public string Titulo { get; set; }

        public string Status { get; set; }
        public string buscaSimples_filter { get; set; }
        public string distribuidor { get; set; }
    }
}