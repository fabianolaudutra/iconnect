using System.Collections.Generic;
using System.Text;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;
using System.Security.Cryptography;
using Iconnect.Aplicacao.ViewModel;
using Iconnect.Aplicacao.ViewModels;
using PagedList;
using Iconnect.Aplicacao.FilterModel;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using CORS.CitroxDecompiled;
using Iconnect.Infraestrutura.Exceptions;
using System.Globalization;

namespace Iconnect.Aplicacao.Services
{
    public class AgendaService : RepositoryBase<tb_age_agenda>, IAgendaService
    {
        private IconnectCoreContext context;

        public AgendaService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
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

        private IVisitanteAppService _visitanteApp;
        public IVisitanteAppService VisitanteApp
        {
            get
            {
                if (_visitanteApp == null)
                {
                    _visitanteApp = new VisitanteAppService(context);
                }
                return _visitanteApp;
            }
        }

        private IControleAcessoService _controleAcesso;
        public IControleAcessoService ControleAcesso
        {
            get
            {
                if (_controleAcesso == null)
                {
                    _controleAcesso = new ControleAcessoService(context);
                }
                return _controleAcesso;
            }
        }

        private ILiberacaoVisitanteService _liberacao;
        public ILiberacaoVisitanteService Liberacao
        {
            get
            {
                if (_liberacao == null)
                {
                    _liberacao = new LiberacaoVisitanteService(context);
                }
                return _liberacao;
            }
        }

        private IChavesDeAcessoService _chaves;
        public IChavesDeAcessoService Cheves
        {
            get
            {
                if (_chaves == null)
                {
                    _chaves = new ChavesDeAcessoService(context);
                }
                return _chaves;
            }
        }

        private ISincronizacaoPlacasService _sincronizadora;
        public ISincronizacaoPlacasService Sincronizadora
        {
            get
            {
                if (_sincronizadora == null)
                {
                    _sincronizadora = new SincronizacaoPlacasService(context);
                }
                return _sincronizadora;
            }
        }

        private IAcompanhanteService _acompanhante;
        public IAcompanhanteService Acompanhante
        {
            get
            {
                if (_acompanhante == null)
                {
                    _acompanhante = new AcompanhanteService(context);
                }
                return _acompanhante;
            }
        }


        public void SalvarAgendamento(AgendaViewModel model, string usuarioLogado)
        {
            try
            {
                //Retorno retorno = new Retorno();

                // tb_vis_visitasApp visApp;
                int idVis = 0;

                tb_grf_grupoFamiliar GrupoFamiliar = context.tb_grf_grupoFamiliar.Find(model.age_grf_n_codigo);
                tb_vis_visitante tbVisitante = new tb_vis_visitante();

                if (verificaDisponibilidade(model) == true)
                {
                    var visitante = new VisitanteViewModel
                    {
                        vis_n_codigo = model.visitante.vis_n_codigo,
                        vis_c_nome = model.visitante.vis_c_nome,
                        vis_c_cpf = model.visitante.vis_c_cpf,
                        vis_c_email = model.visitante.vis_c_email,
                        vis_c_celular = model.visitante.vis_c_celular,
                        vis_cli_n_codigo = GrupoFamiliar.grf_cli_n_codigo.Value.ToString(),
                        vis_c_rg = model.visitante.vis_c_rg,

                    };
                    idVis = Visitante.SalvarVisitante(visitante);
                    tbVisitante.vis_c_nome = visitante.vis_c_nome;
                    tbVisitante.vis_c_celular = visitante.vis_c_celular;

                    //SALVA AGENDAMENTO
                    tb_age_agenda agenda;
                    if (model.age_n_codigo == 0)
                    {
                        Insert(agenda = new tb_age_agenda()
                        {
                            age_c_horarioFim = model.age_c_horarioFim,
                            age_c_horarioInicio = model.age_c_horarioInicio,
                            age_d_dataAgendamento = Convert.ToDateTime(model.age_d_dataAgendamento),
                            age_grf_n_codigo = GrupoFamiliar.grf_n_codigo,
                            age_vis_n_codigo = idVis,
                            // age_cal_n_codigo = Convert.ToInt32(model.age_cal_n_codigo),
                            age_c_usuario = usuarioLogado,
                            age_d_inclusao = DateTime.Now,
                            age_c_unique = Guid.NewGuid(),
                            age_mor_n_codigo = Convert.ToInt32(model.age_mor_n_codigo),
                        });
                        context.SaveChanges();

                        //SALVA VISITA APP

                        calcDatas _datas = calcDuracao(model);
                        string dataHota = _datas.data;

                        VisitasAppViewModel visitasAPP = new VisitasAppViewModel();
                        visitasAPP.vis_c_descricao = model.visitasApp.vis_c_descricao;
                        visitasAPP.vis_age_n_codigo = agenda.age_n_codigo;
                        visitasAPP.vis_d_dataHora = Convert.ToDateTime(dataHota);
                        visitasAPP.vis_c_hora = _datas.hora;
                        visitasAPP.vis_n_duracao = Convert.ToInt32(_datas.duracao.TotalMinutes);
                        VisitanteApp.SalvarVisitasApp(visitasAPP);

                        //SALVA CONTROLE ACESSO
                        string novoToken = GerarChave();
                        ControleAcessoViewModel cac = new ControleAcessoViewModel();
                        cac.cac_mor_n_codigo = null;
                        cac.cac_vis_n_codigo = idVis.ToString();
                        cac.cac_c_descricao = string.Empty;
                        cac.cac_c_numeroCartao = string.Empty;
                        cac.cac_c_tipo = string.Empty;
                        cac.cac_c_numeroChave = string.Empty;
                        cac.cac_b_panico = "false";
                        cac.cac_c_tipoAcesso = "LA"; //Liberação APP ÓRION
                        cac.cac_c_senha = ConverterSenha(novoToken);

                        ControleAcesso.SalvarControleAcesso(cac, true);
                        var idCac = (from c in context.tb_cac_controleAcesso orderby c.cac_n_codigo descending where c.cac_c_senha == c.cac_c_senha && c.cac_vis_n_codigo == idVis && c.cac_c_tipoAcesso == "LA" select c.cac_n_codigo).FirstOrDefault();

                        //SALVAR LIBERAÇAO
                        LiberacaoVisitanteViewModel liv = new LiberacaoVisitanteViewModel();
                         liv.liv_b_pendente = true;
                        liv.liv_c_celular = tbVisitante.vis_c_celular;
                        liv.liv_c_nome = tbVisitante.vis_c_nome;
                        liv.liv_mor_n_codigo = null;
                        liv.liv_vis_n_codigo = visitasAPP.vis_n_codigo;
                        liv.liv_visitante_n_codigo = idVis;
                        liv.liv_d_dataHora = visitasAPP.vis_d_dataHora;
                        liv.liv_cac_n_codigo = idCac;//salvar cac codigo

                        Liberacao.SalvarLiberacao(liv);

                        //CHAVE ACESSO
                        ChavesDeAcessoViewModel cha = new ChavesDeAcessoViewModel();
                        cha.cha_liv_n_codigo = liv.liv_n_codigo;
                        cha.cha_c_chave = novoToken;
                        Cheves.SalvarChaveAcesso(cha);

                        //SINCRONIZADORA PLACA
                        //Só envia sincronização para a placa, se o cliente possuir uma controladora ZK
                        string controladoras = getControladorasSincronizacao(GrupoFamiliar.grf_cli_n_codigo.Value);
                        Sincronizadora.SalvarSincronizacaoPlacasInterna(GrupoFamiliar.grf_cli_n_codigo.Value, controladoras, idCac);

                        //ENVIO DE PUSH APP
                        context.SaveChanges();

                    }
                    else
                    {
                        //AGENDAMENTO PERMITIDO
                        if (verificaDisponibilidade(model) == true)
                        {

                            //UPDATE VISITANTE APP
                            var visApp = (from vis in context.tb_vis_visitasApp
                                          where vis.vis_age_n_codigo == model.age_n_codigo
                                          select vis).FirstOrDefault();

                            calcDatas _datas = calcDuracao(model);
                            string dataHota = _datas.data;
                            visApp.vis_c_descricao = model.visitasApp.vis_c_descricao;
                            visApp.vis_d_dataHora = Convert.ToDateTime(dataHota);
                            visApp.vis_n_duracao = Convert.ToInt32(_datas.duracao.TotalMinutes);
                            VisitanteApp.Update(visApp);


                            //UPDATE LIBERAÇÃO APP

                            var liberacao = (from liv in context.tb_liv_liberacaoVisitante
                                             where liv.liv_vis_n_codigo == visApp.vis_n_codigo
                                             select liv).FirstOrDefault();

                            liberacao.liv_d_dataHora = Convert.ToDateTime(dataHota);
                            Liberacao.Update(liberacao);


                            //UPDATE AGENDAMENTO
                            agenda = (from age in context.tb_age_agenda
                                      where age.age_n_codigo == model.age_n_codigo
                                      select age).FirstOrDefault();

                            agenda.age_d_dataAgendamento = model.age_d_dataAgendamento;
                            agenda.age_c_horarioFim = model.age_c_horarioFim;
                            agenda.age_c_horarioInicio = model.age_c_horarioInicio;
                            agenda.age_grf_n_codigo = GrupoFamiliar.grf_n_codigo;
                            agenda.age_mor_n_codigo = Convert.ToInt32(model.age_mor_n_codigo);
                            agenda.age_c_usuario = usuarioLogado;
                            Update(agenda);
                            context.SaveChanges();


                            //NOVA SINCRONIZADORA PLACA
                            string controladoras = getControladorasSincronizacao(GrupoFamiliar.grf_cli_n_codigo.Value);
                            Sincronizadora.SalvarSincronizacaoPlacasInterna(GrupoFamiliar.grf_cli_n_codigo.Value, controladoras, liberacao.liv_cac_n_codigo);

                        }
                        else
                        {
                            throw new MensagemException("Horário indisponível.");
                        }

                    }

                }
                else
                {
                    throw new MensagemException("Horário indisponível.");
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool verificaDisponibilidade(AgendaViewModel model)
        {
            try
            {
                var retorno = true;
                var query = (from age in context.tb_age_agenda
                             where age.age_n_codigo != model.age_n_codigo && age.age_mor_n_codigo == Convert.ToInt32(model.age_mor_n_codigo)
                             && age.age_d_dataAgendamento.Value.Date == model.age_d_dataAgendamento.Value.Date
                             select age).ToList();

                foreach (var agenda in query)
                {
                    if (Convert.ToDateTime(agenda.age_c_horarioInicio).TimeOfDay < Convert.ToDateTime(model.age_c_horarioFim).TimeOfDay &&
                        Convert.ToDateTime(agenda.age_c_horarioFim).TimeOfDay > Convert.ToDateTime(model.age_c_horarioInicio).TimeOfDay)
                    {
                        retorno = false;
                    }
                    else if (Convert.ToDateTime(agenda.age_c_horarioInicio).TimeOfDay == Convert.ToDateTime(model.age_c_horarioFim).TimeOfDay &&
                             Convert.ToDateTime(agenda.age_c_horarioFim).TimeOfDay == Convert.ToDateTime(model.age_c_horarioInicio).TimeOfDay)
                    {
                        retorno = false;
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private calcDatas calcDuracao(AgendaViewModel agenda)
        {
            calcDatas retorno = new calcDatas();
            try
            {

                DateTime dtAgenda = agenda.age_d_dataAgendamento.Value;

                int dia;
                int mes;
                int ano;

                dia = dtAgenda.Day;
                mes = dtAgenda.Month;
                ano = dtAgenda.Year;

                DateTime dt = new DateTime(ano, mes, dia);

                string data = (agenda.age_d_dataAgendamento != null ? dt.ToShortDateString() : DateTime.Now.ToString("dd/MM/yyyy"));
                string hora = (agenda.age_c_horarioInicio != null ? Convert.ToDateTime(agenda.age_c_horarioInicio).ToString("HH:mm") : DateTime.Now.ToString("HH:mm"));
                string horaFim = (agenda.age_c_horarioFim != null ? Convert.ToDateTime(agenda.age_c_horarioFim).ToString("HH:mm") : DateTime.Now.ToString("HH:mm"));
                TimeSpan duracao = Convert.ToDateTime(horaFim) - Convert.ToDateTime(hora);
                var _data = data + " " + hora;
                retorno.data = _data;
                retorno.duracao = duracao;
                retorno.hora = hora;

                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<AgendaViewModel> GetAllAgenda(int id)
        {
            try
            {
                var query = (from age in Context.tb_age_agenda
                             join visApp in Context.tb_vis_visitasApp on age.age_n_codigo equals visApp.vis_age_n_codigo
                             join vis in Context.tb_vis_visitante on age.age_vis_n_codigo equals vis.vis_n_codigo
                             where age.age_mor_n_codigo == id && visApp.vis_c_descricao != "Solicitação acompanhante"
                             select new AgendaViewModel()
                             {
                                 nomeVisitante = vis.vis_c_nome,
                                 titulo = visApp.vis_c_descricao,
                                 age_c_horarioInicio = age.age_c_horarioInicio,
                                 age_n_codigo = age.age_n_codigo,
                                 age_c_horarioFim = age.age_c_horarioFim,
                                 age_d_dataAgendamento = age.age_d_dataAgendamento,
                                 age_mor_n_codigo = age.age_mor_n_codigo.ToString(),
                             }).ToList();

                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string GerarChave()
        {
            List<tb_cac_controleAcesso> controleAcesso = new List<tb_cac_controleAcesso>();
            List<tb_cha_chavesDeAcesso> ChaveAcesso = new List<tb_cha_chavesDeAcesso>();
            string token = "";
            string tokenConvertido = "";
            try
            {
                do
                {
                    token = geraChaveToken();
                    tokenConvertido = ConverterSenha(token);
                    controleAcesso = (from cac in context.tb_cac_controleAcesso where cac.cac_c_senha == tokenConvertido || cac.cac_c_numeroCartao == token || cac.cac_c_numeroChave == token select cac).ToList();
                    ChaveAcesso = (from cha in context.tb_cha_chavesDeAcesso where cha.cha_c_chave == token select cha).ToList();
                } while (controleAcesso.Count > 0 || ChaveAcesso.Count > 0);
                return token;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string geraChaveToken()
        {
            string chave = "";
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                chave += random.Next(0, 9).ToString();
            }

            return chave;
        }

        public string ConverterSenha(string senhaConvertida)
        {
            try
            {
                if (senhaConvertida.Length >= 8)
                {
                    senhaConvertida = senhaConvertida.Substring(0, 8);
                }
                senhaConvertida = PasswordConverter.ConvertPasswordToCardId(senhaConvertida);
            }
            catch (Exception)
            {

            }
            return senhaConvertida;
        }

        public string DesconverterSenha(string senhaConvertida)
        {
            try
            {
                senhaConvertida = PasswordConverter.ConvertCardIdToPassword(senhaConvertida);
            }
            catch (Exception)
            {

            }
            return senhaConvertida;
        }

        private string getControladorasSincronizacao(int IdCli)
        {
            try
            {
                //Verifica se existe alguma controladora ZK deste cliente
                tb_cli_cliente cliente = (from cli in context.tb_cli_cliente where cli.cli_n_codigo == IdCli select cli).FirstOrDefault();
                string controladoras = string.Empty;
                var lstControladoras = cliente.tb_con_controladora.Where(x => x.con_c_modelo != "CITROX" && x.con_b_ativo == true).ToList();
                foreach (var item in lstControladoras)
                {
                    controladoras += "," + item.con_n_codigo;
                }

                return controladoras;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletarAgendamento(int id)
        {
            try
            {
                var visitasApp = (from vis in context.tb_vis_visitasApp where vis.vis_age_n_codigo == id select vis).ToList();
                foreach (var visita in visitasApp)
                {
                    tb_liv_liberacaoVisitante Liv = (from liv in context.tb_liv_liberacaoVisitante where liv.liv_vis_n_codigo == visita.vis_n_codigo select liv).FirstOrDefault();
                    var idChaveAcesso = (from cha in context.tb_cha_chavesDeAcesso where cha.cha_liv_n_codigo == Liv.liv_n_codigo select cha.cha_n_codigo).FirstOrDefault();

                    //DELETE  CONTROLEACESSO
                    ControleAcesso.DeletarControleAcesso(Liv.liv_cac_n_codigo);

                    //DELETE  TB_CHA_CHAVESDEACESSO
                    Cheves.DeleteChaveAcesso(idChaveAcesso);

                    //DELETE  lIBERAÇÃO
                    Liberacao.DeleteLiberacao(Liv.liv_n_codigo);

                    //DELETE  VISITAS APP
                    VisitanteApp.DeleteVisita(visita.vis_n_codigo);
                }

                Acompanhante.DeletarAcompanhante(id);
                
                //DELETE  AGENDA
                Delete(context.tb_age_agenda.Find(id));
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public AgendaViewModel GetAgenda(int id)
        {
            try
            {
                return (from age in context.tb_age_agenda
                        join visApp in Context.tb_vis_visitasApp on age.age_n_codigo equals visApp.vis_age_n_codigo
                        join vis in Context.tb_vis_visitante on age.age_vis_n_codigo equals vis.vis_n_codigo
                        where age.age_n_codigo == id

                        select new AgendaViewModel
                        {
                            nomeVisitante = vis.vis_c_nome,
                            titulo = visApp.vis_c_descricao,
                            email = vis.vis_c_email,
                            telefone = vis.vis_c_celular,
                            cpf = vis.vis_c_cpf,
                            age_c_horarioInicio = age.age_c_horarioInicio,
                            age_n_codigo = age.age_n_codigo,
                            age_c_horarioFim = age.age_c_horarioFim,
                            age_d_dataAgendamento = age.age_d_dataAgendamento,
                            age_vis_n_codigo = age.age_vis_n_codigo,
                            age_mor_n_codigo = age.age_mor_n_codigo.ToString(),
                            rg = vis.vis_c_rg,
                        }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public AgendaViewModel GetProximoDisponivel(AgendaViewModel model)
        {

            DateTime data1 = Convert.ToDateTime(model.age_d_dataAgendamento);
            DateTime data2 = data1.AddHours(23).AddMinutes(59);
            var query = (from age in context.tb_age_agenda
                         where age.age_mor_n_codigo == Convert.ToInt32(model.age_mor_n_codigo)
                         && age.age_d_dataAgendamento >= data1 && age.age_d_dataAgendamento <= data2
                         select new AgendaViewModel
                         {
                             age_d_dataAgendamento = age.age_d_dataAgendamento,
                             age_c_horarioInicio = age.age_c_horarioInicio,
                             age_c_horarioFim = age.age_c_horarioFim,
                         }).ToList();

            return query.Count() == 0 ? null : query.Last();
        }

        public List<int> AgendamentosVisitante(int id)
        {
            return (from age in context.tb_age_agenda where age.age_vis_n_codigo == id select age.age_n_codigo).ToList();
        }
    }
}
public class calcDatas
{
    public string data { get; set; }
    public TimeSpan duracao { get; set; }
    public string hora { get; set; }
}