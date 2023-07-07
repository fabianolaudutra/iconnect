
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
    public interface IPontosAcessoService : IRepositoryBase<tb_pta_pontosAcesso>
    {
        IPagedList<PontosAcessoViewModel> GetPontosAcessoFiltrado(PontosAcessoFilterModel filter);
        List<GenericList> ListarPontosAcesso(int id);
        bool SalvarPontosAcesso(PontosAcessoViewModel model);
        bool DeletarPontosAcesso(int id);
        bool DeletarPontosAcessoSemControladora();
        bool VincularPontoAcesso(int idPontoAcesso, int? idCliente);
        List<GenericList> pontoEntrada(int cliente);
        List<GenericList> pontoSaida(int cliente);

    }
}
