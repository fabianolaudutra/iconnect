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
    public class CategorizacaoEventoService : RepositoryBase<tb_cev_categorizacaoEvento>, ICategorizacaoEventoService
    {
        private readonly IconnectCoreContext context;

        public CategorizacaoEventoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool DeletarCategorizacaoEvento(int id)
        {
            try
            {
                Delete(context.tb_cev_categorizacaoEvento.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public int SalvarCategorizacaoEvento(CategorizacaoEventoViewModel model)
        {
            try
            {
                tb_cev_categorizacaoEvento categorizacaoEvento;
                if (string.IsNullOrEmpty(model.cev_n_codigo) && (model?.cev_n_codigo?.Equals("0") ?? true))
                {
                    Insert(categorizacaoEvento = new tb_cev_categorizacaoEvento()
                    {
                        cev_c_descricao = model.cev_c_descricao,
                        cev_c_unique = Guid.NewGuid(),
                        cev_c_codigoEvento = model.cev_c_codigoEvento,
                        cev_c_cor = model.cev_c_cor,
                        cev_c_usuario = "ISABELA",
                        cev_b_geraAtendimento = model.cev_b_geraAtendimento,
                        cev_d_alteracao = DateTime.Now,
                        cev_d_atualizado = DateTime.Now,
                        cev_d_inclusao = DateTime.Now,
                        cev_d_modificacao = DateTime.Now
                    });
                }
                else
                {
                    int idCev = Convert.ToInt32(model.cev_n_codigo);
                    categorizacaoEvento = (from cat in context.tb_cev_categorizacaoEvento where cat.cev_n_codigo == idCev select cat).FirstOrDefault();
                    categorizacaoEvento.cev_c_descricao = model.cev_c_descricao;
                    categorizacaoEvento.cev_c_cor = model.cev_c_cor;
                    categorizacaoEvento.cev_b_geraAtendimento = Convert.ToBoolean(model.cev_b_geraAtendimento);
                    categorizacaoEvento.cev_c_codigoEvento = model.cev_c_codigoEvento;
                    Update(categorizacaoEvento);
                }
                context.SaveChanges();
                return categorizacaoEvento.cev_n_codigo;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IPagedList<CategorizacaoEventoViewModel> GetCategoFiltrado(CategorizacaoEventoFilterModel filter)
        {
            var query = (from cat in Context.tb_cev_categorizacaoEvento
                         select new CategorizacaoEventoViewModel
                         {
                             cev_n_codigo = cat.cev_n_codigo.ToString(),
                             cev_c_descricao = cat.cev_c_descricao,
                             cev_c_unique = cat.cev_c_unique,
                             cev_c_codigoEvento = cat.cev_c_codigoEvento,
                             cev_c_cor = cat.cev_c_cor,
                             cev_c_usuario = cat.cev_c_usuario,
                             cev_b_geraAtendimento = cat.cev_b_geraAtendimento,
                             cev_d_alteracao = cat.cev_d_alteracao,
                             cev_d_atualizado = cat.cev_d_atualizado,
                             cev_d_inclusao = cat.cev_d_inclusao,
                             cev_d_modificacao = cat.cev_d_modificacao,
                             buscaSimples = cat.cev_c_descricao
                         });

            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));

            }

            if (!string.IsNullOrEmpty(filter.Codigo))
            {
                query = query.Where(w => w.cev_c_codigoEvento.Contains(filter.Codigo));
            }
            if (!string.IsNullOrEmpty(filter.Descricao))
            {
                query = query.Where(w => w.cev_c_descricao.Contains(filter.Descricao));
            }

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public CategorizacaoEventoViewModel GetCategorizacaoEvento(int id)
        {

            return (from cat in context.tb_cev_categorizacaoEvento
                    where cat.cev_n_codigo == id
                    select new CategorizacaoEventoViewModel()
                    {
                        cev_n_codigo = cat.cev_n_codigo.ToString(),
                        cev_c_descricao = cat.cev_c_descricao,
                        cev_c_unique = cat.cev_c_unique,
                        cev_c_codigoEvento = cat.cev_c_codigoEvento,
                        cev_c_cor = cat.cev_c_cor,
                        cev_c_usuario = cat.cev_c_usuario,
                        cev_b_geraAtendimento = cat.cev_b_geraAtendimento,
                        cev_d_alteracao = cat.cev_d_alteracao,
                        cev_d_atualizado = cat.cev_d_atualizado,
                        cev_d_inclusao = cat.cev_d_inclusao,
                        cev_d_modificacao = cat.cev_d_modificacao

                    }).FirstOrDefault();

        }

        public List<CategorizacaoEventoViewModel> GetAll()
        {
            return (from cat in context.tb_cev_categorizacaoEvento
                    where cat.cev_c_descricao != ""
                    select new CategorizacaoEventoViewModel()
                    {
                        cev_n_codigo = cat.cev_n_codigo.ToString(),
                        cev_c_descricao = cat.cev_c_descricao.TrimStart(),
                        cev_c_cor = cat.cev_c_cor,
                        cev_c_unique = cat.cev_c_unique,
                        cev_c_usuario = cat.cev_c_usuario,
                        cev_d_alteracao = cat.cev_d_alteracao,
                        cev_d_modificacao = cat.cev_d_modificacao,
                        cev_d_atualizado = cat.cev_d_atualizado,
                        cev_d_inclusao = cat.cev_d_inclusao

                    }).OrderBy(x => x.cev_c_descricao).ToList();
        }

        public byte[] GeraExcel(CategorizacaoEventoFilterModel filter)
        {
            var query = (from cat in Context.tb_cev_categorizacaoEvento
                         select new CategorizacaoEventoViewModel
                         {
                             cev_n_codigo = cat.cev_n_codigo.ToString(),
                             cev_c_descricao = cat.cev_c_descricao,
                             cev_c_unique = cat.cev_c_unique,
                             cev_c_codigoEvento = cat.cev_c_codigoEvento,
                             cev_c_cor = cat.cev_c_cor,
                             cev_c_usuario = cat.cev_c_usuario,
                             cev_b_geraAtendimento = cat.cev_b_geraAtendimento,
                             cev_d_alteracao = cat.cev_d_alteracao,
                             cev_d_atualizado = cat.cev_d_atualizado,
                             cev_d_inclusao = cat.cev_d_inclusao,
                             cev_d_modificacao = cat.cev_d_modificacao,
                             buscaSimples = cat.cev_c_descricao
                         });

            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));

            }

            if (!string.IsNullOrEmpty(filter.Codigo))
            {
                query = query.Where(w => w.cev_c_codigoEvento.Contains(filter.Codigo));
            }
            if (!string.IsNullOrEmpty(filter.Descricao))
            {
                query = query.Where(w => w.cev_c_descricao.Contains(filter.Descricao));
            }

            var listaCategorias = query.ToList();
            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Código",
                    "Código Evento",
                    "Descrição"
                };

                var worksheet = package.Workbook.Worksheets.Add("Categorização de Eventos");
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
                    foreach (var categoria in listaCategorias)
                    {
                        worksheet.Cells["A" + j].Value = categoria.cev_n_codigo;
                        worksheet.Cells["B" + j].Value = categoria.cev_c_codigoEvento;
                        worksheet.Cells["C" + j].Value = categoria.cev_c_descricao;

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
