using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ISolicitacaoAberturaRemotaService : IRepositoryBase<tb_sol_solicitacaoAberturaRemota>
    {
        bool SalvarSolicitacaoAberturaRemota(SolicitacaoAberturaRemotaViewModel sol);
        IPagedList<SolicitacaoAberturaRemotaViewModel> ExibirSolicitacaoAberturaRemota(SolicitacaoAberturaRemotaFilterModel filter);
        bool ExcluirSolicitacoes();
    }
}