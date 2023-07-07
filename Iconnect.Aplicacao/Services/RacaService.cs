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
using System.ComponentModel;
using System.Data;
using System.Linq;


namespace Iconnect.Aplicacao.Services
{
    class RacaService : RepositoryBase<tb_rac_raca>, IRacaService
    {
        private readonly IconnectCoreContext context;

        public RacaService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool DeletarRaca(int id)
        {
            try
            {
                Delete(context.tb_rac_raca.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public int SalvarRaca(RacaViewModel model)
        {
            try
            {
                tb_rac_raca raca;
                if (model.rac_n_codigo == 0)
                {
                    Insert(raca = new tb_rac_raca()
                    {
                        rac_c_nome = model.rac_c_nome,
                        rac_c_unique = Guid.NewGuid(),
                        rac_c_usuario = "FELIPE",
                        rac_d_alteracao = DateTime.Now,
                        rac_d_atualizado = DateTime.Now,
                        rac_d_inclusao = DateTime.Now,
                        rac_d_modificacao = DateTime.Now
                    });
                }
                else
                {
                    raca = (from rac in context.tb_rac_raca where rac.rac_n_codigo == model.rac_n_codigo select rac).FirstOrDefault();
                    raca.rac_c_nome = model.rac_c_nome;
                    raca.rac_d_atualizado = DateTime.Now;
                    raca.rac_d_modificacao = DateTime.Now;
                    Update(raca);
                }
                //entityToUpper();
                context.SaveChanges();
                return raca.rac_n_codigo;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public IPagedList<RacaViewModel> GetRacaFiltrado(RacaFilterModel filter)
        {
            var query = (from rac in Context.tb_rac_raca
                         orderby rac.rac_c_nome
                         select new RacaViewModel
                         {
                             rac_n_codigo = rac.rac_n_codigo,
                             rac_c_nome = rac.rac_c_nome,
                             rac_d_alteracao = rac.rac_d_alteracao,
                             rac_c_usuario = rac.rac_c_usuario,
                             rac_c_tipo = rac.rac_c_tipo,
                             rac_d_modificacao = rac.rac_d_modificacao,
                             rac_c_unique = rac.rac_c_unique,
                             rac_d_atualizado = rac.rac_d_atualizado,
                             rac_d_inclusao = rac.rac_d_inclusao,
                             buscaSimples = rac.rac_c_nome + " " + rac.rac_c_tipo + " " + rac.rac_c_usuario
                         });
            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.rac_c_nome.Contains(filter.buscaSimples_filter));
            }

            if (!string.IsNullOrEmpty(filter.Tipo))
            {
                query = query.Where(w => w.rac_c_tipo.Contains(filter.Tipo));
            }

            if (!string.IsNullOrEmpty(filter.Nome))
            {
                query = query.Where(w => w.rac_c_nome.Contains(filter.Nome));
            }

            if (!string.IsNullOrEmpty(filter.Usuario))
            {
                query = query.Where(w => w.rac_c_usuario.Contains(filter.Usuario));
            }

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public RacaViewModel GetRaca(int id)
        {

            return (from rac in context.tb_rac_raca
                    where rac.rac_n_codigo == id
                    select new RacaViewModel()
                    {
                        rac_n_codigo = rac.rac_n_codigo,
                        rac_c_nome = rac.rac_c_nome,
                        rac_c_tipo = rac.rac_c_tipo,
                        rac_c_usuario = rac.rac_c_usuario,
                        rac_c_unique = rac.rac_c_unique,
                        rac_d_alteracao = rac.rac_d_alteracao,
                        rac_d_atualizado = rac.rac_d_atualizado,
                        rac_d_inclusao = rac.rac_d_inclusao,
                        rac_d_modificacao = rac.rac_d_modificacao
                    }).FirstOrDefault();

        }

        public static DataTable ConvertTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            return table;
        }

        public byte[] GeraExcel(RacaFilterModel filter)
        {
            var query = (from rac in Context.tb_rac_raca
                         select new RacaViewModel
                         {
                             rac_n_codigo = rac.rac_n_codigo,
                             rac_c_nome = rac.rac_c_nome,
                             rac_d_alteracao = rac.rac_d_alteracao,
                             rac_c_usuario = rac.rac_c_usuario,
                             rac_c_tipo = rac.rac_c_tipo,
                             rac_d_modificacao = rac.rac_d_modificacao,
                             rac_c_unique = rac.rac_c_unique,
                             rac_d_atualizado = rac.rac_d_atualizado,
                             rac_d_inclusao = rac.rac_d_inclusao,
                             buscaSimples = rac.rac_c_nome + " " + rac.rac_c_tipo + " " + rac.rac_c_usuario
                         });
            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));

            }

            if (!string.IsNullOrEmpty(filter.Tipo))
            {
                query = query.Where(w => w.rac_c_tipo.Contains(filter.Tipo));
            }
            if (!string.IsNullOrEmpty(filter.Nome))
            {
                query = query.Where(w => w.rac_c_nome.Contains(filter.Nome));
            }

            if (!string.IsNullOrEmpty(filter.Usuario))
            {
                query = query.Where(w => w.rac_c_usuario.Contains(filter.Usuario));
            }

            var listaEmpresas = query.ToList();
            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Código",
                    "Nome",
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
                        worksheet.Cells["A" + j].Value = empresa.rac_n_codigo;
                        worksheet.Cells["B" + j].Value = empresa.rac_c_nome;

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

        public List<RacaViewModel> GetAllRaca()
        {
            var query = (from rac in Context.tb_rac_raca
                         select new RacaViewModel
                         {
                             rac_n_codigo = rac.rac_n_codigo,
                             rac_c_nome = rac.rac_c_nome,
                             rac_c_usuario = rac.rac_c_usuario,
                             rac_c_tipo = rac.rac_c_tipo,
                         }).OrderBy(x => x.rac_c_nome);


            List<RacaViewModel> lista = query.ToList();
            return lista;
        }
    }
}
