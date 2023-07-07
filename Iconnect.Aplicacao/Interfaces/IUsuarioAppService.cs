using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IUsuarioAppService : IRepositoryBase<tb_usu_UsuarioApp>
    {
        IPagedList<UsuarioAppViewModel> GetUsuarioAppFiltrado(UsuarioAppFilterModel filter);
        UsuarioAppViewModel GetLiberacoesUsuario(int id);
        bool SalvarLiberacoesUsuario(UsuarioAppViewModel model);
        bool deleteUsuario(int id);
        UsuarioAppViewModel GetLiberacaoAtualizacaoGrid(int clienteId);
    }
}
