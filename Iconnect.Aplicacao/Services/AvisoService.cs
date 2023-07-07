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
    public class AvisoService : RepositoryBase<tb_avi_aviso>, IAvisoService
    {
        private readonly IconnectCoreContext context;

        public AvisoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public IPagedList<AvisoViewModel> GetAvisoFiltrado(AvisoFilterModel filter)
        {
            var query = ObterQueryAvisoFiltrados(filter);

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        private IQueryable<AvisoViewModel> ObterQueryAvisoFiltrados(AvisoFilterModel filter, bool excel = false)
        {
            var query = from avi in Context.tb_avi_aviso
                        join emp in Context.tb_emp_empresa on avi.avi_emp_n_codigo equals emp.emp_n_codigo
                        orderby emp.emp_c_nomeFantasia
                        select new AvisoViewModel
                        {
                            avi_n_codigo = avi.avi_n_codigo.ToString(),
                            avi_c_titulo = avi.avi_c_titulo,
                            avi_c_descricao = avi.avi_c_descricao,
                            avi_d_inicio = avi.avi_d_inicio.Value == null ? string.Empty : avi.avi_d_inicio.Value.ToString("dd/MM/yyyy"),
                            avi_d_fim = avi.avi_d_fim.Value == null ? string.Empty : avi.avi_d_fim.Value.ToString("dd/MM/yyyy"),
                            avi_ace_n_codigo = avi.avi_ace_n_codigo.ToString(),
                            avi_emp_n_codigo = avi.avi_emp_n_codigo.ToString(),
                            avi_ope_c_enviarPara = avi.avi_ope_c_enviarPara,
                            avi_c_status = avi.avi_c_status,
                            avi_d_alteracao = avi.avi_d_alteracao.ToString(),
                            avi_c_usuario = avi.avi_c_usuario,
                            avi_d_modificacao = avi.avi_d_modificacao.ToString(),
                            avi_c_unique = avi.avi_c_unique.ToString(),
                            avi_d_atualizado = avi.avi_d_atualizado.ToString(),
                            avi_d_inclusao = avi.avi_d_inclusao.ToString(),
                            NomeEmpresa = emp.emp_c_nomeFantasia,
                            buscaSimples = avi.avi_c_titulo + " " + emp.emp_c_nomeFantasia,
                            data_inicio = avi.avi_d_inicio,
                            data_fim = avi.avi_d_inicio
                        };

            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
            }

            if (!string.IsNullOrEmpty(filter.Titulo))
            {
                query = query.Where(w => w.avi_c_titulo.Contains(filter.Titulo));
            }

            if (!string.IsNullOrEmpty(filter.idEmp) && (!filter?.idEmp.Equals("0") ?? false))
            {
                query = query.Where(w => w.avi_emp_n_codigo.Contains(filter.idEmp));
            }


            if (!string.IsNullOrEmpty(filter.EmpresaId) && (!filter?.EmpresaId.Equals("0") ?? false))
            {
                query = query.Where(w => w.avi_emp_n_codigo.Contains(filter.EmpresaId));
            }

            if (!string.IsNullOrEmpty(filter.DataInicio))
            {
                if (DateTime.TryParse(filter.DataInicio, out DateTime auxData))
                {
                    query = query.Where(w => w.data_inicio.Value.Date == auxData.Date);
                }
            }

            return query;
        }

        public byte[] GeraExcel(AvisoFilterModel filter)
        {
            var query = ObterQueryAvisoFiltrados(filter, true);
            var listaEmpresas = query.ToList();

            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                   "Código",
                    "Título",
                    "Empresa",
                    "Data",
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
                        worksheet.Cells["C" + j].Value = empresa.NomeEmpresa.ToUpper();
                        worksheet.Cells["D" + j].Value = empresa.avi_d_inicio;
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

        public AvisoViewModel GetAviso(int id)
        {
            var aviso =
                    (from avi in context.tb_avi_aviso
                     join emp in context.tb_emp_empresa on avi.avi_emp_n_codigo equals emp.emp_n_codigo
                     where avi.avi_n_codigo == id
                     select new AvisoViewModel()
                     {
                         avi_n_codigo = avi.avi_n_codigo.ToString(),
                         avi_c_titulo = avi.avi_c_titulo,
                         avi_c_descricao = avi.avi_c_descricao,
                         avi_d_inicio = avi.avi_d_inicio.Value == null ? string.Empty : avi.avi_d_inicio.Value.ToString("yyyy-MM-dd"),
                         avi_d_fim = avi.avi_d_fim.Value == null ? string.Empty : avi.avi_d_fim.Value.ToString("yyyy-MM-dd"),
                         avi_ace_n_codigo = avi.avi_ace_n_codigo.ToString(),
                         avi_emp_n_codigo = avi.avi_emp_n_codigo.ToString(),
                         avi_ope_c_enviarPara = avi.avi_ope_c_enviarPara,
                         avi_c_status = avi.avi_c_status,
                         avi_d_alteracao = avi.avi_d_alteracao.ToString(),
                         avi_c_usuario = avi.avi_c_usuario,
                         avi_d_modificacao = avi.avi_d_modificacao.ToString(),
                         avi_c_unique = avi.avi_c_unique.ToString(),
                         avi_d_atualizado = avi.avi_d_atualizado.ToString(),
                         avi_d_inclusao = avi.avi_d_inclusao.ToString(),
                         NomeEmpresa = emp.emp_c_nomeFantasia
                     }).FirstOrDefault();

            aviso.OperadoresSelecionados = aviso.avi_ope_c_enviarPara.Split(',');

            return aviso;
        }

        public int SalvarAviso(AvisoViewModel model)
        {
            try
            {
                tb_avi_aviso aviso;
                if (string.IsNullOrEmpty(model.avi_n_codigo) || model.avi_n_codigo == "0")
                {
                    Insert(aviso = new tb_avi_aviso()
                    {
                        avi_c_titulo = model.avi_c_titulo,
                        avi_c_descricao = model.avi_c_descricao,
                        avi_d_inicio = Convert.ToDateTime(model.avi_d_inicio),
                        //avi_d_fim = Convert.ToDateTime(model.avi_d_fim),
                        //avi_ace_n_codigo = Convert.ToInt32(model.avi_ace_n_codigo),
                        avi_emp_n_codigo = Convert.ToInt32(model.avi_emp_n_codigo),
                        avi_ope_c_enviarPara = model.avi_ope_c_enviarPara,
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
                    aviso = (from avi in context.tb_avi_aviso where avi.avi_n_codigo == Convert.ToInt32(model.avi_n_codigo) select avi).FirstOrDefault();
                    aviso.avi_c_titulo = model.avi_c_titulo;
                    aviso.avi_c_descricao = model.avi_c_descricao;
                    aviso.avi_d_inicio = Convert.ToDateTime(model.avi_d_inicio);
                    //aviso.avi_d_fim = Convert.ToDateTime(model.avi_d_fim);
                    //aviso.avi_ace_n_codigo = Convert.ToInt32(model.avi_ace_n_codigo);
                    aviso.avi_emp_n_codigo = Convert.ToInt32(model.avi_emp_n_codigo);
                    aviso.avi_ope_c_enviarPara = model.avi_ope_c_enviarPara;
                    aviso.avi_c_status = model.avi_c_status;
                    aviso.avi_d_alteracao = DateTime.Now;
                    aviso.avi_c_usuario = "FELIPE";
                    aviso.avi_d_modificacao = DateTime.Now;
                    aviso.avi_d_atualizado = DateTime.Now;

                    Update(aviso);
                }

                context.SaveChanges();

                return aviso.avi_n_codigo;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool DeletarAviso(int id)
        {
            try
            {
                Delete(context.tb_avi_aviso.Find(id));

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