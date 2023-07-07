using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface INotificacaoService: IRepositoryBase<tb_not_notificacao>
    {
        IPagedList<NotificacaoViewModel> ListarNotificacao(NotificacaoFilterViewModel filter);
        List<NotificacaoViewModel> PrimeirasNotificacoes(int IdUsuario, int IdPerfil);
        bool UpdateStatus(NotificacaoViewModel[] model, int IdPerfil);
        bool SalvarAvisoNotificacao(AvisoViewModel model);
        bool SalvarAvisoEmpresaNotificacao(AvisoEmpresaViewModel model);
        int IdPerfil(int id);
    }
}
