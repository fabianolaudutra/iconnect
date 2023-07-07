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
using OfficeOpenXml;

namespace Iconnect.Aplicacao.Services
{
    class MonitoramentoService : RepositoryBase<tb_mon_monitoramento>, IMonitoramentoService
    {
        private IconnectCoreContext context;

        public MonitoramentoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public IPagedList<MonitoramentoViewModel> GetMonitoramentoFiltrado(MonitoramentoFilterModel filter)
        {
            var query = QueryMonitoramento(filter.mon_cli_n_codigo_filter, filter.mon_stm_n_codigo_filter);

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public IList<int?> ClientesComAlerta(IList<int> idsClientes)
        {
            var query = from mon in Context.tb_mon_monitoramento
                        join cev in Context.tb_cev_categorizacaoEvento on mon.mon_cev_n_codigo equals cev.cev_n_codigo
                        join zoc in Context.tb_zoc_zoneamentoCliente on mon.mon_zoc_n_codigo equals zoc.zoc_n_codigo
                        join eqc in Context.tb_eqc_equipamentoCliente on zoc.zoc_eqc_n_codigo equals eqc.eqc_n_codigo
                        where (mon.mon_b_limpaEvento == false || mon.mon_b_limpaEvento == null) &&
                        mon.mon_b_exibido == true && cev.cev_b_geraAtendimento == true && mon.mon_stm_n_codigo == 1
                        orderby mon.mon_d_dataEvento descending
                        select mon.mon_cli_n_codigo;

            var lista = query.ToList();

            if (idsClientes?.Count > 0)
            {
                lista = lista.Where(x => idsClientes.Contains(x ?? 0))?.ToList();
            }

            var filtrado = lista.GroupBy(x => x)
                .Select(group => group.Key);

            return filtrado?.ToList();
        }

        public MonitoramentoViewModel GetMonitoramento(int id)
        {
            var monitoramento = (from mon in Context.tb_mon_monitoramento
                                 join cli in Context.tb_cli_cliente on mon.mon_cli_n_codigo equals cli.cli_n_codigo
                                 join cev in Context.tb_cev_categorizacaoEvento on mon.mon_cev_n_codigo equals cev.cev_n_codigo
                                 join zoc in Context.tb_zoc_zoneamentoCliente on mon.mon_zoc_n_codigo equals zoc.zoc_n_codigo
                                 join eqc in Context.tb_eqc_equipamentoCliente on zoc.zoc_eqc_n_codigo equals eqc.eqc_n_codigo
                                 where mon.mon_n_codigo == id
                                 select new MonitoramentoViewModel
                                 {
                                     mon_n_codigo = mon.mon_n_codigo.ToString(),
                                     mon_cli_n_codigo = mon.mon_cli_n_codigo.ToString(),
                                     mon_eve_n_codigo = mon.mon_eve_n_codigo.ToString(),
                                     mon_cev_n_codigo = mon.mon_cev_n_codigo.ToString(),
                                     mon_d_dataInsercao = mon.mon_d_dataInsercao.ToString(),
                                     mon_d_dataEdicao = mon.mon_stm_n_codigo == 1 ? DateTime.Now.ToString("dd/MM/yyyy HH:mm") : mon.mon_d_dataEdicao.Value.ToString("dd/MM/yyyy HH:mm"),
                                     mon_stm_n_codigo = mon.mon_stm_n_codigo.ToString(),
                                     mon_zoc_n_codigo = mon.mon_zoc_n_codigo.ToString(),
                                     mon_c_observacao = mon.mon_c_observacao,
                                     mon_n_responsavel = mon.mon_n_responsavel.ToString(),
                                     mon_d_dataEvento = mon.mon_d_dataEvento.Value.ToString("dd/MM/yyyy HH:mm"),
                                     mon_c_motivo = mon.mon_c_motivo,
                                     mon_ate_n_codigo = mon.mon_ate_n_codigo.ToString(),
                                     mon_b_precisaAtendimento = mon.mon_b_precisaAtendimento.ToString(),
                                     mon_c_motivoConclusao = mon.mon_c_motivoConclusao,
                                     mon_n_responsavelConclusao = mon.mon_n_responsavelConclusao.ToString(),
                                     mon_c_observacaoConclusao = mon.mon_c_observacaoConclusao,
                                     mon_d_dataEventoConclusao = mon.mon_stm_n_codigo == 2 ? DateTime.Now.ToString("dd/MM/yyyy HH:mm") : mon.mon_d_dataEventoConclusao.Value.ToString("dd/MM/yyyy HH:mm"),
                                     mon_d_modificacao = mon.mon_d_modificacao.ToString(),
                                     mon_d_dataExibicao = mon.mon_d_dataExibicao.ToString(),
                                     mon_b_exibido = mon.mon_b_exibido.ToString(),
                                     mon_b_limpaEvento = mon.mon_b_limpaEvento.ToString(),
                                     mon_pec_n_codigo = mon.mon_pec_n_codigo.ToString(),
                                     mon_c_unique = mon.mon_c_unique.ToString(),
                                     mon_d_atualizado = mon.mon_d_atualizado.ToString(),
                                     mon_d_inclusao = mon.mon_d_inclusao.ToString(),
                                     NomeZona = zoc.zoc_c_nomePonto,
                                     NomeCentral = eqc.eqc_c_nomePonto,
                                     NomeCategoria = cev.cev_c_descricao,
                                     NomeCliente = cli.cli_c_nomeFantasia,
                                 }).FirstOrDefault();

            return monitoramento;
        }

        public bool SalvarMonitoramento(MonitoramentoViewModel model)
        {
            try
            {
                var monitoramento = (from mon in context.tb_mon_monitoramento where mon.mon_n_codigo == Convert.ToInt32(model.mon_n_codigo) select mon).FirstOrDefault();

                //Status e datas
                if (monitoramento.mon_stm_n_codigo == 1)
                {
                    //Responsavel
                    if (!string.IsNullOrEmpty(model.mon_n_responsavel) && model.mon_n_responsavel != "0")
                    {
                        monitoramento.mon_n_responsavel = Convert.ToInt32(model.mon_n_responsavel);
                    }
                    else
                    {
                        return false;
                    }

                    if (model.moc_b_encerrar == "True")
                    {
                        monitoramento.mon_stm_n_codigo = 3;
                    }
                    else
                    {
                        monitoramento.mon_stm_n_codigo = 2;
                    }

                    
                    monitoramento.mon_d_dataEdicao = DateTime.Now;
                    monitoramento.mon_c_motivo = model.mon_c_motivo;
                    monitoramento.mon_c_observacao = model.mon_c_observacao;
                }
                else
                {
                    //Responsavel Conclusão
                    if (!string.IsNullOrEmpty(model.mon_n_responsavelConclusao) && model.mon_n_responsavelConclusao != "0")
                    {
                        monitoramento.mon_n_responsavelConclusao = Convert.ToInt32(model.mon_n_responsavelConclusao);
                    }
                    else
                    {
                        return false;
                    }

                    monitoramento.mon_stm_n_codigo = 3;
                    monitoramento.mon_d_dataEventoConclusao = DateTime.Now;
                    monitoramento.mon_c_motivoConclusao = model.mon_c_motivoConclusao;
                    monitoramento.mon_c_observacaoConclusao = model.mon_c_observacaoConclusao;
                }

                Update(monitoramento);

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        byte[] IMonitoramentoService.getRelatorioMonitoramento(MonitoramentoViewModel model)
        {
            int? idCli = 0;
            DateTime dtInicial, dtFinal, conInicial, conFinal;
            List<string> idPessoa = new List<string>();
            List<MonitoramentoViewModel> query;
            List<PessoaViewModel> queryPessoa;

            if (model.mon_cli_n_codigo != null)
            {
                idCli = Convert.ToInt32(model.mon_cli_n_codigo);
            }
            if (model.pessoas != null)
            {
                foreach (var item in model.pessoas)
                {
                    idPessoa.Add(item.ToString());
                }
                queryPessoa = (from pes in context.vw_pessoa
                               where pes.TIPO == model.tipoPessoa && idPessoa.Contains(pes.CODIGO.ToString())
                               select new PessoaViewModel()
                               {
                                   cli_c_nomeFantasia = pes.cli_c_nomeFantasia,
                                   Cliente= pes.cli_c_nomeFantasia,
                                   CODIGO = pes.CODIGO.ToString(),
                                   NOME = pes.NOME,
                                   RG = pes.RG,
                                   CPF = pes.CPF,
                                   DATA = pes.DATA.ToString(),
                                   EMAIL = pes.EMAIL,
                                   TELEFONE = pes.TELEFONE,
                                   CELULAR = pes.CELULAR,
                                   ativoInativo = pes.ATIVO_INATIVO ? "Ativo" : "Inativo",
                                   RAMAL = pes.RAMAL,
                                   TIPO = pes.TIPO,
                                   CODCLIENTE = pes.CODCLIENTE.ToString(),
                                   CODIGOEMPRESA = pes.CODIGOEMPRESA.ToString(),
                                   TIPOCLIENTE = pes.TIPOCLIENTE.ToString()

                               }).ToList();
            }
            else if (model.tipoPessoa != null)
            {
                queryPessoa = (from pes in context.vw_pessoa
                               where pes.TIPO == model.tipoPessoa
                               select new PessoaViewModel()
                               {
                                   cli_c_nomeFantasia = pes.cli_c_nomeFantasia,
                                   Cliente = pes.cli_c_nomeFantasia,
                                   CODIGO = pes.CODIGO.ToString(),
                                   NOME = pes.NOME,
                                   RG = pes.RG,
                                   CPF = pes.CPF,
                                   DATA = pes.DATA.ToString(),
                                   EMAIL = pes.EMAIL,
                                   TELEFONE = pes.TELEFONE,
                                   CELULAR = pes.CELULAR,
                                   ativoInativo = pes.ATIVO_INATIVO ? "Ativo" : "Inativo",
                                   RAMAL = pes.RAMAL,
                                   TIPO = pes.TIPO,
                                   CODCLIENTE = pes.CODCLIENTE.ToString(),
                                   CODIGOEMPRESA = pes.CODIGOEMPRESA.ToString(),
                                   TIPOCLIENTE = pes.TIPOCLIENTE.ToString()
                               }).ToList();
            }
            else
            {
                queryPessoa = (from pes in context.vw_pessoa
                               where pes.CODCLIENTE == idCli
                               select new PessoaViewModel()
                               {
                                   cli_c_nomeFantasia = pes.cli_c_nomeFantasia,
                                   Cliente = pes.cli_c_nomeFantasia,
                                   CODIGO = pes.CODIGO.ToString(),
                                   NOME = pes.NOME,
                                   RG = pes.RG,
                                   CPF = pes.CPF,
                                   DATA = pes.DATA.ToString(),
                                   EMAIL = pes.EMAIL,
                                   TELEFONE = pes.TELEFONE,
                                   CELULAR = pes.CELULAR,
                                   ativoInativo = pes.ATIVO_INATIVO ? "Ativo" : "Inativo",
                                   RAMAL = pes.RAMAL,
                                   TIPO = pes.TIPO,
                                   CODCLIENTE = pes.CODCLIENTE.ToString(),
                                   CODIGOEMPRESA = pes.CODIGOEMPRESA.ToString(),
                                   TIPOCLIENTE = pes.TIPOCLIENTE.ToString()
                               }).ToList();
            }
            if (((model.data_inicio != null && model.data_fim != null) && (model.data_inicio != "" && model.data_fim != "")))
            {
                dtInicial = Convert.ToDateTime(model.data_inicio);
                dtFinal = Convert.ToDateTime(model.data_fim);
                dtFinal = dtFinal.AddHours(23).AddMinutes(59);

                query = (from mon in context.tb_mon_monitoramento
                         join cev in Context.tb_cev_categorizacaoEvento on mon.mon_cev_n_codigo equals cev.cev_n_codigo
                         join zoc in Context.tb_zoc_zoneamentoCliente on mon.mon_zoc_n_codigo equals zoc.zoc_n_codigo
                         join eqc in Context.tb_eqc_equipamentoCliente on zoc.zoc_eqc_n_codigo equals eqc.eqc_n_codigo
                         join stm in Context.tb_stm_statusMonitoramento on mon.mon_stm_n_codigo equals stm.stm_n_codigo
                         join cli in Context.tb_cli_cliente on mon.mon_cli_n_codigo equals cli.cli_n_codigo
                         where mon.mon_cli_n_codigo == idCli && mon.mon_d_dataEvento >= dtInicial && mon.mon_d_dataEvento <= dtFinal
                          && mon.mon_zoc_n_codigo != null
                         //&& mon.mon_d_dataEventoConclusao >= conInicial && mon.mon_d_dataEventoConclusao <= conFinal
                         select new MonitoramentoViewModel()
                         {
                             mon_n_codigo = mon.mon_n_codigo.ToString(),
                             mon_cli_n_codigo = mon.mon_cli_n_codigo.ToString(),
                             mon_stm_n_codigo = mon.mon_stm_n_codigo.ToString(),
                             mon_d_dataEvento = mon.mon_d_dataEvento.Value.ToString("dd/MM/yyyy HH:mm"),
                             mon_d_dataEventoConclusao = mon.mon_d_dataEventoConclusao.Value.ToString("dd/MM/yyyy HH:mm"),
                             NomeZona = zoc.zoc_c_nomePonto,
                             NomeCentral = eqc.eqc_c_nomePonto,
                             NomeCategoria = cev.cev_c_descricao,
                             NomeCliente = cli.cli_c_nomeFantasia,
                             cev_c_cor = cev.cev_c_cor,
                             Status = stm.stm_c_descricao,
                             tipoEvento = cev.cev_c_descricao,
                             CodigoStatus = stm.stm_n_codigo.ToString(),
                             mon_n_codigoPessoaConclusao = mon.mon_n_codigoPessoaConclusao.ToString(),
                             mon_dtEvento = mon.mon_d_dataEvento.Value,
                             mon_dtEventoConclusao = mon.mon_d_dataEventoConclusao.Value,

                         }).ToList();
            }
            else if (model.conclusao_inicio != null && model.conclusao_fim != null)
            {
                conInicial = Convert.ToDateTime(model.conclusao_inicio);
                conFinal = Convert.ToDateTime(model.conclusao_fim);
                conFinal = conFinal.AddHours(23).AddMinutes(59);

                query = (from mon in context.tb_mon_monitoramento
                         join cev in Context.tb_cev_categorizacaoEvento on mon.mon_cev_n_codigo equals cev.cev_n_codigo
                         join zoc in Context.tb_zoc_zoneamentoCliente on mon.mon_zoc_n_codigo equals zoc.zoc_n_codigo
                         join eqc in Context.tb_eqc_equipamentoCliente on zoc.zoc_eqc_n_codigo equals eqc.eqc_n_codigo
                         join stm in Context.tb_stm_statusMonitoramento on mon.mon_stm_n_codigo equals stm.stm_n_codigo
                         join cli in Context.tb_cli_cliente on mon.mon_cli_n_codigo equals cli.cli_n_codigo
                         where mon.mon_cli_n_codigo == idCli && mon.mon_d_dataEventoConclusao >= conInicial && mon.mon_d_dataEventoConclusao <= conFinal
                          && mon.mon_zoc_n_codigo != null

                         select new MonitoramentoViewModel()
                         {
                             mon_n_codigo = mon.mon_n_codigo.ToString(),
                             mon_cli_n_codigo = mon.mon_cli_n_codigo.ToString(),
                             mon_stm_n_codigo = mon.mon_stm_n_codigo.ToString(),
                             mon_d_dataEvento = mon.mon_d_dataEvento.Value.ToString("dd/MM/yyyy HH:mm"),
                             mon_d_dataEventoConclusao = mon.mon_d_dataEventoConclusao.Value.ToString("dd/MM/yyyy HH:mm"),
                             NomeZona = zoc.zoc_c_nomePonto,
                             NomeCentral = eqc.eqc_c_nomePonto,
                             NomeCategoria = cev.cev_c_descricao,
                             NomeCliente = cli.cli_c_nomeFantasia,
                             cev_c_cor = cev.cev_c_cor,
                             Status = stm.stm_c_descricao,
                             tipoEvento = cev.cev_c_descricao,
                             CodigoStatus = stm.stm_n_codigo.ToString(),
                             mon_n_codigoPessoaConclusao = mon.mon_n_codigoPessoaConclusao.ToString(),
                             mon_dtEvento = mon.mon_d_dataEvento.Value,
                             mon_dtEventoConclusao = mon.mon_d_dataEventoConclusao.Value,
                         }).ToList();
            }
            else
            {
                query = (from mon in context.tb_mon_monitoramento
                         join cev in Context.tb_cev_categorizacaoEvento on mon.mon_cev_n_codigo equals cev.cev_n_codigo
                         join zoc in Context.tb_zoc_zoneamentoCliente on mon.mon_zoc_n_codigo equals zoc.zoc_n_codigo
                         join eqc in Context.tb_eqc_equipamentoCliente on zoc.zoc_eqc_n_codigo equals eqc.eqc_n_codigo
                         join stm in Context.tb_stm_statusMonitoramento on mon.mon_stm_n_codigo equals stm.stm_n_codigo
                         join cli in Context.tb_cli_cliente on mon.mon_cli_n_codigo equals cli.cli_n_codigo
                         where mon.mon_cli_n_codigo == idCli && mon.mon_zoc_n_codigo != null
                         select new MonitoramentoViewModel()
                         {
                             mon_n_codigo = mon.mon_n_codigo.ToString(),
                             mon_cli_n_codigo = mon.mon_cli_n_codigo.ToString(),
                             mon_stm_n_codigo = mon.mon_stm_n_codigo.ToString(),
                             mon_d_dataEvento = mon.mon_d_dataEvento.Value.ToString("dd/MM/yyyy HH:mm"),
                             NomeZona = zoc.zoc_c_nomePonto,
                             NomeCentral = eqc.eqc_c_nomePonto,
                             NomeCategoria = cev.cev_c_descricao,
                             cev_c_cor = cev.cev_c_cor,
                             Status = stm.stm_c_descricao,
                             NomeCliente = cli.cli_c_nomeFantasia,
                             tipoEvento = cev.cev_c_descricao,
                             CodigoStatus = stm.stm_n_codigo.ToString(),
                             mon_n_responsavel = mon.mon_n_responsavel.ToString(),
                             mon_c_motivo = mon.mon_c_motivo,
                             mon_c_observacao = mon.mon_c_observacao,
                             mon_n_codigoPessoaConclusao = mon.mon_n_codigoPessoaConclusao.ToString(),
                             mon_dtEvento = mon.mon_d_dataEvento.Value,
                             mon_dtEventoConclusao = mon.mon_d_dataEventoConclusao.Value,
                         }).ToList();
            }

            if (model.mon_stm_n_codigo != null)
            {
                query = query.Where(x => x.mon_stm_n_codigo == model.mon_stm_n_codigo.ToString()).ToList();
            }
            if (model.cev_n_codigo != null && model.cev_n_codigo.Count() > 0)
            {
                query = query.Where(x => model.cev_n_codigo.Contains(x.NomeCategoria.ToString())).ToList();
            }
            var lst = query.ToList();

            if (lst.Count == 0)
            {
                throw new Exception("Empty collection");
            }

            PessoaViewModel usuario = new PessoaViewModel();
            using (var package = new ExcelPackage())
            {


                var columHeaders = new string[]
                {
                    "Status",
                    "Tipo de Evento",
                    "Dt. Criação",
                    "Hora",
                    "Dt. Conclusão",
                    "Hora",
                    "Responsável",
                    "Motivo",
                    "Observação",
                    "Usuário",
                    "RG",
                    "Telefone",
                };

                var worksheet = package.Workbook.Worksheets.Add("Monitoramento");
                worksheet.DefaultColWidth = 20;
                using (var cells = worksheet.Cells[5, 1, 5, columHeaders.Count()])
                {
                    cells.Style.Font.Bold = true;
                }

                for (var i = 0; i < columHeaders.Count(); i++)
                {
                    worksheet.Cells[5, i + 1].Value = columHeaders[i];
                }
                //Titulo
                using (var cellsTi = worksheet.Cells[1, 1, 1, 1])
                {
                    cellsTi.Style.Font.Bold = true;
                    cellsTi.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                    cellsTi.Style.Font.Size = 24;
                    cellsTi.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    cellsTi.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    cellsTi.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.DarkBlue);
                }
                worksheet.Cells["A1"].Value = "Relatório de Monitoramento";
                worksheet.Cells["A1:L1"].Merge = true;


                //Cabeçalho Cliente
                using (var cellsTi = worksheet.Cells[2, 1, 2, 1])
                {
                    cellsTi.Style.Font.Bold = true;
                }
                worksheet.Cells[2, 1].Value = "Cliente";
                worksheet.Cells["A3"].Value = (lst.Count > 0 ? lst[0].NomeCliente : "");
                worksheet.Cells["A3:E3"].Merge = true;

                //Cabeçalho Status
                using (var cellsTi = worksheet.Cells[2, 6, 2, 6])
                {
                    cellsTi.Style.Font.Bold = true;
                }
                worksheet.Cells[2, 6].Value = "Status";
                worksheet.Cells["F3"].Value = VerificaStatus(model.CodigoStatus);


                //Cabeçalho Datas
                using (var cellsTi = worksheet.Cells[2, 9, 2, 9])
                {
                    cellsTi.Style.Font.Bold = true;
                }
                worksheet.Cells[2, 9].Value = "De";
                worksheet.Cells["I3"].Value = ((model.data_inicio != null && model.data_inicio != "") ? Convert.ToDateTime(model.data_inicio).ToString("dd/MM/yyyy") : "");

                //Cabeçalho Datas
                using (var cellsTi = worksheet.Cells[2, 11, 2, 11])
                {
                    cellsTi.Style.Font.Bold = true;
                }
                worksheet.Cells[2, 11].Value = "Até";
                worksheet.Cells["K3"].Value = ((model.data_fim != null && model.data_fim != "") ? Convert.ToDateTime(model.data_fim).ToString("dd/MM/yyyy") : "");

                worksheet.Cells["A2:L4"].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells["A2:L4"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells["A2:L4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                worksheet.Cells["A5:L5"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells["A5:L5"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells["A5:L5"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSlateGray);

                var j = 6;

                try
                {
                    foreach (var item in lst)
                    {

                        worksheet.Cells["A" + j].Value = item.Status;
                        worksheet.Cells["B" + j].Value = item.tipoEvento.ToUpper();
                        if (item.CodigoStatus == "3")
                        {

                            usuario = queryPessoa.Where(x => x.CODIGO == item.mon_n_codigoPessoaConclusao).FirstOrDefault();
                            //Data
                            worksheet.Cells["C" + j].Value = (item.mon_d_dataEventoConclusao != null ? Convert.ToDateTime(item.mon_dtEvento).ToString("dd/MM/yyyy") : string.Empty);
                            //string t = (item.mon_d_dataEventoConclusao != null ? Convert.ToDateTime(item.mon_d_dataEvento).ToString("dd/MM/yyyy") : string.Empty);
                            //Hora
                            worksheet.Cells["D" + j].Value = (item.mon_d_dataEventoConclusao != null ? Convert.ToDateTime(item.mon_dtEvento).ToString("HH:mm") : string.Empty);

                            //Data Conslusão
                            worksheet.Cells["E" + j].Value = (item.mon_d_dataEventoConclusao != null ? Convert.ToDateTime(item.mon_dtEventoConclusao).ToString("dd/MM/yyyy") : string.Empty);

                            //Hora Conslusão
                            worksheet.Cells["F" + j].Value = (item.mon_d_dataEventoConclusao != null ? Convert.ToDateTime(item.mon_dtEventoConclusao).ToString("HH:mm") : string.Empty);

                            // Responsavel
                            string nomeResp = "";
                            if (item.mon_n_responsavelConclusao != null)
                            {
                                int idVic = Convert.ToInt32(item.mon_n_responsavelConclusao);
                                var vigilante = (from vig in Context.tb_vic_vigilanteCliente where vig.vic_n_codigo == idVic select vig).FirstOrDefault();
                                if (vigilante != null)
                                {
                                    nomeResp = vigilante.vic_c_nome;
                                }
                            }
                            worksheet.Cells["G" + j].Value = nomeResp;

                            //Motivo
                            string motivo = "";
                            if (item.mon_c_motivoConclusao != null && item.mon_c_motivoConclusao != "")
                            {
                                int idMot = Convert.ToInt32(item.mon_c_motivoConclusao);
                                var _motivo = (from mot in Context.tb_moc_motivoOcorrenciaCliente where mot.moc_n_codigo == idMot select mot).FirstOrDefault();
                                if (_motivo != null)
                                {
                                    motivo = _motivo.moc_c_descricao;
                                }
                            }
                            worksheet.Cells["H" + j].Value = motivo;

                            // Obs
                            worksheet.Cells["I" + j].Value = (item.mon_c_observacaoConclusao != null ? item.mon_c_observacaoConclusao.ToString() : "");

                            // Nome do Usuario
                            worksheet.Cells["J" + j].Value = (usuario != null && usuario.NOME != null ? usuario.NOME.ToString() : "");

                            // RG do Usuario
                            worksheet.Cells["K" + j].Value = (usuario != null && usuario.RG != null ? usuario.RG.ToString() : "");

                            // Telefone do Usuario
                            worksheet.Cells["L" + j].Value = (usuario != null && usuario.TELEFONE != null ? usuario.TELEFONE.ToString() : "");
                        }
                        else
                        {
                            usuario = queryPessoa.Where(x => x.CODIGO == item.mon_n_codigoPessoa).FirstOrDefault();

                            //Data
                            worksheet.Cells["C" + j].Value = (item.mon_d_dataEvento != null ? Convert.ToDateTime(item.mon_dtEvento).ToString("dd/MM/yyyy") : string.Empty);

                            //Hora
                            worksheet.Cells["D" + j].Value = (item.mon_d_dataEvento != null ? Convert.ToDateTime(item.mon_dtEvento).ToString("HH:mm") : string.Empty);

                            //Data Conslusão
                            worksheet.Cells["E" + j].Value = (item.mon_d_dataEvento != null ? Convert.ToDateTime(item.mon_dtEvento).ToString("dd/MM/yyyy") : string.Empty);

                            //Hora Conslusão
                            worksheet.Cells["F" + j].Value = (item.mon_d_dataEvento != null ? Convert.ToDateTime(item.mon_dtEvento).ToString("HH:mm") : string.Empty);

                            // Responsavel
                            string nomeResp = "";
                            if (item.mon_n_responsavel != null && item.mon_n_responsavel != "")
                            {
                                int idVic = Convert.ToInt32(item.mon_n_responsavel);
                                var vigilante = (from vig in Context.tb_vic_vigilanteCliente where vig.vic_n_codigo == idVic select vig).FirstOrDefault();
                                if (vigilante != null)
                                {
                                    nomeResp = vigilante.vic_c_nome;
                                }
                            }
                            worksheet.Cells["G" + j].Value = nomeResp;

                            //Motivo
                            string motivo = "";
                            if (item.mon_c_motivo != null && item.mon_c_motivo != "")
                            {
                                int idMot = Convert.ToInt32(item.mon_c_motivo);
                                var _motivo = (from mot in Context.tb_moc_motivoOcorrenciaCliente where mot.moc_n_codigo == idMot select mot).FirstOrDefault();
                                if (_motivo != null)
                                {
                                    motivo = _motivo.moc_c_descricao;
                                }
                            }
                            worksheet.Cells["H" + j].Value = motivo;

                            // Obs
                            worksheet.Cells["I" + j].Value = (item.mon_c_observacao != null ? item.mon_c_observacao.ToString() : "");

                            // Nome do Usuario
                            worksheet.Cells["J" + j].Value = (usuario != null && usuario.NOME != null ? usuario.NOME.ToString() : "");

                            // RG do Usuario
                            worksheet.Cells["K" + j].Value = (usuario != null && usuario.RG != null ? usuario.RG.ToString() : "");

                            // Telefone do Usuario
                            worksheet.Cells["L" + j].Value = (usuario != null && usuario.TELEFONE != null ? usuario.TELEFONE.ToString() : "");
                        }
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

        private object VerificaStatus(object codigoStatus)
        {
            string status = "";
            switch (codigoStatus)
            {
                case "1":
                    status = "PENDENTE";
                    break;
                case "2":
                    status = "AGUARDANDO RESPOSTA";
                    break;
                case "3":
                    status = "FINALIZADO";
                    break;
                default:
                    status = "TODOS";
                    break;
            }
            return status;
        }

        private IQueryable<MonitoramentoViewModel> QueryMonitoramento(string clienteId, string statusCod)
        {
            var query = from mon in Context.tb_mon_monitoramento
                        join cev in Context.tb_cev_categorizacaoEvento on mon.mon_cev_n_codigo equals cev.cev_n_codigo
                        join zoc in Context.tb_zoc_zoneamentoCliente on mon.mon_zoc_n_codigo equals zoc.zoc_n_codigo
                        join eqc in Context.tb_eqc_equipamentoCliente on zoc.zoc_eqc_n_codigo equals eqc.eqc_n_codigo
                        join cli in Context.tb_cli_cliente on mon.mon_cli_n_codigo equals cli.cli_n_codigo
                        where (mon.mon_b_limpaEvento == false || mon.mon_b_limpaEvento == null) &&
                               mon.mon_b_exibido == true &&
                               cev.cev_b_geraAtendimento == true
                        orderby mon.mon_d_dataEvento descending
                        select new MonitoramentoViewModel
                        {
                            mon_n_codigo = mon.mon_n_codigo.ToString(),
                            mon_cli_n_codigo = mon.mon_cli_n_codigo.ToString(),
                            mon_stm_n_codigo = mon.mon_stm_n_codigo.ToString(),
                            mon_d_dataEvento = mon.mon_d_dataEvento.Value.ToString("dd/MM/yyyy HH:mm"),
                            NomeZona = zoc.zoc_c_nomePonto,
                            NomeCentral = eqc.eqc_c_nomePonto,
                            NomeCategoria = cev.cev_c_descricao,
                            cev_c_cor = cev.cev_c_cor,
                            NomeCliente = cli.cli_c_nomeFantasia
                        };

            if (!string.IsNullOrEmpty(clienteId))
                query = query.Where(w => w.mon_cli_n_codigo == clienteId);

            if (!string.IsNullOrEmpty(statusCod))
                query = query.Where(w => w.mon_stm_n_codigo == statusCod);

            return query;
        }

        public MonitoramentoViewModel GetMonitoramentoAtualizacaoGrid(string clienteId, string statusCod)
        {
            var query = QueryMonitoramento(clienteId, statusCod);

            return query?.FirstOrDefault();
        }
    }
}