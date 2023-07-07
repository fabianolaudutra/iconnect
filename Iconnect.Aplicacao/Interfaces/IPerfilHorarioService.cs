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
    public interface IPerfilHorarioService : IRepositoryBase<tb_phr_perfilHorario>
    {
        List<PerfilHorarioViewModel> GetPerfilHorarioByCliente(int idCliente, string tipoPessoa);
        List<PerfilHorarioViewModel> GetPerfilHorarioFilter(int idCliente);
        List<PerfilHorarioViewModel> GetPerfilHorarioByClienteFiltrado(int idCliente);
        IPagedList<PerfilHorarioViewModel> GetPerfilHorarioFiltrado(PerfilHorarioFilterModel filter);
        bool SalvarPerfilHorario(PerfilHorarioViewModel model);
        bool DeletarPerfilHorario(int id);
        PerfilHorarioViewModel GetPerfilHorario(string idPerfil);
    }
}