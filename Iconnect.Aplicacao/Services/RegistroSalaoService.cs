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
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Infraestrutura.Exceptions;
using System.IO;

namespace Iconnect.Aplicacao.Services
{
    class RegistroSalaoService : RepositoryBase<tb_res_registroSalao>, IRegistroSalaoService
    {
        private Boolean per = false;
        private IconnectCoreContext context;

        public RegistroSalaoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private IEmailService _email;
        public IEmailService Email
        {
            get
            {
                if (_email == null)
                {
                    _email = new EmailService(context);
                }
                return _email;
            }
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

        public void InsertOrUpdate(RegistroSalaoViewModel model, int perfil)
        {
            string status = "";
            int idRes = 0;
            tb_res_registroSalao reserva;
            int? codeDpn = !string.IsNullOrEmpty(model.res_dpn_n_codigo) && !model.res_dpn_n_codigo.Equals("0") ? Convert.ToInt32(model.res_dpn_n_codigo) : new int?();
            int? codeMor = !string.IsNullOrEmpty(model.res_mor_n_codigo) && !model.res_mor_n_codigo.Equals("0") ? Convert.ToInt32(model.res_mor_n_codigo) : new int?();
            int codeRes = !string.IsNullOrEmpty(model.res_n_codigo) && !model.res_n_codigo.Equals("0") ? Convert.ToInt32(model.res_n_codigo) : new int();

            if (codeRes == 0)
            {
                if (perfil == 7)
                {
                    per = true;
                    int id = 0;
                    var rel = (from r in context.tb_rel_responsavelLocacaoSaloes where r.rel_n_codigo == id select r).FirstOrDefault();

                    if (rel != null)
                    {
                        if (rel.rel_c_permissao == "ADM")
                        {
                            status = "AP";
                        }
                        else if (rel.rel_c_permissao == "GESTOR DE RESERVA")
                        {
                            status = "AA";
                        }
                    }
                }
                if (perfil == 1)
                {
                    per = false;
                    status = "AP";
                }
                else
                {
                    per = false;
                    status = "AA";
                }


                reserva = new tb_res_registroSalao()
                {
                    res_mor_n_codigo = codeMor,
                    res_dpn_n_codigo = codeDpn,
                    res_d_dataSolicitacao = !string.IsNullOrEmpty(model.res_mor_n_codigo) ? Convert.ToDateTime(model.res_d_dataSolicitacao) : new DateTime?(),
                    res_c_periodo = model.res_c_periodo,
                    res_c_status = status,
                    res_c_unique = Guid.NewGuid(),
                    res_d_atualizado = DateTime.Now,
                    res_d_inclusao = DateTime.Now,
                    res_n_inUsuarioId = !string.IsNullOrEmpty(model.res_mor_n_codigo) && !model.res_mor_n_codigo.Equals("0") ? Convert.ToInt32(model.res_n_inUsuarioId) : new int?()
                };

                Insert(reserva);
                context.SaveChanges();

                idRes = codeRes == 0 ? reserva.res_n_codigo : codeRes;

            }
            else
            {
                var res = context.tb_res_registroSalao.Where(x => x.res_n_codigo == codeRes)?.FirstOrDefault();

                if (res == null)
                    throw new MensagemException("Reserva não foi encontrada.");

                codeDpn = res?.res_dpn_n_codigo;
                codeMor = res?.res_mor_n_codigo;
                res.res_c_status = model?.res_c_status;
                res.res_c_observacao = model?.res_c_observacao;
                res.res_d_atualizado = DateTime.Now;
                status = res?.res_c_status;
                res.res_n_inUsuarioId = !string.IsNullOrEmpty(model.res_mor_n_codigo) && !model.res_mor_n_codigo.Equals("0") ? Convert.ToInt32(model.res_n_inUsuarioId) : new int?();
                Update(res);
                context.SaveChanges();

                idRes = codeRes == 0 ? res.res_n_codigo : codeRes;
            }

            //Envio de Email
            EnviarEmail(status, codeMor, idRes);

            //Envio Notificação App
            EnviarNotificaçãoApp(status, codeMor, codeDpn);
        }

        public RegistroSalaoViewModel GetReserva(int id)
        {
            return (from r in Context.tb_res_registroSalao
                    join d in Context.tb_dpn_dependencias on r.res_dpn_n_codigo equals d.dpn_n_codigo
                    join m in Context.tb_mor_Morador on r.res_mor_n_codigo equals m.mor_n_codigo
                    join c in Context.tb_cli_cliente on d.dpn_cli_n_codigo equals c.cli_n_codigo

                    where r.res_n_codigo == id

                    select new RegistroSalaoViewModel
                    {
                        res_n_codigo = r.res_n_codigo.ToString(),
                        res_dpn_n_codigo = r.res_dpn_n_codigo.ToString(),
                        res_d_dataSolicitacao = r.res_d_dataSolicitacao == null ? string.Empty : r.res_d_dataSolicitacao.Value.ToString("yyyy-MM-dd"),
                        res_c_periodo = r.res_c_periodo,
                        res_c_status = r.res_c_status,
                        res_c_observacao = r.res_c_observacao,
                        nomeMorador = m.mor_c_nome,
                        nomeCliente = c.cli_c_nomeFantasia,
                        nomeDependencia = d.dpn_c_nome,
                    }).FirstOrDefault();
        }

        public List<RegistroSalaoViewModel> GetReservas(int id)
        {
            return (from r in Context.tb_res_registroSalao
                    where r.res_dpn_n_codigo == id
                    orderby r.res_d_dataSolicitacao
                    select new RegistroSalaoViewModel()
                    {
                        res_d_dataSolicitacao = r.res_d_dataSolicitacao == null ? string.Empty : r.res_d_dataSolicitacao.Value.ToString("yyyy-MM-dd"),
                        res_c_periodo = r.res_c_periodo

                    }).ToList();
        }

        public IPagedList<RegistroSalaoViewModel> GetFiltrado(RegistroSalaoFilterModel filter, string ids)
        {
            if (string.IsNullOrEmpty(filter.codigo_cliente_filter))
            {
                return new PagedList<RegistroSalaoViewModel>(null, 1, 1);
            }

            try
            {
                List<RegistroSalaoViewModel> temp = new List<RegistroSalaoViewModel>();
                List<RegistroSalaoViewModel> lstRegistros = new List<RegistroSalaoViewModel>();
                var query = (from r in Context.tb_res_registroSalao
                             join d in Context.tb_dpn_dependencias on r.res_dpn_n_codigo equals d.dpn_n_codigo
                             join m in Context.tb_mor_Morador on r.res_mor_n_codigo equals m.mor_n_codigo
                             join c in Context.tb_cli_cliente on d.dpn_cli_n_codigo equals c.cli_n_codigo
                             where c.cli_b_ativo == true
                             orderby r.res_c_status, m.mor_c_nome
                             select new RegistroSalaoViewModel
                             {
                                 res_n_codigo = r.res_n_codigo.ToString(),
                                 res_dpn_n_codigo = r.res_dpn_n_codigo.ToString(),
                                 data_solicitacao = r.res_d_dataSolicitacao,
                                 res_d_dataSolicitacao = r.res_d_dataSolicitacao == null ? string.Empty : r.res_d_dataSolicitacao.Value.ToString("dd/MM/yyyy"),
                                 res_c_periodo = r.res_c_periodo,
                                 res_c_status = r.res_c_status,
                                 aprovar = r.res_c_status == "AA" ? "true" : "false",
                                 reprovar = r.res_c_status == "AA" ? "true" : "false",
                                 excluir = r.res_c_status == "RP" || r.res_c_status == "AA" ? "true" : "false",
                                 editar = (r.res_c_status == "AP" || r.res_c_status == "CN") && r.res_d_dataSolicitacao > DateTime.Now ? "true" : "false",
                                 cancelar = r.res_c_status == "AP" ? "true" : "false",
                                 codigo_cliente = d.dpn_cli_n_codigo.ToString(),
                                 nomeMorador = m.mor_c_nome,
                                 nomeCliente = c.cli_c_nomeFantasia,
                                 nomeDependencia = d.dpn_c_nome,
                                 cli_tcl_n_codigo = Convert.ToInt32(c.cli_tcl_n_codigo)
                             });

                int codCli = Convert.ToInt32(filter.codigo_cliente_filter);
                int codDpn = Convert.ToInt32(filter.res_dpn_n_codigo_filter);

                DateTime data_solicitacao_filter = Convert.ToDateTime(filter.res_d_dataSolicitacao_filter);

                if (codDpn > 0)
                {
                    query = query.Where(w => w.res_dpn_n_codigo.Equals(codDpn.ToString()));
                }

                if (codCli > 0)
                {
                    query = query.Where(w => w.codigo_cliente.Equals(codCli.ToString()));
                }

                if (filter.res_c_status_filter != null)
                {
                    query = query.Where(w => w.res_c_status.Contains(filter.res_c_status_filter));
                }

                if (filter.res_c_status_filter != null)
                {
                    query = query.Where(w => w.res_c_status.Contains(filter.res_c_status_filter));
                }

                if (filter.nomeMorador_filter != null)
                {
                    query = query.Where(w => w.nomeMorador.Contains(filter.nomeMorador_filter));
                }

                if (filter.nomeDependencia_filter != null)
                {
                    query = query.Where(w => w.nomeDependencia.Contains(filter.nomeDependencia_filter));
                }


                if (filter.res_c_periodo_filter != null)
                {
                    query = query.Where(w => w.res_c_periodo.Contains(filter.res_c_periodo_filter));
                }

                if (filter.res_d_dataSolicitacao_filter != null)
                {
                    query = query.Where(w => w.data_solicitacao == data_solicitacao_filter);
                }

                if(filter.buscaSimples_filter != "")
                {
                    query = query.Where(w => w.nomeMorador.Contains(filter.buscaSimples_filter));
                }

                foreach (var registro in query)
                {
                    switch (registro.res_c_status)
                    {
                        case "AA":
                            registro.statusDescricao = "Pendente";
                            break;
                        case "AP":
                            registro.statusDescricao = "Aprovado";
                            break;
                        case "CN":
                            registro.statusDescricao = "Cancelado";
                            break;
                        case "RP":
                            registro.statusDescricao = "Reprovado";
                            break;
                        default:
                            break;
                    }

                    lstRegistros.Add(registro);
                }

                if (ids != "" && ids != "todos")
                {
                    foreach (var id in ids.Split(','))
                    {
                        foreach (var item in lstRegistros)
                        {
                            if (item.codigo_cliente == id)
                            {
                                temp.Add(item);

                            }

                        }
                    }
                    temp.OrderBy(x => x.statusDescricao == "AA").ThenBy(x=> x.nomeCliente);
                    lstRegistros = temp;

                }


                return lstRegistros.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<RegistroSalaoViewModel> GetByData(RegistroSalaoFilterModel filter)
        {
            try
            {
                var query = (from r in Context.tb_res_registroSalao
                             orderby r.res_d_dataSolicitacao
                             select new RegistroSalaoViewModel
                             {
                                 res_n_codigo = r.res_n_codigo.ToString(),
                                 res_dpn_n_codigo = r.res_dpn_n_codigo.ToString(),
                                 res_d_dataSolicitacao = r.res_d_dataSolicitacao == null ? string.Empty : r.res_d_dataSolicitacao.Value.ToString("yyyy-MM-dd"),
                                 res_c_periodo = r.res_c_periodo
                             });

                int codDpn = Convert.ToInt32(filter.res_dpn_n_codigo_filter);
                if (codDpn > 0)
                {
                    query = query.Where(w => w.res_dpn_n_codigo.Equals(codDpn.ToString()));
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Deletar(int id)
        {
            try
            {
                Delete(context.tb_res_registroSalao.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Aprovar(int id)
        {
            try
            {
                var res = (from reserva in context.tb_res_registroSalao where reserva.res_n_codigo == id select reserva).FirstOrDefault();
                res.res_c_status = "AP";
                res.res_d_atualizado = DateTime.Now;

                Update(res);
                context.SaveChanges();

                //Envio de Email
                EnviarEmail(res.res_c_status, res.res_mor_n_codigo, res.res_n_codigo);
                //Envio Notificação App
                EnviarNotificaçãoApp(res.res_c_status, res.res_mor_n_codigo, res.res_dpn_n_codigo);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void EnviarEmail(string status, int? codMor, int? codRes)
        {
            string assunto = "";
            if (status != "")
            {
                if (status == "AA")
                {
                    assunto = "Reserva de salão | Aguardando Aprovação";

                }
                else if (status == "RP")
                {
                    assunto = "Reserva de salão | Reprovado";
                }
                else if (status == "AP")
                {
                    assunto = "Reserva de salão | Aprovado";
                }
            }

            tb_mor_Morador morador = (from mor in context.tb_mor_Morador where mor.mor_n_codigo == codMor select mor).FirstOrDefault();

            var res = (from resLocacao in context.tb_rel_responsavelLocacaoSaloes
                       where resLocacao.rel_c_permissao == "ADM" && resLocacao.rel_cli_n_codigo == morador.mor_cli_n_codigo
                       select resLocacao.rel_c_email).ToList();


            //Envio de Email
            EmailViewModel modelEma = new EmailViewModel();
            modelEma.ema_b_enviado = false;
            modelEma.ema_c_assunto = assunto;
            modelEma.ema_c_corpo = MontaEmailSituacaoReservaSalao(codMor, codRes); //objEnvio.LiberacaoClienteAtivo(emp.emp_c_nomeFantasia, obj.cli_c_nomeFantasia, obj.cli_c_cnpj, DateTime.Now);
            modelEma.ema_c_destinatario = (from m in context.tb_mor_Morador where m.mor_n_codigo == codMor select m).FirstOrDefault().mor_c_email;
            modelEma.ema_c_copiaOculta = "";
            modelEma.ema_d_data = DateTime.Now;
            modelEma.ema_b_enviado = false;
            modelEma.ema_d_modificacao = DateTime.Now;
            Email.InsertOrUpdate(modelEma);


            if (res.Any())
            {
                EmailViewModel modelEmail = new EmailViewModel();
                modelEmail.ema_b_enviado = false;
                modelEmail.ema_c_assunto = assunto;
                modelEmail.ema_c_corpo = MontaEmailResponsavelLocacao(codMor, codRes);

                modelEmail.ema_c_destinatario = per == true ? "" : res[0].ToString() + ",";

                for (var i = 1; i < res.Count; i++)
                {
                    modelEmail.ema_c_destinatario = modelEmail.ema_c_destinatario + res[i].ToString() + ",";
                }

                modelEmail.ema_c_destinatario = modelEmail.ema_c_destinatario.Remove(modelEmail.ema_c_destinatario.Length - 1, 1);
                modelEmail.ema_c_copiaOculta = "";
                modelEmail.ema_d_data = DateTime.Now;
                modelEmail.ema_b_enviado = false;
                modelEmail.ema_d_modificacao = DateTime.Now;
                per = false;
                Email.InsertOrUpdate(modelEmail);
            }
        }

        public void EnviarNotificaçãoApp(string status, int? codMor, int? codDpn)
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
            var dependecia = (from d in context.tb_dpn_dependencias
                              where d.dpn_n_codigo == codDpn
                              select d).FirstOrDefault();

            string mensagem = "";

            if (status != "")
            {
                if (status == "AA")
                {
                    mensagem = "Reserva de salão | Aguardando Aprovação";

                }
                else if (status == "RP")
                {
                    mensagem = "Reserva de salão | Reprovado";
                }
                else if (status == "AP")
                {
                    mensagem = "Reserva de salão | Aprovado";
                }
                else if (status == "CN")
                {
                    mensagem = "Sua solicitação da reserva para " + dependecia.dpn_c_nome + " foi cancelada.";
                }
            }
            /*
                ENVIO DE NOTIFICAÇÃO PARA MORADORES QUE POSSUEM APPS MORADOR AUTÔNOMO
             */
            if (morador != null && (!modulo.mol_b_connectGaren))
            {
                if (morador.mor_c_autorizacao != null)
                {
                    notApp.not_mor_n_codigo = morador.mor_n_codigo.ToString();
                    notApp.not_grf_n_codigo = morador.mor_grf_n_codigo.ToString();
                    notApp.not_b_enviar_app_pro = "false";
                    notApp.not_b_excluido = "false";
                    notApp.not_b_pendente = "true";
                    notApp.not_c_mensagem = mensagem;
                    notApp.not_c_origem = "PORTAL";
                    Notificacao.SalvarNotificacaoApp(notApp);
                }
            }
            else if (morador != null && (modulo.mol_b_connectGaren)) {
                    notApp.not_mor_n_codigo = morador.mor_n_codigo.ToString();
                    notApp.not_grf_n_codigo = morador.mor_grf_n_codigo.ToString();
                    notApp.not_b_enviar_app_pro = "true";
                    notApp.not_b_excluido = "false";
                    notApp.not_b_pendente = "true";
                    notApp.not_c_mensagem = mensagem;
                    notApp.not_c_origem = "PORTAL";
                    Notificacao.SalvarNotificacaoApp(notApp);
            }
        }

        public string MontaEmailSituacaoReservaSalao(int? codMor, int? codRes)
        {
            try
            {
                var morador = (from m in context.tb_mor_Morador where m.mor_n_codigo == codMor select m).FirstOrDefault().mor_c_nome;
                var registroSalao = (from reserva in context.tb_res_registroSalao where reserva.res_n_codigo == codRes select reserva).FirstOrDefault();
                var dependecia = (from d in context.tb_dpn_dependencias
                                  where d.dpn_n_codigo == registroSalao.res_dpn_n_codigo
                                  select d).FirstOrDefault();

                //string path = Directory.GetCurrentDirectory() + "\\Iconnect.Aplicacao\\Template\\EmailClienteReserva.html";
                string path = Directory.GetCurrentDirectory() + "\\Template\\EmailClienteReserva.html";
                var caminhoArquivoAnterior = path.Replace("\\iconnect-portal", "");
                FileStream fileStream = new FileStream(caminhoArquivoAnterior, FileMode.Open);

                StreamReader reader = new StreamReader(fileStream);
                StringBuilder CorpoEmail = new StringBuilder(reader.ReadToEnd().Trim());

                if (registroSalao.res_c_status == "RP")
                {
                    CorpoEmail = CorpoEmail
                    .Replace("{mensagem}", @"Olá, " + morador + ", sua reserva para " + dependecia.dpn_c_nome
                    + ", em " + registroSalao.res_d_dataSolicitacao.Value.ToString("dd/MM/yyyy") + "-" + registroSalao.res_c_periodo + " foi reprovado. <BR><BR>motivo: " + registroSalao.res_c_observacao + " <BR><BR>");
                }
                else if (registroSalao.res_c_status == "AP")
                {
                    CorpoEmail = CorpoEmail
                    .Replace("{mensagem}", @"Olá, " + morador + ", sua reserva para " + dependecia.dpn_c_nome
                    + ", em " + registroSalao.res_d_dataSolicitacao.Value.ToString("dd/MM/yyyy") + "-" + registroSalao.res_c_periodo + " foi aprovado.");
                }
                else if (registroSalao.res_c_status == "AA")
                {
                    CorpoEmail = CorpoEmail
                    .Replace("{mensagem}", @"Olá, " + morador + ", sua reserva para " + dependecia.dpn_c_nome
                    + ", em " + registroSalao.res_d_dataSolicitacao.Value.ToString("dd/MM/yyyy") + "-" + registroSalao.res_c_periodo + " está aguardando aprovação.");
                }
                fileStream.Close();
                return CorpoEmail.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string MontaEmailResponsavelLocacao(int? codMor, int? codRes)
        {
            try
            {
                var morCli = (from mor in context.tb_mor_Morador
                              join cli in context.tb_cli_cliente on mor.mor_cli_n_codigo equals cli.cli_n_codigo
                              where mor.mor_n_codigo == codMor
                              select cli.cli_tcl_n_codigo).FirstOrDefault();

                string morFun = "";

                if (morCli == 2 || morCli == 3)
                {
                    morFun = "funcionário(a)";
                }
                else
                {
                    morFun = "morador(a)";
                }

                var res = (from resLocacao in context.tb_rel_responsavelLocacaoSaloes
                           where resLocacao.rel_c_permissao == "ADM" && resLocacao.rel_cli_n_codigo == codMor
                           select resLocacao);

                var morador = (from m in context.tb_mor_Morador where m.mor_n_codigo == codMor select m).FirstOrDefault().mor_c_nome;
                var registroSalao = (from reserva in context.tb_res_registroSalao where reserva.res_n_codigo == codRes select reserva).FirstOrDefault();
                var dependecia = (from d in context.tb_dpn_dependencias
                                  where d.dpn_n_codigo == registroSalao.res_dpn_n_codigo
                                  select d).FirstOrDefault();

                //string path = Directory.GetCurrentDirectory() + "\\Iconnect.Aplicacao\\Template\\EmailClienteReserva.html";
                string path = Directory.GetCurrentDirectory() + "\\Template\\EmailClienteReserva.html";
                var caminhoArquivoAnterior = path.Replace("\\iconnect-portal", "");
                FileStream fileStream = new FileStream(caminhoArquivoAnterior, FileMode.Open);

                StreamReader reader = new StreamReader(fileStream);
                StringBuilder CorpoEmail = new StringBuilder(reader.ReadToEnd().Trim());

                if (registroSalao.res_c_status == "RP")
                {
                    CorpoEmail = CorpoEmail
                    .Replace("{mensagem}", @$"Olá, a reserva para o(a) {morFun} {morador}, para " + dependecia.dpn_c_nome
                    + ", em " + registroSalao.res_d_dataSolicitacao.Value.ToString("dd/MM/yyyy") + "-" + registroSalao.res_c_periodo + " foi reprovado. <BR><BR>motivo: " + registroSalao.res_c_observacao + " <BR><BR>");
                }
                else if (registroSalao.res_c_status == "AP")
                {
                    CorpoEmail = CorpoEmail
                    .Replace("{mensagem}", @$"Olá, a reserva para o(a) {morFun} {morador}, para " + dependecia.dpn_c_nome
                    + ", em " + registroSalao.res_d_dataSolicitacao.Value.ToString("dd/MM/yyyy") + "-" + registroSalao.res_c_periodo + " foi aprovado.");
                }
                else if (registroSalao.res_c_status == "AA")
                {
                    CorpoEmail = CorpoEmail
                    .Replace("{mensagem}", @$"Olá, a reserva para o(a) {morFun} {morador}, para " + dependecia.dpn_c_nome
                    + ", em " + registroSalao.res_d_dataSolicitacao.Value.ToString("dd/MM/yyyy") + "-" + registroSalao.res_c_periodo + " está aguardando aprovação.");
                }
                fileStream.Close();
                return CorpoEmail.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

