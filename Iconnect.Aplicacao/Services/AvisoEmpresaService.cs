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
    class AvisoEmpresaService : RepositoryBase<tb_avi_avisoEmpresa>, IAvisoEmpresaService
    {
        private IconnectCoreContext context;

        public AvisoEmpresaService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public IPagedList<AvisoEmpresaViewModel> GetAvisoEmpresaFiltrado(AvisoEmpresaFilterModel filter)
        {
            var query = ObterQueryEmpresa(filter);
            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public AvisoEmpresaViewModel GetAvisoEmpresa(int id)
        {
            var avisoEmpresa = (from avi in context.tb_avi_avisoEmpresa
                                where avi.avi_n_codigo == id
                                select new AvisoEmpresaViewModel()
                                {
                                    avi_n_codigo = avi.avi_n_codigo.ToString(),
                                    avi_c_titulo = avi.avi_c_titulo,
                                    avi_c_descricao = avi.avi_c_descricao,
                                    avi_d_inicio = avi.avi_d_inicio.Value == null ? string.Empty : avi.avi_d_inicio.Value.ToString("yyyy-MM-dd"),
                                    avi_d_fim = avi.avi_d_fim.Value == null ? string.Empty : avi.avi_d_fim.Value.ToString("yyyy-MM-dd"),
                                    avi_emp_c_enviarPara = avi.avi_emp_c_enviarPara,
                                    avi_c_status = avi.avi_c_status,
                                    avi_d_alteracao = avi.avi_d_alteracao.ToString(),
                                    avi_c_usuario = avi.avi_c_usuario,
                                    avi_d_modificacao = avi.avi_d_modificacao.ToString(),
                                    avi_c_unique = avi.avi_c_unique.ToString(),
                                    avi_d_atualizado = avi.avi_d_atualizado.ToString(),
                                    avi_d_inclusao = avi.avi_d_inclusao.ToString()
                                }).FirstOrDefault();

            avisoEmpresa.EmpresasSelecionadas = avisoEmpresa.avi_emp_c_enviarPara.Split(',');

            return avisoEmpresa;
        }

        public int SalvarAvisoEmpresa(AvisoEmpresaViewModel model)
        {
            try
            {
                tb_avi_avisoEmpresa avisoEmpresa;
                if (string.IsNullOrEmpty(model.avi_n_codigo) || model.avi_n_codigo.ToString() == "0")
                {
                    Insert(avisoEmpresa = new tb_avi_avisoEmpresa()
                    {
                        avi_c_titulo = model.avi_c_titulo,
                        avi_c_descricao = model.avi_c_descricao,
                        avi_d_inicio = Convert.ToDateTime(model.avi_d_inicio),
                        //avi_d_fim = Convert.ToDateTime(model.avi_d_fim),
                        avi_emp_c_enviarPara = model.avi_emp_c_enviarPara,
                        //avi_c_status = model.avi_c_status,
                        avi_d_alteracao = DateTime.Now,
                        avi_c_usuario = "FELIPE",
                        avi_d_modificacao = DateTime.Now,
                        avi_c_unique = Guid.NewGuid(),
                        avi_d_atualizado = DateTime.Now,
                        avi_d_inclusao = DateTime.Now
                    });
                }
                else
                {
                    avisoEmpresa = (from avi in context.tb_avi_avisoEmpresa where avi.avi_n_codigo == Convert.ToInt32(model.avi_n_codigo) select avi).FirstOrDefault();
                    avisoEmpresa.avi_c_titulo = model.avi_c_titulo;
                    avisoEmpresa.avi_c_descricao = model.avi_c_descricao;
                    avisoEmpresa.avi_d_inicio = Convert.ToDateTime(model.avi_d_inicio);
                    //avisoEmpresa.avi_d_fim = Convert.ToDateTime(model.avi_d_fim);
                    avisoEmpresa.avi_emp_c_enviarPara = model.avi_emp_c_enviarPara;
                    //avisoEmpresa.avi_c_status = model.avi_c_status;
                    avisoEmpresa.avi_d_alteracao = DateTime.Now;
                    avisoEmpresa.avi_c_usuario = "FELIPE";
                    avisoEmpresa.avi_d_modificacao = DateTime.Now;
                    avisoEmpresa.avi_d_atualizado = DateTime.Now;

                    Update(avisoEmpresa);
                }

                context.SaveChanges();

                return avisoEmpresa.avi_n_codigo;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool DeletarAvisoEmpresa(int id)
        {
            try
            {
                Delete(context.tb_avi_avisoEmpresa.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public byte[] GeraExcel(AvisoEmpresaFilterModel filter)
        {
            var listaEmpresas = ObterQueryEmpresa(filter).ToList();

            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                   "Código",
                    "Título",
                    "Data Início",
                    "Data Fim",
                    "Status",
                };

                var worksheet = package.Workbook.Worksheets.Add("Operador");
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
                    foreach (var empresa in listaEmpresas)
                    {
                        worksheet.Cells["A" + j].Value = empresa.avi_n_codigo;
                        worksheet.Cells["B" + j].Value = empresa.avi_c_titulo.ToUpper();
                        worksheet.Cells["C" + j].Value = empresa.avi_d_inicio;
                        worksheet.Cells["D" + j].Value = empresa.avi_d_fim;
                        worksheet.Cells["E" + j].Value = empresa.avi_c_status;

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

        private IQueryable<AvisoEmpresaViewModel> ObterQueryEmpresa(AvisoEmpresaFilterModel filter)
        {
            var query = (from avi in Context.tb_avi_avisoEmpresa
                         from emp in context.tb_emp_empresa
                         join dis in context.tb_dis_distribuidor on emp.emp_dis_n_codigo equals dis.dis_n_codigo
                         where dis.dis_n_codigo == Convert.ToInt32(filter.distribuidor) &&
                         avi.avi_emp_c_enviarPara.Contains(emp.emp_n_codigo.ToString())
                         orderby avi.avi_d_inicio descending, avi.avi_c_titulo
                         select new AvisoEmpresaViewModel
                         {
                             avi_n_codigo = avi.avi_n_codigo.ToString(),
                             avi_c_titulo = avi.avi_c_titulo,
                             avi_c_descricao = avi.avi_c_descricao,
                             avi_d_inicio = avi.avi_d_inicio.Value == null ? string.Empty : avi.avi_d_inicio.Value.ToString("dd/MM/yyyy"),
                             avi_d_fim = avi.avi_d_fim.Value == null ? string.Empty : avi.avi_d_fim.Value.ToString("dd/MM/yyyy"),
                             avi_emp_c_enviarPara = avi.avi_emp_c_enviarPara,
                             avi_c_status = avi.avi_c_status,
                             avi_d_alteracao = avi.avi_d_alteracao.ToString(),
                             avi_c_usuario = avi.avi_c_usuario,
                             avi_d_modificacao = avi.avi_d_modificacao.ToString(),
                             avi_c_unique = avi.avi_c_unique.ToString(),
                             avi_d_atualizado = avi.avi_d_atualizado.ToString(),
                             avi_d_inclusao = avi.avi_d_inclusao.ToString(),
                             data_inicio = avi.avi_d_inicio,
                             data_fim = avi.avi_d_fim,
                             buscaSimples = avi.avi_c_titulo,
                         });

            query.Distinct();

            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
            }

            if (!string.IsNullOrEmpty(filter.Titulo))
            {
                query = query.Where(w => w.avi_c_titulo.Contains(filter.Titulo));
            }

            if (!string.IsNullOrEmpty(filter.DataInicio))
            {
                if (DateTime.TryParse(filter.DataInicio, out DateTime auxData))
                {
                    query = query.Where(w => w.data_inicio.Value.Date == auxData.Date);
                }
            }

            if (!string.IsNullOrEmpty(filter.Status))
            {
                query = query.Where(w => w.avi_c_status == filter.Status);
            }

            return query;
        }
    }
}