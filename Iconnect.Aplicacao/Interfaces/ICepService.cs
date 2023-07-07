using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ICepService
    {
        public CepVielModel BuscaCep(string cep);
    }


}
