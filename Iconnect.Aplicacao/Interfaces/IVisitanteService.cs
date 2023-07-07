using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IVisitanteService : IRepositoryBase<tb_vis_visitante>
    {
        IPagedList<VisitanteViewModel> GetVisitanteFiltrado(VisitanteFilterModel filter);
        List<VisitanteViewModel> GetVisitantesByCliente(int id);
        VisitanteViewModel GetVisitante(int id);
        int SalvarVisitante(VisitanteViewModel model);
        bool? AtivarDesativar(int id);
        bool Deletar(int id);
        VisitanteViewModel GetVisitanteCPF(VisitanteViewModel model);
        IPagedList<VisitanteViewModel> GetVisitanteBuscarFiltrado(VisitanteFilterModel filter);
    }
}