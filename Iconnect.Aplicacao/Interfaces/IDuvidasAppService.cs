using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Services;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
   public interface IDuvidasAppService : IRepositoryBase<tb_dva_duvidasApp>
    {
        public DuvidasAppViewModel InsertOrUpdate(DuvidasAppViewModel model);
        IPagedList<DuvidasAppViewModel> GetDuvidasFiltrado(DuvidasAppFilterModel filter);
        public DuvidasAppViewModel GetDuvida(int id);
        public bool DeletarDuvida(int id);
        bool ExcluirTemporarios();
        public bool Vincular(int id);
        public List<DuvidasAppViewModel> GetDuvidasByCliente(int idCliente);
    }
}