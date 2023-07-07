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
    public interface IAfastamentoService : IRepositoryBase<tb_afa_afastamento>
    {
        public object InsertOrUpdate(AfastamentoViewModel model);
        public object InsertOrUpdateByGrupo(AfastamentoViewModel model);

        IPagedList<AfastamentoViewModel> GetFiltrado(AfastamentoFilterModel filter);
        public bool Deletar(int id);
        public AfastamentoViewModel GetAfastamento(int id);
        public List<AfastamentoViewModel> GetAfastamentoRel(AfastamentoViewModel model);

    }
}
