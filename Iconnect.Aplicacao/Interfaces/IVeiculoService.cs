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
    public interface IVeiculoService : IRepositoryBase<tb_vec_veiculo>
    {
        IPagedList<VeiculoViewModel> GetVeiculoFiltrado(VeiculoFilterModel filter);
        
        public bool SalvarVeiculo(VeiculoViewModel model);

        public bool DeletarVeiculo(int id);

        public bool DeletarVeiculoSemGrupo();

        public bool VincularVeiculos(int idGrupo);
        IPagedList<VeiculoViewModel> GetVeiculoBuscarFiltrado(VeiculoFilterModel filter);
        List<VeiculoViewModel> GetVeiculoGrupoFamiliar(int idGrupo);
    }
}