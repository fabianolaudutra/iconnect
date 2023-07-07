using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IInformacoesClienteService : IRepositoryBase<tb_inc_informacoesCliente>
    {
        IPagedList<InformacoesClienteViewModel> GetInformacoesClienteFiltrado(InformacoesClienteFilterModel filter);

        InformacoesClienteViewModel GetInformacoesCliente(int id);

        bool SalvarInformacoesCliente(InformacoesClienteViewModel model);
    }
}