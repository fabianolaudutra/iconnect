using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;


namespace Iconnect.Aplicacao.Interfaces
{
    public interface IZoneamentoClienteService : IRepositoryBase<tb_zoc_zoneamentoCliente>
    {
        public ZoneamentoClienteViewModel InsertOrUpdate(ZoneamentoClienteViewModel model);
        IPagedList<ZoneamentoClienteViewModel> GetZoneamentoFiltrado(ZoneamentoClienteFilterModel filter);
        public ZoneamentoClienteViewModel GetZoneamento(int id);
        public bool DeletarZoneamento(int id);
        bool ExcluirTemporarios();
        public bool Vincular(int id);


    }
}
