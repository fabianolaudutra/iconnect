using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IAgenteComercialService : IRepositoryBase<tb_age_agenteComercial>
    {
        int InsertOrUpdate(AgenteComercialViewModel model);
        IPagedList<AgenteComercialViewModel> GetFiltrado(AgenteComercialFilterModel filter);
        object Deletar(int id);
        AgenteComercialViewModel GetAgenteComercial(int id);
        byte[] GerarExcel(AgenteComercialFilterModel filter);
    }
}
