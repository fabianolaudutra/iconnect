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
    public interface ISubCategoriaCatalogoService : IRepositoryBase<tb_scc_subCategoriaCatalogo>
    {
        public SubCategoriaCatalogoViewModel InserOrUpdate(SubCategoriaCatalogoViewModel model);
        IPagedList<SubCategoriaCatalogoViewModel> GetSubCategoriaCatalogoFiltrado(SubCategoriaCatalogoFilterModel filter); 
        SubCategoriaCatalogoViewModel GetSubCategoriaCatalogo(int id);
        public bool DeletarSubCategoriaCatalogo(int id);
        public List<SubCategoriaCatalogoViewModel> GetSubCategoriaCatalogoPorCliente(int idCliente);
        public List<GenericList> GetSubCategoriaCatalogoComboPorId(int id);
    }
}
