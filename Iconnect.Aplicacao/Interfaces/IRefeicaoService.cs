using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IRefeicaoService : IRepositoryBase<tb_ref_refeicao>
    {
        IPagedList<RefeicaoViewModel> GetFiltrado(RefeicaoFilterModel filter);
        object InsertOrUpdate(RefeicaoViewModel model);
        bool DeletarRefeicao(int id);
    }
}
