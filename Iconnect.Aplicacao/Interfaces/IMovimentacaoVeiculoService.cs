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
    public interface IMovimentacaoVeiculoService : IRepositoryBase<tb_mve_movimentacaoVeiculo>
    {
        public object SalvarMovimentacao(MovimentacaoVeiculoViewModel model, string usuarioLogado);
        IPagedList<MovimentacaoVeiculoViewModel> GetMovimentacaoFiltrado(MovimentacaoVeiculoFilterModel filter);
        public object GetUltimaMovimentacao(int id);
        public bool DeletarMovimentacao(int id);
        public List<RelatorioMovimentacao> RelatorioAnalitico(MovimentacaoVeiculoViewModel model);
        public List<RelatorioMovimentacao> RelatorioMacro(MovimentacaoVeiculoViewModel model);
    }
}
