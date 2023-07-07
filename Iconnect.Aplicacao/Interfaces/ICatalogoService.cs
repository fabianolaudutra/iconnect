using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ICatalogoService : IRepositoryBase<tb_cal_catalogo>
    {
        public Retorno InserOrUpdate(CatalogoViewModel model);
        IPagedList<CatalogoViewModel> GetCatalogoFiltrado(CatalogoFilterModel filter);
        IPagedList<CatalogoViewModel> GetFilteredByGrupoFamiliar(CatalogoFilterModel filter);
        CatalogoViewModel GetCatalogo(int id);
        List<CatalogoViewModel> GetCatalogoByGrupo(int idGrupo);
        CatalogoViewModel GetCatalogoGrupo(int id); 
        public bool DeletarCatalogoBuyGrupoFamiliar(int idGrupo);
        public bool DeletarCatalogo(int id);
        public List<CatalogoViewModel> GetCatalogoPorCliente(int idCliente);
        object UpdateStatus(CatalogoViewModel model);
        bool validaQuantidadeCatalogos(int id);
        bool validaPrimeiroCatalogo(int idGrupo, int idCal);
    }
}
