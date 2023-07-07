using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Iconnect.Aplicacao.Services
{
    class LimpezaClienteService : RepositoryBase<tb_pec_processoExclusaoCliente>, ILimpezaClienteService
    {
        private IconnectCoreContext context;

        public LimpezaClienteService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }
        public bool DeletarLimpeza(int id)
        {
            try
            {
                Delete(context.tb_pec_processoExclusaoCliente.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public object SalvarLimpeza(LimpezaClienteViewModel model)
        {
            Retorno retorno = new Retorno();
            try
            {
               
                string[] thisArray = model.pec_cli_n_codigo.Split(',');
                var panico = model.pec_b_panico == "SIM" ? true : false;
                List<int> lstIdsCliente = new List<int>();
                foreach (string str in thisArray)
                {
                    if (str != "")
                    {
                        lstIdsCliente.Add(Convert.ToInt16(str));
                    }
                }
                if (lstIdsCliente.Count > 0)
                {
                    //GUARD
                    #region Guard
                    int qtdMonitoramento = 0;
                    int qtdAtendimento = 0;

                    qtdMonitoramento = (from x in context.tb_mon_monitoramento where lstIdsCliente.Contains(x.mon_cli_n_codigo.Value) &&
                     (x.mon_b_limpaEvento == null || x.mon_b_limpaEvento == false) && x.mon_stm_n_codigo == 1  select x).Count();

                    qtdAtendimento = (from x in context.tb_ate_atendimento where lstIdsCliente.Contains(x.ate_cli_n_codigo.Value) &&
                    (x.ate_b_LimparEvento == null || x.ate_b_LimparEvento == false) &&
                    (x.ate_c_status != "FN" && x.ate_c_status != "CN") && x.ate_tpa_n_codigo == 1 select x).Count();

                    //Verifica se existe registros de monitoramento para esse cliente
                    qtdMonitoramento += qtdMonitoramento + qtdAtendimento;

                    #endregion

                    //ACCESS
                    #region Access
                    int qtdAtendimentoAccess = 0;
                    int qtdMonitoramentoControleAcesso = 0;

                    if (panico)
                    {
                        qtdMonitoramentoControleAcesso = (from pec in context.tb_con_monitoramentoControleAcesso where lstIdsCliente.Contains(pec.con_cli_n_codigo.Value) &&
                                                          (pec.con_b_LimparEvento == null || pec.con_b_LimparEvento == false) && pec.con_b_panico == true  select pec).Count();

                        qtdAtendimentoAccess = (from pec in context.tb_ate_atendimento where lstIdsCliente.Contains(pec.ate_cli_n_codigo.Value) 
                                                && (pec.ate_b_LimparEvento == null || pec.ate_b_LimparEvento == false) && (pec.ate_c_status != "FN" && pec.ate_c_status != "CN") && 
                                                pec.ate_tpa_n_codigo == 3 select pec).Count();
                    }
                    else {
                        qtdMonitoramentoControleAcesso = (from x in context.tb_con_monitoramentoControleAcesso where lstIdsCliente.Contains(x.con_cli_n_codigo.Value) &&
                             (x.con_b_LimparEvento == null || x.con_b_LimparEvento == false) &&
                             x.con_b_panico == false select x).Count();

                        qtdAtendimentoAccess = (from x in context.tb_ate_atendimento where lstIdsCliente.Contains(x.ate_cli_n_codigo.Value) &&
                         (x.ate_b_LimparEvento == null || x.ate_b_LimparEvento == false) &&
                         (x.ate_c_status != "FN" && x.ate_c_status != "CN") && x.ate_tpa_n_codigo == 2 select x).Count();
                    }
                   

                    qtdMonitoramentoControleAcesso = qtdMonitoramentoControleAcesso + qtdAtendimentoAccess;

                    #endregion
                    //Verifica se existe registros de monitoramento de alarme para esse cliente 
                   
                    if (qtdMonitoramento == 0 && qtdMonitoramentoControleAcesso == 0)
                    {
                        if (model.pec_c_tipo == "ACCESS")
                        {
                            retorno.status = "error";
                            retorno.conteudo = "SEM_MONITORAMENTO_CONTROLE_ACESSO";
                            return retorno;
                        }
                        else {
                            retorno.status = "error";
                            retorno.conteudo = "SEM_MONITORAMENTO";
                            return retorno;
                        }
                        
                    }

                    
                }
                if (model.pec_n_codigo == 0)
                {
                    Insert(new tb_pec_processoExclusaoCliente()
                    {
                        pec_c_observacao = model.pec_c_observacao,
                        pec_c_tipo = model.pec_c_tipo,
                        //pec_cli_n_codigo = Convert.ToInt32(model.pec_cli_n_codigo),
                        pec_c_unique = Guid.NewGuid(),
                        pec_b_panico = panico,
                        pec_c_usuario = "ISABELA",
                        pec_d_atualizado = DateTime.Now,
                        pec_d_data = DateTime.Now,
                        pec_d_inclusao = DateTime.Now,
                    });

                    string clausulaIn = model.pec_cli_n_codigo.Substring(0, model.pec_cli_n_codigo.Length - 1);
                    bool ACCESS, GUARD, LIMPA_PANICO, OPCAO_TODOS;

                    if (model.pec_c_tipo == "GUARD")
                    {
                        GUARD = true;
                        ACCESS = false;
                        LIMPA_PANICO = false;
                        OPCAO_TODOS = false;

                        context.Database.ExecuteSqlRaw("exec [EXECUTA_LIMPEZA_GERAL] '" + clausulaIn + "', " + GUARD + " , " + ACCESS + " , " + LIMPA_PANICO + " , " + OPCAO_TODOS);
                    }
                    else if (model.pec_c_tipo == "ACCESS")
                    {
                        GUARD = false;
                        ACCESS = true;
                        LIMPA_PANICO = panico; // Convert.ToBoolean(model.pec_b_panico);
                        OPCAO_TODOS = false;

                        context.Database.ExecuteSqlRaw("exec [EXECUTA_LIMPEZA_GERAL] '" + clausulaIn + "', " + GUARD + " , " + ACCESS + " , " + LIMPA_PANICO + " , " + OPCAO_TODOS);
                    }
                    else if (model.pec_c_tipo == "TODOS")
                    {
                        GUARD = true;
                        ACCESS = true;
                        LIMPA_PANICO = false;
                        OPCAO_TODOS = true;

                        context.Database.ExecuteSqlRaw("exec [EXECUTA_LIMPEZA_GERAL] '" + clausulaIn + "', " + GUARD + " , " + ACCESS + " , " + LIMPA_PANICO + " , " + OPCAO_TODOS);
                        
                    }
                }
                else
                {
                    var proc = (from pec in context.tb_pec_processoExclusaoCliente where pec.pec_n_codigo == model.pec_n_codigo select pec).FirstOrDefault();
                    proc.pec_c_observacao = model.pec_c_observacao;
                    proc.pec_c_tipo = model.pec_c_tipo;
                    //proc.pec_cli_n_codigo = Convert.ToInt32(model.pec_cli_n_codigo);
                    Update(proc);
                }
                context.SaveChanges();
                retorno.status = "ok";
                retorno.conteudo = "true";
                return retorno;
            }
            catch (Exception)
            {
            }
            retorno.status = "error";
            retorno.conteudo = "false";
            return retorno;
        }

        public bool LimpezaAccessByCliente(int idCliente)
        {
            Retorno retorno = new Retorno();
            try
            {
                if(idCliente != 0)
                {
                    context.Database.ExecuteSqlRaw("exec [EXECUTA_LIMPEZA_ACCESS] " + idCliente.ToString() + ", 0, 0");

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public IPagedList<LimpezaClienteViewModel> ListarLimpezas(LimpezaClienteFilterModel filter)
        {
            var query = (from lim in Context.tb_pec_processoExclusaoCliente
                         join cli in Context.tb_cli_cliente on lim.pec_cli_n_codigo  equals cli.cli_n_codigo
                         join emp in Context.tb_emp_empresa on cli.cli_emp_n_codigo equals emp.emp_n_codigo
                         select new LimpezaClienteViewModel
                         {
                             pec_c_observacao = lim.pec_c_observacao,
                             pec_c_tipo = lim.pec_c_tipo,
                             pec_d_data = lim.pec_d_data.Value.ToString("dd/MM/yyyy"),
                             pec_c_usuario = lim.pec_c_usuario,
                             pec_b_panico = lim.pec_b_panico.ToString().ToLower(),
                             cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                             nomeEmpresa = emp.emp_c_nomeFantasia
                         });

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade); 
        }
    }
}
