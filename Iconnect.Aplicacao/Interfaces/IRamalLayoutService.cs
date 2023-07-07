using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IRamalLayoutService : IRepositoryBase<tb_ral_ramalLayout>
    {
        public object InsertOrUpdate(RamalLayoutViewModel model);
        IPagedList<RamalLayoutViewModel> GetRamalLayoutFiltrado(RamalLayoutFilterModel filter);
        public RamalLayoutViewModel GetRamalLayout(int id);
        public bool DeletarRamalLayout(int id);

    }
}