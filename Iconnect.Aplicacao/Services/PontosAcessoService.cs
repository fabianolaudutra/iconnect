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
using System.Data;
using System.ComponentModel;

namespace Iconnect.Aplicacao.Services
{
    class PontosAcessoService : RepositoryBase<tb_pta_pontosAcesso>, IPontosAcessoService
    {
        private IconnectCoreContext context;

        public PontosAcessoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public List<GenericList> ListarPontosAcesso(int id)
        {
            var lista =  (from con in Context.tb_con_controladora
                    join pta in Context.tb_pta_pontosAcesso on con.con_n_codigo equals pta.pta_con_n_codigo
                    where con.con_cli_n_codigo == id && pta.pta_b_status.Value == true && con.con_b_ativo == true
                    orderby pta.pta_c_nomePonto
                    select new GenericList()
                    {
                        value = pta.pta_n_codigo.ToString(),
                        text = pta.pta_c_nomePonto,

                    }).ToList();

            return lista;
        }

        public IPagedList<PontosAcessoViewModel> GetPontosAcessoFiltrado(PontosAcessoFilterModel filter)
        { 
            var query = (from pta in Context.tb_pta_pontosAcesso
                         select new PontosAcessoViewModel
                         {
                             pta_n_codigo = pta.pta_n_codigo.ToString(),
                             pta_con_n_codigo = pta.pta_con_n_codigo.ToString(),
                             pta_b_status = pta.pta_b_status == true ? "ATIVO" : "INATIVO",
                             pta_b_visitante = pta.pta_b_visitante == true ? "SIM" : "NÃO",
                             pta_b_servico = pta.pta_b_servico == true ? "SIM" : "NÃO",
                             pta_c_nomePonto = pta.pta_c_nomePonto,
                             pta_c_fluxo = pta.pta_c_fluxo,
                             pta_n_indexPorta = pta.pta_n_indexPorta.ToString(),
                             pta_d_modificacao = pta.pta_d_modificacao.ToString(),
                             pta_b_desabilitaVisitante = pta.pta_b_desabilitaVisitante == true ? "SIM" : "NÃO",
                             pta_b_desabilitaPrestador = pta.pta_b_desabilitaPrestador == true ? "SIM" : "NÃO",
                             pta_lay_n_codigo = pta.pta_lay_n_codigo.ToString(),
                             pta_cli_n_codigo = pta.pta_cli_n_codigo.ToString(),
                             pta_cla_n_codigo = pta.pta_cla_n_codigo.ToString(),
                             pta_c_unique = pta.pta_c_unique.ToString(),
                             pta_d_atualizado = pta.pta_d_atualizado.ToString(),
                             pta_d_inclusao = pta.pta_d_inclusao.ToString(),
                             pta_b_connectProGaren = pta.pta_b_connectProGaren.ToString(),
                             pta_b_exibirEventosReleAuxiliar = pta.pta_b_exibirEventosReleAuxiliar == true ? "SIM" : "NÃO",
                             pta_c_descricaoReleAuxiliar = pta.pta_c_descricaoReleAuxiliar,
                             pta_c_periodoMonitoramentoAte = pta.pta_c_periodoMonitoramentoAte,
                             pta_c_periodoMonitoramentoDe = pta.pta_c_periodoMonitoramentoDe,
                         });

            if (!string.IsNullOrEmpty(filter.pta_con_n_codigo_filter) && filter.pta_con_n_codigo_filter != "0")
            {
                query = query.Where(w => w.pta_con_n_codigo == filter.pta_con_n_codigo_filter);
            }
            else
            {
                query = query.Where(w => w.pta_con_n_codigo == null);
            }

            return query.OrderBy(x => x.pta_n_indexPorta).ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public bool SalvarPontosAcesso(PontosAcessoViewModel model)
        {
            try
            {
                int? auxIdControladora = null;
                if (model.pta_con_n_codigo != "0")
                {
                    auxIdControladora = Convert.ToInt32(model.pta_con_n_codigo);
                }

                if(model.pta_b_exibirEventosReleAuxiliar == "NÃO")
                {
                    model.pta_c_descricaoReleAuxiliar = string.Empty;
                    model.pta_c_periodoMonitoramentoAte = string.Empty;
                    model.pta_c_periodoMonitoramentoDe = string.Empty;
                }

                if (string.IsNullOrEmpty(model.pta_n_codigo) || model.pta_n_codigo.ToString() == "0")
                {
                    Insert(new tb_pta_pontosAcesso()
                    {
                        pta_con_n_codigo = auxIdControladora,
                        pta_b_status = model.pta_b_status == "ATIVO",
                        pta_b_visitante = model.pta_b_visitante == "SIM",
                        pta_b_servico = model.pta_b_servico == "SIM",
                        pta_c_nomePonto = model.pta_c_nomePonto,
                        pta_c_fluxo = model.pta_c_fluxo,
                        pta_n_indexPorta = Convert.ToInt32(model.pta_n_indexPorta),
                        pta_d_modificacao = DateTime.Now,
                        pta_b_desabilitaVisitante = model.pta_b_desabilitaVisitante == "SIM",
                        pta_b_desabilitaPrestador = model.pta_b_desabilitaPrestador == "SIM",
                        //pta_cla_n_codigo = model.pta_cla_n_codigo,
                        pta_c_unique = new Guid(),
                        pta_d_atualizado = DateTime.Now,
                        pta_d_inclusao = DateTime.Now,
                        //pta_b_connectProGaren = model.pta_b_connectProGaren,
                        pta_b_exibirEventosReleAuxiliar = model.pta_b_exibirEventosReleAuxiliar == "SIM",
                        pta_c_descricaoReleAuxiliar = model.pta_c_descricaoReleAuxiliar,
                        pta_c_periodoMonitoramentoAte = model.pta_c_periodoMonitoramentoAte,
                        pta_c_periodoMonitoramentoDe = model.pta_c_periodoMonitoramentoDe,
                        pta_b_refeicao = Convert.ToBoolean(model.pta_b_refeicao),
                        pta_b_connectProGaren = Convert.ToBoolean(model.pta_b_connectProGaren),
                    });
                }
                else
                {
                    var PontosAcesso = (from pta in context.tb_pta_pontosAcesso where pta.pta_n_codigo == Convert.ToInt32(model.pta_n_codigo) select pta).FirstOrDefault();
                    PontosAcesso.pta_con_n_codigo = auxIdControladora;
                    PontosAcesso.pta_b_status = model.pta_b_status == "ATIVO";
                    PontosAcesso.pta_b_visitante = model.pta_b_visitante == "SIM";
                    PontosAcesso.pta_b_servico = model.pta_b_servico == "SIM";
                    PontosAcesso.pta_c_nomePonto = model.pta_c_nomePonto;
                    PontosAcesso.pta_c_fluxo = model.pta_c_fluxo;
                    PontosAcesso.pta_n_indexPorta = Convert.ToInt32(model.pta_n_indexPorta);
                    PontosAcesso.pta_d_modificacao = DateTime.Now;
                    PontosAcesso.pta_b_desabilitaVisitante = model.pta_b_desabilitaVisitante == "SIM";
                    PontosAcesso.pta_b_desabilitaPrestador = model.pta_b_desabilitaPrestador == "SIM";
                    PontosAcesso.pta_d_atualizado = DateTime.Now;
                    PontosAcesso.pta_b_exibirEventosReleAuxiliar = model.pta_b_exibirEventosReleAuxiliar == "SIM";
                    PontosAcesso.pta_c_descricaoReleAuxiliar = model.pta_c_descricaoReleAuxiliar;
                    PontosAcesso.pta_c_periodoMonitoramentoAte = model.pta_c_periodoMonitoramentoAte;
                    PontosAcesso.pta_c_periodoMonitoramentoDe = model.pta_c_periodoMonitoramentoDe;
                    PontosAcesso.pta_b_refeicao = Convert.ToBoolean(model.pta_b_refeicao);
                    PontosAcesso.pta_b_connectProGaren = Convert.ToBoolean(model.pta_b_connectProGaren);
                    Update(PontosAcesso);
                }

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarPontosAcesso(int id)
        {
            try
            {
                Delete(context.tb_pta_pontosAcesso.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarPontosAcessoSemControladora()
        {
            try
            {
                var lstPontoAcessos = context.tb_pta_pontosAcesso.Where(x => x.pta_con_n_codigo == null).ToList();

                if (lstPontoAcessos.Count() > 0)
                {
                    foreach (var pontoAcesso in lstPontoAcessos)
                    {
                        Delete(pontoAcesso);
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


        public bool VincularPontoAcesso(int idPontoAcesso, int? idCliente)
        {
            try
            {
                var lstPontoAcessos = context.tb_pta_pontosAcesso.Where(x => x.pta_con_n_codigo == null).ToList();

                if (lstPontoAcessos.Count() > 0)
                {
                    foreach (var pontoAcesso in lstPontoAcessos)
                    {
                        pontoAcesso.pta_con_n_codigo = idPontoAcesso;
                        pontoAcesso.pta_cli_n_codigo = idCliente != null ? idCliente.Value : new Nullable<int>();
                        Update(pontoAcesso);
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

        public List<GenericList> pontoEntrada(int cliente)
        {
            var query = (from pta in context.tb_pta_pontosAcesso where pta.pta_cli_n_codigo == cliente && (pta.pta_c_fluxo == "ENTRADA" || pta.pta_c_fluxo == "BIDIRECIONAL")
                         select new GenericList()
                         {
                             value = pta.pta_n_codigo.ToString(),
                             text = pta.pta_c_nomePonto,

                         }).ToList();
            return query;
        }

        public List<GenericList> pontoSaida(int cliente)
        {
            var query = (from pta in context.tb_pta_pontosAcesso
                         where pta.pta_cli_n_codigo == cliente && (pta.pta_c_fluxo == "SAIDA" || pta.pta_c_fluxo == "BIDIRECIONAL")
                         select new GenericList()
                         {
                             value = pta.pta_n_codigo.ToString(),
                             text = pta.pta_c_nomePonto,

                         }).ToList();
            return query;

        }

    }
}