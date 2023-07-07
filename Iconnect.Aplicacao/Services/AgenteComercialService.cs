using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PagedList;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Infraestrutura.Exceptions;
using OfficeOpenXml;

namespace Iconnect.Aplicacao.Services
{
    public class AgenteComercialService : RepositoryBase<tb_age_agenteComercial>, IAgenteComercialService
    {

        private readonly IconnectCoreContext context;

        public AgenteComercialService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private IAcessoService _acesso;
        public IAcessoService Acesso
        {
            get
            {
                if (_acesso == null)
                {
                    _acesso = new AcessoService(context);
                }
                return _acesso;
            }
        }

        public int InsertOrUpdate(AgenteComercialViewModel model)
        {
            ValidaDuplicado(model);

            tb_age_agenteComercial agente;

            if (String.IsNullOrEmpty(model.age_n_codigo))
            {
                agente = new tb_age_agenteComercial()
                {
                    age_n_codigo = Convert.ToInt32(model.age_n_codigo),
                    age_c_nome = model.age_c_nome,
                    age_c_rg = model.age_c_rg,
                    age_c_email = model.age_c_email,
                    age_c_celular = model.age_c_celular,
                    age_ace_n_codigo = Convert.ToInt32(model.age_ace_n_codigo),
                };

                Insert(agente);
                context.SaveChanges();
            }
            else
            {
                agente = (from a in context.tb_age_agenteComercial where a.age_n_codigo == Convert.ToInt32(model.age_n_codigo) select a).FirstOrDefault();
                agente.age_c_nome = model.age_c_nome;
                agente.age_c_rg = model.age_c_rg;
                agente.age_c_email = model.age_c_email;
                agente.age_c_celular = model.age_c_celular;
                agente.age_ace_n_codigo = Convert.ToInt32(model.age_ace_n_codigo);

                Update(agente);
                context.SaveChanges();
            }

            return agente.age_n_codigo;
        }

        public void ValidaDuplicado(AgenteComercialViewModel model)
        {
            if (!string.IsNullOrEmpty(model.age_c_rg))
            {
                var ageCount = (from age in context.tb_age_agenteComercial
                                where age.age_n_codigo != Convert.ToInt32(model.age_n_codigo)
                                && age.age_c_rg == model.age_c_rg
                                select age).Count();

                if (ageCount > 0)
                {
                    throw new MensagemException("O RG digitado já está sendo utilizado. Verifique novamente ou contate o administrador.");
                }
            }

            if (!string.IsNullOrEmpty(model.age_c_email))
            {
                var ageCount = (from age in context.tb_age_agenteComercial
                                where age.age_n_codigo != Convert.ToInt32(model.age_n_codigo)
                                && age.age_c_email == model.age_c_email
                                select age).Count();

                if (ageCount > 0)
                {
                    throw new MensagemException("O Email digitado já está sendo utilizado. Verifique novamente ou contate o administrador.");
                }
            }

        }

        public IPagedList<AgenteComercialViewModel> GetFiltrado(AgenteComercialFilterModel filter)
        {
            var query = (from age in context.tb_age_agenteComercial
                         orderby age.age_c_nome
                         select new AgenteComercialViewModel
                         {
                             age_n_codigo = age.age_n_codigo.ToString(),
                             age_c_nome = age.age_c_nome,
                             age_c_rg = age.age_c_rg,
                             age_c_email = age.age_c_email,
                             age_c_celular = age.age_c_celular,
                             buscaSimples = age.age_c_nome,
                         });

            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(x => x.buscaSimples.Contains(filter.buscaSimples_filter));
            }

            if (!string.IsNullOrEmpty(filter.age_c_nome_filter))
            {
                query = query.Where(x => x.age_c_nome.Contains(filter.age_c_nome_filter));
            }

            if (!string.IsNullOrEmpty(filter.age_c_rg_filter))
            {
                query = query.Where(x => x.age_c_rg.Contains(filter.age_c_rg_filter));
            }

            if (!string.IsNullOrEmpty(filter.age_c_email_filter))
            {
                query = query.Where(x => x.age_c_email.Contains(filter.age_c_email_filter));
            }

            if (!string.IsNullOrEmpty(filter.age_c_celular_filter))
            {
                query = query.Where(x => x.age_c_celular.Contains(filter.age_c_celular_filter));
            }

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public AgenteComercialViewModel GetAgenteComercial(int id)
        {
            var query = (from age in context.tb_age_agenteComercial
                         join ace in context.tb_ace_acesso on age.age_ace_n_codigo equals ace.ace_n_codigo
                         where age.age_n_codigo == id
                         select new AgenteComercialViewModel()
                         {
                             age_n_codigo = age.age_n_codigo.ToString(),
                             age_c_nome = age.age_c_nome,
                             age_c_rg = age.age_c_rg,
                             age_c_email = age.age_c_email,
                             age_c_celular = age.age_c_celular,
                             age_ace_n_codigo = age.age_ace_n_codigo.ToString(),
                             age_ace_login = ace.ace_c_login,

                         }).FirstOrDefault();

            return query;
        }

        public object Deletar(int id)
        {
            Retorno retorno = new Retorno();

            try
            {
                var result = (from age in context.tb_age_agenteComercial where age.age_n_codigo == id select age).FirstOrDefault();
                int codAcesso = Convert.ToInt32(result.age_ace_n_codigo);
                Delete(context.tb_age_agenteComercial.Find(id));
                context.SaveChanges();
                Acesso.DeletarAcesso(codAcesso);

                retorno.status = "Ok";
                retorno.conteudo = "Dados excluidos com sucesso.";
                return retorno;
            }
            catch (Exception e)
            {
                retorno.status = e.ToString();
                retorno.conteudo = "Ocorreu um erro ao excluir os dados.";
                return retorno;
            }
        }

        public byte[] GerarExcel(AgenteComercialFilterModel filter)
        {
            var query = (from age in context.tb_age_agenteComercial
                         select new AgenteComercialViewModel()
                         {
                             age_c_nome = age.age_c_nome,
                             age_c_rg = age.age_c_rg,
                             age_c_email = age.age_c_email,
                             age_c_celular = age.age_c_celular,
                             buscaSimples = age.age_c_nome,
                         });

            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(x => x.buscaSimples.Contains(filter.buscaSimples_filter));
            }

            if (!string.IsNullOrEmpty(filter.age_c_nome_filter))
            {
                query = query.Where(x => x.age_c_nome.Contains(filter.age_c_nome_filter));
            }

            if (!string.IsNullOrEmpty(filter.age_c_rg_filter))
            {
                query = query.Where(x => x.age_c_rg.Contains(filter.age_c_rg_filter));
            }

            if (!string.IsNullOrEmpty(filter.age_c_email_filter))
            {
                query = query.Where(x => x.age_c_email.Contains(filter.age_c_email_filter));
            }

            if (!string.IsNullOrEmpty(filter.age_c_celular_filter))
            {
                query = query.Where(x => x.age_c_celular.Contains(filter.age_c_celular_filter));
            }

            var agentes = query.ToList();
            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Nome",
                    "RG",
                    "E-mail",
                    "Celular",
                };

                var worksheet = package.Workbook.Worksheets.Add("Agente Comercial");
                worksheet.DefaultColWidth = 20;
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
                    foreach (var agente in agentes)
                    {
                        worksheet.Cells["A" + j].Value = agente.age_c_nome;
                        worksheet.Cells["B" + j].Value = agente.age_c_rg;
                        worksheet.Cells["C" + j].Value = agente.age_c_celular;
                        worksheet.Cells["D" + j].Value = agente.age_c_email;

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
    }
}
