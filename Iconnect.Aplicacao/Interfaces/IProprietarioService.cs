using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IProprietarioService : IRepositoryBase<tb_pro_proprietario>
    {
        IPagedList<ProprietarioViewModel> GetProprietarioFiltrado(ProprietarioFilterModel filter);
        public List<ProprietarioViewModel> GetProprietarios();
        public ProprietarioViewModel GetProprietario(int id);
        int SalvarProprietario(ProprietarioViewModel model);
        public bool DeletarProprietario(int id);
        byte[] GeraExcel(ProprietarioFilterModel filter);
    }
}
