using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ICabecalhoLayoutService : IRepositoryBase<tb_cla_cabecalhoLayout>
    {
        public List<GenericList> ListarLayout(int codigo);
        public List<GenericList> ListarCanais(int codigo);
        public List<CanalLayoutViewModel> ListarCanaisByLayout(int codigo);
        

        public List<CanalLayoutViewModel> ListarCanaisByDispositivo(CabecalhoLayoutViewModel model);

        public List<CanalLayoutViewModel> ListarDispositivoCanal(int codigo);

        public object InsertOrUpdate(CabecalhoLayoutViewModel model);
        IPagedList<CabecalhoLayoutViewModel> GetLayoutFiltrado(CabecalhoLayoutFilterModel filter);
        public CabecalhoLayoutViewModel GetLayout(int id);
        public List<CabecalhoLayoutViewModel> GetLayoutPadrao(int id);
        public List<CabecalhoLayoutViewModel> GetLayoutPadraoFiltered(int id);
        
        public bool DeletarLayout(int id);
        public List<CabecalhoLayoutViewModel> GetLayoutGuardByCliente(int id);
        public List<CabecalhoLayoutViewModel> GetLayoutGuardByLayout(int id);
        public IEnumerable<CabecalhoLayoutViewModel> GetLayoutsGuardModalByCliente(int id);
        public IEnumerable<CabecalhoLayoutViewModel> GetLayoutsViewModalByCliente(int id);
    }
}