using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IMoradorService : IRepositoryBase<tb_mor_Morador>
    {
        IPagedList<MoradorViewModel> GetMoradorFiltrado(MoradorFilterModel filter);
        List<MoradorViewModel> GetMoradores();
        List<MoradorViewModel> GetMoradoresByGrupoFamiliar(int idGrupoFamiliar);
        List<MoradorViewModel> GetMoradoresBySalaComercial(int idSala);
        List<MoradorViewModel> GetFuncionariosByCliente(int id);
        List<MoradorViewModel> GetMoradoresByCliente(int id);
        MoradorViewModel GetMorador(int id);
        int SalvarMorador(MoradorViewModel model);
        bool? AtivarDesativar(int id);
        void Deletar(int id);
        List<MoradorViewModel> GetFuncionariosAtivosByCliente(int id);
        IPagedList<MoradorViewModel> GetMoradorBuscarFiltrado(MoradorFilterModel filter);
    }
}