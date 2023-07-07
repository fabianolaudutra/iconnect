using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IMarcaVeiculoService : IRepositoryBase<tb_mav_marcaVeiculo>
    {
        IPagedList<MarcaVeiculoViewModel> GetMarcaVeiculoFiltrado(MarcaVeiculoFilterModel filter);
        MarcaVeiculoViewModel GetMarcaVeiculo(int id);
        int SalvarMarcaVeiculo(MarcaVeiculoViewModel model);
        bool DeletarMarcaVeiculo(int id);
        byte[] GeraExcel(MarcaVeiculoFilterModel filter);
        public List<MarcaVeiculoViewModel> GetAll();
    }
}
