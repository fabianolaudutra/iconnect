using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    class SolicitacaoAberturaRemotaService : RepositoryBase<tb_sol_solicitacaoAberturaRemota>, ISolicitacaoAberturaRemotaService
    {
        private IconnectCoreContext context;

        public SolicitacaoAberturaRemotaService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool SalvarSolicitacaoAberturaRemota(SolicitacaoAberturaRemotaViewModel sol)
        {
            try
            {
                Insert(new tb_sol_solicitacaoAberturaRemota()
                {
                    sol_cli_n_codigo = Convert.ToInt32(sol.sol_cli_n_codigo),
                    sol_c_usuarioSolicitou = sol.sol_c_usuarioSolicitou,
                    sol_d_data = DateTime.Now,
                    sol_c_tipoUsuario = sol.sol_c_tipoUsuario,
                    sol_usu_n_codigo = Convert.ToInt32(sol.sol_usu_n_codigo),
                    sol_d_modificacao = DateTime.Now,
                    sol_pta_n_codigo = Convert.ToInt32(sol.sol_pta_n_codigo),
                    sol_c_unique = Guid.NewGuid(),
                    sol_d_atualizado = DateTime.Now,
                    sol_d_inclusao = DateTime.Now,
                });

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IPagedList<SolicitacaoAberturaRemotaViewModel> ExibirSolicitacaoAberturaRemota(SolicitacaoAberturaRemotaFilterModel filter)
        {
            return (from sol in context.tb_sol_solicitacaoAberturaRemota
                    join cli in context.tb_cli_cliente on sol.sol_cli_n_codigo equals cli.cli_n_codigo
                    select new SolicitacaoAberturaRemotaViewModel()
                    {
                        sol_cli_n_codigo = sol.sol_cli_n_codigo.ToString(),
                        sol_cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                        sol_c_usuarioSolicitou = sol.sol_c_usuarioSolicitou,
                        sol_d_data = sol.sol_d_data.ToString(),
                        sol_c_tipoUsuario = sol.sol_c_tipoUsuario,
                    }).ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public bool ExcluirSolicitacoes()
        {
            try
            {
                context.tb_sol_solicitacaoAberturaRemota.RemoveRange(from sol in context.tb_sol_solicitacaoAberturaRemota select sol);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}