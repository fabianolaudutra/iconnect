using System;
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



namespace Iconnect.Aplicacao.Services
{
    class EmailService : RepositoryBase<tb_ema_email>, IEmailService
    {
        private IconnectCoreContext context;

        public EmailService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public object InsertOrUpdate(EmailViewModel model)
        {
            Retorno retorno = new Retorno();
            try
            {
                tb_ema_email email = new tb_ema_email();

                email.ema_d_data = DateTime.Now;
                email.ema_c_assunto = model.ema_c_assunto;
                email.ema_c_corpo = model.ema_c_corpo;
                email.ema_b_enviado = model.ema_b_enviado;
                email.ema_c_remetente = model.ema_c_remetente;
                email.ema_c_destinatario = model.ema_c_destinatario;
                email.ema_c_copia = model.ema_c_copia;
                email.ema_c_copiaOculta = model.ema_c_copiaOculta;
                email.ema_c_caminhoAnexo = model.ema_c_caminhoAnexo;
                email.ema_c_anexo = model.ema_c_anexo;
                email.ema_d_modificacao = DateTime.Now;
                Insert(email);
                context.SaveChanges();

                retorno.status = "ok";
                retorno.conteudo = "true";
                return retorno;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public ParametrosEmpresaViewModel FindParametrosEmpresa(ParametrosEmpresaViewModel parametros)
        {
            string chave = parametros.par_c_chave;
            int empresa = parametros.par_emp_n_codigo.Value;
            return (from par in Context.tb_par_parametrosEmpresa

                    where par.par_c_chave == chave && par.par_emp_n_codigo == empresa
                    select new ParametrosEmpresaViewModel()
                    {
                        par_n_codigo = par.par_n_codigo,

                        par_c_descricao = par.par_c_descricao,
                        par_c_chave = par.par_c_chave,
                        par_c_valor = par.par_c_valor,
                        par_c_titulo = par.par_c_titulo,
                        par_b_interno = par.par_b_interno,
                        par_c_aba = par.par_c_aba,
                        par_emp_n_codigo = par.par_emp_n_codigo,

                    }).FirstOrDefault();
        }
    }
}
