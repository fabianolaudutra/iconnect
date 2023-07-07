using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;


namespace Iconnect.Aplicacao.Interfaces
{
    public interface IHistoricoLiberacaoService : IRepositoryBase<tb_hil_historicoLiberacao>
    {
        public bool SalvarHistorico(HistoricoLiberacaoViewModel model);
    }
}
