using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IClienteService : IRepositoryBase<tb_cli_cliente>
    {
        public List<ClienteViewModel> ListarTodos(string ids, bool userIsAdmin = false);
        public List<ClienteViewModel> GetClientes(int id, string idsClientes);
        public List<ClienteViewModel> GetClienteEmpresarial(int id, string clientes);
        public object InsertOrUpdate(ClienteViewModel model);

        public ClienteViewModel GetCliente(int id, bool userIsAdmin = false);
        IPagedList<ClienteViewModel> GetClienteFiltrado(ClienteFilterModel filter);
        public List<TipoClienteViewModel> ListarTipos();

        public List<ClienteViewModel> GetRelClientes(EmpresaViewModel model);

        public List<ClienteViewModel> getClienteCnpj(ClienteViewModel model);

        public List<ClienteViewModel> GetRelClientesLicenca(ClienteViewModel model);
        byte[] GeraExcel(ClienteFilterModel filter);
        public object GerarCodigoReferencia();
        public bool DeletarCliente(int id);

        public object UpdateLicenca(ClienteViewModel model, string usuarioLogado);
        public object SalvarSerial(ClienteViewModel model);
        public bool RemoverLicenca(int id);
        public int? getTipo(int id);
        public ClienteTipoFlagAcessoGratuitoViewModel GetTipo_FlagAcessoGratuito(int id, bool userIsAdmin = false);
        public bool? getModulo(int id);
        public bool SalvaEmailSegTrabalho(ClienteViewModel model);
        ClienteViewModel GetClienteQR(int id);
        List<ClienteViewModel> getTipoEmpresarial();
        List<ClienteViewModel> GetComboCliente(int idEmpresa);
        List<ClienteViewModel> FiltraCliente(string id);
        ModuloViewModel GetModuloCliente(int id);
        List<ClienteViewModel> GetClienteComercial(string ids);
        public bool SalvarIdFotoFachada(ClienteViewModel model);
        List<ClienteViewModel> GetFotoFachada(int id);
        public List<ClienteViewModel> GetComboRelMovimentacaoCliente(int id);
    }
}
