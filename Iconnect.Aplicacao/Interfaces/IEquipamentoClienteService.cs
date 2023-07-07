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
    public interface IEquipamentoClienteService : IRepositoryBase<tb_eqc_equipamentoCliente>
    {
        public object InsertOrUpdate(EquipamentoClienteViewModel model);
        public EquipamentoClienteViewModel GetEquipamento(int id);
        IPagedList<EquipamentoClienteViewModel> GetEquipamentoFiltrado(EquipamentoClienteFiltermodel filter);
        public bool DeletarEquipamento(int id);
        public List<GenericList> ListarCentrais(int id);
        bool ExcluirTemporarios();
        public bool Vincular(int id);
    }
}
