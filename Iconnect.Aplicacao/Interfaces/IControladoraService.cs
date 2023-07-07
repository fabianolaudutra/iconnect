using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using Newtonsoft.Json.Linq;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IControladoraService : IRepositoryBase<tb_con_controladora>
    {
        IPagedList<ControladoraViewModel> GetControladoraFiltrado(ControladoraFilterModel filter);
        byte[] GeraExcel(ControladoraFilterModel filter);
        ControladoraViewModel GetControladora(int id);
        object SalvarControladora(ControladoraViewModel model);
        bool DeletarControladora(int id);
        bool ExcluirTodosPontosAcesso(ControladoraViewModel model);
        List<GenericList> RebindComboPorta(ControladoraViewModel model);
        List<GenericList> RebindComboFluxo(ControladoraViewModel model);
        List<ControladoraViewModel> GetControladoraByCliente(int id);
        public bool SincronizarAlteracoesPlacas(int cli_n_codigo, string sin_c_controladoras);
    }
}