using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ISalaComercialCatalogoService : IRepositoryBase<tb_sca_salaComercialCatalogo>
    {
        void InserirRelacionamento(CatalogoViewModel model);
    }
}
