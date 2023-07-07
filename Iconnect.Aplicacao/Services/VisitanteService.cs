using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Exceptions;
using Iconnect.Infraestrutura.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace Iconnect.Aplicacao.Services
{
    public class VisitanteService : RepositoryBase<tb_vis_visitante>, IVisitanteService
    {
        private readonly IconnectCoreContext context;
        private ISincronizacaoPlacasService _sincronizacaoPlacas;

        public VisitanteService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public ISincronizacaoPlacasService SincronizacaoPlacas
        {
            get
            {
                if (_sincronizacaoPlacas == null)
                {
                    _sincronizacaoPlacas = new SincronizacaoPlacasService(context);
                }
                return _sincronizacaoPlacas;
            }
        }

        public IPagedList<VisitanteViewModel> GetVisitanteFiltrado(VisitanteFilterModel filter)
        {
            var query = (from visitante in Context.tb_vis_visitante
                         select new VisitanteViewModel
                         {
                             vis_n_codigo = visitante.vis_n_codigo.ToString(),
                             vis_cli_n_codigo = visitante.vis_cli_n_codigo.ToString(),
                             vis_c_nome = visitante.vis_c_nome,
                             vis_c_rg = visitante.vis_c_rg,
                             vis_c_estado = visitante.vis_c_estado,
                             vis_c_cpf = visitante.vis_c_cpf,
                             vis_c_celular = visitante.vis_c_celular.Replace(" ", ""),
                         });

            //Filtros
            if (!string.IsNullOrEmpty(filter.vis_cli_n_codigo_filter))
            {
                query = query.Where(w => w.vis_cli_n_codigo == filter.vis_cli_n_codigo_filter);
            }

            if (!string.IsNullOrEmpty(filter.vis_c_nome_filter))
            {
                query = query.Where(w => w.vis_c_nome.Contains(filter.vis_c_nome_filter));
            }
            else if (!string.IsNullOrEmpty(filter.vis_c_cpf_filter))
            {
                string auxDoc = filter.vis_c_cpf_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.vis_c_cpf.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.vis_c_rg_filter))
            {
                string auxDoc = filter.vis_c_rg_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.vis_c_rg.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.vis_c_celular_filter))
            {
                string auxFone = filter.vis_c_celular_filter.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                query = query.Where(w => w.vis_c_celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Contains(auxFone));
            }

            //Ordenação
            query = query.OrderBy(x => x.vis_c_nome);

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public List<VisitanteViewModel> GetVisitantesByCliente(int id)
        {
            return (from vis in context.tb_vis_visitante
                    where vis.vis_cli_n_codigo == id
                    select new VisitanteViewModel()
                    {
                        vis_n_codigo = vis.vis_n_codigo.ToString(),
                        vis_c_nome = vis.vis_c_nome,
                        vis_c_rg = vis.vis_c_rg,
                        vis_c_cpf = vis.vis_c_cpf,
                        vis_c_celular = vis.vis_c_celular,
                        vis_c_email = vis.vis_c_email,
                        vis_c_perfil = vis.vis_c_perfil,
                        vis_d_dataExpriracao = vis.vis_d_dataExpriracao.ToString(),
                        vis_c_numeroCartao = vis.vis_c_numeroCartao,
                        vis_c_observacao = vis.vis_c_observacao,
                        //vis_fot_n_codigo = vis.vis_fot_n_codigo.ToString(),
                        vis_cli_n_codigo = vis.vis_cli_n_codigo.ToString(),
                        vis_c_localizacao = vis.vis_c_localizacao,
                        vis_d_alteracao = vis.vis_d_alteracao.ToString(),
                        vis_c_usuario = vis.vis_c_usuario,
                        vis_gpv_n_codigo = vis.vis_gpv_n_codigo.ToString(),
                        vis_c_placaVeiculo = vis.vis_c_placaVeiculo,
                        vis_c_modeloVeiculo = vis.vis_c_modeloVeiculo,
                        vis_c_corVeiculo = vis.vis_c_corVeiculo,
                        vis_d_modificacao = vis.vis_d_modificacao.ToString(),
                        vis_b_ativoInativo = vis.vis_b_ativoInativo.ToString(),
                        vis_b_liberadoAntPassBack = vis.vis_b_liberadoAntPassBack.ToString(),
                        //vis_fot_n_documento = vis.vis_fot_n_documento.ToString(),
                        vis_c_unique = vis.vis_c_unique.ToString(),
                        vis_d_atualizado = vis.vis_d_atualizado.ToString(),
                        vis_d_inclusao = vis.vis_d_inclusao.ToString(),
                        vis_b_inOut = vis.vis_b_inOut.ToString(),
                        vis_d_dataEntrada = vis.vis_d_dataEntrada.ToString(),
                        vis_c_estado = vis.vis_c_estado,
                        vis_c_codExternoVisitante = vis.vis_c_codExternoVisitante
                    }).ToList();

        }

        public VisitanteViewModel GetVisitante(int id)
        {
            return (from vis in context.tb_vis_visitante
                    where vis.vis_n_codigo == id
                    select new VisitanteViewModel()
                    {
                        vis_n_codigo = vis.vis_n_codigo.ToString(),
                        vis_c_nome = vis.vis_c_nome,
                        vis_c_rg = vis.vis_c_rg,
                        vis_c_cpf = vis.vis_c_cpf,
                        vis_c_celular = vis.vis_c_celular,
                        vis_c_email = vis.vis_c_email,
                        vis_c_perfil = vis.vis_c_perfil,
                        vis_d_dataExpriracao = vis.vis_d_dataExpriracao != null ? vis.vis_d_dataExpriracao.Value.ToString("yyyy-MM-dd") : string.Empty,
                        vis_c_numeroCartao = vis.vis_c_numeroCartao,
                        vis_c_observacao = vis.vis_c_observacao,
                        vis_fot_n_codigo = vis.vis_fot_n_codigo != null ? vis.vis_fot_n_codigo.ToString() : "0",
                        vis_cli_n_codigo = vis.vis_cli_n_codigo.ToString(),
                        vis_c_localizacao = vis.vis_c_localizacao,
                        vis_d_alteracao = vis.vis_d_alteracao.ToString(),
                        vis_c_usuario = vis.vis_c_usuario,
                        vis_gpv_n_codigo = vis.vis_gpv_n_codigo.ToString(),
                        vis_c_placaVeiculo = vis.vis_c_placaVeiculo,
                        vis_c_modeloVeiculo = vis.vis_c_modeloVeiculo,
                        vis_c_corVeiculo = vis.vis_c_corVeiculo,
                        vis_d_modificacao = vis.vis_d_modificacao.ToString(),
                        vis_b_ativoInativo = vis.vis_b_ativoInativo.Value ? "ATIVO" : "INATIVO",
                        //vis_b_liberadoAntPassBack = vis.vis_b_liberadoAntPassBack.ToString(),
                        vis_fot_n_documento = vis.vis_fot_n_documento != null ? vis.vis_fot_n_documento.ToString() : "0",
                        vis_c_unique = vis.vis_c_unique.ToString(),
                        vis_d_atualizado = vis.vis_d_atualizado.ToString(),
                        vis_d_inclusao = vis.vis_d_inclusao.ToString(),
                        vis_b_inOut = vis.vis_b_inOut.ToString(),
                        vis_d_dataEntrada = vis.vis_d_dataEntrada.ToString(),
                        vis_c_estado = vis.vis_c_estado,
                        vis_c_codExternoVisitante = vis.vis_c_codExternoVisitante
                    }).FirstOrDefault();

        }

        public int SalvarVisitante(VisitanteViewModel model)
        {
            if (!string.IsNullOrEmpty(model.vis_c_rg))
            {
                VerificarRGDuplicado(model);
            }

            VerificaCPFDuplicado(model);
            tb_vis_visitante visitante;

            if (string.IsNullOrEmpty(model.vis_n_codigo) || model.vis_n_codigo.ToString() == "0")
            {
                visitante = new tb_vis_visitante()
                {
                    vis_c_nome = model.vis_c_nome.Trim().ToUpper(),
                    vis_c_rg = model.vis_c_rg,
                    vis_c_cpf = model.vis_c_cpf,
                    vis_c_celular = model.vis_c_celular,
                    vis_c_email = model.vis_c_email,
                    vis_c_perfil = model.vis_c_perfil,
                    vis_d_dataExpriracao = !string.IsNullOrEmpty(model.vis_d_dataExpriracao) ? Convert.ToDateTime(model.vis_d_dataExpriracao) : new Nullable<DateTime>(),
                    vis_c_numeroCartao = model.vis_c_numeroCartao,
                    vis_c_observacao = model.vis_c_observacao,
                    vis_fot_n_codigo = !string.IsNullOrEmpty(model.vis_fot_n_codigo) && !model.vis_fot_n_codigo.Equals("0") ? Convert.ToInt32(model.vis_fot_n_codigo) : new int?(),
                    vis_cli_n_codigo = !string.IsNullOrEmpty(model.vis_cli_n_codigo) && !model.vis_cli_n_codigo.Equals("0") ? Convert.ToInt32(model.vis_cli_n_codigo) : new int?(),
                    vis_c_localizacao = model.vis_c_localizacao,
                    vis_d_alteracao = DateTime.Now,
                    vis_c_usuario = "FELIPE",
                    vis_gpv_n_codigo = !string.IsNullOrEmpty(model.vis_gpv_n_codigo) && !model.vis_gpv_n_codigo.Equals("0") ? Convert.ToInt32(model.vis_gpv_n_codigo) : new int?(),
                    vis_c_placaVeiculo = model.vis_c_placaVeiculo,
                    vis_c_modeloVeiculo = model.vis_c_modeloVeiculo,
                    vis_c_corVeiculo = model.vis_c_corVeiculo,
                    vis_d_modificacao = DateTime.Now,
                    vis_b_ativoInativo = model.vis_b_ativoInativo == "ATIVO",
                    //vis_b_liberadoAntPassBack = model.vis_b_liberadoAntPassBack == "SIM",
                    vis_fot_n_documento = !string.IsNullOrEmpty(model.vis_fot_n_documento) && !model.vis_fot_n_documento.Equals("0") ? Convert.ToInt32(model.vis_fot_n_documento) : new int?(),
                    vis_c_unique = Guid.NewGuid(),
                    vis_d_atualizado = DateTime.Now,
                    vis_d_inclusao = DateTime.Now,
                    vis_b_inOut = false,
                    vis_c_estado = model.vis_c_estado,
                    vis_c_codExternoVisitante = model.vis_c_codExternoVisitante
                };

                Insert(visitante);
                context.SaveChanges();

                return visitante.vis_n_codigo;
            }
            else
            {
                visitante = context.tb_vis_visitante.Where(x => x.vis_n_codigo == Convert.ToInt32(model.vis_n_codigo)).FirstOrDefault();

                if (visitante.vis_b_ativoInativo != (model.vis_b_ativoInativo == "ATIVO") || visitante.vis_c_perfil != model.vis_c_perfil)
                {
                    SincronizarPlaca(visitante.vis_n_codigo);
                }

                visitante.vis_c_nome = model.vis_c_nome?.Trim()?.ToUpper() ?? visitante.vis_c_nome;
                visitante.vis_c_rg = model.vis_c_rg;
                visitante.vis_c_cpf = model.vis_c_cpf;
                visitante.vis_c_celular = model.vis_c_celular;
                visitante.vis_c_email = model.vis_c_email;
                visitante.vis_c_perfil = model.vis_c_perfil;
                visitante.vis_d_dataExpriracao = !string.IsNullOrEmpty(model.vis_d_dataExpriracao) ? Convert.ToDateTime(model.vis_d_dataExpriracao) : new Nullable<DateTime>();
                visitante.vis_c_numeroCartao = model.vis_c_numeroCartao;
                visitante.vis_c_observacao = model.vis_c_observacao;
                visitante.vis_fot_n_codigo = !string.IsNullOrEmpty(model.vis_fot_n_codigo) && !model.vis_fot_n_codigo.Equals("0") ? Convert.ToInt32(model.vis_fot_n_codigo) : new int?();
                visitante.vis_cli_n_codigo = !string.IsNullOrEmpty(model.vis_cli_n_codigo) && !model.vis_cli_n_codigo.Equals("0") ? Convert.ToInt32(model.vis_cli_n_codigo) : new int?();
                visitante.vis_c_localizacao = model.vis_c_localizacao;
                visitante.vis_d_alteracao = DateTime.Now;
                visitante.vis_c_usuario = "FELIPE";
                visitante.vis_gpv_n_codigo = !string.IsNullOrEmpty(model.vis_gpv_n_codigo) && !model.vis_gpv_n_codigo.Equals("0") ? Convert.ToInt32(model.vis_gpv_n_codigo) : new int?();
                visitante.vis_c_placaVeiculo = model.vis_c_placaVeiculo;
                visitante.vis_c_modeloVeiculo = model.vis_c_modeloVeiculo;
                visitante.vis_c_corVeiculo = model.vis_c_corVeiculo;
                visitante.vis_d_modificacao = DateTime.Now;
                visitante.vis_b_ativoInativo = model.vis_b_ativoInativo == "ATIVO";
                //visitante.vis_b_liberadoAntPassBack = model.vis_b_liberadoAntPassBack == "SIM";
                visitante.vis_fot_n_documento = !string.IsNullOrEmpty(model.vis_fot_n_documento) && !model.vis_fot_n_documento.Equals("0") ? Convert.ToInt32(model.vis_fot_n_documento) : new int?();
                visitante.vis_d_atualizado = DateTime.Now;
                visitante.vis_c_estado = model.vis_c_estado;
                visitante.vis_c_codExternoVisitante = model.vis_c_codExternoVisitante;

                Update(visitante);
                context.SaveChanges();

                return visitante.vis_n_codigo;
            }
        }

        public void VerificaCPFDuplicado(VisitanteViewModel model)
        {
            if (string.IsNullOrEmpty(model.vis_c_cpf))
                return;

            var visitantes = (from vis in context.tb_vis_visitante
                              where vis.vis_n_codigo != Convert.ToInt32(model.vis_n_codigo) && vis.vis_cli_n_codigo == Convert.ToInt32(model.vis_cli_n_codigo)
                              && vis.vis_c_cpf == model.vis_c_cpf
                              select vis).Count();

            var moradores = (from mor in context.tb_mor_Morador
                             where mor.mor_cli_n_codigo == Convert.ToInt32(model.vis_cli_n_codigo) && mor.mor_c_cpf == model.vis_c_cpf
                             select mor).Count();

            var prestadores = (from pse in context.tb_pse_prestadorServico
                               where pse.pse_cli_n_codigo == Convert.ToInt32(model.vis_cli_n_codigo) && pse.pse_c_cpf == model.vis_c_cpf
                               select pse).Count();

            if (moradores > 0 || visitantes > 0 || prestadores > 0)
                throw new MensagemException("O CPF digitado já está sendo usado, verifque novamente ou contate o Administrador.");
        }

        public void VerificarRGDuplicado(VisitanteViewModel model)
        {
            var queryVisitante = (from vis in context.tb_vis_visitante
                                  where vis.vis_cli_n_codigo == Convert.ToInt32(model.vis_cli_n_codigo)
                                  && vis.vis_c_rg != null && vis.vis_n_codigo != Convert.ToInt32(model.vis_n_codigo)
                                  select vis).ToList();

            var queryMorador = (from mor in context.tb_mor_Morador
                                where mor.mor_cli_n_codigo == Convert.ToInt32(model.vis_cli_n_codigo)
                                && mor.mor_c_rg != null
                                select mor).ToList();

            var queryPrestador = (from pse in context.tb_pse_prestadorServico
                                  where pse.pse_cli_n_codigo == Convert.ToInt32(model.vis_cli_n_codigo)
                                  && pse.pse_c_rg != null
                                  select pse).ToList();

            string inputIn = model.vis_c_rg;
            string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\\s]";
            string inputOut = Regex.Replace(inputIn, pattern, "").ToUpper();

            List<string> listaRgMorador = new List<string>();
            List<string> listaRgVisitante = new List<string>();
            List<string> listaRgPrestador = new List<string>();

            //Visitante
            for (int i = 0; i < queryVisitante.Count; i++)
            {
                listaRgVisitante.Add(Regex.Replace(queryVisitante[i].vis_c_rg.ToString(), pattern, ""));
            }
            string[] arrayVisitante_rg = listaRgVisitante.ToArray();
            for (int i = 0; i < arrayVisitante_rg.Length; i++)
            {
                if (inputOut == arrayVisitante_rg[i] && model.vis_c_estado == queryVisitante[i].vis_c_estado)
                {
                    throw new MensagemException("O RG digitado já está sendo usado, verifque novamente ou contate o Administrador.");
                }
            }

            //Morador
            for (int i = 0; i < queryMorador.Count; i++)
            {
                listaRgMorador.Add(Regex.Replace(queryMorador[i].mor_c_rg.ToString(), pattern, ""));
            }
            string[] arrayMorador_rg = listaRgMorador.ToArray();
            for (int i = 0; i < arrayMorador_rg.Length; i++)
            {
                if (inputOut == arrayMorador_rg[i] && model.vis_c_estado == queryMorador[i].mor_c_estado)
                {
                    throw new MensagemException("O RG digitado já está sendo usado, verifque novamente ou contate o Administrador.");
                }
            }


            //Prestador
            for (int i = 0; i < queryPrestador.Count; i++)
            {
                listaRgPrestador.Add(Regex.Replace(queryPrestador[i].pse_c_rg.ToString(), pattern, ""));
            }
            string[] arrayPrestador_rg = listaRgPrestador.ToArray();
            for (int i = 0; i < arrayPrestador_rg.Length; i++)
            {
                if (inputOut == arrayPrestador_rg[i] && model.vis_c_estado == queryPrestador[i].pse_c_estado)
                {
                    throw new MensagemException("O RG digitado já está sendo usado, verifque novamente ou contate o Administrador.");
                }
            }
        }

        public bool? AtivarDesativar(int id)
        {
            try
            {
                var visitante = (from vis in context.tb_vis_visitante where vis.vis_n_codigo == id select vis).FirstOrDefault();
                if (visitante != null)
                {
                    using var transaction = context.Database.BeginTransaction();

                    visitante.vis_b_ativoInativo = !visitante.vis_b_ativoInativo;
                    Update(visitante);
                    context.SaveChanges();

                    SincronizarPlaca(visitante.vis_n_codigo);

                    transaction.Commit();

                    return visitante.vis_b_ativoInativo;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public bool Deletar(int id)
        {
            try
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    SqlParameter auxId = new SqlParameter("@VIS_N_CODIGO", id);

                    command.CommandText = "[EXCLUSAO_VISITANTE]";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(auxId);

                    context.Database.OpenConnection();

                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public VisitanteViewModel GetVisitanteCPF(VisitanteViewModel model)
        {
            string auxDoc = Regex.Replace(model.vis_c_cpf ?? "", "[^0-9,]", "");
            var query = (from vis in context.tb_vis_visitante
                         join visApp in context.tb_vpp_visitanteApp on vis.vis_vpp_n_codigo equals visApp.vpp_n_codigo into visVpp
                         from vpp in visVpp.DefaultIfEmpty()
                         where vis.vis_cli_n_codigo == Convert.ToInt32(model.vis_cli_n_codigo)
                         select new VisitanteViewModel()
                         {
                             vis_n_codigo = vis.vis_n_codigo.ToString(),
                             vis_c_nome = vis.vis_c_nome,
                             vis_c_rg = vis.vis_c_rg,
                             vis_c_cpf = vis.vis_c_cpf,
                             vis_c_celular = vis.vis_c_celular,
                             vis_c_email = vpp.vpp_c_email,
                             vis_c_perfil = vis.vis_c_perfil,
                             vis_d_dataExpriracao = vis.vis_d_dataExpriracao != null ? vis.vis_d_dataExpriracao.Value.ToString("yyyy-MM-dd") : string.Empty,
                             vis_c_numeroCartao = vis.vis_c_numeroCartao,
                             vis_c_observacao = vis.vis_c_observacao,
                             vis_fot_n_codigo = vis.vis_fot_n_codigo != null ? vis.vis_fot_n_codigo.ToString() : "0",
                             vis_cli_n_codigo = vis.vis_cli_n_codigo.ToString(),
                             vis_c_localizacao = vis.vis_c_localizacao,
                             vis_d_alteracao = vis.vis_d_alteracao.ToString(),
                             vis_c_usuario = vis.vis_c_usuario,
                             vis_gpv_n_codigo = vis.vis_gpv_n_codigo.ToString(),
                             vis_c_placaVeiculo = vis.vis_c_placaVeiculo,
                             vis_c_modeloVeiculo = vis.vis_c_modeloVeiculo,
                             vis_c_corVeiculo = vis.vis_c_corVeiculo,
                             vis_d_modificacao = vis.vis_d_modificacao.ToString(),
                             vis_b_ativoInativo = vis.vis_b_ativoInativo.Value ? "ATIVO" : "INATIVO",
                             vis_fot_n_documento = vis.vis_fot_n_documento != null ? vis.vis_fot_n_documento.ToString() : "0",
                             vis_c_unique = vis.vis_c_unique.ToString(),
                             vis_d_atualizado = vis.vis_d_atualizado.ToString(),
                             vis_d_inclusao = vis.vis_d_inclusao.ToString(),
                             vis_b_inOut = vis.vis_b_inOut.ToString(),
                             vis_d_dataEntrada = vis.vis_d_dataEntrada.ToString(),
                         });

            if (!string.IsNullOrEmpty(auxDoc))
            {
                return query.Where(x => x.vis_c_cpf.Replace(".", "").Replace("-", "").Contains(auxDoc)).FirstOrDefault();
            }
            else if (!string.IsNullOrEmpty(model.vis_c_nome))
            {
                return query.Where(x => x.vis_c_nome.ToUpper().Contains(model.vis_c_nome.ToUpper())).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        private void SincronizarPlaca(int visitanteId)
        {
            string controladoras = "";
            var idsControladoras = new List<int>();
            var clienteId = (from vis in context.tb_vis_visitante where vis.vis_n_codigo == visitanteId select vis.vis_cli_n_codigo)?.FirstOrDefault();
            var tb_cac = (from cac in context.tb_cac_controleAcesso where cac.cac_vis_n_codigo == visitanteId select cac)?.ToList();
            List<tb_con_controladora> lstCon = (from con in context.tb_con_controladora where con.con_cli_n_codigo == clienteId && (con.con_c_modelo == "ZK" || con.con_c_modelo == "LINEAR HCS" || con.con_c_modelo == "CONTROL ID" || con.con_c_modelo == "CITROX") select con)?.ToList();

            foreach (var item in lstCon)
            {
                if (item.con_c_modelo != "CITROX")
                {
                    idsControladoras.Add(item.con_n_codigo);
                }
            }

            if (idsControladoras.Any())
            {
                controladoras = string.Join(',', idsControladoras);
            }

            foreach (var item in tb_cac)
            {
                SincronizacaoPlacas.SalvarSincronizacaoPlacasInterna(Convert.ToInt32(clienteId), controladoras, item.cac_n_codigo);
            }
        }

        public IPagedList<VisitanteViewModel> GetVisitanteBuscarFiltrado(VisitanteFilterModel filter)
        {
            var query = (from visitante in Context.tb_vis_visitante
                         select new VisitanteViewModel
                         {
                             vis_n_codigo = visitante.vis_n_codigo.ToString(),
                             vis_cli_n_codigo = visitante.vis_cli_n_codigo.ToString(),
                             vis_c_nome = visitante.vis_c_nome,
                             vis_c_rg = visitante.vis_c_rg,
                             vis_c_estado = visitante.vis_c_estado,
                             vis_c_cpf = visitante.vis_c_cpf,
                             vis_c_celular = visitante.vis_c_celular.Replace(" ", ""),
                             vis_c_localizacao = visitante.vis_c_localizacao,
                             vis_c_placaVeiculo = visitante.vis_c_placaVeiculo,
                             vis_c_corVeiculo = visitante.vis_c_corVeiculo,
                             vis_c_modeloVeiculo = visitante.vis_c_modeloVeiculo,
                         });

            //Filtros
            if (!string.IsNullOrEmpty(filter.vis_cli_n_codigo_filter))
            {
                query = query.Where(w => w.vis_cli_n_codigo == filter.vis_cli_n_codigo_filter);
            }

            if (!string.IsNullOrEmpty(filter.vis_c_nome_filter))
            {
                query = query.Where(w => w.vis_c_nome.Contains(filter.vis_c_nome_filter));
            }
            else if (!string.IsNullOrEmpty(filter.vis_c_cpf_filter))
            {
                string auxDoc = filter.vis_c_cpf_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.vis_c_cpf.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.vis_c_rg_filter))
            {
                string auxDoc = filter.vis_c_rg_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.vis_c_rg.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.vis_c_celular_filter))
            {
                string auxFone = filter.vis_c_celular_filter.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                query = query.Where(w => w.vis_c_celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Contains(auxFone));
            }

            if (!string.IsNullOrEmpty(filter.vis_c_placaVeiculo_filter))
            {
                query = query.Where(w => w.vis_c_placaVeiculo.Contains(filter.vis_c_placaVeiculo_filter));
            }

            if (!string.IsNullOrEmpty(filter.vis_c_localizacao_filter))
            {
                var aux = new List<string>();
                foreach (var q in query)
                {
                    if (!string.IsNullOrEmpty(q.vis_c_localizacao))
                    {
                        var index = q.vis_c_localizacao.IndexOf('/') + 1;
                        var localizacao = q.vis_c_localizacao.Substring(index).ToLower();
                        if (localizacao.Replace(" ", "") == filter.vis_c_localizacao_filter.ToLower().Replace(" ", ""))
                        {
                            aux.Add(q.vis_n_codigo);
                        }
                    }
                }
                query = query.Where(w => aux.Contains(w.vis_n_codigo));
            }

            //Ordenação
            query = query.OrderBy(x => x.vis_c_nome);

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }
    }
}