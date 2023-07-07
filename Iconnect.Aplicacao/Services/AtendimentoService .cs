using System;
using System.Collections.Generic;
using System.Text;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;
using System.Security.Cryptography;
using Iconnect.Aplicacao.ViewModel;
using Iconnect.Aplicacao.ViewModels;
using PagedList;
using Iconnect.Aplicacao.FilterModel;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Iconnect.Aplicacao.Services
{
    public class AtendimentoService : RepositoryBase<tb_ate_atendimento>, IAtendimentoService
    {
        private IconnectCoreContext context;

        public AtendimentoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public AtendimentoViewModel GetTotalizadoresSolution(AtendimentoFilterModel filter, string idClientes)
        {
            AtendimentoViewModel retorno = new AtendimentoViewModel();
            retorno.lstEmAtt = new List<ClienteViewModel>();
            retorno.lstAguardAtt = new List<ClienteViewModel>();

            var atendimentos = (from ate in context.tb_ate_atendimento
                                join cli in context.tb_cli_cliente on ate.ate_cli_n_codigo equals cli.cli_n_codigo
                                join mol in context.tb_mol_modulosLiberados on cli.cli_mol_n_codigo equals mol.mol_n_codigo
                                where (ate.ate_c_status == "AA" || ate.ate_c_status == "AT")
                                && (ate.ate_ope_n_preferencial == Convert.ToInt32(filter.usuario_filter) || ate.ate_ope_n_preferencial == null)
                                select new TotalizadoresSolutionViewModel()
                                {
                                    ate_cli_n_codigo = ate.ate_cli_n_codigo.ToString(),
                                    ate_tpa_n_codigo = ate.ate_tpa_n_codigo.ToString(),
                                    ate_c_status = ate.ate_c_status,
                                    cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                                    mol_b_controleDeAcesso = mol.mol_b_controleDeAcesso.ToString(),
                                    mol_b_MonitoriamentoPerimetral = mol.mol_b_MonitoriamentoPerimetral.ToString(),
                                    ate_ope_preferencial = ate.ate_ope_n_preferencial.ToString()
                                }).ToList();

            if (!string.IsNullOrEmpty(idClientes) && idClientes != "0" && idClientes != "todos")
            {
                atendimentos = atendimentos.Where(x => idClientes.Contains(x.ate_cli_n_codigo)).ToList();
            }

            var AT = AgruparAtendimentos(atendimentos, "AT");
            var AA = AgruparAtendimentos(atendimentos, "AA");
            var clientes = AA.Concat(AT).ToList();

            foreach (var atendimento in clientes)
            {
                if (atendimento.cli_c_nomeFantasia.Length > 25)
                {
                    atendimento.cli_c_nomeFantasia.Remove(25);
                }

                if (atendimento.statusAtt == "AT")
                {
                    retorno.lstEmAtt.Add(atendimento);
                }
                else
                {
                    retorno.lstAguardAtt.Add(atendimento);
                }
            }

            retorno.totalEmAtt = atendimentos.Where(x => x.ate_c_status.Contains("AT")).Count().ToString();
            retorno.totalAguardAtt = atendimentos.Where(x => x.ate_c_status.Contains("AA")).Count().ToString();

            return retorno;
        }

        public Retorno FinalizarAtendimento(AtendimentoViewModel model)
        {
            var retorno = new Retorno();
            try
            {
                var atendimentos = (from ate in context.tb_ate_atendimento
                                    where (ate.ate_n_codigo == Convert.ToInt32(model.ate_n_codigo)
                                    || ate.ate_cli_n_codigo.Equals(Convert.ToInt32(model.ate_cli_n_codigo)))
                                    && (ate.ate_c_status.Contains("AT") || ate.ate_c_status.Contains("AA"))
                                    select ate).ToList();

                foreach (var atendimento in atendimentos)
                {
                    var panicoTratado = AtendimentosPanico(atendimento.ate_n_codigo);
                    var guardTratado = AtendimentosGuard(atendimento.ate_n_codigo);

                    atendimento.ate_d_dataFinalizacao = DateTime.Now;
                    atendimento.ate_d_inclusao = DateTime.Now;
                    atendimento.ate_d_atualizado = DateTime.Now;
                    atendimento.ate_ope_n_preferencial = null;

                    if ((atendimento.ate_tpa_n_codigo != 1 && atendimento.ate_tpa_n_codigo != 3 && atendimento.ate_tpa_n_codigo != 7)
                        || panicoTratado == true || guardTratado == true)
                    {
                        atendimento.ate_c_status = "FN";
                    }
                    else
                    {
                        atendimento.ate_c_status = "AA";
                    }

                    Update(atendimento);
                    context.SaveChanges();
                }

                retorno.status = "Sucesso";
                retorno.conteudo = "Atendimento finalizado com sucesso.";
                return retorno;
            }
            catch (Exception)
            {
                retorno.status = "Erro";
                retorno.conteudo = "Não foi possível finalizar o atendimentos.";
                return retorno;
            }
        }

        public object FinalizarAtendimentosRecinto(string idsAtendimento)
        {
            try
            {
                context.Database.ExecuteSqlRaw("EXEC [FINALIZA_ATENDIMENTOS_RECINTO] '" + idsAtendimento + "'");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public object CancelarAtendimento(AtendimentoViewModel model)
        {
            try
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    SqlParameter cli_n_codigo = new SqlParameter("@ID_CLIENTE", Convert.ToInt32(model.ate_cli_n_codigo));

                    command.CommandText = "[CANCELAR_ATENDIMENTOS]";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(cli_n_codigo);

                    context.Database.OpenConnection();

                    var dataReader = command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public object AlterarStatusAtendimento(AtendimentoViewModel model)
        {
            try
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    SqlParameter cli_n_codigo = new SqlParameter("@ID_CLIENTE", Convert.ToInt32(model.ate_cli_n_codigo));
                    SqlParameter statusAtual = new SqlParameter("@STATUS_ATUAL", model.ate_c_status);

                    command.CommandText = "[ALTERA_STATUS_ANDAMENTO]";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(cli_n_codigo);
                    command.Parameters.Add(statusAtual);

                    context.Database.OpenConnection();

                    var dataReader = command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public AtendimentoViewModel ListarClientesSolution(AtendimentoFilterModel filter)
        {
            try
            {
                AtendimentoViewModel retorno = new AtendimentoViewModel();
                retorno.lstAguardAtt = new List<ClienteViewModel>();

                int countOnline = 0;
                int countOffline = 0;

                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    SqlParameter idUsuario = new SqlParameter("@ID_USUARIO", Convert.ToInt32(filter.usuario_filter));
                    SqlParameter idPerfil = new SqlParameter("@ID_PERFIL", Convert.ToInt32(filter.perfil_filter));

                    command.CommandText = "[LISTAR_CLIENTES_SOLUTION]";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(idUsuario);
                    command.Parameters.Add(idPerfil);

                    context.Database.OpenConnection();

                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ClienteViewModel cli = new ClienteViewModel();
                        cli.cli_n_codigo = dataReader["CLI_N_CODIGO"].ToString();
                        cli.cli_c_nomeFantasia = dataReader["CLI_C_NOMEFANTASIA"].ToString();
                        cli.statusSolution = dataReader["STATUS_CLIENTE"].ToString();
                        cli.mol_b_MonitoriamentoPerimetral = dataReader["MOL_B_MONITORIAMENTOPERIMETRAL"].ToString();
                        cli.mol_b_controleDeAcesso = dataReader["MOL_B_CONTROLEDEACESSO"].ToString();

                        if (cli.cli_c_nomeFantasia.Length > 25)
                        {
                            cli.cli_c_nomeFantasia = cli.cli_c_nomeFantasia.Remove(25);
                        }

                        if (cli.statusSolution == "ONLINE")
                        {
                            countOnline++;
                        }
                        else if (cli.statusSolution == "OFFLINE")
                        {
                            countOffline++;
                        }

                        retorno.lstAguardAtt.Add(cli);
                    }

                    retorno.totalCliOn = countOnline.ToString();
                    retorno.totalCliOff = countOffline.ToString();
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Retorno TransferirAtendimento(AtendimentoViewModel model, string perfil)
        {
            var retorno = new Retorno();
            try
            {
                var atendimento = (from ate in context.tb_ate_atendimento
                                   where ate.ate_cli_n_codigo == Convert.ToInt32(model.ate_cli_n_codigo)
                                   && ate.ate_c_status != "FN"
                                   && (ate.ate_b_LimparEvento == false || ate.ate_b_LimparEvento == null)
                                   select ate).FirstOrDefault();

                atendimento.ate_ope_n_preferencial = Convert.ToInt32(model.ate_ope_n_preferencial);
                atendimento.ate_c_status = "AT";
                context.Update(atendimento);
                context.SaveChanges();

                retorno.status = "Sucesso";
                retorno.conteudo = "Transferência realizada com sucesso.";
                return retorno;
            }
            catch (Exception)
            {
                retorno.status = "Erro";
                retorno.conteudo = "Ocorreu um erro ao realizar a transferência.";
                return retorno;
            }
        }

        private List<ClienteViewModel> AgruparAtendimentos(List<TotalizadoresSolutionViewModel> atendimentos, string status)
        {
            var tempAtendimentos = new List<ClienteViewModel>();

            foreach (var atendimentoGrupo in atendimentos.Where(x => x.ate_c_status.Contains(status)).GroupBy(x => new { x.ate_cli_n_codigo }))
            {
                ClienteViewModel cliAtend = new ClienteViewModel();
                cliAtend.cli_n_codigo = atendimentoGrupo.Key.ate_cli_n_codigo;
                cliAtend.cli_c_nomeFantasia = atendimentoGrupo.Select(x => x.cli_c_nomeFantasia).First();
                cliAtend.statusAtt = atendimentoGrupo.Select(x => x.ate_c_status).First();
                cliAtend.attGuard = atendimentoGrupo.Where(x => x.ate_tpa_n_codigo.Contains("1")).Count().ToString();
                cliAtend.attAccess = atendimentoGrupo.Where(x => x.ate_tpa_n_codigo.Contains("2")
                || x.ate_tpa_n_codigo.Contains("3") || x.ate_tpa_n_codigo.Contains("7")).Count().ToString();
                cliAtend.attVoip = atendimentoGrupo.Where(x => x.ate_tpa_n_codigo.Contains("4")
                || x.ate_tpa_n_codigo.Contains("5") || x.ate_tpa_n_codigo.Contains("6")).Count().ToString();
                cliAtend.attTotal = atendimentoGrupo.Count().ToString();
                cliAtend.mol_b_MonitoriamentoPerimetral = atendimentoGrupo.Select(x => x.mol_b_MonitoriamentoPerimetral).First();
                cliAtend.mol_b_controleDeAcesso = atendimentoGrupo.Select(x => x.mol_b_controleDeAcesso).First();

                tempAtendimentos.Add(cliAtend);
            }

            return tempAtendimentos;
        }

        private bool? AtendimentosPanico(int idAtendimento)
        {
            var panicoTratado = (from con in context.tb_con_monitoramentoControleAcesso
                                 where con.con_ate_n_codigo.Equals(idAtendimento)
                                 select con).FirstOrDefault();

            return panicoTratado?.con_b_panicoTratado;
        }

        private bool? AtendimentosGuard(int idAtendimento)
        {
            var guardTratado = (from mon in context.tb_mon_monitoramento
                                where mon.mon_ate_n_codigo.Equals(idAtendimento)
                                select mon).FirstOrDefault();

            if (guardTratado?.mon_stm_n_codigo == 3)
                return true;
            else
                return false;
        }
    }
}