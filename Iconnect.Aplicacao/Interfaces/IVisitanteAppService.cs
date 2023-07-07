using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IVisitanteAppService : IRepositoryBase<tb_vis_visitasApp>
    {
        public VisitasAppViewModel SalvarVisitasApp(VisitasAppViewModel model);
        bool DeleteVisita(int id);
    }
}
