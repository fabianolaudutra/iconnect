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
    public class GrupoVagasService : RepositoryBase<tb_gpv_grupoVagas>, IGrupoVagasService
    {
        private readonly IconnectCoreContext _context;

        public GrupoVagasService(IconnectCoreContext context) : base(context)
        {
            _context = context;
        }

        public bool DeletarGrupoVagas(int id)
        {
            try
            {
                Delete(_context.tb_gpv_grupoVagas.Find(id));
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public GrupoVagasViewModel GetGrupoVagas(int id)
        {
            return (from gpv in _context.tb_gpv_grupoVagas
                    where gpv.gpv_n_codigo == id
                    select new GrupoVagasViewModel()
                    {
                        gpv_n_codigo = gpv.gpv_n_codigo.ToString(),
                        gpv_cli_n_codigo = gpv.gpv_cli_n_codigo.ToString(),
                        gpv_c_perfil = gpv.gpv_c_perfil,
                        gpv_c_descricao = gpv.gpv_c_descricao,
                        gpv_n_numeroVagas = gpv.gpv_n_numeroVagas.ToString()
                    }).FirstOrDefault();
        }

        public IPagedList<GrupoVagasViewModel> GetGrupoVagasFiltrado(GrupoVagasFilterModel filter)
        {
            if (string.IsNullOrEmpty(filter.idsClientes))
            {
                return new PagedList<GrupoVagasViewModel>(null, 1, 1);
            }

            var query = QueryGrupoDeVagasFiltrado(filter);

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public bool SalvarGrupoVagas(GrupoVagasViewModel model)
        {
            try
            {
                if (Convert.ToInt32(model.gpv_n_codigo) == 0)
                {
                    Insert(new tb_gpv_grupoVagas()
                    {
                        gpv_c_perfil = model.gpv_c_perfil,
                        gpv_c_descricao = model.gpv_c_descricao,
                        gpv_n_numeroVagas = Convert.ToInt32(model.gpv_n_numeroVagas),
                        gpv_cli_n_codigo = Convert.ToInt32(model.gpv_cli_n_codigo),
                        gpv_c_unique = Guid.NewGuid(),
                    });
                }
                else
                {
                    var grpv = (from gpv in _context.tb_gpv_grupoVagas where gpv.gpv_n_codigo == Convert.ToInt32(model.gpv_n_codigo) select gpv).FirstOrDefault();
                    grpv.gpv_c_perfil = model.gpv_c_perfil;
                    grpv.gpv_c_descricao = model.gpv_c_descricao;
                    grpv.gpv_n_numeroVagas = Convert.ToInt32(model.gpv_n_numeroVagas);
                    grpv.gpv_cli_n_codigo = Convert.ToInt32(model.gpv_cli_n_codigo);
                    grpv.gpv_cli_n_codigo = Convert.ToInt32(model.gpv_cli_n_codigo);
                    grpv.gpv_d_atualizado = DateTime.Now;

                    Update(grpv);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public byte[] GeraExcel(GrupoVagasFilterModel filter)
        {
            var query = QueryGrupoDeVagasFiltrado(filter);
            var listaVagas = query.ToList();

            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                   "Código",
                   "Descrição",
                   "Tipo",
                   "Cliente"
                };

                var worksheet = package.Workbook.Worksheets.Add("Grupo de Vagas");
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
                    foreach (var vagas in listaVagas)
                    {
                        worksheet.Cells["A" + j].Value = vagas.gpv_n_codigo;
                        worksheet.Cells["B" + j].Value = vagas.gpv_c_descricao;
                        worksheet.Cells["C" + j].Value = vagas.gpv_c_perfil;
                        worksheet.Cells["d" + j].Value = vagas.cliente_nome;

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

        public List<GrupoVagasViewModel> GetGrupoVagasByCliente(int id)
        {
            return (from gpv in _context.tb_gpv_grupoVagas
                    where gpv.gpv_cli_n_codigo == id
                    select new GrupoVagasViewModel()
                    {
                        gpv_n_codigo = gpv.gpv_n_codigo.ToString(),
                        gpv_cli_n_codigo = gpv.gpv_cli_n_codigo.ToString(),
                        gpv_c_descricao = gpv.gpv_c_descricao,
                        gpv_n_numeroVagas = gpv.gpv_n_numeroVagas.ToString()

                    }).ToList();
        }

        private IQueryable<GrupoVagasViewModel> QueryGrupoDeVagasFiltrado(GrupoVagasFilterModel filter)
        {
            var query = (from gpv in _context.tb_gpv_grupoVagas
                         join cli in _context.tb_cli_cliente on gpv.gpv_cli_n_codigo equals cli.cli_n_codigo
                         orderby gpv.gpv_c_descricao
                         where cli.cli_b_ativo == true
                         select new GrupoVagasViewModel
                         {
                             gpv_n_codigo = gpv.gpv_n_codigo.ToString(),
                             gpv_c_descricao = gpv.gpv_c_descricao,
                             gpv_n_numeroVagas = gpv.gpv_n_numeroVagas.ToString(),
                             gpv_cli_n_codigo = gpv.gpv_cli_n_codigo.ToString(),
                             cliente_nome = cli.cli_c_nomeFantasia,
                             buscaSimples = cli.cli_c_nomeFantasia + " " + gpv.gpv_c_descricao
                         });

            if (!string.IsNullOrEmpty(filter.idsClientes) && (!filter?.idsClientes?.Equals("todos") ?? false) && (!filter?.idsClientes?.Equals("NULL") ?? false) && string.IsNullOrEmpty(filter.cliente_filter))
            {
                var ids = filter.idsClientes.Split(",");
                query = query.Where(w => ids.Contains(w.gpv_cli_n_codigo));
            }

            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
            }

            if (!string.IsNullOrEmpty(filter.cliente_filter))
            {
                query = query.Where(w => w.gpv_cli_n_codigo.Equals(filter.cliente_filter));
            }

            if (!string.IsNullOrEmpty(filter.descricao_filter))
            {
                query = query.Where(w => w.gpv_c_descricao.Contains(filter.descricao_filter));
            }

            if (!string.IsNullOrEmpty(filter.numeroVagas_filter))
            {
                query = query.Where(w => w.gpv_n_numeroVagas.Equals(filter.numeroVagas_filter));
            }

            return query;
        }
    }
}
