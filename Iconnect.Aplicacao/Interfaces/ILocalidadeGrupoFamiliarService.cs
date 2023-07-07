using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ILocalidadeGrupoFamiliarService : IRepositoryBase<tb_lcg_localidadeClienteGrupoFamiliar>
    {
        public object SalvarLocalidade(LocalidadeGrupoFamiliarViewModel model);
        IPagedList<LocalidadeGrupoFamiliarViewModel> GetLocalidade(LocalidadeGrupoFamiliarFilterModel filter);
        public bool DeletarLocalidade(int id);
        public bool VincularGrupoFamiliar(int id);
        public bool verificaLocalidade(int idGrupoFamiliar, int idCliente);
        public bool DeletarLocalidadeSemGrupo();
    }
}
