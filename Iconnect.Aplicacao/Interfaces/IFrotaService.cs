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
    public interface IFrotaService : IRepositoryBase<tb_fro_frota>
    {
        IPagedList<FrotaViewModel> GetVeiculoFiltrado(FrotaFilterModel filter);
        public bool SalvarVeiculo(FrotaViewModel model);
        public FrotaViewModel GetVeiculo(int id);
        public bool DeletarVeiculo(int id);
        List<GenericList> GetByCliente(int id);

        byte[] GeraExcel(FrotaFilterModel filter);
        IPagedList<FrotaViewModel> GetVeiculoBuscarFiltrado(FrotaFilterModel filter);

    }
}
