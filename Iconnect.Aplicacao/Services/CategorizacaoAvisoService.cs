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
    class CategorizacaoAvisoService : RepositoryBase<tb_cav_categorizacaoAviso>, ICategorizacaoAvisoService
    {
        private IconnectCoreContext context;

        public CategorizacaoAvisoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }
        public bool DeletarAviso(int id)
        {
            try
            {
                Delete(context.tb_cav_categorizacaoAviso.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        public int SalvarAviso(CategorizacaoAvisoViewModel model)
        {
            try
            {
                tb_cav_categorizacaoAviso categorizacaoAviso;

                if (model.cav_n_codigo == 0)
                {
                    Insert(categorizacaoAviso = new tb_cav_categorizacaoAviso()
                    {
                        cav_c_descricao = model.cav_c_descricao,
                        cav_c_unique = Guid.NewGuid(),
                        cav_c_cor = model.cav_c_cor,
                        cav_c_usuario = "ISABELA",
                        cav_d_alteracao = DateTime.Now,
                        cav_d_modificacao = DateTime.Now,
                        cav_d_atualizado = DateTime.Now,
                        cav_d_inclusao = DateTime.Now
                    });
                }
                else
                {
                    categorizacaoAviso = (from cat in context.tb_cav_categorizacaoAviso where cat.cav_n_codigo == model.cav_n_codigo select cat).FirstOrDefault();
                    categorizacaoAviso.cav_c_descricao = model.cav_c_descricao;
                    categorizacaoAviso.cav_c_cor = model.cav_c_cor;
                    categorizacaoAviso.cav_c_usuario = "ISABELA";

                    Update(categorizacaoAviso);
                }
                context.SaveChanges();
                return categorizacaoAviso.cav_n_codigo;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public IPagedList<CategorizacaoAvisoViewModel> GetAvisoFiltrado(CategorizacaoAvisoFilterModel filter)
        {
            var query = (from cat in Context.tb_cav_categorizacaoAviso
                         select new CategorizacaoAvisoViewModel
                         {
                             cav_n_codigo = cat.cav_n_codigo,
                             cav_c_cor = cat.cav_c_cor,
                             cav_c_descricao = cat.cav_c_descricao,
                             cav_c_unique = cat.cav_c_unique,
                             cav_c_usuario = cat.cav_c_usuario,
                             cav_d_alteracao = cat.cav_d_alteracao,
                             cav_d_modificacao = cat.cav_d_modificacao,
                             cav_d_atualizado = cat.cav_d_atualizado,
                             cav_d_inclusao = cat.cav_d_inclusao

                         });

            if (!string.IsNullOrEmpty(filter.Descricao))
            {
                query = query.Where(w => w.cav_c_descricao.Contains(filter.Descricao));
            }

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public CategorizacaoAvisoViewModel GetAviso(int id)
        {

            return (from cat in context.tb_cav_categorizacaoAviso
                    where cat.cav_n_codigo == id
                    select new CategorizacaoAvisoViewModel()
                    {
                        cav_n_codigo = cat.cav_n_codigo,
                        cav_c_cor = cat.cav_c_cor,
                        cav_c_descricao = cat.cav_c_descricao,
                        cav_c_unique = cat.cav_c_unique,
                        cav_c_usuario = cat.cav_c_usuario,
                        cav_d_alteracao = cat.cav_d_alteracao,
                        cav_d_modificacao = cat.cav_d_modificacao,
                        cav_d_atualizado = cat.cav_d_atualizado,
                        cav_d_inclusao = cat.cav_d_inclusao

                    }).FirstOrDefault();

        }

        public List<CategorizacaoAvisoViewModel> GetAll()
        {
            return (from cat in context.tb_cav_categorizacaoAviso
                    select new CategorizacaoAvisoViewModel()
                    {
                        cav_n_codigo = cat.cav_n_codigo,
                        cav_c_cor = cat.cav_c_cor,
                        cav_c_descricao = cat.cav_c_descricao,
                        cav_c_unique = cat.cav_c_unique,
                        cav_c_usuario = cat.cav_c_usuario,
                        cav_d_alteracao = cat.cav_d_alteracao,
                        cav_d_modificacao = cat.cav_d_modificacao,
                        cav_d_atualizado = cat.cav_d_atualizado,
                        cav_d_inclusao = cat.cav_d_inclusao

                    }).OrderBy(x => x.cav_c_descricao).ToList();
        }

        public byte[] GeraExcel(CategorizacaoAvisoFilterModel filter)
        {
            var query = (from cat in Context.tb_cav_categorizacaoAviso
                         select new CategorizacaoAvisoViewModel
                         {
                             cav_n_codigo = cat.cav_n_codigo,
                             cav_c_cor = cat.cav_c_cor,
                             cav_c_descricao = cat.cav_c_descricao,
                             cav_c_unique = cat.cav_c_unique,
                             cav_c_usuario = cat.cav_c_usuario,
                             cav_d_alteracao = cat.cav_d_alteracao,
                             cav_d_modificacao = cat.cav_d_modificacao,
                             cav_d_atualizado = cat.cav_d_atualizado,
                             cav_d_inclusao = cat.cav_d_inclusao

                         });

            if (!string.IsNullOrEmpty(filter.Descricao))
            {
                query = query.Where(w => w.cav_c_descricao.Contains(filter.Descricao));
            }

            var listaCategorias = query.ToList();
            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Código",
                    "Descrição"
                };

                var worksheet = package.Workbook.Worksheets.Add("Categorização de Avisos");
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
                        worksheet.Cells["A" + j].Value = categoria.cav_n_codigo;
                        worksheet.Cells["B" + j].Value = categoria.cav_c_descricao;

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
