using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Enums;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    public class ConnectionSignalRService : RepositoryBase<tb_csr_connectionSignalR>, IConnectionSignalRService
    {
        private readonly IconnectCoreContext _context;

        public ConnectionSignalRService(IconnectCoreContext context) : base(context)
        {
            _context = context;
        }

        public List<string> ObterConnections(string idCliente, EnumHubs hub)
        {
            int.TryParse(idCliente, out int _idCliente);

            return _context.tb_csr_connectionSignalR.Where(x => x.csr_n_id == _idCliente && x.csr_b_conectado == true && x.csr_n_hub == hub)
                ?.Select(x => x.csr_c_connectionId)?.Distinct().ToList();
        }

        public void IncluirAlterar(SaveConnectionSignalRViewModel obj, EnumHubs hub)
        {
            string[] idsCli;
            int.TryParse(obj.ClienteId, out int _clienteId);
            int.TryParse(obj.UsuarioId, out int _usuarioId);
            int.TryParse(obj.Perfil, out int _perfil);
            int cliId;

            if (obj.IdsClientes.Equals("todos") && _clienteId == 0)
            {
                var ids = (from cli in _context.tb_cli_cliente select cli.cli_n_codigo)?.ToList();
                obj.IdsClientes = string.Join(',', ids);
            }

            if (_clienteId != 0)
            {
                obj.IdsClientes = _clienteId.ToString();
            }

            idsCli = obj.IdsClientes.Split(',');

            InativarConnections(_usuarioId, _perfil, hub);

            foreach (var id in idsCli)
            {
                if (_clienteId == 0)
                    int.TryParse(id, out cliId);
                else
                    cliId = _clienteId;

                var connectionSignalR = _context.tb_csr_connectionSignalR.Where(x => x.csr_n_hub == hub &&
                    x.csr_n_usuarioId == _usuarioId && x.csr_n_perfil == _perfil && x.csr_n_id == cliId)?.FirstOrDefault();

                if (connectionSignalR == null)
                {
                    Insert(new tb_csr_connectionSignalR
                    {
                        csr_b_conectado = true,
                        csr_n_id = cliId,
                        csr_n_hub = hub,
                        csr_c_connectionId = obj.ConnectionId,
                        csr_n_usuarioId = _usuarioId,
                        csr_n_perfil = _perfil,
                        csr_d_dataInclusao = DateTime.Now,
                        csr_d_dataAlteracao = DateTime.Now,
                    });
                }
                else
                {
                    connectionSignalR.csr_b_conectado = true;
                    connectionSignalR.csr_n_id = cliId;
                    connectionSignalR.csr_n_hub = hub;
                    connectionSignalR.csr_c_connectionId = obj.ConnectionId;
                    connectionSignalR.csr_n_usuarioId = _usuarioId;
                    connectionSignalR.csr_n_perfil = _perfil;
                    connectionSignalR.csr_d_dataAlteracao = DateTime.Now;

                    Update(connectionSignalR);
                }
                _context.SaveChanges();
            }
        }

        public void InativarConnections(int usuarioId, int perfil, EnumHubs hub)
        {
            var connections = _context.tb_csr_connectionSignalR.Where(x => x.csr_n_hub == hub
              && x.csr_n_usuarioId == usuarioId && x.csr_n_perfil == perfil)?.ToList();

            foreach (var connection in connections)
            {
                if (connection != null)
                {
                    connection.csr_b_conectado = false;
                    connection.csr_d_dataAlteracao = DateTime.Now;

                    Update(connection);
                    _context.SaveChanges();
                }
            }
        }

        public void Remover(string connectionId, EnumHubs hub)
        {
            var connections = _context.tb_csr_connectionSignalR.Where(x => x.csr_n_hub == hub
              && x.csr_c_connectionId.Equals(connectionId))?.ToList();

            foreach (var connection in connections)
            {
                if (connection != null)
                {
                    connection.csr_b_conectado = false;
                    connection.csr_d_dataAlteracao = DateTime.Now;

                    Update(connection);
                    _context.SaveChanges();
                }
            }
        }
    }
}
