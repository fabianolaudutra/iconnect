using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PagedList;

namespace Iconnect.Aplicacao.Services
{
    class EquipamentoClienteService : RepositoryBase<tb_eqc_equipamentoCliente>, IEquipamentoClienteService
    {
        private IconnectCoreContext context;

        public EquipamentoClienteService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public object InsertOrUpdate(EquipamentoClienteViewModel model)
        {
            try
            {
                Retorno retorno = new Retorno();

                int? codCli = null;
                if (model.eqc_cli_n_codigo != null && model.eqc_cli_n_codigo != "0" && model.eqc_cli_n_codigo != "")
                {
                    codCli = Convert.ToInt32(model.eqc_cli_n_codigo);
                }

                int codeEqc = Convert.ToInt32(model.eqc_n_codigo);
                
                if(model.eqc_c_porta != null)
                {
                    if (PortaOcupada(model.eqc_c_porta, codCli, codeEqc, Convert.ToBoolean(model.eqc_b_apontamentoLocal)))
                    {
                        retorno.status = "error";
                        retorno.conteudo = "PORTA_OCUPADA";

                        return retorno;
                    }
                }

                bool apontamento = Convert.ToBoolean(model.eqc_b_apontamentoLocal);
                if (codeEqc == 0)
                {
                    Insert(new tb_eqc_equipamentoCliente()
                    {
                        eqc_cli_n_codigo = codCli,
                        eqc_c_nomePonto = model.eqc_c_nomePonto,
                        eqc_n_modelo = Convert.ToInt32(model.eqc_n_modelo),
                        eqc_b_apontamentoLocal = apontamento,
                        eqc_c_conta = model.eqc_c_conta,
                        eqc_c_ip = model.eqc_c_ip,
                        eqc_c_porta = model.eqc_c_porta,
                        eqc_c_senhaRemota = model.eqc_c_senhaRemota,
                        eqc_c_unique = Guid.NewGuid(),
                        eqc_d_atualizado = DateTime.Now,
                        eqc_d_inclusao = DateTime.Now,
                        eqc_d_modificacao = DateTime.Now
                    });
                }
                else
                {
                    var eqc = (from equipamento in context.tb_eqc_equipamentoCliente where equipamento.eqc_n_codigo == codeEqc select equipamento).FirstOrDefault();
                    eqc.eqc_cli_n_codigo = codCli;
                    eqc.eqc_c_nomePonto = model.eqc_c_nomePonto;
                    eqc.eqc_n_modelo = Convert.ToInt32(model.eqc_n_modelo);
                    eqc.eqc_b_apontamentoLocal = apontamento;
                    eqc.eqc_c_conta = model.eqc_c_conta;
                    eqc.eqc_c_ip = model.eqc_c_ip;
                    eqc.eqc_c_porta = model.eqc_c_porta;
                    eqc.eqc_c_senhaRemota = model.eqc_c_senhaRemota;
                    eqc.eqc_c_conta = model.eqc_c_conta;
                    eqc.eqc_d_atualizado = DateTime.Now;
                    eqc.eqc_d_modificacao = DateTime.Now;

                    Update(eqc);
                }
                context.SaveChanges();
                retorno.status = "ok";
                retorno.conteudo = "true";
                return retorno;
            }
            catch (Exception ex)
            {
            }
            return model;


        }
        public EquipamentoClienteViewModel GetEquipamento(int id)
        {
            return (from eqc in Context.tb_eqc_equipamentoCliente
                    where eqc.eqc_n_codigo == id

                    select new EquipamentoClienteViewModel
                    {
                        eqc_n_codigo = eqc.eqc_n_codigo.ToString(),
                        eqc_c_nomePonto = eqc.eqc_c_nomePonto.ToString(),
                        eqc_n_modelo = eqc.eqc_n_modelo.ToString(),
                        eqc_b_apontamentoLocal = eqc.eqc_b_apontamentoLocal.ToString(),
                        eqc_c_conta = eqc.eqc_c_conta,
                        eqc_c_ip = eqc.eqc_c_ip,
                        eqc_c_porta = eqc.eqc_c_porta,
                        eqc_c_senhaRemota = eqc.eqc_c_senhaRemota,

                    }).FirstOrDefault();
        }

        public IPagedList<EquipamentoClienteViewModel> GetEquipamentoFiltrado(EquipamentoClienteFiltermodel filter)
        {
            try
            {
                DateTime tempoLimiteUltimoContato = DateTime.Now.AddSeconds(-15);

                var query = (from eqc in Context.tb_eqc_equipamentoCliente
                             orderby eqc.eqc_c_nomePonto
                             select new EquipamentoClienteViewModel
                             {
                                 eqc_n_codigo = eqc.eqc_n_codigo.ToString(),
                                 eqc_c_nomePonto = eqc.eqc_c_nomePonto,
                                 eqc_n_modelo = eqc.eqc_n_modelo.Value.ToString(),
                                 eqc_modelo = eqc.eqc_n_modelo.Value == 1 ? "AMT 18EG" : (eqc.eqc_n_modelo.Value == 2 ? "JFL" : ""),
                                 eqc_c_ip = eqc.eqc_c_ip,
                                 eqc_c_conta = eqc.eqc_c_conta,
                                 eqc_c_senhaRemota = eqc.eqc_c_senhaRemota,
                                 eqc_c_versao = eqc.eqc_c_versao,
                                 eqc_cli_n_codigo = eqc.eqc_cli_n_codigo.Value.ToString(),
                                 eqc_status = eqc.eqc_d_ultimoContato.Value != null && eqc.eqc_d_ultimoContato.Value >= tempoLimiteUltimoContato ? "bolaVerde" : "bolaVermelho",

                             });

                int codCli = Convert.ToInt32(filter.eqc_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.eqc_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.eqc_cli_n_codigo == null);
                }


                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeletarEquipamento(int id)
        {
            try
            {
                Delete(context.tb_eqc_equipamentoCliente.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
       
        public List<GenericList> ListarCentrais(int id)
        {
            int? codCli = null;
            if (id != 0)
            {
                codCli = id;
            }

            return (from eqc in Context.tb_eqc_equipamentoCliente
                    where eqc.eqc_cli_n_codigo == codCli
                    select new GenericList()
                    {
                        value = eqc.eqc_n_codigo.ToString(),
                        value2 = eqc.eqc_n_modelo.ToString(),
                        text = eqc.eqc_c_nomePonto + " | " + eqc.eqc_c_ip,

                    }).ToList();
        }

        public bool PortaOcupada(string porta, int? idEmpresa, int codigo, bool local)
        {
            return (from eqc in context.tb_eqc_equipamentoCliente 
                    where eqc.eqc_c_porta == porta 
                    && eqc.eqc_cli_n_codigo == idEmpresa 
                    && eqc.eqc_b_apontamentoLocal == local 
                    && eqc.eqc_n_codigo != codigo 
                    select eqc).Any();
        }

        public bool ExcluirTemporarios()
        {
            try
            {
                List<tb_eqc_equipamentoCliente> lista = new List<tb_eqc_equipamentoCliente>();


                lista = (from eqc in context.tb_eqc_equipamentoCliente where eqc.eqc_cli_n_codigo == null select eqc).OrderBy(x => x.eqc_c_nomePonto).ToList();


                foreach (var item in lista)
                {

                    DeletarEquipamento(item.eqc_n_codigo);
                }
                return true;

            }
            catch (Exception)
            {
                return false;

                throw;
            }
        }

        public bool Vincular(int id)
        {
            try
            {
                var lista = context.tb_eqc_equipamentoCliente.Where(x => x.eqc_cli_n_codigo == null).ToList();

                if (lista.Count() > 0)
                {
                    foreach (var item in lista)
                    {
                        item.eqc_cli_n_codigo = id;
                        Update(item);
                    }

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
