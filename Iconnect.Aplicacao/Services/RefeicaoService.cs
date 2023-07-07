using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections;
using System.Globalization;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    class RefeicaoService : RepositoryBase<tb_ref_refeicao>, IRefeicaoService
    {
        private readonly IconnectCoreContext context;
        public RefeicaoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public IPagedList<RefeicaoViewModel> GetFiltrado(RefeicaoFilterModel filter)
        {
            var query = (from Ref in context.tb_ref_refeicao
                             //orderby Ref.ref_d_inicio ascending
                         orderby Ref.ref_c_nomeRefeicao ascending
                         select new RefeicaoViewModel()
                         {
                             ref_n_codigo = Ref.ref_n_codigo.ToString(),
                             ref_c_nomeRefeicao = Ref.ref_c_nomeRefeicao.ToString(),
                             ref_d_valor = Ref.ref_d_valor.ToString(),
                             ref_d_inicio = Ref.ref_d_inicio.ToString("HH:mm"),
                             ref_d_fim = Ref.ref_d_fim.ToString("HH:mm"),
                             ref_cli_n_codigo = Ref.ref_cli_n_codigo.ToString(),
                         });

            if (!string.IsNullOrEmpty(filter.ref_cli_n_codigo_filter))
            {
                query = query.Where(x => x.ref_cli_n_codigo.Contains(filter.ref_cli_n_codigo_filter));
            }

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public object InsertOrUpdate(RefeicaoViewModel model)
        {
            Retorno retorno = new Retorno();

            try
            {
                tb_ref_refeicao refeicao;

                var inicio = Convert.ToDateTime(model.ref_d_inicio);
                var fim = Convert.ToDateTime(model.ref_d_fim);
                var culture = CultureInfo.CreateSpecificCulture("en-GB");
                decimal valorFormatado;

                if (string.IsNullOrEmpty(model.ref_n_codigo) || model.ref_n_codigo == "0")
                {
                    var refeicoes = (from Ref in context.tb_ref_refeicao
                                     where Ref.ref_cli_n_codigo == Convert.ToInt32(model.ref_cli_n_codigo)
                                     select Ref).ToList();

                    foreach (var refe in refeicoes)
                    {
                        if (refe.ref_d_inicio == inicio
                           && refe.ref_d_fim == fim)
                        {
                            retorno.id = 0;
                            retorno.status = "horário duplicado";
                            retorno.conteudo = "false";
                            return retorno;
                        }
                    }

                    if (Decimal.TryParse(model.ref_d_valor, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, culture, out valorFormatado)) ;

                    refeicao = new tb_ref_refeicao()
                    {
                        ref_cli_n_codigo = Convert.ToInt32(model.ref_cli_n_codigo),
                        ref_c_nomeRefeicao = model.ref_c_nomeRefeicao.ToUpper(),
                        ref_d_valor = valorFormatado,
                        ref_d_inicio = inicio,
                        ref_d_fim = fim,
                    };

                    Insert(refeicao);
                    context.SaveChanges();
                }
                else
                {
                    var refeicoes = (from Ref in context.tb_ref_refeicao
                                     where Ref.ref_cli_n_codigo == Convert.ToInt32(model.ref_cli_n_codigo)
                                     && Ref.ref_n_codigo != Convert.ToInt32(model.ref_n_codigo)
                                     select Ref).ToList();

                    foreach (var refe in refeicoes)
                    {
                        if (refe.ref_d_inicio == inicio
                           && refe.ref_d_fim == fim)
                        {
                            retorno.id = 0;
                            retorno.status = "horário duplicado";
                            retorno.conteudo = "false";
                            return retorno;
                        }
                    }

                    if (Decimal.TryParse(model.ref_d_valor, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, culture, out valorFormatado)) ;

                    refeicao = (from Ref in context.tb_ref_refeicao where Ref.ref_n_codigo == Convert.ToInt32(model.ref_n_codigo) select Ref).FirstOrDefault();
                    refeicao.ref_c_nomeRefeicao = model.ref_c_nomeRefeicao.ToUpper();
                    refeicao.ref_d_valor = valorFormatado;
                    refeicao.ref_d_inicio = inicio;
                    refeicao.ref_d_fim = fim;

                    Update(refeicao);
                    context.SaveChanges();
                }

                retorno.id = 0;
                retorno.status = "ok";
                retorno.conteudo = "true";
                return retorno;
            }
            catch (Exception e)
            {
                retorno.id = 0;
                retorno.status = e.ToString();
                retorno.conteudo = "false";
                return retorno;
            }
        }

        public bool DeletarRefeicao(int id)
        {
            try
            {
                Delete(context.tb_ref_refeicao.Find(id));

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
