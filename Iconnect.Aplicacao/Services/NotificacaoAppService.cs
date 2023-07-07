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

namespace Iconnect.Aplicacao.Services
{
    class NotificacaoAppService : RepositoryBase<tb_not_notificacaoApp>, INotificacaoAppService
    {
        private IconnectCoreContext context;

        public NotificacaoAppService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }
        
        public bool SalvarNotificacaoApp(NotificacaoAppViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.not_n_codigo) || model.not_n_codigo == "0")
                {
                    Insert(new tb_not_notificacaoApp()
                    {
                        not_zec_n_codigo = ConvertToInt(model.not_zec_n_codigo),
                        not_b_pendente = Convert.ToBoolean(model.not_b_pendente),
                        not_d_data = DateTime.Now,
                        not_c_mensagem = model.not_c_mensagem,
                        not_b_excluido = Convert.ToBoolean(model.not_b_excluido),
                        not_c_cor = model.not_c_cor,
                        not_c_retornoPush = model.not_c_retornoPush,
                        not_mor_n_codigo = ConvertToInt(model.not_mor_n_codigo),
                        not_c_origem = model.not_c_origem,
                        not_d_modificacao = DateTime.Now,
                        not_eno_n_codigo = ConvertToInt(model.not_eno_n_codigo),
                        not_c_unique = Guid.NewGuid(),
                        not_d_atualizado = DateTime.Now,
                        not_d_inclusao = DateTime.Now,
                        not_grf_n_codigo = ConvertToInt(model.not_grf_n_codigo),
                        not_b_enviar_app_pro = Convert.ToBoolean(model.not_b_enviar_app_pro),
                    });
                }
                else
                {
                    var notificacao = (from not in context.tb_not_notificacaoApp where not.not_n_codigo == Convert.ToInt32(model.not_n_codigo) select not).FirstOrDefault();
                    notificacao.not_n_codigo = Convert.ToInt32(model.not_n_codigo);
                    notificacao.not_zec_n_codigo = ConvertToInt(model.not_zec_n_codigo);
                    notificacao.not_b_pendente = Convert.ToBoolean(model.not_b_pendente);
                    notificacao.not_d_data = Convert.ToDateTime(model.not_d_data);
                    notificacao.not_c_mensagem = model.not_c_mensagem;
                    notificacao.not_b_excluido = Convert.ToBoolean(model.not_b_excluido);
                    notificacao.not_c_cor = model.not_c_cor;
                    notificacao.not_c_retornoPush = model.not_c_retornoPush;
                    notificacao.not_mor_n_codigo = ConvertToInt(model.not_mor_n_codigo);
                    notificacao.not_c_origem = model.not_c_origem;
                    notificacao.not_d_modificacao = Convert.ToDateTime(model.not_d_modificacao);
                    notificacao.not_eno_n_codigo = ConvertToInt(model.not_eno_n_codigo);
                    notificacao.not_d_atualizado = DateTime.Now;
                    notificacao.not_grf_n_codigo = ConvertToInt(model.not_grf_n_codigo);
                    notificacao.not_b_enviar_app_pro = Convert.ToBoolean(model.not_b_enviar_app_pro);

                    Update(notificacao);
                }

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private int? ConvertToInt(string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                return Convert.ToInt32(valor);
            }

            return null;
        }
    }
}