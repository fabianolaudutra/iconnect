using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    class MonitoramentoControleAcessoService : RepositoryBase<tb_con_monitoramentoControleAcesso>, IMonitoramentoControleAcessoService
    {
        private readonly IconnectCoreContext context;

        public MonitoramentoControleAcessoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private ISolicitacaoAberturaRemotaService _solicitacaoAberturaRemota;
        public ISolicitacaoAberturaRemotaService SolicitacaoAberturaRemota
        {
            get
            {
                if (_solicitacaoAberturaRemota == null)
                {
                    _solicitacaoAberturaRemota = new SolicitacaoAberturaRemotaService(context);
                }
                return _solicitacaoAberturaRemota;
            }
        }

        public IPagedList<MonitoramentoControleAcessoViewModel> GetMonitoramentoControleAcessoFiltrado(MonitoramentoControleAcessoFilterModel filter)
        {
            if (string.IsNullOrEmpty(filter.IdsClientes))
            {
                return new PagedList<MonitoramentoControleAcessoViewModel>(null, 1, 1);
            }

            var query = (from con in Context.tb_con_monitoramentoControleAcesso
                         join cli in Context.tb_cli_cliente on con.con_cli_n_codigo.Value equals cli.cli_n_codigo
                         join mor in context.tb_mor_Morador on con.con_usu_n_codigo equals mor.mor_n_codigo into tempMorador
                         from mor in tempMorador.DefaultIfEmpty()
                         join vis in context.tb_vis_visitante on con.con_usu_n_codigo equals vis.vis_n_codigo into tempVisitante
                         from vis in tempVisitante.DefaultIfEmpty()
                         join pse in context.tb_pse_prestadorServico on con.con_usu_n_codigo equals pse.pse_n_codigo into tempPrestador
                         from pse in tempPrestador.DefaultIfEmpty()
                         where (con.con_b_LimparEvento == false || con.con_b_LimparEvento == null)
                         orderby con.con_d_evento descending
                         select new MonitoramentoControleAcessoViewModel
                         {
                             con_n_codigo = con.con_n_codigo.ToString(),
                             con_cli_n_codigo = con.con_cli_n_codigo.ToString(),
                             con_usu_n_codigo = con.con_usu_n_codigo.ToString(),
                             con_c_usuario = !string.IsNullOrEmpty(con.con_c_usuario) ? con.con_c_usuario.ToUpper() : "NÃO IDENTIFICADO",
                             con_c_cardNumber = con.con_c_cardNumber.ToUpper(),
                             con_c_tipoPessoa =
                                string.IsNullOrEmpty(con.con_c_tipoPessoa) ? "NÃO IDENTIFICADO" :
                                    con.con_c_tipoPessoa.ToUpper() == "MORADOR" && cli.cli_tcl_n_codigo == 2 ?
                                        "FUNCIONÁRIO" :
                                        con.con_c_tipoPessoa.ToUpper(),
                             con_c_pontoAcesso = con.con_c_pontoAcesso.ToUpper(),
                             con_c_status = con.con_c_status.ToUpper(),
                             cin_c_tipoEventoMotivo = con.cin_c_tipoEventoMotivo,
                             con_d_evento = con.con_d_evento.Value.ToString("dd/MM/yyyy HH:mm:ss"),
                             con_c_tipoAcesso = !string.IsNullOrEmpty(con.con_c_tipoAcesso) ? con.con_c_tipoAcesso.ToUpper() : "NI",
                             con_b_panico = con.con_b_panico.ToString(),
                             con_b_panicoTratado = con.con_b_panicoTratado.ToString(),
                             con_b_tipoPanico = con.con_b_tipoPanico.ToString(),
                             con_c_obsTratamentoPanico = con.con_c_obsTratamentoPanico,
                             NomeCliente = cli.cli_c_nomeFantasia.ToUpper(),
                             con_fot_n_codigo = con.con_fot_n_codigo == null ? "0" : con.con_fot_n_codigo.ToString(),
                             cli_tcl_n_codigo = Convert.ToInt32(cli.cli_tcl_n_codigo),
                             con_c_telefone = RetornarTelefoneUsuario(con.con_c_tipoPessoa, mor.mor_c_celular, vis.vis_c_celular, pse.pse_c_celular)
                         });

            if ((!string.IsNullOrEmpty(filter.IdsClientes) && (!filter?.IdsClientes?.Equals("todos") ?? false) && (!filter?.IdsClientes?.Equals("NULL") ?? false) && string.IsNullOrEmpty(filter.con_cli_n_codigo_filter)))
            {
                var ids = filter.IdsClientes.Split(",");
                query = query.Where(w => ids.Contains(w.con_cli_n_codigo));
            }
            else
            {
                if (!string.IsNullOrEmpty(filter.con_cli_n_codigo_filter))
                {
                    query = query.Where(w => w.con_cli_n_codigo.Equals(filter.con_cli_n_codigo_filter));
                }
            }

            var listaAcesso = query.ToPagedList(filter.paginaDataTable, filter.quantidade);

            foreach (var acesso in listaAcesso)
            {
                if (acesso.con_c_usuario.Length >= 26)
                {
                    acesso.con_c_usuario = acesso.con_c_usuario.Substring(0, 23) + "...";
                }
            }

            return listaAcesso;
        }

        public bool DispararAberturaRemota(SolicitacaoAberturaRemotaViewModel sol)
        {
            try
            {
                SolicitacaoAberturaRemota.SalvarSolicitacaoAberturaRemota(sol);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public MonitoramentoControleAcessoViewModel GetAcesso(int id)
        {
            return (from con in context.tb_con_monitoramentoControleAcesso
                    join cli in Context.tb_cli_cliente on con.con_cli_n_codigo.Value equals cli.cli_n_codigo
                    where con.con_n_codigo == id
                    select new MonitoramentoControleAcessoViewModel()
                    {
                        con_n_codigo = con.con_n_codigo.ToString(),
                        con_cli_n_codigo = con.con_cli_n_codigo.ToString(),
                        con_usu_n_codigo = con.con_usu_n_codigo.ToString(),
                        con_c_usuario = !string.IsNullOrEmpty(con.con_c_usuario) ? con.con_c_usuario.ToUpper() : "NÃO IDENTIFICADO",
                        con_c_cardNumber = con.con_c_cardNumber.ToUpper(),
                        con_c_tipoPessoa = con.con_c_tipoPessoa.ToUpper(),
                        con_c_pontoAcesso = con.con_c_pontoAcesso.ToUpper(),
                        con_c_status = con.con_c_status.ToUpper(),
                        cin_c_tipoEventoMotivo = con.cin_c_tipoEventoMotivo,
                        con_d_evento = con.con_d_evento.Value.ToString("dd/MM/yyyy HH:mm:ss"),
                        con_c_tipoAcesso = !string.IsNullOrEmpty(con.con_c_tipoAcesso) ? con.con_c_tipoAcesso.ToUpper() : "NI",
                        con_b_panico = con.con_b_panico.ToString(),
                        con_b_panicoTratado = con.con_b_panicoTratado.ToString(),
                        con_b_tipoPanico = con.con_b_tipoPanico.ToString(),
                        con_c_obsTratamentoPanico = con.con_c_obsTratamentoPanico,
                        NomeCliente = string.IsNullOrEmpty(cli.cli_c_nomeFantasia) ? "" : cli.cli_c_nomeFantasia.ToUpper(),
                        con_fot_n_codigo = con.con_fot_n_codigo == null ? "0" : con.con_fot_n_codigo.ToString()
                    }).FirstOrDefault();
        }

        public bool SalvarTratamentoPanico(MonitoramentoControleAcessoViewModel model)
        {
            try
            {
                var evento = (from con in context.tb_con_monitoramentoControleAcesso where con.con_n_codigo == Convert.ToInt32(model.con_n_codigo) select con).FirstOrDefault();
                if (evento != null)
                {
                    evento.con_d_dataTratamentoPanico = DateTime.Now;
                    evento.con_c_UsuarioTratamentoPanico = model.con_c_UsuarioTratamentoPanico; //controller
                    evento.con_b_panicoTratado = true;
                    evento.con_c_obsTratamentoPanico = model.con_c_obsTratamentoPanico;
                    evento.con_b_tipoPanico = Convert.ToBoolean(model.con_b_tipoPanico);

                    Update(evento);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public List<MonitoramentoControleAcessoViewModel> getRelatorioDestino(MonitoramentoControleAcessoViewModel model)
        {
            int? idCli = 0;
            DateTime dtInicial, dtFinal;
            List<MonitoramentoControleAcessoViewModel> query;
            if (model.con_cli_n_codigo != null)
            {
                idCli = Convert.ToInt32(model.con_cli_n_codigo);
            }
            dtInicial = Convert.ToDateTime(model.data_inicio);
            dtFinal = Convert.ToDateTime(model.data_fim);
            dtFinal = dtFinal.AddHours(23).AddMinutes(59);

            query = (from rel in context.vw_relatorioControleAcesso
                     join cli in Context.tb_cli_cliente on rel.con_cli_n_codigo equals cli.cli_n_codigo
                     where rel.con_cli_n_codigo == idCli
                     && rel.con_d_evento >= dtInicial
                     && rel.con_d_evento <= dtFinal
                     && rel.con_c_destino.Contains(model.grupo)
                     orderby rel.con_c_usuario
                     select new MonitoramentoControleAcessoViewModel()
                     {
                         NomeCliente = cli.cli_c_nomeFantasia.ToUpper(),
                         con_c_usuario = rel.con_c_usuario.ToUpper(),
                         con_c_tipoPessoa = rel.con_c_tipoPessoa == "" ? "NÃO IDENTIFICADO" : rel.con_c_tipoPessoa.ToUpper(),
                         con_c_pontoAcesso = rel.con_c_pontoAcesso.ToUpper(),
                         con_c_status = rel.con_c_status,
                         con_d_evento = rel.con_d_evento.Value.ToString("MM/dd/yyyy HH:mm:ss"),
                         link = rel.vid_c_link,
                         con_c_destino = model.grupo.ToUpper(),
                         grupo = rel.GrupoFamiliar.ToUpper()
                     }).ToList();

            if (!string.IsNullOrEmpty(model.perfil))
            {
                query = query.Where(w => w.perfil != null && w.perfil.Contains(model.perfil)).ToList();
            }

            if (!string.IsNullOrEmpty(model.con_c_pontoAcesso))
            {
                query = query.Where(x => x.con_c_pontoAcesso.Contains(model.con_c_pontoAcesso)).ToList();
            }

            if (!string.IsNullOrEmpty(model.con_c_tipoPessoa))
            {
                query = query.Where(x => x.con_c_tipoPessoa.Contains(model.con_c_tipoPessoa)).ToList();
            }
            else
            {
                query = query.Where(x => x.con_c_tipoPessoa.Contains("PRESTADOR") || x.con_c_tipoPessoa.Contains("VISITANTE")).ToList();
            }
            return query;

        }

        public List<MonitoramentoControleAcessoViewModel> getRelatorioControleAcesso(MonitoramentoControleAcessoViewModel model)
        {
            int? idCli = 0;
            DateTime dtInicial, dtFinal;
            List<MonitoramentoControleAcessoViewModel> query;
            if (model.con_cli_n_codigo != null)
            {
                idCli = Convert.ToInt32(model.con_cli_n_codigo);
            }
            dtInicial = Convert.ToDateTime(model.data_inicio);
            dtFinal = Convert.ToDateTime(model.data_fim);
            dtFinal = dtFinal.AddHours(23).AddMinutes(59);

            query = (from rel in context.vw_relatorioControleAcesso
                     join cli in Context.tb_cli_cliente on rel.con_cli_n_codigo equals cli.cli_n_codigo
                     join tempGrf in Context.tb_grf_grupoFamiliar on rel.grf_n_codigo equals tempGrf.grf_n_codigo into tempGrupoFamiliar
                     from grf in tempGrupoFamiliar.DefaultIfEmpty()
                     join tempLcg in context.tb_lcg_localidadeClienteGrupoFamiliar on grf.grf_n_codigo equals tempLcg.lcg_grf_n_codigo into tempLcgGrupoFamiliar
                     from lcg in tempLcgGrupoFamiliar.DefaultIfEmpty()
                     join tempLccB in context.tb_lcc_localidadeCliente on lcg.lcg_lcc_n_codigoBlocoQuadra equals tempLccB.lcc_n_codigo into tempLccBlocoQuadra
                     from lccB in tempLccBlocoQuadra.DefaultIfEmpty()
                     join tempLccL in context.tb_lcc_localidadeCliente on lcg.lcg_lcc_n_codigoLoteApto equals tempLccL.lcc_n_codigo into tempLccLoteApto
                     from lccL in tempLccLoteApto.DefaultIfEmpty()
                     join cMor in context.tb_cac_controleAcesso on rel.con_usu_n_codigo equals cMor.cac_mor_n_codigo into tempControleAcessoMor
                     from cacMor in tempControleAcessoMor.DefaultIfEmpty()
                     join cVis in context.tb_cac_controleAcesso on rel.con_usu_n_codigo equals cVis.cac_vis_n_codigo into tempControleAcessoVis
                     from cacVis in tempControleAcessoVis.DefaultIfEmpty()
                     join cPse in context.tb_cac_controleAcesso on rel.con_usu_n_codigo equals cPse.cac_pse_n_codigo into tempControleAcesso
                     from cacPse in tempControleAcesso.DefaultIfEmpty()
                     where rel.con_cli_n_codigo == idCli && rel.con_d_evento >= dtInicial && rel.con_d_evento <= dtFinal
                     select new MonitoramentoControleAcessoViewModel()
                     {
                         NomeCliente = cli.cli_c_nomeFantasia,
                         con_c_usuario = rel.con_c_usuario,
                         con_c_tipoPessoa =
                            string.IsNullOrEmpty(rel.con_c_tipoPessoa) ? "NÃO IDENTIFICADO"
                            : rel.TIPOCLIENTE == 2 ? "FUNCIONÁRIO"
                            : rel.con_c_tipoPessoa.ToUpper(),
                         con_c_pontoAcesso = rel.con_c_pontoAcesso.ToUpper(),
                         con_c_status = rel.con_c_status == null ? rel.con_c_acao : rel.con_c_status,
                         con_d_evento = rel.con_d_evento.Value.ToString("MM/dd/yyyy HH:mm:ss"),
                         link = rel.vid_c_link,
                         con_c_destino = grf.grf_c_nomeResponsavel,
                         grupo = grf.grf_n_codigo.ToString(),
                         con_usu_n_codigo = rel.con_usu_n_codigo.ToString(),
                         con_b_inOut = rel.con_b_inOut.ToString(),
                         con_b_panico = rel.con_b_panico.ToString(),
                         con_c_cardNumber = rel.con_c_cardNumber,
                         perfil = string.IsNullOrEmpty(rel.perfil) ? "" : rel.perfil,
                         con_d_dataTratamentoPanico = rel.con_d_dataTratamentoPanico != null ? rel.con_d_dataTratamentoPanico.Value.ToString("MM/dd/yyyy hh:mm:ss") : "NÃO TRATADO",
                         con_b_tipoPanico = rel.con_b_tipoPanico != null ? rel.con_b_tipoPanico.Value == true ? "SIM" : "NÃO" : "NÃO TRATADO",
                         con_c_obsTratamentoPanico = (rel.con_c_obsTratamentoPanico != null ? rel.con_c_obsTratamentoPanico : ""),
                         TIPOCLIENTE = rel.TIPOCLIENTE.ToString(),
                         DataEvento = rel.con_d_evento.Value,
                         localidade = $"{lccB.lcc_c_descricao}-{lccL.lcc_c_descricao}",
                         con_c_tipoAcesso = cacMor.cac_c_tipoAcesso ?? cacVis.cac_c_tipoAcesso ?? cacPse.cac_c_tipoAcesso
                     }).ToList();

            if (!string.IsNullOrEmpty(model.grupo))
            {
                List<string> IdsGrupo = new List<string>();
                foreach (var item in model.grupo.Split(","))
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        IdsGrupo.Add(item);
                    }
                }

                query = query.Where(w => IdsGrupo.Contains(w.grupo)).ToList();
            }
            if (!string.IsNullOrEmpty(model.con_b_inOut))
            {
                switch (model.con_b_inOut)
                {
                    case "E":
                        query = query.Where(w => w.con_b_inOut == "True").ToList();
                        break;
                    case "S":
                        query = query.Where(w => w.con_b_inOut == "False").ToList();
                        break;
                    case "B":
                        query = query.Where(w => string.IsNullOrEmpty(w.con_b_inOut)).ToList();
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(model.con_b_panico))
            {
                if (model.con_b_panico == "1")
                {
                    query = query.Where(w => w.con_b_panico == "True").ToList();
                }
                else
                {
                    query = query.Where(w => w.con_b_panico == "False").ToList();
                }
            }
            if (!string.IsNullOrEmpty(model.con_c_cardNumber))
            {
                query = query
                    .Where(w => model.con_c_cardNumber == "1" ?
                            w.con_c_cardNumber.ToLower().Contains("abertura remota")
                            : !w.con_c_cardNumber.ToLower().Contains("abertura remota"))
                    .ToList();
            }
            if (!string.IsNullOrEmpty(model.perfil))
            {
                query = query.Where(pessoa => pessoa.perfil.Contains(model.perfil)).ToList();
            }
            if (!string.IsNullOrEmpty(model.con_c_pontoAcesso))
            {
                List<MonitoramentoControleAcessoViewModel> aux = new List<MonitoramentoControleAcessoViewModel>();
                foreach (var item in model.con_c_pontoAcesso.Split(","))
                {
                    aux = query.Where(x => x.con_c_pontoAcesso.Contains(item)).Concat(aux).ToList();
                }
                query = aux;
            }
            if (model.pessoas.Length > 0)
            {
                var lista = new List<string>();
                foreach (var pessoa in model.pessoas)
                {
                    var id = pessoa.GetValue(0).ToString();
                    lista.Add(id);
                }
                query = query.Where(x => lista.Contains(x.con_usu_n_codigo)).ToList();
            }
            else
            {
                query = query.Where(x => x.con_c_status.ToLower() != "sem cadastro").ToList();
            }

            return query.DistinctBy(x => x.con_d_evento).OrderBy(x => x.DataEvento).ToList();
        }

        public byte[] GetRelRefeitorio(MonitoramentoControleAcessoViewModel model)
        {
            var inicio = Convert.ToDateTime(model.data_inicio).AddHours(00).AddMinutes(00);
            var fim = Convert.ToDateTime(model.data_fim).AddHours(23).AddMinutes(59);

            var query = (from con in context.tb_con_monitoramentoControleAcesso
                         join pta in context.tb_pta_pontosAcesso on con.con_c_pontoAcesso equals pta.pta_c_nomePonto
                         join cnt in context.tb_con_controladora on pta.pta_con_n_codigo equals cnt.con_n_codigo
                         join tempMor in context.tb_mor_Morador on con.con_usu_n_codigo equals tempMor.mor_n_codigo into tempMorador
                         from mor in tempMorador.DefaultIfEmpty()
                         join tempPse in context.tb_pse_prestadorServico on con.con_usu_n_codigo equals tempPse.pse_n_codigo into tempPrestador
                         from pse in tempPrestador.DefaultIfEmpty()
                         join tempVis in context.tb_vis_visitante on con.con_usu_n_codigo equals tempVis.vis_n_codigo into tempVisitante
                         from vis in tempVisitante.DefaultIfEmpty()
                         join cli in context.tb_cli_cliente on cnt.con_cli_n_codigo equals cli.cli_n_codigo
                         where con.con_cli_n_codigo == Convert.ToInt32(model.con_cli_n_codigo) && con.con_d_evento >= inicio
                         && con.con_d_evento <= fim && pta.pta_b_refeicao == true && con.con_c_status == "PERMITIDO"
                         && con.con_ref_c_nomeRefeicao != null && con.con_ref_d_valor != null
                         orderby con.con_d_evento ascending
                         select new RelatorioRefeitorioViewModel()
                         {
                             TipoCliente = cli.cli_tcl_n_codigo.ToString(),
                             ClienteId = con.con_cli_n_codigo.ToString(),
                             TipoPessoa = con.con_c_tipoPessoa,
                             PontoAcesso = con.con_c_pontoAcesso,
                             Usuario = con.con_c_usuario,
                             UsuarioId = con.con_usu_n_codigo.ToString(),
                             DataEvento = con.con_d_evento.Value.ToString("dd/MM/yyyy HH:mm:ss"),
                             Status = con.con_c_status,
                             DescricaoRefeicao = con.con_ref_c_nomeRefeicao,
                             ValorRefeicao = con.con_ref_d_valor.ToString(),
                             MoradorGrupoFamiliarId = mor.mor_grf_n_codigo.ToString(),
                             CpfMorador = mor.mor_c_cpf,
                             CpfPrestador = pse.pse_c_cpf,
                             CpfVisitante = vis.vis_c_cpf
                         }).ToList();

            if (!string.IsNullOrEmpty(model.grupo))
            {
                query = query.Where(x => model.grupo.Equals(x.MoradorGrupoFamiliarId)).ToList();
            }

            var lista = query;
            var total = query.Count();
            decimal preco = 0.00M;
            using var package = new ExcelPackage();
            var columHeaders = new string[]
            {
                   "Pessoa",
                    "CPF",
                    "Tipo",
                    "Ponto de Acesso",
                    "Data/Hora",
                    "Refeição",
                    "Valor"
            };

            var worksheet = package.Workbook.Worksheets.Add("refeitorio");
            worksheet.DefaultColWidth = 30;
            using (var cells = worksheet.Cells[1, 1, 1, columHeaders.Count()])
            {
                cells.Style.Font.Bold = true;
                cells.Style.Font.Size = 14;
                cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cells.Style.Fill.BackgroundColor.SetColor(Color.Silver);
            }

            for (var i = 0; i < columHeaders.Count(); i++)
            {
                worksheet.Cells[1, i + 1].Value = columHeaders[i];
            }

            var j = 2;

            try
            {
                foreach (var acesso in lista)
                {
                    worksheet.Cells["A" + j].Value = string.IsNullOrEmpty(acesso.Usuario) ? "NOME NÃO CADASTRADO" : acesso.Usuario;
                    worksheet.Cells["B" + j].Value = string.IsNullOrEmpty(acesso.CPF) ? "CPF NÃO CADASTRADO" : acesso.CPF;
                    worksheet.Cells["C" + j].Value = acesso.TipoPessoa == "MORADOR" && acesso.TipoCliente == "2" ? "FUNCIONÁRIO" : acesso.TipoPessoa;
                    worksheet.Cells["D" + j].Value = acesso.PontoAcesso;
                    worksheet.Cells["E" + j].Value = acesso.DataEvento;
                    worksheet.Cells["F" + j].Value = acesso.DescricaoRefeicao;
                    worksheet.Cells["G" + j].Value = $"R${acesso.ValorRefeicao.Replace(".", ",")}";

                    j++;

                    preco += decimal.Parse(acesso.ValorRefeicao, CultureInfo.InvariantCulture);
                }

                var row = total + 2;
                var row1 = total + 4;

                worksheet.Cells["A" + row].Value = $"Total de Acessos: {total}";
                worksheet.Cells["A" + row1].Value = $"Preço total: {preco.ToString("C")}";

                worksheet.Cells["A" + row].Style.Font.Size = 14;

                worksheet.Cells["A" + row1].Style.Font.Bold = true;
                worksheet.Cells["A" + row1].Style.Font.Size = 14;

                worksheet.Cells["A" + row].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A" + row].Style.Fill.BackgroundColor.SetColor(Color.Silver);

                worksheet.Cells["A" + row1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A" + row1].Style.Fill.BackgroundColor.SetColor(Color.Silver);

                worksheet.Cells["A" + row].Value = $"Total de Acessos: {total}";
                worksheet.Cells["A" + row].Style.Font.Bold = true;
                worksheet.Cells["A" + row].Style.Font.Size = 14;

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

        public IPagedList<MonitoramentoControleAcessoViewModel> GetAcessosPorPessoa(MonitoramentoControleAcessoFilterModel filter)
        {
            var query = (from con in Context.tb_con_monitoramentoControleAcesso
                         join cli in Context.tb_cli_cliente on con.con_cli_n_codigo.Value equals cli.cli_n_codigo
                         join vis in context.tb_vis_visitante on con.con_usu_n_codigo equals vis.vis_n_codigo
                         join pse in context.tb_pse_prestadorServico on con.con_usu_n_codigo equals pse.pse_n_codigo
                         where /*(con.con_b_LimparEvento == false || con.con_b_LimparEvento == null) &&*/
                         con.con_usu_n_codigo == Convert.ToInt32(filter.con_usu_n_codigo) &&
                         con.con_c_tipoPessoa.ToUpper() == filter.con_c_tipoPessoa.ToUpper()
                         orderby con.con_d_evento descending
                         select new MonitoramentoControleAcessoViewModel
                         {
                             con_n_codigo = con.con_n_codigo.ToString(),
                             con_cli_n_codigo = con.con_cli_n_codigo.ToString(),
                             con_usu_n_codigo = con.con_usu_n_codigo.ToString(),
                             con_c_usuario = !string.IsNullOrEmpty(con.con_c_usuario) ? con.con_c_usuario.ToUpper() : "NÃO IDENTIFICADO",
                             con_c_cardNumber = con.con_c_cardNumber.ToUpper(),
                             con_c_tipoPessoa = con.con_c_tipoPessoa.ToUpper(),
                             con_c_pontoAcesso = con.con_c_pontoAcesso.ToUpper(),
                             con_c_status = con.con_c_status.ToUpper(),
                             cin_c_tipoEventoMotivo = con.cin_c_tipoEventoMotivo,
                             con_d_evento = con.con_d_evento.Value.ToString("dd/MM/yyyy HH:mm:ss"),
                             con_c_tipoAcesso = !string.IsNullOrEmpty(con.con_c_tipoAcesso) ? con.con_c_tipoAcesso.ToUpper() : "NI",
                             con_b_panico = con.con_b_panico.ToString(),
                             con_b_panicoTratado = con.con_b_panicoTratado.ToString(),
                             con_b_tipoPanico = con.con_b_tipoPanico.ToString(),
                             con_c_obsTratamentoPanico = con.con_c_obsTratamentoPanico,
                             NomeCliente = cli.cli_c_nomeFantasia.ToUpper(),
                             con_fot_n_codigo = con.con_fot_n_codigo == null ? "0" : con.con_fot_n_codigo.ToString(),
                             cli_tcl_n_codigo = Convert.ToInt32(cli.cli_tcl_n_codigo),
                             con_c_telefone = con.con_c_tipoPessoa.ToUpper() == "VISITANTE" ? vis.vis_c_celular.Replace(" ", "")
                             : pse.pse_c_celular.Replace(" ", "")
                         })?.Take(5)?.ToList();

            return query?.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }
        
        private static string RetornarTelefoneUsuario(string con_c_tipoPessoa,
            string mor_c_celular, string vis_c_celular, string pse_c_celular)
        {
            switch (con_c_tipoPessoa.Trim().ToUpper())
            {
                case "MORADOR":
                    return mor_c_celular?.Replace(" ", "");
                case "VISITANTE":
                    return vis_c_celular?.Replace(" ", "");
                case "PRESTADOR":
                    return pse_c_celular?.Replace(" ", "");
                default: 
                    return "";
            }
        }
    }
}
