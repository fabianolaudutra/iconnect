using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IAcessoService : IRepositoryBase<tb_ace_acesso>
    {
        public UsuarioViewModel Logar(string usuario, string senha);
        public UsuarioViewModel Find(int id);
        public AcessoViewModel InsertOrUpdate(AcessoViewModel model);
        IPagedList<AcessoViewModel> GetAcessoFiltrado(AcessoFilterModel filter);
        public AcessoViewModel GetAcesso(int id);
        public List<AcessoViewModel> GetAllAcessos();        
        public bool DeletarAcesso(int id);
        public bool ValidaUsuario (string usuario, string codigo);
        public bool ExcluirTemporarios();
        public object EsqueciSenha(UsuarioViewModel model);
        bool VincularAcessoAEmpresa(int? empresaId);
        bool VincularAcessoADistribuidor(int? distribuidorId);
    }
}
