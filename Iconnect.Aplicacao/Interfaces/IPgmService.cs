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
    public interface IPgmService : IRepositoryBase<tb_pgc_pgmCliente>
    {
        IPagedList<PgcViewModel> GetPgcFiltrado(PgcFiltermodel filter);

        public List<GenericList> ListarPgm(int id);
        public object InsertOrUpdate(PgcViewModel model);

        public PgcViewModel GetPgc(int id);
        public bool DeletarPgc(int id);

        public List<PgcViewModel> GetPgcByEquipamento(int idEquipamento);

    }
}
