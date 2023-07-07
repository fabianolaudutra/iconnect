using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IControleAcessoService : IRepositoryBase<tb_cac_controleAcesso>
    {
        IPagedList<ControleAcessoViewModel> GetControleAcessoFiltrado(ControleAcessoFilterModel filter);
        IList<Dictionary<string, string>> SalvarControleAcesso(ControleAcessoViewModel model, bool validarDuplicidade = false);
        bool DeletarControleAcesso(int id);
        bool DeletarControleAcessoSemPessoa();
        bool VincularAcessos(int idPessoa, string tipoPessoa);
      
        int SolicitacaoBiometria(string idCliente, string idControladora);
        IList<Dictionary<string, string>> CarregaComboDispositivoBiometrico(int cli_n_codigo);
        string GetImagemBiometria(int idBiometria);
        bool DeleteComSincronizacao(int id);

        bool GerarQrCodeLiberacaoApp(int id);
        string Criptografar(string parametro);
        string Descriptografar(string parametro);
        ControleAcessoViewModel GetAcessoByGuid(string guid);
        ControleAcessoViewModel GetAcessoVisitanteQR(int id);
    }
}