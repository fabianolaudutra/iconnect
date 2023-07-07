using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;


namespace Iconnect.Aplicacao.Interfaces
{
    public interface ICategoriaCatalogoService : IRepositoryBase<tb_cat_categoriaCatalogo>
    {
        public CategoriaCatalogoViewModel InserOrUpdate(CategoriaCatalogoViewModel model);
        IPagedList<CategoriaCatalogoViewModel> GetCategoriaCatalogoFiltrado(CategoriaCatalogoFilterModel filter); 
        CategoriaCatalogoViewModel GetCategoriaCatalogo(int id);
        public bool DeletarCategoriaCatalogo(int id);
        public List<CategoriaCatalogoViewModel> GetCategoriaCatalogoPorCliente(int idCliente);
        public List<GenericList> GetCatalogoSemLink(int id);
        public List<CategoriaCatalogoViewModel> GetComboCatalogoSemLink(int id);
        
        public List<GenericList> GetCategoriaCatalogoComboPorId(int id); 
    }
}
