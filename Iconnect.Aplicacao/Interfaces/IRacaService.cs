using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IRacaService : IRepositoryBase<tb_rac_raca>
    {
        IPagedList<RacaViewModel> GetRacaFiltrado(RacaFilterModel filter);
        byte[] GeraExcel(RacaFilterModel filter);
        RacaViewModel GetRaca(int id);
        int SalvarRaca(RacaViewModel model);
        bool DeletarRaca(int id);
        List<RacaViewModel> GetAllRaca();
    }
}
