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
    class SolicitarZeladorService : RepositoryBase<tb_soz_solicitarZelador>, ISolicitarZeladorService
    {
        private IconnectCoreContext context;

        public SolicitarZeladorService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private INotificacaoAppService _notificacao;
        public INotificacaoAppService Notificacao
        {
            get
            {
                if (_notificacao == null)
                {
                    _notificacao = new NotificacaoAppService(context);
                }
                return _notificacao;
            }
        }

        public IPagedList<SolicitarZeladorViewModel> GetSolicitarZeladorFiltrado(SolicitarZeladorFilterModel filter)
        {
            if (string.IsNullOrEmpty(filter.idsClientes))
            {
                return new PagedList<SolicitarZeladorViewModel>(null, 1, 1);
            }

            //Filtrar depois somente por OPERADOR
            var query = from ocorrencia in Context.tb_soz_solicitarZelador
                        join morador in Context.tb_mor_Morador on ocorrencia.soz_mor_n_codigo equals morador.mor_n_codigo
                        join cliente in Context.tb_cli_cliente on morador.mor_cli_n_codigo equals cliente.cli_n_codigo
                        where ocorrencia.soz_c_status != "C"
                        orderby ocorrencia.soz_d_dataSolicitacao descending
                        select new SolicitarZeladorViewModel
                        {
                            soz_n_codigo = ocorrencia.soz_n_codigo.ToString(),
                            soz_c_descricao = ocorrencia.soz_c_descricao,
                            soz_mor_n_codigo = ocorrencia.soz_mor_n_codigo.ToString(),
                            soz_c_status = ocorrencia.soz_c_status,
                            soz_d_dataSolicitacao = ocorrencia.soz_d_dataSolicitacao.Value.ToString("dd/MM/yyyy HH:mm:ss"),
                            NomeMorador = morador.mor_c_nome,
                            NomeCliente = cliente.cli_c_nomeFantasia,
                            dateOrder = ocorrencia.soz_d_dataSolicitacao.Value,
                        };

            if (!string.IsNullOrEmpty(filter.idsClientes) && (!filter?.idsClientes?.Equals("todos") ?? false) && (!filter?.idsClientes?.Equals("NULL") ?? false) && string.IsNullOrEmpty(filter.cli_n_codigo_filter))
            {
                var ids = filter.idsClientes.Split(",");
                var lstIdsMoradores = (from morador in context.tb_mor_Morador
                                       where ids.Contains(morador.mor_cli_n_codigo.ToString())
                                       select morador.mor_n_codigo.ToString()).ToList();

                query = query.Where(w => lstIdsMoradores.Contains(w.soz_mor_n_codigo));
            }
            else if (!string.IsNullOrEmpty(filter.cli_n_codigo_filter))
            {
                var lstIdsMoradores = (from morador in context.tb_mor_Morador
                                       where morador.mor_cli_n_codigo == Convert.ToInt32(filter.cli_n_codigo_filter)
                                       select morador.mor_n_codigo.ToString()).ToList();

                query = query.Where(w => lstIdsMoradores.Contains(w.soz_mor_n_codigo));
            }

            if (!string.IsNullOrEmpty(filter.soz_c_status_filter))
            {
                query = query.Where(w => w.soz_c_status == filter.soz_c_status_filter);
            }

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public SolicitarZeladorViewModel GetOcorrencia(int id)
        {
            var query = (from soz in context.tb_soz_solicitarZelador
                         where soz.soz_n_codigo == id
                         join foto in context.tb_fap_fotoApp on soz.soz_fap_n_codigo equals foto.fap_n_codigo
                         select soz.soz_fap_n_codigo).FirstOrDefault();

            return (from soz in context.tb_soz_solicitarZelador
                    where soz.soz_n_codigo == id
                    select new SolicitarZeladorViewModel()
                    {
                        soz_n_codigo = soz.soz_n_codigo.ToString(),
                        soz_c_descricao = soz.soz_c_descricao,
                        soz_mor_n_codigo = soz.soz_mor_n_codigo.ToString(),
                        soz_c_status = soz.soz_c_status,
                        soz_d_dataSolicitacao = soz.soz_d_dataSolicitacao.Value.ToString("dd/MM/yyyy HH:mm:ss"),
                        soz_c_resposta = soz.soz_c_resposta,
                        soz_fap_n_codigo = query == null ? "0" : query.ToString()
                    }).FirstOrDefault();

        }

        public byte[] GetFoto(int id)
        {
            byte[] b = null;
            if (id != 0)
            {
                tb_fap_fotoApp foto = (from fot in context.tb_fap_fotoApp where fot.fap_n_codigo == Convert.ToInt32(id) select fot)?.FirstOrDefault();
                b = foto?.fap_c_imagem ?? null;

                return b;

            }
            return b;
        }

        public bool SalvarTratamentoOcorrencia(SolicitarZeladorViewModel model)
        {
            try
            {
                var ocorrencia = (from soz in context.tb_soz_solicitarZelador where soz.soz_n_codigo == Convert.ToInt32(model.soz_n_codigo) select soz).FirstOrDefault();
                if (ocorrencia != null)
                {
                    ocorrencia.soz_c_status = "A";
                    ocorrencia.soz_c_resposta = model.soz_c_resposta;
                    ocorrencia.soz_d_modificacao = DateTime.Now;
                    ocorrencia.soz_d_atualizado = DateTime.Now;

                    Update(ocorrencia);
                    context.SaveChanges();

                    EnviarNotificaçãoApp(ocorrencia.soz_mor_n_codigo, ocorrencia.soz_c_resposta);

                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public byte[] GeraExcel(SolicitarZeladorFilterModel filter)
        {
            var query = from ocorrencia in Context.tb_soz_solicitarZelador
                        join morador in Context.tb_mor_Morador on ocorrencia.soz_mor_n_codigo equals morador.mor_n_codigo
                        select new SolicitarZeladorViewModel
                        {
                            soz_n_codigo = ocorrencia.soz_n_codigo.ToString(),
                            soz_c_descricao = ocorrencia.soz_c_descricao,
                            soz_mor_n_codigo = ocorrencia.soz_mor_n_codigo.ToString(),
                            soz_c_status = ocorrencia.soz_c_status,
                            soz_d_dataSolicitacao = ocorrencia.soz_d_dataSolicitacao.ToString(),
                            NomeMorador = morador.mor_c_nome,
                        };

            if (!string.IsNullOrEmpty(filter.cli_n_codigo_filter))
            {
                var lstIdsMoradores = (from morador in Context.tb_mor_Morador
                                       where morador.mor_cli_n_codigo == Convert.ToInt32(filter.cli_n_codigo_filter)
                                       select morador.mor_n_codigo.ToString()).ToList();

                query = query.Where(w => lstIdsMoradores.Contains(w.soz_mor_n_codigo));
            }

            if (!string.IsNullOrEmpty(filter.soz_c_status_filter))
            {
                query = query.Where(w => w.soz_c_status == filter.soz_c_status_filter);
            }

            //Ordenação
            query = query.OrderByDescending(x => x.soz_d_dataSolicitacao);

            var lstOcorrencias = query.ToList();
            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "CLIENTE",
                    "NOME",
                    "TIPO",
                    "TELEFONE",
                    "DEPARTAMENTO",
                    "DATA ENTRADA",
                };

                var worksheet = package.Workbook.Worksheets.Add("Ocorrências");
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
                    foreach (var pessoa in lstOcorrencias)
                    {
                        //worksheet.Cells["A" + j].Value = pessoa.NOMECLIENTE;
                        //worksheet.Cells["B" + j].Value = pessoa.NOME;
                        //worksheet.Cells["C" + j].Value = pessoa.TIPO;
                        //worksheet.Cells["E" + j].Value = pessoa.TELEFONE;
                        //worksheet.Cells["F" + j].Value = pessoa.LOCALIZACAO;
                        //worksheet.Cells["G" + j].Value = pessoa.DATA;
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

        public void EnviarNotificaçãoApp(int? codMor, string resposta)
        {
            //Envio deNotificação
            NotificacaoAppViewModel notApp = new NotificacaoAppViewModel();
            var morador = (from m in context.tb_mor_Morador
                           where m.mor_n_codigo == codMor
                           select m).FirstOrDefault();

            var cliente = (from c in context.tb_cli_cliente
                           where c.cli_n_codigo == morador.mor_cli_n_codigo
                           select c).FirstOrDefault();

            var modulo = (from m in context.tb_mol_modulosLiberados
                          where m.mol_n_codigo == cliente.cli_mol_n_codigo
                          select m).FirstOrDefault();

            string mensagem = $"Olá {morador.mor_c_nome}, sua ocorrência foi atendida. {resposta}";


            if (morador != null && (!modulo.mol_b_connectGaren))
            {
                if (morador.mor_c_autorizacao != null)
                {
                    notApp.not_mor_n_codigo = morador.mor_n_codigo.ToString();
                    notApp.not_grf_n_codigo = null;
                    notApp.not_b_enviar_app_pro = "false";
                    notApp.not_b_excluido = "false";
                    notApp.not_b_pendente = "true";
                    notApp.not_c_mensagem = mensagem;
                    notApp.not_c_origem = "PORTAL";
                    Notificacao.SalvarNotificacaoApp(notApp);
                }
            }
        }

        public SolicitacaoZeladorSignalRViewModel GetOcorrenciaAtualizacaoGrid(int ocorrenciaId)
        {
            var query = (from ocorrencia in context.tb_soz_solicitarZelador
                    join morador in context.tb_mor_Morador on ocorrencia.soz_mor_n_codigo equals morador.mor_n_codigo
                    join cliente in context.tb_cli_cliente on morador.mor_cli_n_codigo equals cliente.cli_n_codigo
                    where ocorrencia.soz_n_codigo == ocorrenciaId && ocorrencia.soz_c_status == "F"
                    select new SolicitacaoZeladorSignalRViewModel
                    {
                        soz_n_codigo = ocorrencia.soz_n_codigo.ToString(),
                        soz_c_descricao = ocorrencia.soz_c_descricao,
                        soz_mor_n_codigo = ocorrencia.soz_mor_n_codigo.ToString(),
                        soz_c_status = ocorrencia.soz_c_status,
                        soz_d_dataSolicitacao = ocorrencia.soz_d_dataSolicitacao.Value.ToString("dd/MM/yyyy HH:mm:ss"),
                        NomeMorador = morador.mor_c_nome,
                        NomeCliente = cliente.cli_c_nomeFantasia,
                        dateOrder = ocorrencia.soz_d_dataSolicitacao.Value,
                        cli_n_codigo = cliente.cli_n_codigo
                    }).FirstOrDefault();

            return query;
        }
    }
}