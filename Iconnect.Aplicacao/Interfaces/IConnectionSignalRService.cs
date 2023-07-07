using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Enums;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IConnectionSignalRService : IRepositoryBase<tb_csr_connectionSignalR>
    {
        void IncluirAlterar(SaveConnectionSignalRViewModel obj, EnumHubs hub);
        void Remover(string connectionId, EnumHubs hub);
        List<string> ObterConnections(string idCliente, EnumHubs hub);
    }
}
