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
    public interface IGrupoVagasService : IRepositoryBase<tb_gpv_grupoVagas>
    {
        public IPagedList<GrupoVagasViewModel> GetGrupoVagasFiltrado(GrupoVagasFilterModel filter);
        public GrupoVagasViewModel GetGrupoVagas(int id);
        public bool SalvarGrupoVagas(GrupoVagasViewModel model);
        public bool DeletarGrupoVagas(int id);
        byte[] GeraExcel(GrupoVagasFilterModel filter);

        List<GrupoVagasViewModel> GetGrupoVagasByCliente(int id);
    }
}
