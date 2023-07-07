using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IPrestadorServicoService : IRepositoryBase<tb_pse_prestadorServico>
    {
        IPagedList<PrestadorServicoViewModel> GetPrestadorFiltrado(PrestadorServicoFilterModel filter);
        IPagedList<PrestadorServicoViewModel> GetPrestadorByFilter(PrestadorServicoFilterModel filter);
        List<PrestadorServicoViewModel> GetPrestadorServicoByCliente(int id);
        PrestadorServicoViewModel GetPrestadorServico(int id);
        int SalvarPrestadorServico(PrestadorServicoViewModel model);
        bool? AtivarDesativar(int id);
        bool Deletar(int id);
        bool salvarHoraio(PrestadorServicoViewModel model);
        IPagedList<PrestadorServicoViewModel> GetPrestadorBuscarFiltrado(PrestadorServicoFilterModel filter);
    }
}