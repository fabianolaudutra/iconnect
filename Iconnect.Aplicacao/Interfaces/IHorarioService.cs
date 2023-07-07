
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
    public interface IHorarioService : IRepositoryBase<tb_hor_horario>
    {
        IPagedList<HorarioViewModel> GetHorarioFiltrado(HorarioFilterModel filter);
        bool SalvarHorario(HorarioViewModel model);
        bool DeletarHorario(int id);
        List<GenericList> ListarHorarios(int id);
    }
}
