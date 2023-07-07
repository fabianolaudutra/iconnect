using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using OfficeOpenXml;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    public class EnvioNotificacaoService : RepositoryBase<tb_eno_envioNotificacao>, IEnvioNotificacaoService
    {
        private readonly IconnectCoreContext context;

        public EnvioNotificacaoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private INotificacaoAppService _notificacaoApp;
        public INotificacaoAppService NotificacaoApp
        {
            get
            {
                if (_notificacaoApp == null)
                {
                    _notificacaoApp = new NotificacaoAppService(context);
                }
                return _notificacaoApp;
            }
        }

        public IPagedList<EnvioNotificacaoViewModel> GetEnvioNotificacaoFiltrado(EnvioNotificacaoFilterModel filter)
        {
            if (string.IsNullOrEmpty(filter.ClienteId))
            {
                return new PagedList<EnvioNotificacaoViewModel>(null, 1, 1);
            }

            var query = ObterQueryEnvioNotificacaoFiltrados(filter);

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }


        private IQueryable<EnvioNotificacaoViewModel> ObterQueryEnvioNotificacaoFiltrados(EnvioNotificacaoFilterModel filter, bool excel = false)
        {
            var query = from eno in Context.tb_eno_envioNotificacao
                        join cli in Context.tb_cli_cliente on eno.eno_cli_n_codigo equals cli.cli_n_codigo
                        where cli.cli_emp_n_codigo == Convert.ToInt32(filter.idEmp)
                        orderby eno.eno_d_inclusao descending, cli.cli_c_nomeFantasia
                        select new EnvioNotificacaoViewModel
                        {
                            eno_n_codigo = eno.eno_n_codigo.ToString(),
                            eno_c_titulo = eno.eno_c_titulo,
                            eno_c_mensagem = eno.eno_c_mensagem,
                            eno_cli_n_codigo = eno.eno_cli_n_codigo.ToString(),
                            eno_c_GruposFamiliares = eno.eno_c_GruposFamiliares,
                            eno_d_inicio = eno.eno_d_inicio.Value == null ? string.Empty : eno.eno_d_inicio.Value.ToString("dd/MM/yyyy"),
                            eno_d_fim = eno.eno_d_fim.Value == null ? string.Empty : eno.eno_d_fim.Value.ToString("dd/MM/yyyy"),
                            eno_c_MoradoresGruposFamiliares = eno.eno_c_MoradoresGruposFamiliares,
                            eno_c_unique = eno.eno_c_unique.ToString(),
                            eno_d_atualizado = eno.eno_d_atualizado.ToString(),
                            eno_d_inclusao = eno.eno_d_inclusao.ToString(),
                            NomeCliente = cli.cli_c_nomeFantasia,
                            data_inicio = eno.eno_d_inicio,
                            data_fim = eno.eno_d_fim,
                            buscaSimples = eno.eno_c_titulo + " " + cli.cli_c_nomeFantasia
                        };

            //Filtros
            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
            }

            if (!string.IsNullOrEmpty(filter.Titulo))
            {
                query = query.Where(w => w.eno_c_titulo.Contains(filter.Titulo));
            }

            if (!string.IsNullOrEmpty(filter.ClienteId) && (!filter?.ClienteId?.Equals("0") ?? false) && (filter.ClienteId != "todos"))
            {
                List<EnvioNotificacaoViewModel> aux = new List<EnvioNotificacaoViewModel>();
                foreach (var id in filter.ClienteId.Split(","))
                {
                    var notificacoes = query.Where(w => w.eno_cli_n_codigo.Contains(id)).ToList();
                    foreach (var notificacao in notificacoes)
                    {
                        aux.Add(notificacao);
                    }
                }

                query = aux.AsQueryable();
            }

            if (!string.IsNullOrEmpty(filter.DataInicio))
            {
                if (DateTime.TryParse(filter.DataInicio, out DateTime auxData))
                {
                    query = query.Where(w => w.data_inicio.Value.Date == auxData.Date);
                }
            }

            //List<EnvioNotificacaoViewModel> lstEno = new List<EnvioNotificacaoViewModel>();
            //foreach (var item in query)
            //{
            //    item.Status = GetStatus(item.eno_d_inicio, item.eno_d_fim);
            //    lstEno.Add(item);
            //}

            //if (!string.IsNullOrEmpty(filter.Status))
            //{
            //    lstEno = lstEno.Where(w => w.Status == filter.Status).ToList();
            //}

            return query;
        }

        public byte[] GeraExcel(EnvioNotificacaoFilterModel filter)
        {
            var query = ObterQueryEnvioNotificacaoFiltrados(filter, true);
            var lstAvisos = query;

            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                   "Código",
                    "Título",
                    "Data Início",
                    "Data Fim",
                    "Cliente",
                    "Status",
                };

                var worksheet = package.Workbook.Worksheets.Add("Operador");
                using (var cells = worksheet.Cells[1, 1, 1, columHeaders.Count()])
                {
                    cells.Style.Font.Bold = true;
                }

                for (var i = 0; i < columHeaders.Count(); i++)
                {
                    worksheet.Cells[1, i + 1].Value = columHeaders[i];
                }

                var j = 2;

                try
                {
                    foreach (var aviso in lstAvisos)
                    {
                        worksheet.Cells["A" + j].Value = aviso.eno_n_codigo;
                        worksheet.Cells["B" + j].Value = aviso.eno_c_titulo.ToUpper();
                        worksheet.Cells["C" + j].Value = aviso.eno_d_inicio;
                        worksheet.Cells["D" + j].Value = aviso.eno_d_fim;
                        worksheet.Cells["E" + j].Value = aviso.NomeCliente;
                        worksheet.Cells["F" + j].Value = aviso.Status;

                        j++;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                for (var i = 0; i < columHeaders.Count(); i++)
                {
                    worksheet.Cells[1, i + 1].AutoFitColumns();
                }

                return package.GetAsByteArray();
            }
        }

        private string GetStatus(string strEno_d_inicio, string strEno_d_fim)
        {
            //REGRA TIRADA DA VIEW VW_NOTIFICACAOAPP:
            //((CASE WHEN CONVERT(date , GETDATE()) < eno_d_inicio THEN 'PENDENTE' 
            //WHEN(dbo.tb_eno_envioNotificacao.eno_d_inicio IS NULL AND 
            //(CONVERT(date, GETDATE()) <= dbo.tb_eno_envioNotificacao.eno_d_Fim OR dbo.tb_eno_envioNotificacao.eno_d_Fim IS NULL)) OR 
            //(CONVERT(date, GETDATE()) >= dbo.tb_eno_envioNotificacao.eno_d_inicio AND(dbo.tb_eno_envioNotificacao.eno_d_Fim IS NULL)) OR 
            //(CONVERT(date, GETDATE()) >= dbo.tb_eno_envioNotificacao.eno_d_inicio AND CONVERT(date, GETDATE()) <= dbo.tb_eno_envioNotificacao.eno_d_Fim) 
            //THEN 'EM EXIBIÇÃO' ELSE 'EXPIRADO' END))

            try
            {
                DateTime? eno_d_inicio = null;
                DateTime auxDataInicio;
                if (DateTime.TryParse(strEno_d_inicio, out auxDataInicio))
                {
                    eno_d_inicio = auxDataInicio;
                }


                DateTime? eno_d_fim = null;
                DateTime auxDataFim;
                if (DateTime.TryParse(strEno_d_fim, out auxDataFim))
                {
                    eno_d_fim = auxDataFim;
                }


                DateTime dataAtual = DateTime.Now;

                if (dataAtual < eno_d_inicio)
                {
                    return "PENDENTE";
                }
                else if ((eno_d_inicio == null) && (dataAtual <= eno_d_fim || eno_d_fim == null))
                {
                    return "EM EXIBIÇÃO";
                }
                else if (dataAtual >= eno_d_inicio && eno_d_fim == null)
                {
                    return "EM EXIBIÇÃO";
                }
                else if (dataAtual >= eno_d_inicio && dataAtual <= eno_d_fim)
                {
                    return "EM EXIBIÇÃO";
                }
                else
                {
                    return "EXPIRADO";
                }
            }
            catch (Exception ex)
            {
                return "ERRO";
            }
        }

        public EnvioNotificacaoViewModel GetEnvioNotificacao(int id)
        {
            var auxEno = (from eno in context.tb_eno_envioNotificacao
                          join cli in Context.tb_cli_cliente on eno.eno_cli_n_codigo equals cli.cli_n_codigo
                          join not in Context.tb_not_notificacaoApp on eno.eno_n_codigo equals not.not_eno_n_codigo
                          where eno.eno_n_codigo == id
                          select new EnvioNotificacaoViewModel()
                          {
                              eno_n_codigo = eno.eno_n_codigo.ToString(),
                              eno_c_titulo = eno.eno_c_titulo,
                              eno_c_mensagem = eno.eno_c_mensagem,
                              eno_cli_n_codigo = eno.eno_cli_n_codigo.ToString(),
                              eno_c_GruposFamiliares = eno.eno_c_GruposFamiliares,
                              eno_d_inicio = eno.eno_d_inicio.Value == null ? string.Empty : eno.eno_d_inicio.Value.ToString("yyyy-MM-dd"),
                              eno_d_fim = eno.eno_d_fim.Value == null ? string.Empty : eno.eno_d_fim.Value.ToString("yyyy-MM-dd"),
                              eno_c_MoradoresGruposFamiliares = eno.eno_c_MoradoresGruposFamiliares,
                              eno_c_unique = eno.eno_c_unique.ToString(),
                              eno_d_atualizado = eno.eno_d_atualizado.ToString(),
                              eno_d_inclusao = eno.eno_d_inclusao.ToString(),
                              NomeCliente = cli.cli_c_nomeFantasia,
                              enviar_app_connect = not.not_b_enviar_app_pro.ToString()
                          }).FirstOrDefault();

            auxEno.Status = GetStatus(auxEno.eno_d_inicio, auxEno.eno_d_fim);
            auxEno.MoradoresSelecionados = auxEno.eno_c_MoradoresGruposFamiliares.Split(',');
            auxEno.Moradores = GetMoradores(auxEno.MoradoresSelecionados);

            return auxEno;
        }

        private List<MoradorViewModel> GetMoradores(string[] idsMoradores)
        {
            List<int> lstIdsMoradores = new List<int>();

            foreach (var id in idsMoradores)
            {
                int auxId;
                if (int.TryParse(id, out auxId))
                {
                    lstIdsMoradores.Add(auxId);
                }
            }

            var lstMoradores = (from mor in context.tb_mor_Morador
                                where lstIdsMoradores.Contains(mor.mor_n_codigo)
                                select new MoradorViewModel()
                                {
                                    mor_n_codigo = mor.mor_n_codigo.ToString(),
                                    mor_c_nome = mor.mor_c_nome
                                }).ToList();

            return lstMoradores;
        }

        public int SalvarEnvioNotificacao(EnvioNotificacaoViewModel model)
        {
            try
            {
                List<string> lstMoradores = new List<string>();
                string aux_eno_c_MoradoresGruposFamiliares = string.Empty;

                foreach (var morador in model.Moradores)
                {
                    lstMoradores.Add(morador.mor_n_codigo);
                    aux_eno_c_MoradoresGruposFamiliares += morador.mor_n_codigo + ",";
                }

                tb_eno_envioNotificacao envioNotificacao;

                if (string.IsNullOrEmpty(model.eno_n_codigo) || model.eno_n_codigo.ToString() == "0")
                {
                    envioNotificacao = new tb_eno_envioNotificacao()
                    {
                        eno_c_titulo = model.eno_c_titulo,
                        eno_c_mensagem = model.eno_c_mensagem,
                        eno_cli_n_codigo = Convert.ToInt32(model.eno_cli_n_codigo),
                        eno_c_GruposFamiliares = model.eno_c_GruposFamiliares,
                        eno_d_inicio = Convert.ToDateTime(model.eno_d_inicio),
                        //eno_d_fim = Convert.ToDateTime(model.eno_d_fim),
                        eno_c_MoradoresGruposFamiliares = aux_eno_c_MoradoresGruposFamiliares,
                        eno_c_unique = Guid.NewGuid(),
                        eno_d_atualizado = DateTime.Now,
                        eno_d_inclusao = DateTime.Now
                    };

                    Insert(envioNotificacao);

                    context.SaveChanges();

                    if (envioNotificacao.eno_n_codigo > 0)
                    {
                        foreach (var mor_n_codigo in lstMoradores)
                        {
                            var not = new NotificacaoAppViewModel()
                            {
                                not_zec_n_codigo = null,
                                not_b_pendente = (model.enviar_app_connect == "true" ? "false" : "true"),
                                not_d_data = DateTime.Now.ToString(),
                                not_c_mensagem = envioNotificacao.eno_c_mensagem,
                                not_b_excluido = "false",
                                not_c_cor = null,
                                not_c_retornoPush = null,
                                not_mor_n_codigo = mor_n_codigo,
                                not_c_origem = "PORTAL",
                                not_d_modificacao = DateTime.Now.ToString(),
                                not_eno_n_codigo = envioNotificacao.eno_n_codigo.ToString(),
                                not_c_unique = Guid.NewGuid().ToString(),
                                not_d_atualizado = DateTime.Now.ToString(),
                                not_d_inclusao = DateTime.Now.ToString(),
                                not_grf_n_codigo = Convert.ToInt32(envioNotificacao.eno_c_GruposFamiliares).ToString(),
                                not_b_enviar_app_pro = model.enviar_app_connect,
                            };

                            NotificacaoApp.SalvarNotificacaoApp(not);
                        }
                    }
                }
                else
                {
                    envioNotificacao = (from eno in context.tb_eno_envioNotificacao where eno.eno_n_codigo == Convert.ToInt32(model.eno_n_codigo) select eno).FirstOrDefault();
                    envioNotificacao.eno_n_codigo = Convert.ToInt32(model.eno_n_codigo);
                    envioNotificacao.eno_c_titulo = model.eno_c_titulo;
                    envioNotificacao.eno_c_mensagem = model.eno_c_mensagem;
                    envioNotificacao.eno_cli_n_codigo = Convert.ToInt32(model.eno_cli_n_codigo);
                    envioNotificacao.eno_c_GruposFamiliares = model.eno_c_GruposFamiliares;
                    envioNotificacao.eno_d_inicio = Convert.ToDateTime(model.eno_d_inicio);
                    envioNotificacao.eno_d_fim = Convert.ToDateTime(model.eno_d_fim);
                    envioNotificacao.eno_c_MoradoresGruposFamiliares = model.eno_c_MoradoresGruposFamiliares;
                    envioNotificacao.eno_d_atualizado = DateTime.Now;

                    Update(envioNotificacao);

                    context.SaveChanges();
                }

                return envioNotificacao.eno_n_codigo;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool DeletarEnvioNotificacao(int id)
        {
            try
            {
                Delete(context.tb_eno_envioNotificacao.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}