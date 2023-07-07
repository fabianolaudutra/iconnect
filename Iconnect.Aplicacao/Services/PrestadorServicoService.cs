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
    class PrestadorServicoService : RepositoryBase<tb_pse_prestadorServico>, IPrestadorServicoService
    {
        private readonly IconnectCoreContext context;
        private ISincronizacaoPlacasService _sincronizacaoPlacas;

        public PrestadorServicoService(IconnectCoreContext context) : base(context)
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

        public IPagedList<PrestadorServicoViewModel> GetPrestadorFiltrado(PrestadorServicoFilterModel filter)
        {
            var query = (from prestador in Context.tb_pse_prestadorServico
                         select new PrestadorServicoViewModel
                         {
                             pse_n_codigo = prestador.pse_n_codigo.ToString(),
                             pse_cli_n_codigo = prestador.pse_cli_n_codigo.ToString(),
                             pse_c_nome = prestador.pse_c_nome,
                             pse_c_rg = prestador.pse_c_rg,
                             pse_c_estado = prestador.pse_c_estado,
                             pse_c_cpf = prestador.pse_c_cpf,
                             pse_c_celular = prestador.pse_c_celular.Replace(" ", ""),
                         });

            //Filtros
            if (!string.IsNullOrEmpty(filter.pse_cli_n_codigo_filter))
            {
                query = query.Where(w => w.pse_cli_n_codigo == filter.pse_cli_n_codigo_filter);
            }

            if (!string.IsNullOrEmpty(filter.pse_c_nome_filter))
            {
                query = query.Where(w => w.pse_c_nome.Contains(filter.pse_c_nome_filter));
            }

            else if (!string.IsNullOrEmpty(filter.pse_c_cpf_filter))
            {
                string auxDoc = filter.pse_c_cpf_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.pse_c_cpf.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.pse_c_rg_filter))
            {
                string auxDoc = filter.pse_c_rg_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.pse_c_rg.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.pse_c_celular_filter))
            {
                string auxFone = filter.pse_c_celular_filter.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                query = query.Where(w => w.pse_c_celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Contains(auxFone));
            }

            //Ordenação
            query = query.OrderBy(x => x.pse_c_nome);

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public IPagedList<PrestadorServicoViewModel> GetPrestadorByFilter(PrestadorServicoFilterModel filter)
        {
            int idPse = Convert.ToInt32(filter.pse_n_codigo_filter);
            var query = (from prestador in Context.tb_pse_prestadorServico
                         join cliente in Context.tb_cli_cliente on prestador.pse_cli_n_codigo equals cliente.cli_n_codigo
                         where prestador.pse_n_codigo == idPse && prestador.pse_d_dataSaidaManual != null
                         select new PrestadorServicoViewModel
                         {
                             nomeCliente = cliente.cli_c_nomeFantasia,
                             pse_n_codigo = prestador.pse_n_codigo.ToString(),
                             pse_cli_n_codigo = prestador.pse_cli_n_codigo.ToString(),
                             pse_c_nome = prestador.pse_c_nome,
                             pse_c_rg = prestador.pse_c_rg,
                             pse_c_cpf = prestador.pse_c_cpf,
                             pse_c_celular = prestador.pse_c_celular,
                             pse_n_horarioAdicional = prestador.pse_n_horarioAdicional.ToString(),
                             pse_d_dataEntrada = prestador.pse_d_dataEntrada != null ? prestador.pse_d_dataEntrada.Value.ToString("dd/MM/yyyy HH:mm:ss") : "",
                             pse_d_dataSaidaManual = prestador.pse_d_dataSaidaManual != null ? prestador.pse_d_dataSaidaManual.Value.ToString("dd/MM/yyyy HH:mm:ss") : "",
                             pse_c_estado = prestador.pse_c_estado
                         });

            var lista = query.ToPagedList(filter.paginaDataTable, filter.quantidade);

            return lista;
        }

        public List<PrestadorServicoViewModel> GetPrestadorServicoByCliente(int id)
        {
            return (from pse in context.tb_pse_prestadorServico
                    where pse.pse_cli_n_codigo == id
                    select new PrestadorServicoViewModel()
                    {
                        pse_n_codigo = pse.pse_n_codigo.ToString(),
                        pse_c_nome = pse.pse_c_nome,
                        pse_c_rg = pse.pse_c_rg,
                        pse_c_cpf = pse.pse_c_cpf,
                        pse_c_celular = pse.pse_c_celular,
                        pse_c_email = pse.pse_c_email,
                        pse_c_perfil = pse.pse_c_perfil,
                        pse_d_dataExpriracao = pse.pse_d_dataExpriracao.ToString(),
                        pse_c_numeroCartao = pse.pse_c_numeroCartao,
                        pse_c_localizacao = pse.pse_c_localizacao,
                        pse_c_observacao = pse.pse_c_observacao,
                        //pse_fot_n_codigo = pse.pse_fot_n_codigo,
                        pse_cli_n_codigo = pse.pse_cli_n_codigo.ToString(),
                        pse_d_alteracao = pse.pse_d_alteracao.ToString(),
                        pse_c_usuario = pse.pse_c_usuario,
                        pse_gpv_n_codigo = pse.pse_gpv_n_codigo.ToString(),
                        pse_c_placaVeiculo = pse.pse_c_placaVeiculo,
                        pse_c_modeloVeiculo = pse.pse_c_modeloVeiculo,
                        pse_c_corVeiculo = pse.pse_c_corVeiculo,
                        pse_d_modificacao = pse.pse_d_modificacao.ToString(),
                        pse_b_ativoInativo = pse.pse_b_ativoInativo.ToString(),
                        pse_b_liberadoAntPassBack = pse.pse_b_liberadoAntPassBack.ToString(),
                        //pse_fot_n_documento = pse.pse_fot_n_documento.ToString(),
                        pse_c_unique = pse.pse_c_unique.ToString(),
                        pse_d_atualizado = pse.pse_d_atualizado.ToString(),
                        pse_d_inclusao = pse.pse_d_inclusao.ToString(),
                        pse_b_inOut = pse.pse_b_inOut.ToString(),
                        pse_d_dataEntrada = pse.pse_d_dataEntrada.ToString(),
                        pse_d_dataSaidaManual = pse.pse_d_dataSaidaManual.ToString(),
                        pse_b_panicoTratado = pse.pse_b_panicoTratado.ToString(),
                        pse_n_horarioAdicional = pse.pse_n_horarioAdicional.ToString(),
                        pse_b_gerou_atendimento = pse.pse_b_gerou_atendimento.ToString(),
                        pse_c_estado = pse.pse_c_estado,
                        pse_c_codExternoPrestador = pse.pse_c_codExternoPrestador
                    }).ToList();

        }

        public PrestadorServicoViewModel GetPrestadorServico(int id)
        {
            return (from pse in context.tb_pse_prestadorServico
                    where pse.pse_n_codigo == id
                    select new PrestadorServicoViewModel()
                    {
                        pse_n_codigo = pse.pse_n_codigo.ToString(),
                        pse_c_nome = pse.pse_c_nome,
                        pse_c_rg = pse.pse_c_rg,
                        pse_c_cpf = pse.pse_c_cpf,
                        pse_c_celular = pse.pse_c_celular,
                        pse_c_email = pse.pse_c_email,
                        pse_c_perfil = pse.pse_c_perfil,
                        pse_d_dataExpriracao = pse.pse_d_dataExpriracao != null ? pse.pse_d_dataExpriracao.Value.ToString("yyyy-MM-dd") : string.Empty,
                        pse_c_numeroCartao = pse.pse_c_numeroCartao,
                        pse_c_localizacao = pse.pse_c_localizacao,
                        pse_c_observacao = pse.pse_c_observacao,
                        pse_fot_n_codigo = pse.pse_fot_n_codigo.ToString(),
                        pse_cli_n_codigo = pse.pse_cli_n_codigo.ToString(),
                        pse_d_alteracao = pse.pse_d_alteracao.ToString(),
                        pse_c_usuario = pse.pse_c_usuario,
                        pse_gpv_n_codigo = pse.pse_gpv_n_codigo.ToString(),
                        pse_c_placaVeiculo = pse.pse_c_placaVeiculo,
                        pse_c_modeloVeiculo = pse.pse_c_modeloVeiculo,
                        pse_c_corVeiculo = pse.pse_c_corVeiculo,
                        pse_d_modificacao = pse.pse_d_modificacao.ToString(),
                        pse_b_ativoInativo = pse.pse_b_ativoInativo.Value ? "ATIVO" : "INATIVO",
                        //pse_b_liberadoAntPassBack = pse.pse_b_liberadoAntPassBack.ToString(),
                        pse_fot_n_documento = pse.pse_fot_n_documento != null ? pse.pse_fot_n_documento.ToString() : "0",
                        pse_c_unique = pse.pse_c_unique.ToString(),
                        pse_d_atualizado = pse.pse_d_atualizado.ToString(),
                        pse_d_inclusao = pse.pse_d_inclusao.ToString(),
                        pse_b_inOut = pse.pse_b_inOut.ToString(),
                        pse_d_dataEntrada = pse.pse_d_dataEntrada.ToString(),
                        pse_d_dataSaidaManual = pse.pse_d_dataSaidaManual.ToString(),
                        pse_b_panicoTratado = pse.pse_b_panicoTratado.ToString(),
                        pse_n_horarioAdicional = pse.pse_n_horarioAdicional.ToString(),
                        pse_b_gerou_atendimento = pse.pse_b_gerou_atendimento.ToString(),
                        pse_c_estado = pse.pse_c_estado,
                        pse_c_codExternoPrestador = pse.pse_c_codExternoPrestador
                    }).FirstOrDefault();

        }

        public int SalvarPrestadorServico(PrestadorServicoViewModel model)
        {
            if (!string.IsNullOrEmpty(model.pse_c_rg))
            {
                VerificarRGDuplicado(model);
            }

            VerificaCPFDuplicado(model);
            tb_pse_prestadorServico prestadorServico;

            if (string.IsNullOrEmpty(model.pse_n_codigo) || model.pse_n_codigo.Equals("0"))
            {
                prestadorServico = new tb_pse_prestadorServico()
                {
                    pse_c_nome = model.pse_c_nome.Trim().ToUpper(),
                    pse_c_rg = model.pse_c_rg,
                    pse_c_cpf = model.pse_c_cpf,
                    pse_c_celular = model.pse_c_celular,
                    pse_c_email = model.pse_c_email,
                    pse_c_perfil = model.pse_c_perfil,
                    pse_d_dataExpriracao = !string.IsNullOrEmpty(model.pse_d_dataExpriracao) ? Convert.ToDateTime(model.pse_d_dataExpriracao) : new DateTime?(),
                    pse_c_numeroCartao = model.pse_c_numeroCartao,
                    pse_c_localizacao = model.pse_c_localizacao,
                    pse_c_observacao = model.pse_c_observacao,
                    pse_fot_n_codigo = !string.IsNullOrEmpty(model.pse_fot_n_codigo) && !model.pse_fot_n_codigo.Equals("0") ? Convert.ToInt32(model.pse_fot_n_codigo) : new int?(),
                    pse_cli_n_codigo = !string.IsNullOrEmpty(model.pse_cli_n_codigo) && !model.pse_cli_n_codigo.Equals("0") ? Convert.ToInt32(model.pse_cli_n_codigo) : new int?(),
                    pse_d_alteracao = DateTime.Now,
                    pse_c_usuario = "FELIPE",
                    pse_gpv_n_codigo = !string.IsNullOrEmpty(model.pse_gpv_n_codigo) && !model.pse_gpv_n_codigo.Equals("0") ? Convert.ToInt32(model.pse_gpv_n_codigo) : new int?(),
                    pse_c_placaVeiculo = model.pse_c_placaVeiculo,
                    pse_c_modeloVeiculo = model.pse_c_modeloVeiculo,
                    pse_c_corVeiculo = model.pse_c_corVeiculo,
                    pse_d_modificacao = DateTime.Now,
                    pse_b_ativoInativo = model.pse_b_ativoInativo == "ATIVO",
                    //pse_b_liberadoAntPassBack = model.pse_b_liberadoAntPassBack == "SIM",
                    pse_fot_n_documento = !string.IsNullOrEmpty(model.pse_fot_n_documento) && !model.pse_fot_n_documento.Equals("0") ? Convert.ToInt32(model.pse_fot_n_documento) : new int?(),
                    pse_c_unique = Guid.NewGuid(),
                    pse_d_atualizado = DateTime.Now,
                    pse_d_inclusao = DateTime.Now,
                    pse_b_inOut = false,
                    pse_c_estado = model.pse_c_estado,
                    pse_c_codExternoPrestador = model.pse_c_codExternoPrestador
                };

                Insert(prestadorServico);
                context.SaveChanges();
            }
            else
            {
                prestadorServico = context.tb_pse_prestadorServico.Where(x => x.pse_n_codigo == Convert.ToInt32(model.pse_n_codigo)).FirstOrDefault();

                if (prestadorServico.pse_b_ativoInativo != (model.pse_b_ativoInativo == "ATIVO") || prestadorServico.pse_c_perfil != model.pse_c_perfil)
                {
                    SincronizarPlaca(prestadorServico.pse_n_codigo);
                }

                prestadorServico.pse_c_nome = model.pse_c_nome.Trim().ToUpper();
                prestadorServico.pse_c_rg = model.pse_c_rg;
                prestadorServico.pse_c_cpf = model.pse_c_cpf;
                prestadorServico.pse_c_celular = model.pse_c_celular;
                prestadorServico.pse_c_email = model.pse_c_email;
                prestadorServico.pse_c_perfil = model.pse_c_perfil;
                prestadorServico.pse_d_dataExpriracao = !string.IsNullOrEmpty(model.pse_d_dataExpriracao) ? Convert.ToDateTime(model.pse_d_dataExpriracao) : new DateTime?();
                prestadorServico.pse_c_numeroCartao = model.pse_c_numeroCartao;
                prestadorServico.pse_c_localizacao = model.pse_c_localizacao;
                prestadorServico.pse_c_observacao = model.pse_c_observacao;
                prestadorServico.pse_fot_n_codigo = !string.IsNullOrEmpty(model.pse_fot_n_codigo) && !model.pse_fot_n_codigo.Equals("0") ? Convert.ToInt32(model.pse_fot_n_codigo) : new int?();
                prestadorServico.pse_cli_n_codigo = !string.IsNullOrEmpty(model.pse_cli_n_codigo) && !model.pse_cli_n_codigo.Equals("0") ? Convert.ToInt32(model.pse_cli_n_codigo) : new int?();
                prestadorServico.pse_d_alteracao = DateTime.Now;
                prestadorServico.pse_c_usuario = "FELIPE";
                prestadorServico.pse_gpv_n_codigo = !string.IsNullOrEmpty(model.pse_gpv_n_codigo) && !model.pse_gpv_n_codigo.Equals("0") ? Convert.ToInt32(model.pse_gpv_n_codigo) : new int?();
                prestadorServico.pse_c_placaVeiculo = model.pse_c_placaVeiculo;
                prestadorServico.pse_c_modeloVeiculo = model.pse_c_modeloVeiculo;
                prestadorServico.pse_c_corVeiculo = model.pse_c_corVeiculo;
                prestadorServico.pse_d_modificacao = DateTime.Now;
                prestadorServico.pse_b_ativoInativo = model.pse_b_ativoInativo == "ATIVO";
                //prestadorServico.pse_b_liberadoAntPassBack = model.pse_b_liberadoAntPassBack == "SIM";
                prestadorServico.pse_fot_n_documento = !string.IsNullOrEmpty(model.pse_fot_n_documento) && !model.pse_fot_n_documento.Equals("0") ? Convert.ToInt32(model.pse_fot_n_documento) : new int?();
                prestadorServico.pse_d_atualizado = DateTime.Now;
                prestadorServico.pse_c_estado = model.pse_c_estado;
                prestadorServico.pse_c_codExternoPrestador = model.pse_c_codExternoPrestador;

                Update(prestadorServico);
                context.SaveChanges();
            }

            return prestadorServico.pse_n_codigo;
        }

        public void VerificaCPFDuplicado(PrestadorServicoViewModel model)
        {
            if (string.IsNullOrEmpty(model.pse_c_cpf))
                return;

            var prestadores = (from pse in context.tb_pse_prestadorServico
                               where pse.pse_n_codigo != Convert.ToInt32(model.pse_n_codigo) && pse.pse_cli_n_codigo == Convert.ToInt32(model.pse_cli_n_codigo)
                               && pse.pse_c_cpf == model.pse_c_cpf
                               select pse).Count();

            var visitantes = (from vis in context.tb_vis_visitante
                              where vis.vis_cli_n_codigo == Convert.ToInt32(model.pse_cli_n_codigo) && vis.vis_c_cpf == model.pse_c_cpf
                              select vis).Count();

            var moradores = (from mor in context.tb_mor_Morador
                             where mor.mor_cli_n_codigo == Convert.ToInt32(model.pse_cli_n_codigo) && mor.mor_c_cpf == model.pse_c_cpf
                             select mor).Count();

            if (moradores > 0 || visitantes > 0 || prestadores > 0)
                throw new MensagemException("O CPF digitado já está sendo usado, verifque novamente ou contate o Administrador.");
        }

        public void VerificarRGDuplicado(PrestadorServicoViewModel model)
        {
            var queryPrestador = (from pse in context.tb_pse_prestadorServico
                                  where pse.pse_cli_n_codigo == Convert.ToInt32(model.pse_cli_n_codigo)
                                  && pse.pse_c_rg != null && pse.pse_n_codigo != Convert.ToInt32(model.pse_n_codigo)
                                  select pse).ToList();

            var queryVisitante = (from vis in context.tb_vis_visitante
                                  where vis.vis_cli_n_codigo == Convert.ToInt32(model.pse_cli_n_codigo)
                                  && vis.vis_c_rg != null
                                  select vis).ToList();

            var queryMorador = (from mor in context.tb_mor_Morador
                                where mor.mor_cli_n_codigo == Convert.ToInt32(model.pse_cli_n_codigo)
                                && mor.mor_c_rg != null
                                select mor).ToList();

            string inputIn = model.pse_c_rg;
            string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\\s]";
            string inputOut = Regex.Replace(inputIn, pattern, "").ToUpper();

            List<string> listaRgMorador = new List<string>();
            List<string> listaRgVisitante = new List<string>();
            List<string> listaRgPrestador = new List<string>();

            //Prestador
            for (int i = 0; i < queryPrestador.Count; i++)
            {
                listaRgPrestador.Add(Regex.Replace(queryPrestador[i].pse_c_rg.ToString(), pattern, ""));
            }
            string[] arrayPrestador_rg = listaRgPrestador.ToArray();
            for (int i = 0; i < arrayPrestador_rg.Length; i++)
            {
                if (inputOut == arrayPrestador_rg[i] && model.pse_c_estado == queryPrestador[i].pse_c_estado)
                {
                    throw new MensagemException("O RG digitado já está sendo usado, verifque novamente ou contate o Administrador.");
                }
            }

            //Visitante
            for (int i = 0; i < queryVisitante.Count; i++)
            {
                listaRgVisitante.Add(Regex.Replace(queryVisitante[i].vis_c_rg.ToString(), pattern, ""));
            }
            string[] arrayVisitante_rg = listaRgVisitante.ToArray();
            for (int i = 0; i < arrayVisitante_rg.Length; i++)
            {
                if (inputOut == arrayVisitante_rg[i] && model.pse_c_estado == queryVisitante[i].vis_c_estado)
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
                if (inputOut == arrayMorador_rg[i] && model.pse_c_estado == queryMorador[i].mor_c_estado)
                {
                    throw new MensagemException("O RG digitado já está sendo usado, verifque novamente ou contate o Administrador.");
                }
            }
        }

        public bool? AtivarDesativar(int id)
        {
            try
            {
                var prestador = (from pse in context.tb_pse_prestadorServico where pse.pse_n_codigo == id select pse).FirstOrDefault();
                if (prestador != null)
                {
                    using var transaction = context.Database.BeginTransaction();
                    prestador.pse_b_ativoInativo = !prestador.pse_b_ativoInativo;

                    Update(prestador);

                    SincronizarPlaca(prestador.pse_n_codigo);
                    transaction.Commit();

                    context.SaveChanges();

                    return prestador.pse_b_ativoInativo;
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
                    SqlParameter auxId = new SqlParameter("@PSE_N_CODIGO", id);

                    command.CommandText = "[EXCLUSAO_PRESTADORSERVICO]";
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

        private void SincronizarPlaca(int prestadorId)
        {
            string controladoras = "";
            var idsControladoras = new List<int>();
            var clienteId = (from pse in context.tb_pse_prestadorServico where pse.pse_n_codigo == prestadorId select pse.pse_cli_n_codigo)?.FirstOrDefault();
            var tb_cac = (from cac in context.tb_cac_controleAcesso where cac.cac_pse_n_codigo == prestadorId select cac)?.ToList();
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

        public bool salvarHoraio(PrestadorServicoViewModel model)
        {
            try
            {
                var prestador = (from pse in context.tb_pse_prestadorServico where pse.pse_n_codigo == Convert.ToInt32(model.pse_n_codigo) select pse).FirstOrDefault();
                if (prestador != null)
                {
                    prestador.pse_n_horarioAdicional = Convert.ToInt32(model.horario);
                    prestador.pse_d_dataSaidaManual = DateTime.Now.AddMinutes(prestador.pse_n_horarioAdicional.Value);
                    prestador.pse_b_panicoTratado = true;

                    Update(prestador);
                    context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IPagedList<PrestadorServicoViewModel> GetPrestadorBuscarFiltrado(PrestadorServicoFilterModel filter)
        {
            var query = (from prestador in Context.tb_pse_prestadorServico
                         select new PrestadorServicoViewModel
                         {
                             pse_n_codigo = prestador.pse_n_codigo.ToString(),
                             pse_cli_n_codigo = prestador.pse_cli_n_codigo.ToString(),
                             pse_c_nome = prestador.pse_c_nome,
                             pse_c_rg = prestador.pse_c_rg,
                             pse_c_estado = prestador.pse_c_estado,
                             pse_c_cpf = prestador.pse_c_cpf,
                             pse_c_celular = prestador.pse_c_celular.Replace(" ", ""),
                             pse_c_localizacao = prestador.pse_c_localizacao,
                             pse_c_placaVeiculo = prestador.pse_c_placaVeiculo,
                             pse_c_modeloVeiculo = prestador.pse_c_modeloVeiculo,
                             pse_c_corVeiculo = prestador.pse_c_corVeiculo,
                         });

            //Filtros
            if (!string.IsNullOrEmpty(filter.pse_cli_n_codigo_filter))
            {
                query = query.Where(w => w.pse_cli_n_codigo == filter.pse_cli_n_codigo_filter);
            }

            if (!string.IsNullOrEmpty(filter.pse_c_nome_filter))
            {
                query = query.Where(w => w.pse_c_nome.Contains(filter.pse_c_nome_filter));
            }

            else if (!string.IsNullOrEmpty(filter.pse_c_cpf_filter))
            {
                string auxDoc = filter.pse_c_cpf_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.pse_c_cpf.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.pse_c_rg_filter))
            {
                string auxDoc = filter.pse_c_rg_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.pse_c_rg.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.pse_c_celular_filter))
            {
                string auxFone = filter.pse_c_celular_filter.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                query = query.Where(w => w.pse_c_celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Contains(auxFone));
            }

            if (!string.IsNullOrEmpty(filter.pse_c_placaVeiculo_filter))
            {
                query = query.Where(w => w.pse_c_placaVeiculo.Contains(filter.pse_c_placaVeiculo_filter));
            }

            if (!string.IsNullOrEmpty(filter.pse_c_localizacao_filter))
            {
                var aux = new List<string>();
                foreach (var q in query)
                {
                    if (!string.IsNullOrEmpty(q.pse_c_localizacao))
                    {
                        var index = q.pse_c_localizacao.IndexOf('/') + 1;
                        var localizacao = q.pse_c_localizacao.Substring(index).ToLower();
                        if (localizacao.Replace(" ", "") == filter.pse_c_localizacao_filter.ToLower().Replace(" ", ""))
                        {
                            aux.Add(q.pse_n_codigo);
                        }
                    }
                }
                query = query.Where(w => aux.Contains(w.pse_n_codigo));
            }

            //Ordenação
            query = query.OrderBy(x => x.pse_c_nome);

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }
    }
}