using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class Paginacao
    {
        public int quantidade { get; set; } = 10;
        //padrao do datatable é inicial 0
        //para o pagedlist é 1
        public int pagina { get; set; }
        public int paginaDataTable { get { return pagina + 1; } }
        public int total { get; set; }
    }
}
