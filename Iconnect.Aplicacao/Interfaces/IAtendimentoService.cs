using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IAtendimentoService : IRepositoryBase<tb_ate_atendimento>
    {
        public AtendimentoViewModel GetTotalizadoresSolution(AtendimentoFilterModel filter, string idClientes);
        public Retorno FinalizarAtendimento(AtendimentoViewModel model);
        public object CancelarAtendimento(AtendimentoViewModel model);
        public object AlterarStatusAtendimento(AtendimentoViewModel model);
        public AtendimentoViewModel ListarClientesSolution(AtendimentoFilterModel filter);
        public Retorno TransferirAtendimento(AtendimentoViewModel model, string perfil);
        public object FinalizarAtendimentosRecinto(string idsAtendimento);
        
    }
}