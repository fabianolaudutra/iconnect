using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using PagedList;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IResponsavelLocacaoService
    {
        void InsertOrUpdate(ResponsavelLocacaoViewModel model);
        IPagedList<ResponsavelLocacaoViewModel> GetFiltrado(ResponsavelLocacaoFilterModel filter);
        ResponsavelLocacaoViewModel Get(int id);
        ResponsavelLocacaoViewModel GetResponsavel(int id);
        bool Deletar(int id);
    }
}
