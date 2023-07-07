using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class PagedResponse<T> where T : class
    {
        public int Total { get; set; }
        public T Data { get; set; }
    }
}
