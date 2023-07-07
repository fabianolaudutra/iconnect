using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IDependenciasService : IRepositoryBase<tb_dpn_dependencias>
    {
        public void InsertOrUpdate(DependenciaViewModel model);
        IPagedList<DependenciaViewModel> GetFiltrado(DependenciaFilterModel filter);
        public DependenciaViewModel Get(int id);
        public DependenciaViewModel GetDependencia(int id);
        public void Deletar(int id);
        public RetornoFotoViewModel GetFoto(int id);
    }
}
