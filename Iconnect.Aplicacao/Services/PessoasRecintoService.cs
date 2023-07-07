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
    class PessoasRecintoService : RepositoryBase<vw_pessoasRecinto>, IPessoasRecintoService
    {
        private IconnectCoreContext context;


        private IMonitoramentoControleAcessoService _monitoramentoControleAcesso;
        public IMonitoramentoControleAcessoService MonitoramentoControleAcesso
        {
            get
            {
                if (_monitoramentoControleAcesso == null)
                {
                    _monitoramentoControleAcesso = new MonitoramentoControleAcessoService(context);
                }
                return _monitoramentoControleAcesso;
            }
        }

        private IMoradorService _morador;
        public IMoradorService Morador
        {
            get
            {
                if (_morador == null)
                {
                    _morador = new MoradorService(context);
                }
                return _morador;
            }
        }

        private IVisitanteService _visitante;
        public IVisitanteService Visitante
        {
            get
            {
                if (_visitante == null)
                {
                    _visitante = new VisitanteService(context);
                }
                return _visitante;
            }
        }

        private IPrestadorServicoService _prestador;
        public IPrestadorServicoService Prestador
        {
            get
            {
                if (_prestador == null)
                {
                    _prestador = new PrestadorServicoService(context);
                }
                return _prestador;
            }
        }

        private IAtendimentoService _atendimento;
        public IAtendimentoService Atendimento
        {
            get
            {
                if (_atendimento == null)
                {
                    _atendimento = new AtendimentoService(context);
                }
                return _atendimento;
            }
        }


        public PessoasRecintoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public IPagedList<PessoasRecintoViewModel> GetPessoasRecintoFiltrado(PessoasRecintoFilterModel filter)
        {
            if (string.IsNullOrEmpty(filter.CODCLIENTE_filter))
            {
                return new PagedList<PessoasRecintoViewModel>(null, 1, 1);
            }

            var query = (from pessoa in Context.vw_pessoasRecinto
                         join grf in Context.tb_grf_grupoFamiliar on pessoa.LOCALIZACAO equals grf.grf_n_codigo.ToString() into tempGrf
                         from grf in tempGrf.DefaultIfEmpty()
                         where pessoa.IN_OUT && pessoa.DATA != null && pessoa.CODCLIENTE == Convert.ToInt32(filter.CODCLIENTE_filter)
                         select new PessoasRecintoViewModel
                         {
                             CODIGO = pessoa.CODIGO.ToString(),
                             NOME = pessoa.NOME,
                             DATA = pessoa.DATA.Value != null ? pessoa.DATA.Value.ToString("dd/MM/yyyy HH:mm:ss") : "",
                             DATA_AUX = pessoa.DATA.ToString(),
                             TELEFONE = pessoa.TELEFONE,
                             LOCALIZACAO = pessoa.LOCALIZACAO,
                             LOCALIZACAONOME =
                            string.IsNullOrEmpty(grf.grf_c_nomeResponsavel) ? pessoa.LOCALIZACAO : grf.grf_c_nomeResponsavel.ToUpper(),
                             TIPO = pessoa.TIPO,
                             CODCLIENTE = pessoa.CODCLIENTE.ToString(),
                             IN_OUT = pessoa.IN_OUT.ToString(),
                             DATA_SAIDA_MANUAL = pessoa.DATA_SAIDA_MANUAL.ToString(),
                             PERFIL = pessoa.PERFIL,
                             PSE_D_HORARIOFIM = pessoa.PSE_D_HORARIOFIM,
                             pse_b_panicotratado = pessoa.pse_b_panicotratado.ToString(),
                             CODIGOEMPRESA = pessoa.CODIGOEMPRESA.ToString(),
                             GEROU_ATENDIMENTO = pessoa.GEROU_ATENDIMENTO.ToString(),
                             NOMECLIENTE = pessoa.NOMECLIENTE,
                             data_entrada = pessoa.DATA.Value,
                             buscaSimples = pessoa.TIPO == "FUNCIONÁRIO" || pessoa.TIPO == "MORADOR" ? "Morador"
                             : pessoa.TIPO == "VISITANTE" ? "Visitante" : "Prestador",
                             dispararPanico = string.Empty
                         });

            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
            }
            if (!string.IsNullOrEmpty(filter.NOME_filter))
            {
                query = query.Where(w => w.NOME.Contains(filter.NOME_filter));
            }
            if (!string.IsNullOrEmpty(filter.TIPO_filter))
            {
                query = query.Where(w => w.TIPO.Contains(filter.TIPO_filter));
            }
            if (!string.IsNullOrEmpty(filter.TELEFONE_filter))
            {
                query = query.Where(w => w.TELEFONE.Contains(filter.TELEFONE_filter));
            }
            if (!string.IsNullOrEmpty(filter.LOCALIZACAONOME_filter))
            {
                query = query.Where(w => w.LOCALIZACAONOME.Contains(filter.LOCALIZACAONOME_filter));
            }

            if (!string.IsNullOrEmpty(filter.DATA_filter))
            {
                DateTime auxData;
                if (DateTime.TryParse(filter.DATA_filter, out auxData))
                {
                    query = query.Where(w => w.data_entrada.Date == auxData.Date);
                }
            }

            //if (!string.IsNullOrEmpty(filter.NOME_filter))
            //{
            //    query = query.Where(w => w.NOME.Contains(filter.NOME_filter));
            //}

            //if (!string.IsNullOrEmpty(filter.RG_filter))
            //{
            //    query = query.Where(w => w.RG.Contains(filter.RG_filter));
            //}

            //if (!string.IsNullOrEmpty(filter.CPF_filter))
            //{
            //    query = query.Where(w => w.CPF.Contains(filter.CPF_filter));
            //}

            //if (!string.IsNullOrEmpty(filter.TIPO_filter))
            //{
            //    query = query.Where(w => w.TIPO == filter.TIPO_filter);
            //}

            //if (!string.IsNullOrEmpty(filter.ATIVO_INATIVO_filter))
            //{
            //    query = query.Where(w => w.ativoInativo == filter.ATIVO_INATIVO_filter);
            //}

            //Ordenação
            query = query.OrderByDescending(x => x.DATA_AUX);

            //Ajuste tamanho textos
            //var listaPessoasRecintoService = query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            //foreach (var pessoa in listaPessoasRecintoService)
            //{
            //    if (pessoa.cli_c_nomeFantasia.Length > 25)
            //    {
            //        pessoa.cli_c_nomeFantasia = pessoa.cli_c_nomeFantasia.Substring(0, 25) + "...";
            //    }

            //    if (pessoa.NOME.Length > 45)
            //    {
            //        pessoa.NOME = pessoa.NOME.Substring(0, 45) + "...";
            //    }
            //}

            var lista = query.ToPagedList(filter.paginaDataTable, filter.quantidade);

            foreach (var pessoa in lista)
            {
                var cliente = (from cli in context.tb_cli_cliente where cli.cli_n_codigo == Convert.ToInt32(pessoa.CODCLIENTE) select cli).FirstOrDefault();
                pessoa.TIPO = (cliente.cli_tcl_n_codigo == 2 || cliente.cli_tcl_n_codigo == 3) && pessoa.TIPO == "MORADOR" ? "FUNCIONÁRIO" : pessoa.TIPO;
            }

            foreach (var pessoa in lista)
            {
                if (pessoa.TIPO.Equals("PRESTADOR DE SERVIÇO"))
                {
                    pessoa.dispararPanico = VerificaDisparo(pessoa.PSE_D_HORARIOFIM, pessoa.DATA_SAIDA_MANUAL);
                }
                else
                {
                    pessoa.dispararPanico = "false";
                }
            }

            return lista;
        }

        private string VerificaDisparo(string PSE_D_HORARIOFIM, string saidaExtendida)
        {
            if (string.IsNullOrEmpty(PSE_D_HORARIOFIM))
            {
                return "true";
            }

            DateTime.TryParse(PSE_D_HORARIOFIM, out DateTime pse_d_horarioFim);
            DateTime.TryParse(saidaExtendida, out DateTime extendido);
            DateTime dataAtual = DateTime.Now;

            if (string.IsNullOrEmpty(saidaExtendida) && pse_d_horarioFim <= dataAtual)
            {
                return "true";
            }
            else if (!string.IsNullOrEmpty(saidaExtendida) && extendido <= dataAtual)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        public byte[] GeraExcel(PessoasRecintoFilterModel filter)
        {
            var query = (from pessoa in Context.vw_pessoasRecinto
                         where pessoa.DATA != null && pessoa.CODCLIENTE == Convert.ToInt32(filter.CODCLIENTE_filter)
                         select new PessoasRecintoViewModel
                         {
                             CODIGO = pessoa.CODIGO.ToString(),
                             NOME = pessoa.NOME,
                             DATA = pessoa.DATA.Value != null ? pessoa.DATA.Value.ToString("dd/MM/yyyy HH:mm:ss") : "",
                             DATA_AUX = pessoa.DATA.ToString(),
                             TELEFONE = pessoa.TELEFONE,
                             LOCALIZACAO = pessoa.LOCALIZACAO,
                             TIPO = pessoa.TIPO,
                             CODCLIENTE = pessoa.CODCLIENTE.ToString(),
                             IN_OUT = pessoa.IN_OUT.ToString(),
                             DATA_SAIDA_MANUAL = pessoa.DATA_SAIDA_MANUAL.ToString(),
                             PERFIL = pessoa.PERFIL,
                             PSE_D_HORARIOFIM = pessoa.PSE_D_HORARIOFIM,
                             pse_b_panicotratado = pessoa.pse_b_panicotratado.ToString(),
                             CODIGOEMPRESA = pessoa.CODIGOEMPRESA.ToString(),
                             GEROU_ATENDIMENTO = pessoa.GEROU_ATENDIMENTO.ToString(),
                             NOMECLIENTE = pessoa.NOMECLIENTE,
                         });


            //Ordenação
            query = query.OrderByDescending(x => x.DATA_AUX);

            var lstPessoa = query.ToList();
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

                var worksheet = package.Workbook.Worksheets.Add("Pessoas Recinto");
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
                    foreach (var pessoa in lstPessoa)
                    {
                        worksheet.Cells["A" + j].Value = pessoa.NOMECLIENTE;
                        worksheet.Cells["B" + j].Value = pessoa.NOME;
                        worksheet.Cells["C" + j].Value = pessoa.TIPO;
                        worksheet.Cells["E" + j].Value = pessoa.TELEFONE;
                        worksheet.Cells["F" + j].Value = pessoa.LOCALIZACAO;
                        worksheet.Cells["G" + j].Value = pessoa.DATA;
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

        public PessoasRecintoViewModel GetPessoaRecinto(int codigo)
        {
            try
            {
                return (from rec in context.vw_pessoasRecinto
                        where rec.CODIGO == codigo
                        select new PessoasRecintoViewModel()
                        {
                            CODCLIENTE = rec.CODCLIENTE.ToString(),
                            CODIGO = rec.CODIGO.ToString(),
                            NOME = rec.NOME,
                            DATA = rec.DATA != null ? rec.DATA.Value.ToString("dd/MM/yyyy") : null,
                            TELEFONE = rec.TELEFONE,
                            LOCALIZACAO = rec.LOCALIZACAO,
                            TIPO = rec.TIPO,
                            IN_OUT = rec.IN_OUT.ToString(),
                            DATA_SAIDA_MANUAL = rec.DATA_SAIDA_MANUAL != null ? rec.DATA_SAIDA_MANUAL.Value.ToString("dd/MM/yyyy") : null,
                            PERFIL = rec.PERFIL,
                            PSE_D_HORARIOFIM = rec.PSE_D_HORARIOFIM,
                            NOMECLIENTE = rec.NOMECLIENTE,
                            GEROU_ATENDIMENTO = rec.GEROU_ATENDIMENTO.ToString()

                        }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool limpaRecintoGeral(PessoasRecintoViewModel model)
        {
            try
            {
                int idcliente = Convert.ToInt32(model.CODCLIENTE);
                List<vw_pessoasRecinto> list = context.vw_pessoasRecinto.Where(x => x.CODCLIENTE == idcliente && x.IN_OUT == true).ToList();
                foreach (var item in list)
                {
                    switch (item.TIPO)
                    {
                        case "MORADOR":

                            tb_mor_Morador tbMorador = (from mor in context.tb_mor_Morador where mor.mor_n_codigo == item.CODIGO select mor).FirstOrDefault();
                            tbMorador.mor_b_inOut = false;
                            tbMorador.mor_d_dataEntrada = null;

                            Morador.Update(tbMorador);
                            context.SaveChanges();

                            break;
                        case "VISITANTE":

                            tb_con_monitoramentoControleAcesso monVis = new tb_con_monitoramentoControleAcesso();
                            tb_vis_visitante tbVisitante = (from vis in context.tb_vis_visitante where vis.vis_n_codigo == item.CODIGO select vis).FirstOrDefault();


                            if (tbVisitante != null)
                            {
                                tbVisitante.vis_b_inOut = false;
                                tbVisitante.vis_d_dataEntrada = null;

                                Visitante.Update(tbVisitante);
                                context.SaveChanges();
                            }


                            monVis.con_d_evento = DateTime.Now;
                            monVis.con_c_pin = "";
                            monVis.con_cli_n_codigo = tbVisitante.vis_cli_n_codigo;
                            monVis.con_c_cardNumber = "REGISTRO DE SAÍDA";
                            monVis.con_c_doorId = "100"; //Testar pra ver se não irá dar problema na listagem do access
                            monVis.con_c_tipoPessoa = "VISITANTE";
                            monVis.con_c_usuario = tbVisitante.vis_c_nome;
                            monVis.con_c_pontoAcesso = "NÃO IDENTIFICADO";
                            monVis.con_c_acao = "OUTROS";
                            monVis.con_c_status = "PERMITIDO";
                            monVis.cin_c_tipoEventoMotivo = "REGISTRO DE SÁIDA DO RECINTO EM:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "POR: " + model.operTemp;
                            monVis.con_usu_n_codigo = tbVisitante.vis_n_codigo; //ID DO OPERADOR/VISITANTE
                            monVis.con_fot_n_codigo = tbVisitante.vis_fot_n_codigo; //FOTO DA PESSOA SE TIVER CADASTRADA
                            monVis.con_b_inOut = false;
                            monVis.con_b_panico = false;
                            monVis.con_ate_n_codigo = null;
                            monVis.con_b_precisaAtendimento = false;
                            monVis.con_n_h = null;
                            monVis.con_d_modificacao = DateTime.Now;
                            monVis.con_b_LimparEvento = false;
                            monVis.con_b_panicoTratado = null;
                            monVis.con_d_dataTratamentoPanico = null;
                            monVis.con_c_obsTratamentoPanico = "";
                            monVis.con_c_UsuarioTratamentoPanico = "";
                            monVis.con_b_tipoPanico = null;
                            monVis.con_pec_n_codigo = null;
                            monVis.con_b_pendenteVideo = false;
                            monVis.con_c_destino = "";
                            monVis.con_d_atualizado = DateTime.Now;
                            monVis.con_d_inclusao = DateTime.Now;
                            monVis.con_c_unique = Guid.NewGuid(); //confirmar o comendo de new id
                            monVis.con_c_tipoAcesso = "RC";

                            MonitoramentoControleAcesso.Insert(monVis);
                            context.SaveChanges();
                            break;
                        case "PRESTADOR DE SERVIÇO":

                            tb_con_monitoramentoControleAcesso monPse = new tb_con_monitoramentoControleAcesso();
                            tb_pse_prestadorServico tbPse = (from pse in context.tb_pse_prestadorServico where pse.pse_n_codigo == item.CODIGO select pse).FirstOrDefault();

                            if (tbPse != null)
                            {
                                tbPse.tb_avp_avisoPrestador = null;
                                tbPse.tb_cac_controleAcesso = null;
                                tbPse.pse_b_inOut = false;
                                tbPse.pse_d_dataSaidaManual = null;
                                tbPse.pse_b_panicoTratado = null;
                                tbPse.pse_n_horarioAdicional = null;
                                tbPse.pse_d_dataEntrada = null;
                                tbPse.pse_b_gerou_atendimento = false;

                                Prestador.Update(tbPse);
                                context.SaveChanges();
                            }

                            monPse.con_d_evento = DateTime.Now;
                            monPse.con_c_pin = "";
                            monPse.con_cli_n_codigo = tbPse.pse_cli_n_codigo;
                            monPse.con_c_cardNumber = "REGISTRO DE SAÍDA";
                            monPse.con_c_doorId = "100"; //Testar pra ver se não irá dar problema na listagem do access
                            monPse.con_c_tipoPessoa = "PRESTADOR";
                            monPse.con_c_usuario = tbPse.pse_c_nome;
                            monPse.con_c_pontoAcesso = "NÃO IDENTIFICADO";
                            monPse.con_c_acao = "OUTROS";
                            monPse.con_c_status = "PERMITIDO";
                            monPse.cin_c_tipoEventoMotivo = "REGISTRO DE SÁIDA DO RECINTO EM:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "POR: " + model.operTemp;
                            monPse.con_usu_n_codigo = tbPse.pse_n_codigo; //ID DO OPERADOR/VISITANTE
                            monPse.con_fot_n_codigo = tbPse.pse_fot_n_codigo; //FOTO DA PESSOA SE TIVER CADASTRADA
                            monPse.con_b_inOut = false;
                            monPse.con_b_panico = false;
                            monPse.con_ate_n_codigo = null;
                            monPse.con_b_precisaAtendimento = false;
                            monPse.con_n_h = null;
                            monPse.con_d_modificacao = DateTime.Now;
                            monPse.con_b_LimparEvento = false;
                            monPse.con_b_panicoTratado = null;
                            monPse.con_d_dataTratamentoPanico = null;
                            monPse.con_c_obsTratamentoPanico = "";
                            monPse.con_c_UsuarioTratamentoPanico = "";
                            monPse.con_b_tipoPanico = null;
                            monPse.con_pec_n_codigo = null;
                            monPse.con_b_pendenteVideo = false;
                            monPse.con_c_destino = "";
                            monPse.con_d_atualizado = DateTime.Now;
                            monPse.con_d_inclusao = DateTime.Now;
                            monPse.con_c_unique = Guid.NewGuid(); //confirmar o comendo de new id
                            monPse.con_c_tipoAcesso = "RC";

                            MonitoramentoControleAcesso.Insert(monPse);
                            context.SaveChanges();

                            FinalizaAtendimento(tbPse.pse_cli_n_codigo);
                            break;
                        default:
                            break;
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool limpaRecintoIndividual(PessoasRecintoViewModel model)
        {
            try
            {
                int id = Convert.ToInt32(model.CODIGO);
                switch (model.TIPO)
                {
                    case "MORADOR":

                        tb_mor_Morador tbMorador = (from mor in context.tb_mor_Morador where mor.mor_n_codigo == id select mor).FirstOrDefault();
                        tbMorador.mor_b_inOut = false;
                        tbMorador.mor_d_dataEntrada = null;

                        Morador.Update(tbMorador);
                        context.SaveChanges();

                        break;
                    case "VISITANTE":

                        tb_con_monitoramentoControleAcesso monVis = new tb_con_monitoramentoControleAcesso();
                        tb_vis_visitante tbVisitante = (from vis in context.tb_vis_visitante where vis.vis_n_codigo == id select vis).FirstOrDefault();


                        if (tbVisitante != null)
                        {
                            tbVisitante.vis_b_inOut = false;
                            tbVisitante.vis_d_dataEntrada = null;
                            Visitante.Update(tbVisitante);
                            context.SaveChanges();
                        }

                        if (model.abertura == false)
                        {
                            monVis.con_d_evento = DateTime.Now;
                            monVis.con_c_pin = "";
                            monVis.con_cli_n_codigo = tbVisitante.vis_cli_n_codigo;
                            monVis.con_c_cardNumber = "REGISTRO DE SAÍDA";
                            monVis.con_c_doorId = "100"; //Testar pra ver se não irá dar problema na listagem do access
                            monVis.con_c_tipoPessoa = "VISITANTE";
                            monVis.con_c_usuario = tbVisitante.vis_c_nome;
                            monVis.con_c_pontoAcesso = "NÃO IDENTIFICADO";
                            monVis.con_c_acao = "OUTROS";
                            monVis.con_c_status = "PERMITIDO";
                            monVis.cin_c_tipoEventoMotivo = "REGISTRO DE SÁIDA DO RECINTO EM:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " POR: " + model.operTemp;
                            monVis.con_usu_n_codigo = tbVisitante.vis_n_codigo; //ID DO OPERADOR/VISITANTE
                            monVis.con_fot_n_codigo = tbVisitante.vis_fot_n_codigo; //FOTO DA PESSOA SE TIVER CADASTRADA
                            monVis.con_b_inOut = false;
                            monVis.con_b_panico = false;
                            monVis.con_ate_n_codigo = null;
                            monVis.con_b_precisaAtendimento = false;
                            monVis.con_n_h = null;
                            monVis.con_d_modificacao = DateTime.Now;
                            monVis.con_b_LimparEvento = false;
                            monVis.con_b_panicoTratado = null;
                            monVis.con_d_dataTratamentoPanico = null;
                            monVis.con_c_obsTratamentoPanico = "";
                            monVis.con_c_UsuarioTratamentoPanico = "";
                            monVis.con_b_tipoPanico = null;
                            monVis.con_pec_n_codigo = null;
                            monVis.con_b_pendenteVideo = false;
                            monVis.con_c_destino = "";
                            monVis.con_d_atualizado = DateTime.Now;
                            monVis.con_d_inclusao = DateTime.Now;
                            monVis.con_c_unique = Guid.NewGuid();
                            monVis.con_c_tipoAcesso = "RC";

                            MonitoramentoControleAcesso.Insert(monVis);
                            context.SaveChanges();
                        }

                        break;
                    case "PRESTADOR DE SERVIÇO":

                        tb_con_monitoramentoControleAcesso monPse = new tb_con_monitoramentoControleAcesso();
                        tb_pse_prestadorServico tbPse = (from pse in context.tb_pse_prestadorServico where pse.pse_n_codigo == id select pse).FirstOrDefault();

                        if (tbPse != null)
                        {
                            tbPse.tb_avp_avisoPrestador = null;
                            tbPse.tb_cac_controleAcesso = null;
                            tbPse.pse_b_inOut = false;
                            tbPse.pse_d_dataSaidaManual = null;
                            tbPse.pse_b_panicoTratado = null;
                            tbPse.pse_n_horarioAdicional = null;
                            tbPse.pse_d_dataEntrada = null;
                            tbPse.pse_b_gerou_atendimento = false;

                            Prestador.Update(tbPse);
                            context.SaveChanges();
                        }

                        if (model.abertura == false)
                        {
                            monPse.con_d_evento = DateTime.Now;
                            monPse.con_c_pin = "";
                            monPse.con_cli_n_codigo = tbPse.pse_cli_n_codigo;
                            monPse.con_c_cardNumber = "REGISTRO DE SAÍDA";
                            monPse.con_c_doorId = "100"; //Testar pra ver se não irá dar problema na listagem do access
                            monPse.con_c_tipoPessoa = "PRESTADOR";
                            monPse.con_c_usuario = tbPse.pse_c_nome;
                            monPse.con_c_pontoAcesso = "NÃO IDENTIFICADO";
                            monPse.con_c_acao = "OUTROS";
                            monPse.con_c_status = "PERMITIDO";
                            monPse.cin_c_tipoEventoMotivo = "REGISTRO DE SÁIDA DO RECINTO EM:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "POR: " + model.operTemp;
                            monPse.con_usu_n_codigo = tbPse.pse_n_codigo; //ID DO OPERADOR/VISITANTE
                            monPse.con_fot_n_codigo = tbPse.pse_fot_n_codigo; //FOTO DA PESSOA SE TIVER CADASTRADA
                            monPse.con_b_inOut = false;
                            monPse.con_b_panico = false;
                            monPse.con_ate_n_codigo = null;
                            monPse.con_b_precisaAtendimento = false;
                            monPse.con_n_h = null;
                            monPse.con_d_modificacao = DateTime.Now;
                            monPse.con_b_LimparEvento = false;
                            monPse.con_b_panicoTratado = null;
                            monPse.con_d_dataTratamentoPanico = null;
                            monPse.con_c_obsTratamentoPanico = "";
                            monPse.con_c_UsuarioTratamentoPanico = "";
                            monPse.con_b_tipoPanico = null;
                            monPse.con_pec_n_codigo = null;
                            monPse.con_b_pendenteVideo = false;
                            monPse.con_c_destino = "";
                            monPse.con_d_atualizado = DateTime.Now;
                            monPse.con_d_inclusao = DateTime.Now;
                            monPse.con_c_unique = Guid.NewGuid();
                            monPse.con_c_tipoAcesso = "RC";
                            MonitoramentoControleAcesso.Insert(monPse);
                            context.SaveChanges();

                        }


                        FinalizaAtendimento(tbPse.pse_cli_n_codigo);
                        break;
                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void FinalizaAtendimento(int? cliente)
        {
            try
            {
                List<vw_pessoasRecinto> list = context.vw_pessoasRecinto.Where(x => x.CODCLIENTE == cliente && x.IN_OUT == true && x.TIPO == "PRESTADOR DE SERVIÇO").ToList();
                if (list.Count() == 0)
                {
                    //verifico se n existe algum atendimento para o cliente do prestador,assim finalizo o atendimento
                    List<tb_ate_atendimento> possuiAtendmento = (from ate in context.tb_ate_atendimento where ate.ate_c_descricao == "PRESTADOR DE SERVIÇO NO RECINTO" && ate.ate_cli_n_codigo == cliente.Value && ate.ate_c_status != "FN" select ate).ToList();
                    if (possuiAtendmento.Count == 1)//Considerando que sempre iremos ter 1 atendimento por cliente
                    {
                        string idsAten = "";
                        foreach (var i in possuiAtendmento)
                        {
                            idsAten += i.ate_n_codigo + ",";
                        }
                        Atendimento.FinalizarAtendimentosRecinto(idsAten);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
