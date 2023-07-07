using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IPessoasRecintoService : IRepositoryBase<vw_pessoasRecinto>
    {
        IPagedList<PessoasRecintoViewModel> GetPessoasRecintoFiltrado(PessoasRecintoFilterModel filter);
        byte[] GeraExcel(PessoasRecintoFilterModel filter);
        PessoasRecintoViewModel GetPessoaRecinto(int id);
        bool limpaRecintoGeral(PessoasRecintoViewModel model);
        bool limpaRecintoIndividual(PessoasRecintoViewModel model);

        //List<GenericList> GetPessoasRecintosCombo(int idCliente, string usuarioLogado);
        //byte[] GeraExcel(PessoasRecintoViewModel filter);

    }
}