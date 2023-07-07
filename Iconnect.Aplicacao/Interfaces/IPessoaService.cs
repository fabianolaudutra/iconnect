using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IPessoaService : IRepositoryBase<vw_pessoa>
    {
        IPagedList<PessoaViewModel> GetPessoaFiltrado(PessoaFilterModel filter);
        List<GenericList> GetPessoasCombo(int idCliente, string usuarioLogado);
        List<GenericList> GetPessoasComboFiltro(int idCliente, string usuarioLogado, string pesquisa);
        byte[] GeraExcel(PessoaFilterModel filter);
        public List<PessoaViewModel> GetRelPessoas(PessoaViewModel model);
        List<GenericList> GetPessoasComboFiltrado(int idCliente, string tipo);

    }
}