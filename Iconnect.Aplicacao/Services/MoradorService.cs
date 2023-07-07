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
    class MoradorService : RepositoryBase<tb_mor_Morador>, IMoradorService
    {
        private readonly IconnectCoreContext context;
        private ISincronizacaoPlacasService _sincronizacaoPlacas;

        public MoradorService(IconnectCoreContext context) : base(context)
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

        public IPagedList<MoradorViewModel> GetMoradorFiltrado(MoradorFilterModel filter)
        {
            var query = (from morador in Context.tb_mor_Morador
                         select new MoradorViewModel
                         {
                             mor_n_codigo = morador.mor_n_codigo.ToString(),
                             mor_cli_n_codigo = morador.mor_cli_n_codigo.ToString(),
                             mor_c_nome = morador.mor_c_nome,
                             mor_c_rg = morador.mor_c_rg,
                             mor_c_estado = morador.mor_c_estado,
                             mor_c_cpf = morador.mor_c_cpf,
                             mor_c_telefonePermitido = morador.mor_c_telefonePermitido.Replace(" ", ""),
                         });

            //Filtros
            if (filter.idsClientes_filter != null && filter.idsClientes_filter.Count() > 0)
            {
                query = query.Where(w => filter.idsClientes_filter.Contains(w.mor_cli_n_codigo));
            }

            if (!string.IsNullOrEmpty(filter.mor_cli_n_codigo_filter))
            {
                query = query.Where(w => w.mor_cli_n_codigo.Equals(filter.mor_cli_n_codigo_filter));
            }

            if (!string.IsNullOrEmpty(filter.mor_c_nome_filter))
            {
                query = query.Where(w => w.mor_c_nome.Contains(filter.mor_c_nome_filter));
            }
            else if (!string.IsNullOrEmpty(filter.mor_c_cpf_filter))
            {
                string auxDoc = filter.mor_c_cpf_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.mor_c_cpf.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.mor_c_rg_filter))
            {
                string auxDoc = filter.mor_c_rg_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.mor_c_rg.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.mor_c_telefonePermitido_filter))
            {
                string auxFone = filter.mor_c_telefonePermitido_filter.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                query = query.Where(w => w.mor_c_telefonePermitido.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Contains(auxFone));
            }

            //Ordenação
            query = query.OrderBy(x => x.mor_c_nome);

            return query.DistinctBy(x => x.mor_n_codigo).ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public List<MoradorViewModel> GetMoradores()
        {
            return (from mor in context.tb_mor_Morador
                    select new MoradorViewModel()
                    {
                        mor_n_codigo = mor.mor_n_codigo.ToString(),
                        mor_c_nome = mor.mor_c_nome,
                        mor_c_rg = mor.mor_c_rg,
                        mor_c_cpf = mor.mor_c_cpf,
                        mor_d_dataNascimento = mor.mor_d_dataNascimento.ToString(),
                        mor_c_email = mor.mor_c_email,
                        mor_c_telefonePermitido = mor.mor_c_telefonePermitido,
                        mor_c_celular = mor.mor_c_celular,
                        mor_c_ramal = mor.mor_c_ramal,
                        mor_c_perfil = mor.mor_c_perfil,
                        mor_c_observacao = mor.mor_c_observacao,
                        mor_b_ativoInativo = mor.mor_b_ativoInativo.ToString(),
                        //mor_fot_n_codigo = mor.mor_fot_n_codigo.ToString(),
                        mor_cli_n_codigo = mor.mor_cli_n_codigo.ToString(),
                        mor_grf_n_codigo = mor.mor_grf_n_codigo.ToString(),
                        mor_b_antpassback = mor.mor_b_antpassback.ToString(),
                        mor_d_alteracao = mor.mor_d_alteracao.ToString(),
                        mor_c_usuario = mor.mor_c_usuario,
                        mor_c_autorizacao = mor.mor_c_autorizacao,
                        mor_d_modificacao = mor.mor_d_modificacao.ToString(),
                        mor_b_notificacao = mor.mor_b_notificacao.ToString(),
                        mor_b_liberadoAntPassBack = mor.mor_b_liberadoAntPassBack.ToString(),
                        mor_c_senha = mor.mor_c_senha,
                        mor_c_contraSenha = mor.mor_c_contraSenha,
                        mor_fot_n_documento = mor.mor_fot_n_documento.ToString(),
                        mor_c_unique = mor.mor_c_unique.ToString(),
                        mor_d_atualizado = mor.mor_d_atualizado.ToString(),
                        mor_d_inclusao = mor.mor_d_inclusao.ToString(),
                        mor_b_sindico = mor.mor_b_sindico.ToString(),
                        mor_c_senhaAPPPro = mor.mor_c_senhaAPPPro,
                        mor_c_autorizacaoPRO = mor.mor_c_autorizacaoPRO,
                        mor_b_inOut = mor.mor_b_inOut.ToString(),
                        mor_d_dataEntrada = mor.mor_d_dataEntrada.ToString(),
                        mor_c_codExternoFuncionario = mor.mor_c_codExternoFuncionario,
                        mor_c_estado = mor.mor_c_estado
                    }).ToList();

        }

        public List<MoradorViewModel> GetMoradoresByGrupoFamiliar(int idGrupoFamiliar)
        {
            List<int> ids = (from afa in context.tb_afa_afastamento where afa.afa_b_expirado == false select afa.afa_mor_n_codigo).ToList();

            var Moradores = (from mor in context.tb_mor_Morador
                             orderby mor.mor_c_nome ascending
                             where mor.mor_grf_n_codigo == idGrupoFamiliar && mor.mor_b_ativoInativo == true
                             select new MoradorViewModel()
                             {
                                 mor_n_codigo = mor.mor_n_codigo.ToString(),
                                 mor_c_nome = mor.mor_c_nome,
                                 mor_c_rg = mor.mor_c_rg,
                                 mor_c_cpf = mor.mor_c_cpf,
                                 mor_d_dataNascimento = mor.mor_d_dataNascimento.ToString(),
                                 mor_c_email = mor.mor_c_email,
                                 mor_c_telefonePermitido = mor.mor_c_telefonePermitido,
                                 mor_c_celular = mor.mor_c_celular,
                                 mor_c_ramal = mor.mor_c_ramal,
                                 mor_c_perfil = mor.mor_c_perfil,
                                 mor_c_observacao = mor.mor_c_observacao,
                                 mor_b_ativoInativo = mor.mor_b_ativoInativo.ToString(),
                                 //mor_fot_n_codigo = mor.mor_fot_n_codigo.ToString(),
                                 mor_cli_n_codigo = mor.mor_cli_n_codigo.ToString(),
                                 mor_grf_n_codigo = mor.mor_grf_n_codigo.ToString(),
                                 mor_b_antpassback = mor.mor_b_antpassback.ToString(),
                                 mor_d_alteracao = mor.mor_d_alteracao.ToString(),
                                 mor_c_usuario = mor.mor_c_usuario,
                                 mor_c_autorizacao = mor.mor_c_autorizacao,
                                 mor_d_modificacao = mor.mor_d_modificacao.ToString(),
                                 mor_b_notificacao = mor.mor_b_notificacao.ToString(),
                                 mor_b_liberadoAntPassBack = mor.mor_b_liberadoAntPassBack.ToString(),
                                 mor_c_senha = mor.mor_c_senha,
                                 mor_c_contraSenha = mor.mor_c_contraSenha,
                                 mor_fot_n_documento = mor.mor_fot_n_documento.ToString(),
                                 mor_c_unique = mor.mor_c_unique.ToString(),
                                 mor_d_atualizado = mor.mor_d_atualizado.ToString(),
                                 mor_d_inclusao = mor.mor_d_inclusao.ToString(),
                                 mor_b_sindico = mor.mor_b_sindico.ToString(),
                                 mor_c_senhaAPPPro = mor.mor_c_senhaAPPPro,
                                 mor_c_autorizacaoPRO = mor.mor_c_autorizacaoPRO,
                                 mor_b_inOut = mor.mor_b_inOut.ToString(),
                                 mor_d_dataEntrada = mor.mor_d_dataEntrada.ToString(),
                                 mor_c_codExternoFuncionario = mor.mor_c_codExternoFuncionario,
                                 mor_c_estado = mor.mor_c_estado
                             }).ToList();


            Moradores = Moradores.Where(x => !ids.Contains(Convert.ToInt32(x.mor_n_codigo))).ToList();

            return Moradores;
        }

        public List<MoradorViewModel> GetMoradoresBySalaComercial(int idSala)
        {
            List<int> idsMorUserSala = new List<int>();
            var UserSala = (from mor in context.tb_mor_Morador
                            orderby mor.mor_c_nome ascending
                            where mor.mor_grf_n_codigo == idSala && mor.mor_b_ativoInativo == true
                            select new MoradorViewModel()
                            {
                                mor_n_codigo = mor.mor_n_codigo.ToString(),
                                mor_c_nome = mor.mor_c_nome,
                                mor_c_rg = mor.mor_c_cpf,

                            }).ToList();

            return UserSala;
        }

        public List<MoradorViewModel> GetMoradoresByCliente(int id)
        {
            return (from mor in context.tb_mor_Morador
                    where mor.mor_cli_n_codigo == id
                    orderby mor.mor_c_nome
                    select new MoradorViewModel()
                    {
                        mor_n_codigo = mor.mor_n_codigo.ToString(),
                        mor_c_nome = mor.mor_c_nome,
                        mor_c_rg = mor.mor_c_rg,
                        mor_c_cpf = mor.mor_c_cpf,
                        mor_d_dataNascimento = mor.mor_d_dataNascimento.ToString(),
                        mor_c_email = mor.mor_c_email,
                        mor_c_telefonePermitido = mor.mor_c_telefonePermitido,
                        mor_c_celular = mor.mor_c_celular,
                        mor_c_ramal = mor.mor_c_ramal,
                        mor_c_perfil = mor.mor_c_perfil,
                        mor_c_observacao = mor.mor_c_observacao,
                        mor_b_ativoInativo = mor.mor_b_ativoInativo.ToString(),
                        //mor_fot_n_codigo = mor.mor_fot_n_codigo.ToString(),
                        mor_cli_n_codigo = mor.mor_cli_n_codigo.ToString(),
                        mor_grf_n_codigo = mor.mor_grf_n_codigo.ToString(),
                        mor_b_antpassback = mor.mor_b_antpassback.ToString(),
                        mor_d_alteracao = mor.mor_d_alteracao.ToString(),
                        mor_c_usuario = mor.mor_c_usuario,
                        mor_c_autorizacao = mor.mor_c_autorizacao,
                        mor_d_modificacao = mor.mor_d_modificacao.ToString(),
                        mor_b_notificacao = mor.mor_b_notificacao.ToString(),
                        mor_b_liberadoAntPassBack = mor.mor_b_liberadoAntPassBack.ToString(),
                        mor_c_senha = mor.mor_c_senha,
                        mor_c_contraSenha = mor.mor_c_contraSenha,
                        mor_fot_n_documento = mor.mor_fot_n_documento.ToString(),
                        mor_c_unique = mor.mor_c_unique.ToString(),
                        mor_d_atualizado = mor.mor_d_atualizado.ToString(),
                        mor_d_inclusao = mor.mor_d_inclusao.ToString(),
                        mor_b_sindico = mor.mor_b_sindico.ToString(),
                        mor_c_senhaAPPPro = mor.mor_c_senhaAPPPro,
                        mor_c_autorizacaoPRO = mor.mor_c_autorizacaoPRO,
                        mor_b_inOut = mor.mor_b_inOut.ToString(),
                        mor_d_dataEntrada = mor.mor_d_dataEntrada.ToString(),
                        mor_c_codExternoFuncionario = mor.mor_c_codExternoFuncionario,
                        mor_c_estado = mor.mor_c_estado
                    }).ToList();
        }

        public MoradorViewModel GetMorador(int id)
        {
            return (from mor in context.tb_mor_Morador
                    join grupo in context.tb_grf_grupoFamiliar on mor.mor_grf_n_codigo equals grupo.grf_n_codigo into subGrupo
                    from grupoFamiliar in subGrupo.DefaultIfEmpty()
                    where mor.mor_n_codigo == id
                    select new MoradorViewModel()
                    {
                        mor_n_codigo = mor.mor_n_codigo.ToString(),
                        mor_c_nome = mor.mor_c_nome,
                        mor_c_rg = mor.mor_c_rg,
                        mor_c_cpf = mor.mor_c_cpf,
                        mor_d_dataNascimento = mor.mor_d_dataNascimento != null ? mor.mor_d_dataNascimento.Value.ToString("yyyy-MM-dd") : string.Empty,
                        mor_c_email = mor.mor_c_email,
                        mor_c_telefonePermitido = mor.mor_c_telefonePermitido,
                        mor_c_celular = mor.mor_c_celular,
                        mor_c_ramal = mor.mor_c_ramal,
                        mor_c_perfil = mor.mor_c_perfil,
                        mor_c_observacao = mor.mor_c_observacao,
                        mor_b_ativoInativo = mor.mor_b_ativoInativo.Value ? "ATIVO" : "INATIVO",
                        mor_fot_n_codigo = mor.mor_fot_n_codigo.ToString(),
                        mor_cli_n_codigo = mor.mor_cli_n_codigo.ToString(),
                        mor_grf_n_codigo = mor.mor_grf_n_codigo.ToString(),
                        mor_b_antpassback = mor.mor_b_antpassback.Value ? "SIM" : "NAO",
                        mor_d_alteracao = mor.mor_d_alteracao.ToString(),
                        mor_c_usuario = mor.mor_c_usuario,
                        mor_c_autorizacao = mor.mor_c_autorizacao,
                        mor_d_modificacao = mor.mor_d_modificacao.ToString(),
                        mor_b_notificacao = mor.mor_b_notificacao.ToString(),
                        mor_b_liberadoAntPassBack = mor.mor_b_liberadoAntPassBack.ToString(),
                        mor_c_senha = mor.mor_c_senha,
                        mor_c_contraSenha = mor.mor_c_contraSenha,
                        mor_fot_n_documento = mor.mor_fot_n_documento != null ? mor.mor_fot_n_documento.ToString() : "0",
                        mor_c_unique = mor.mor_c_unique.ToString(),
                        mor_d_atualizado = mor.mor_d_atualizado.ToString(),
                        mor_d_inclusao = mor.mor_d_inclusao.ToString(),
                        mor_b_sindico = mor.mor_b_sindico.ToString(),
                        mor_c_senhaAPPPro = mor.mor_c_senhaAPPPro,
                        mor_c_autorizacaoPRO = mor.mor_c_autorizacaoPRO,
                        mor_b_inOut = mor.mor_b_inOut.ToString(),
                        mor_d_dataEntrada = mor.mor_d_dataEntrada.ToString(),
                        inativoByGrupoFamiliar = grupoFamiliar.grf_c_status == "INATIVO",
                        mor_c_codExternoFuncionario = mor.mor_c_codExternoFuncionario,
                        mor_c_estado = mor.mor_c_estado,
                        mor_vec_n_codigo = mor.mor_vec_n_codigo.ToString(),
                        mor_fro_n_codigo = mor.mor_fro_n_codigo.ToString(),
                    }).FirstOrDefault();
        }

        public int SalvarMorador(MoradorViewModel model)
        {
            if (!string.IsNullOrEmpty(model.mor_c_rg))
            {
                VerificarRGDuplicado(model);
            }

            VerificaCPFDuplicado(model);
            var morador = new tb_mor_Morador();

            if (string.IsNullOrEmpty(model.mor_n_codigo) || model.mor_n_codigo.ToString() == "0")
            {
                var clienteFree = (from mor in Context.tb_mor_Morador
                                   join cli in Context.tb_cli_cliente on mor.mor_cli_n_codigo equals cli.cli_n_codigo
                                   where cli.cli_n_codigo == Convert.ToInt32(model.mor_cli_n_codigo) && cli.cli_b_free == true
                                   select mor).Count();

                var qtdCadastroFree = 2500;

                if (clienteFree < qtdCadastroFree)
                {
                    morador = new tb_mor_Morador()
                    {
                        mor_c_nome = model.mor_c_nome.Trim().ToUpper(),
                        mor_c_rg = model.mor_c_rg,
                        mor_c_cpf = model.mor_c_cpf,
                        mor_d_dataNascimento = !string.IsNullOrEmpty(model.mor_d_dataNascimento) ? Convert.ToDateTime(model.mor_d_dataNascimento) : new DateTime?(),
                        mor_c_email = model.mor_c_email,
                        mor_c_telefonePermitido = model.mor_c_telefonePermitido,
                        mor_c_celular = model.mor_c_celular,
                        mor_c_ramal = model.mor_c_ramal,
                        mor_c_perfil = model.mor_c_perfil,
                        mor_c_observacao = model.mor_c_observacao,
                        mor_b_ativoInativo = model.mor_b_ativoInativo == "ATIVO",
                        mor_fot_n_codigo = !string.IsNullOrEmpty(model.mor_fot_n_codigo) && !model.mor_fot_n_codigo.Equals("0") ? Convert.ToInt32(model.mor_fot_n_codigo) : new int?(),
                        mor_cli_n_codigo = !string.IsNullOrEmpty(model.mor_cli_n_codigo) && !model.mor_cli_n_codigo.Equals("0") ? Convert.ToInt32(model.mor_cli_n_codigo) : new int?(),
                        mor_grf_n_codigo = !string.IsNullOrEmpty(model.mor_grf_n_codigo) && !model.mor_grf_n_codigo.Equals("0") ? Convert.ToInt32(model.mor_grf_n_codigo) : new int?(),
                        mor_b_antpassback = model.mor_b_antpassback == "SIM",
                        mor_d_alteracao = DateTime.Now,
                        mor_c_usuario = "FELIPE",
                        mor_d_modificacao = DateTime.Now,
                        mor_fot_n_documento = !string.IsNullOrEmpty(model.mor_fot_n_documento) && !model.mor_fot_n_documento.Equals("0") ? Convert.ToInt32(model.mor_fot_n_documento) : new int?(),
                        mor_c_unique = Guid.NewGuid(),
                        mor_d_atualizado = DateTime.Now,
                        mor_d_inclusao = DateTime.Now,
                        mor_b_inOut = false,
                        mor_c_codExternoFuncionario = model.mor_c_codExternoFuncionario,
                        mor_c_estado = model.mor_c_estado,
                        mor_vec_n_codigo = !string.IsNullOrEmpty(model.mor_vec_n_codigo) && !model.mor_vec_n_codigo.Equals("0") ? Convert.ToInt32(model.mor_vec_n_codigo) : new int?(),
                        mor_fro_n_codigo = !string.IsNullOrEmpty(model.mor_fro_n_codigo) && !model.mor_fro_n_codigo.Equals("0") ? Convert.ToInt32(model.mor_fro_n_codigo) : new int?(),
                    };

                    Context.Add(morador);
                    context.SaveChanges();
                }
                else
                {
                    throw new MensagemException("O limite de cadastros de 2.500 pessoas da conta gratuita foi alcançado");
                }
            }
            else
            {
                morador = (from mor in context.tb_mor_Morador where mor.mor_n_codigo == Convert.ToInt32(model.mor_n_codigo) select mor).FirstOrDefault();
                var controlesDeAcesso = context.tb_cac_controleAcesso.Where(x => x.cac_mor_n_codigo == morador.mor_n_codigo)?.ToList();

                if (morador.mor_b_ativoInativo != (model.mor_b_ativoInativo == "ATIVO") || morador.mor_c_perfil != model.mor_c_perfil || morador.mor_b_antpassback != (model.mor_b_antpassback == "SIM"))
                {
                    SincronizarPlaca(morador.mor_n_codigo);
                }

                morador.mor_c_nome = model.mor_c_nome.Trim().ToUpper();
                morador.mor_c_rg = model.mor_c_rg;
                morador.mor_c_cpf = model.mor_c_cpf;
                morador.mor_d_dataNascimento = !string.IsNullOrEmpty(model.mor_d_dataNascimento) ? Convert.ToDateTime(model.mor_d_dataNascimento) : new DateTime?();
                morador.mor_c_email = model.mor_c_email;
                morador.mor_c_telefonePermitido = model.mor_c_telefonePermitido;
                morador.mor_c_celular = model.mor_c_celular;
                morador.mor_c_ramal = model.mor_c_ramal;
                morador.mor_c_perfil = model.mor_c_perfil;
                morador.mor_c_observacao = model.mor_c_observacao;
                morador.mor_b_ativoInativo = model.mor_b_ativoInativo == "ATIVO";
                morador.mor_fot_n_codigo = !string.IsNullOrEmpty(model.mor_fot_n_codigo) && !model.mor_fot_n_codigo.Equals("0") ? Convert.ToInt32(model.mor_fot_n_codigo) : new int?();
                morador.mor_cli_n_codigo = !string.IsNullOrEmpty(model.mor_cli_n_codigo) && !model.mor_cli_n_codigo.Equals("0") ? Convert.ToInt32(model.mor_cli_n_codigo) : new int?();
                morador.mor_grf_n_codigo = !string.IsNullOrEmpty(model.mor_grf_n_codigo) && !model.mor_grf_n_codigo.Equals("0") ? Convert.ToInt32(model.mor_grf_n_codigo) : new int?();
                morador.mor_b_antpassback = model.mor_b_antpassback == "SIM";
                morador.mor_d_alteracao = DateTime.Now;
                morador.mor_c_usuario = "FELIPE";
                morador.mor_d_modificacao = DateTime.Now;
                morador.mor_fot_n_documento = !string.IsNullOrEmpty(model.mor_fot_n_documento) && !model.mor_fot_n_documento.Equals("0") ? Convert.ToInt32(model.mor_fot_n_documento) : new int?();
                morador.mor_d_atualizado = DateTime.Now;
                morador.mor_c_codExternoFuncionario = model.mor_c_codExternoFuncionario;
                morador.mor_c_estado = model.mor_c_estado;
                morador.mor_vec_n_codigo = !string.IsNullOrEmpty(model.mor_vec_n_codigo) && !model.mor_vec_n_codigo.Equals("0") ? Convert.ToInt32(model.mor_vec_n_codigo) : new int?();
                morador.mor_fro_n_codigo = !string.IsNullOrEmpty(model.mor_fro_n_codigo) && !model.mor_fro_n_codigo.Equals("0") ? Convert.ToInt32(model.mor_fro_n_codigo) : new int?();
                
                Update(morador);
                context.SaveChanges();
            }

            return morador.mor_n_codigo;
        }

        public void VerificaCPFDuplicado(MoradorViewModel model)
        {
            if (string.IsNullOrEmpty(model.mor_c_cpf))
                return;

            var moradores = (from mor in context.tb_mor_Morador
                             where mor.mor_n_codigo != Convert.ToInt32(model.mor_n_codigo) && mor.mor_cli_n_codigo == Convert.ToInt32(model.mor_cli_n_codigo)
                             && mor.mor_c_cpf == model.mor_c_cpf
                             select mor).Count();

            var visitantes = (from vis in context.tb_vis_visitante
                              where vis.vis_cli_n_codigo == Convert.ToInt32(model.mor_cli_n_codigo) && vis.vis_c_cpf == model.mor_c_cpf
                              select vis).Count();

            var prestadores = (from pse in context.tb_pse_prestadorServico
                               where pse.pse_cli_n_codigo == Convert.ToInt32(model.mor_cli_n_codigo) && pse.pse_c_cpf == model.mor_c_cpf
                               select pse).Count();

            if (moradores > 0 || visitantes > 0 || prestadores > 0)
                throw new MensagemException("O CPF digitado já está sendo usado, verifque novamente ou contate o Administrador.");
        }

        public void VerificarRGDuplicado(MoradorViewModel model)
        {
            var queryMorador = (from mor in context.tb_mor_Morador
                                where mor.mor_cli_n_codigo == Convert.ToInt32(model.mor_cli_n_codigo)
                                && mor.mor_c_rg != null
                                && mor.mor_n_codigo != Convert.ToInt32(model.mor_n_codigo)
                                select mor).ToList();

            var queryVisitante = (from vis in context.tb_vis_visitante
                                  where vis.vis_cli_n_codigo == Convert.ToInt32(model.mor_cli_n_codigo)
                                  && vis.vis_c_rg != null
                                  select vis).ToList();

            var queryPrestador = (from pse in context.tb_pse_prestadorServico
                                  where pse.pse_cli_n_codigo == Convert.ToInt32(model.mor_cli_n_codigo)
                                  && pse.pse_c_rg != null
                                  select pse).ToList();

            string inputIn = model.mor_c_rg;
            string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\\s]";
            string inputOut = Regex.Replace(inputIn, pattern, "").ToUpper();

            List<string> listaRgMorador = new List<string>();
            List<string> listaRgVisitante = new List<string>();
            List<string> listaRgPrestador = new List<string>();

            //Morador
            for (int i = 0; i < queryMorador.Count; i++)
            {
                listaRgMorador.Add(Regex.Replace(queryMorador[i].mor_c_rg.ToString(), pattern, ""));
            }
            string[] arrayMorador_rg = listaRgMorador.ToArray();
            for (int i = 0; i < arrayMorador_rg.Length; i++)
            {
                if (inputOut == arrayMorador_rg[i] && model.mor_c_estado == queryMorador[i].mor_c_estado)
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
                if (inputOut == arrayVisitante_rg[i] && model.mor_c_estado == queryVisitante[i].vis_c_estado)
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
                if (inputOut == arrayPrestador_rg[i] && model.mor_c_estado == queryPrestador[i].pse_c_estado)
                {
                    throw new MensagemException("O RG digitado já está sendo usado, verifque novamente ou contate o Administrador.");
                }
            }
        }

        public bool? AtivarDesativar(int id)
        {
            try
            {
                var morador = (from mor in context.tb_mor_Morador where mor.mor_n_codigo == id select mor)?.FirstOrDefault();
                if (morador != null)
                {
                    using var transaction = context.Database.BeginTransaction();
                    morador.mor_b_ativoInativo = !morador.mor_b_ativoInativo;
                    Update(morador);
                    context.SaveChanges();

                    SincronizarPlaca(morador.mor_n_codigo);

                    transaction.Commit();
                    return morador.mor_b_ativoInativo;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Deletar(int id)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                SqlParameter auxId = new SqlParameter("@MOR_N_CODIGO", id);

                command.CommandText = "[EXCLUSAO_MORADOR]";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(auxId);

                context.Database.OpenConnection();

                command.ExecuteNonQuery();
            }
        }

        public List<MoradorViewModel> GetFuncionariosByCliente(int id)
        {
            List<int> ids = (from afa in context.tb_afa_afastamento where afa.afa_b_expirado == false select afa.afa_mor_n_codigo).ToList();

            var Funcionarios = (from mor in context.tb_mor_Morador
                                join cli in context.tb_cli_cliente on mor.mor_cli_n_codigo equals cli.cli_n_codigo
                                where mor.mor_cli_n_codigo == id && cli.cli_tcl_n_codigo == 2
                                select new MoradorViewModel()
                                {
                                    mor_n_codigo = mor.mor_n_codigo.ToString(),
                                    mor_c_nome = mor.mor_c_nome,

                                }).ToList();

            Funcionarios = Funcionarios.Where(x => !ids.Contains(Convert.ToInt32(x.mor_n_codigo))).ToList();

            return Funcionarios;
        }

        public List<MoradorViewModel> GetFuncionariosAtivosByCliente(int id)
        {
            List<int> ids = (from afa in context.tb_afa_afastamento where afa.afa_b_expirado == false select afa.afa_mor_n_codigo).ToList();

            var Funcionarios = (from mor in context.tb_mor_Morador
                                join cli in context.tb_cli_cliente on mor.mor_cli_n_codigo equals cli.cli_n_codigo
                                where mor.mor_cli_n_codigo == id && cli.cli_tcl_n_codigo == 2 && mor.mor_b_ativoInativo == true
                                orderby mor.mor_c_nome
                                select new MoradorViewModel()
                                {
                                    mor_n_codigo = mor.mor_n_codigo.ToString(),
                                    mor_c_nome = mor.mor_c_nome,
                                    //mor_b_ativoInativo = mor.mor_b_ativoInativo.ToString(),

                                }).ToList();

            Funcionarios = Funcionarios
                .Where(x => !ids.Contains(Convert.ToInt32(x.mor_n_codigo)))
                .ToList();

            return Funcionarios;
        }

        private void SincronizarPlaca(int moradorId)
        {
            string controladoras = "";
            var idsControladoras = new List<int>();
            var clienteId = (from mor in context.tb_mor_Morador where mor.mor_n_codigo == moradorId select mor.mor_cli_n_codigo)?.FirstOrDefault();
            var tb_cac = (from cac in context.tb_cac_controleAcesso where cac.cac_mor_n_codigo == moradorId select cac)?.ToList();
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

        public IPagedList<MoradorViewModel> GetMoradorBuscarFiltrado(MoradorFilterModel filter)
        {
            var query = (from morador in Context.tb_mor_Morador
                         join grf in context.tb_grf_grupoFamiliar on morador.mor_grf_n_codigo equals grf.grf_n_codigo
                         join lcg in context.tb_lcg_localidadeClienteGrupoFamiliar on grf.grf_n_codigo equals lcg.lcg_grf_n_codigo
                         join lccB in context.tb_lcc_localidadeCliente on lcg.lcg_lcc_n_codigoBlocoQuadra equals lccB.lcc_n_codigo
                         join lccL in context.tb_lcc_localidadeCliente on lcg.lcg_lcc_n_codigoLoteApto equals lccL.lcc_n_codigo
                         select new MoradorViewModel
                         {
                             mor_n_codigo = morador.mor_n_codigo.ToString(),
                             mor_cli_n_codigo = morador.mor_cli_n_codigo.ToString(),
                             mor_c_nome = morador.mor_c_nome,
                             mor_c_rg = morador.mor_c_rg,
                             mor_c_estado = morador.mor_c_estado,
                             mor_c_cpf = morador.mor_c_cpf,
                             mor_c_telefonePermitido = morador.mor_c_telefonePermitido.Replace(" ", ""),
                             mor_c_blocoQuadra = lccB.lcc_c_descricao,
                             mor_c_loteApto = lccL.lcc_c_descricao,
                         });


            //Filtros
            if (filter.idsClientes_filter != null && filter.idsClientes_filter.Count() > 0)
            {
                query = query.Where(w => filter.idsClientes_filter.Contains(w.mor_cli_n_codigo));
            }

            if (!string.IsNullOrEmpty(filter.mor_cli_n_codigo_filter))
            {
                query = query.Where(w => w.mor_cli_n_codigo.Equals(filter.mor_cli_n_codigo_filter));
            }

            if (!string.IsNullOrEmpty(filter.mor_c_nome_filter))
            {
                query = query.Where(w => w.mor_c_nome.Contains(filter.mor_c_nome_filter));
            }
            else if (!string.IsNullOrEmpty(filter.mor_c_cpf_filter))
            {
                string auxDoc = filter.mor_c_cpf_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.mor_c_cpf.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.mor_c_rg_filter))
            {
                string auxDoc = filter.mor_c_rg_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.mor_c_rg.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.mor_c_telefonePermitido_filter))
            {
                string auxFone = filter.mor_c_telefonePermitido_filter.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                query = query.Where(w => w.mor_c_telefonePermitido.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Contains(auxFone));
            }

            if (!string.IsNullOrEmpty(filter.mor_c_blocoQuadra_filter))
            {
                query = query.Where(x => x.mor_c_blocoQuadra == filter.mor_c_blocoQuadra_filter);
            }

            if (!string.IsNullOrEmpty(filter.mor_c_loteApto_filter))
            {
                query = query.Where(x => x.mor_c_loteApto == filter.mor_c_loteApto_filter);
            }

            //Ordenação
            query = query.OrderBy(x => x.mor_c_nome);

            return query.DistinctBy(x => x.mor_n_codigo).ToPagedList(filter.paginaDataTable, filter.quantidade);
        }
    }
}