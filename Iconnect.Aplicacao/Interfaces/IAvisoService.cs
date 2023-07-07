using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IAvisoService : IRepositoryBase<tb_avi_aviso>
    {
        IPagedList<AvisoViewModel> GetAvisoFiltrado(AvisoFilterModel filter);
        AvisoViewModel GetAviso(int id);
        int SalvarAviso(AvisoViewModel model);
        bool DeletarAviso(int id);
        byte[] GeraExcel(AvisoFilterModel filter);
    }
}