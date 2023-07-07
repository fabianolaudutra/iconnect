using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IEnvioNotificacaoService : IRepositoryBase<tb_eno_envioNotificacao>
    {
        IPagedList<EnvioNotificacaoViewModel> GetEnvioNotificacaoFiltrado(EnvioNotificacaoFilterModel filter);
        public EnvioNotificacaoViewModel GetEnvioNotificacao(int id);
        int SalvarEnvioNotificacao(EnvioNotificacaoViewModel model);
        bool DeletarEnvioNotificacao(int id);
        byte[] GeraExcel(EnvioNotificacaoFilterModel filter);
    }
}