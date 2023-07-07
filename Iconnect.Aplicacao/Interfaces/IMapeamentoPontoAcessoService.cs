using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;


namespace Iconnect.Aplicacao.Interfaces
{
    public interface IMapeamentoPontoAcessoService : IRepositoryBase<tb_mpc_mapeamentoPontoAcesso>
    {
        public object InsertOrUpdate(MapeamentoPontoAcessoViewModel model);
        IPagedList<MapeamentoPontoAcessoViewModel> GetMapeamentoFiltrado(MapeamentoPontoAcessoFilterModel filter);
        public MapeamentoPontoAcessoViewModel GetMapeamento(int id);
        public bool DeletarMapeamento(int id);
        bool ExcluirTemporarios();
        public bool Vincular(int id);

    }
}
