using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IAvisoEmpresaService : IRepositoryBase<tb_avi_avisoEmpresa>
    {
        IPagedList<AvisoEmpresaViewModel> GetAvisoEmpresaFiltrado(AvisoEmpresaFilterModel filter);
        AvisoEmpresaViewModel GetAvisoEmpresa(int id);
        int SalvarAvisoEmpresa(AvisoEmpresaViewModel model);
        bool DeletarAvisoEmpresa(int id);
        byte[] GeraExcel(AvisoEmpresaFilterModel filter);
    }
}