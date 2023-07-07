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
    public interface IAgendaService : IRepositoryBase<tb_age_agenda>
    {
        public void SalvarAgendamento(AgendaViewModel model, string usuarioLogado);
        public List<AgendaViewModel> GetAllAgenda(int id);
        public bool DeletarAgendamento(int id);
        public AgendaViewModel GetAgenda(int id);
        AgendaViewModel GetProximoDisponivel(AgendaViewModel model);
        List<int> AgendamentosVisitante(int id);
    }
}
