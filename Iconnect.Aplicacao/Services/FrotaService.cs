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
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Iconnect.Infraestrutura.Interfaces;
using OfficeOpenXml;

namespace Iconnect.Aplicacao.Services
{
    class FrotaService: RepositoryBase<tb_fro_frota>, IFrotaService
    {
        private IconnectCoreContext context;

        public FrotaService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool DeletarVeiculo(int id)
        {
            try
            {
                Delete(context.tb_fro_frota.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<GenericList> GetByCliente(int id)
        {
            var query = (from fro in context.tb_fro_frota
                         join mav in context.tb_mav_marcaVeiculo on fro.fro_mav_n_codigo equals mav.mav_n_codigo
                         where fro.fro_cli_n_codigo == id
                         orderby fro.fro_c_modelo
                         select new GenericList()
                         {
                             text = (fro.fro_c_codigoVeiculo != null ? " Veículo: " + fro.fro_c_codigoVeiculo + " | " : "") + mav.mav_c_descricao + " - " + fro.fro_c_modelo + " | Placa: " + fro.fro_c_placa,
                             value = fro.fro_n_codigo.ToString(),

                         });
            return query.OrderBy(veiculo => veiculo.text).ToList();
        }

        public IPagedList<FrotaViewModel> GetVeiculoFiltrado(FrotaFilterModel filter)
        {
            var query = (from fro in Context.tb_fro_frota
                         join mav in Context.tb_mav_marcaVeiculo on fro.fro_mav_n_codigo equals mav.mav_n_codigo
                         where fro.fro_b_ativo == true
                         select new FrotaViewModel
                         {
                             fro_n_codigo = fro.fro_n_codigo.ToString(),
                             fro_c_modelo = fro.fro_c_modelo,
                             fro_c_ano = fro.fro_c_ano,
                             fro_c_cor = fro.fro_c_cor,
                             fro_c_placa = fro.fro_c_placa,
                             fro_c_caracteristicas = fro.fro_c_caracteristicas,
                             fro_cli_n_codigo = fro.fro_cli_n_codigo.ToString(),
                             fro_mav_n_codigo = fro.fro_mav_n_codigo.ToString(),
                             Marca = mav.mav_c_descricao.ToString(),
                             buscaSimples = fro.fro_c_placa
                         });

            if (!string.IsNullOrEmpty(filter.fro_cli_n_codigo_filter))
            {
                if (filter.fro_cli_n_codigo_filter == "0")
                {
                    query = query.Where(w => w.fro_cli_n_codigo == null);
                }
                else
                {
                    query = query.Where(w => w.fro_cli_n_codigo == filter.fro_cli_n_codigo_filter);
                }
            }

            //Filtros
            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));

            }

            if (!string.IsNullOrEmpty(filter.fro_mav_n_codigo_filter))
            {
                query = query.Where(w => w.fro_mav_n_codigo.Contains(filter.fro_mav_n_codigo_filter));

            }
            if (!string.IsNullOrEmpty(filter.fro_c_modelo_filter))
            {
                query = query.Where(w => w.fro_c_modelo.Contains(filter.fro_c_modelo_filter));

            }

            if (!string.IsNullOrEmpty(filter.fro_c_ano_filter))
            {
                query = query.Where(w => w.fro_c_ano.Contains(filter.fro_c_ano_filter));

            }

            if (!string.IsNullOrEmpty(filter.fro_c_cor_filter))
            {
                query = query.Where(w => w.fro_c_cor.Contains(filter.fro_c_cor_filter));

            }

            if (!string.IsNullOrEmpty(filter.fro_c_placa_filter))
            {
                query = query.Where(w => w.fro_c_placa.Contains(filter.fro_c_placa_filter));

            }

            if (!string.IsNullOrEmpty(filter.fro_c_caracteristicas_filter))
            {
                query = query.Where(w => w.fro_c_caracteristicas.Contains(filter.fro_c_caracteristicas_filter));
            }

            return query.OrderBy(x => x.fro_c_modelo).ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public byte[] GeraExcel(FrotaFilterModel filter)
        {
            var query = (from fro in Context.tb_fro_frota
                         join mav in Context.tb_mav_marcaVeiculo on fro.fro_mav_n_codigo equals mav.mav_n_codigo
                         select new FrotaViewModel
                         {
                             fro_n_codigo = fro.fro_n_codigo.ToString(),
                             fro_c_modelo = fro.fro_c_modelo,
                             fro_c_ano = fro.fro_c_ano,
                             fro_c_cor = fro.fro_c_cor,
                             fro_c_placa = fro.fro_c_placa,
                             fro_c_caracteristicas = fro.fro_c_caracteristicas,
                             fro_cli_n_codigo = fro.fro_cli_n_codigo.ToString(),
                             fro_mav_n_codigo = fro.fro_mav_n_codigo.ToString(),
                             Marca = mav.mav_c_descricao.ToString(),
                         });

            if (!string.IsNullOrEmpty(filter.fro_cli_n_codigo_filter))
            {
                if (filter.fro_cli_n_codigo_filter == "0")
                {
                    query = query.Where(w => w.fro_cli_n_codigo == null);
                }
                else
                {
                    query = query.Where(w => w.fro_cli_n_codigo == filter.fro_cli_n_codigo_filter);
                }
            }
            //Filtros
            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));

            }

            if (!string.IsNullOrEmpty(filter.fro_mav_n_codigo_filter))
            {
                query = query.Where(w => w.fro_mav_n_codigo.Contains(filter.fro_mav_n_codigo_filter));

            }
            if (!string.IsNullOrEmpty(filter.fro_c_modelo_filter))
            {
                query = query.Where(w => w.fro_c_modelo.Contains(filter.fro_c_modelo_filter));

            }

            if (!string.IsNullOrEmpty(filter.fro_c_ano_filter))
            {
                query = query.Where(w => w.fro_c_ano.Contains(filter.fro_c_ano_filter));

            }

            if (!string.IsNullOrEmpty(filter.fro_c_cor_filter))
            {
                query = query.Where(w => w.fro_c_cor.Contains(filter.fro_c_cor_filter));

            }

            if (!string.IsNullOrEmpty(filter.fro_c_placa_filter))
            {
                query = query.Where(w => w.fro_c_placa.Contains(filter.fro_c_placa_filter));

            }

            if (!string.IsNullOrEmpty(filter.fro_c_caracteristicas_filter))
            {
                query = query.Where(w => w.fro_c_caracteristicas.Contains(filter.fro_c_caracteristicas_filter));
            }

            var listaVeiculo = query.ToList();
            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Código",
                    "Marca",
                    "Modelo",
                    "Ano",
                    "Cor",
                    "Placa",
                    "Características",
                };

                var worksheet = package.Workbook.Worksheets.Add("Marca Veículo");
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
                    foreach (var veiculo in listaVeiculo)
                    {
                        worksheet.Cells["A" + j].Value = veiculo.fro_n_codigo;
                        worksheet.Cells["B" + j].Value = veiculo.Marca;
                        worksheet.Cells["C" + j].Value = veiculo.fro_c_modelo;
                        worksheet.Cells["D" + j].Value = veiculo.fro_c_ano;
                        worksheet.Cells["E" + j].Value = veiculo.fro_c_cor;
                        worksheet.Cells["F" + j].Value = veiculo.fro_c_placa;
                        worksheet.Cells["G" + j].Value = veiculo.fro_c_caracteristicas;

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

        public bool SalvarVeiculo(FrotaViewModel model)
        {
            try
            {
                int codFro = 0;
                if (model.fro_n_codigo != "0")
                {
                    codFro = Convert.ToInt32(model.fro_n_codigo);
                }

                if (codFro == 0)
                {
                    Insert(new tb_fro_frota()
                    {
                        fro_c_modelo = model.fro_c_modelo,
                        fro_c_ano = model.fro_c_ano,
                        fro_c_cor = model.fro_c_cor,
                        fro_c_placa = model.fro_c_placa,
                        fro_c_caracteristicas = model.fro_c_caracteristicas,
                        fro_b_ativo = Convert.ToBoolean(model.fro_b_ativo),
                        fro_c_codigoVeiculo = model.fro_c_codigoVeiculo,
                        fro_cli_n_codigo = Convert.ToInt32(model.fro_cli_n_codigo),
                        fro_d_modificacao = DateTime.Now,
                        fro_mav_n_codigo = Convert.ToInt32(model.fro_mav_n_codigo),
                        fro_c_unique = new Guid(),
                        fro_d_atualizado = DateTime.Now,
                        fro_d_inclusao = DateTime.Now
                    });
                }
                else
                {
                    var Frota = (from fro in context.tb_fro_frota where fro.fro_n_codigo == codFro select fro).FirstOrDefault();
                    Frota.fro_c_modelo = model.fro_c_modelo;
                    Frota.fro_c_cor = model.fro_c_cor;
                    Frota.fro_c_placa = model.fro_c_placa;
                    Frota.fro_c_caracteristicas = model.fro_c_caracteristicas;
                    Frota.fro_b_ativo = Convert.ToBoolean(model.fro_b_ativo);
                    Frota.fro_c_codigoVeiculo = model.fro_c_codigoVeiculo;
                    Frota.fro_d_modificacao = DateTime.Now;
                    Frota.fro_mav_n_codigo = Convert.ToInt32(model.fro_mav_n_codigo);
                    Frota.fro_d_atualizado = DateTime.Now;

                    Update(Frota);
                }

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FrotaViewModel GetVeiculo(int id)
        {

            return (from fro in Context.tb_fro_frota
                    where fro.fro_n_codigo == id

                    select new FrotaViewModel
                    {
                        fro_n_codigo = fro.fro_n_codigo.ToString(),
                        fro_c_modelo = fro.fro_c_modelo,
                        fro_c_ano = fro.fro_c_ano,
                        fro_c_cor = fro.fro_c_cor,
                        fro_c_placa = fro.fro_c_placa,
                        fro_c_caracteristicas = fro.fro_c_caracteristicas,
                        fro_b_ativo = fro.fro_b_ativo.ToString(),
                        fro_c_codigoVeiculo = fro.fro_c_codigoVeiculo,
                        fro_cli_n_codigo = fro.fro_cli_n_codigo.ToString(),
                        fro_mav_n_codigo = fro.fro_mav_n_codigo.ToString(),
                    }).FirstOrDefault();
        }

        public IPagedList<FrotaViewModel> GetVeiculoBuscarFiltrado(FrotaFilterModel filter)
        {
            var query = (from fro in Context.tb_fro_frota
                         join mav in Context.tb_mav_marcaVeiculo on fro.fro_mav_n_codigo equals mav.mav_n_codigo
                         where fro.fro_b_ativo == true
                         select new FrotaViewModel
                         {
                             fro_n_codigo = fro.fro_n_codigo.ToString(),
                             fro_c_modelo = fro.fro_c_modelo,
                             fro_c_ano = fro.fro_c_ano,
                             fro_c_cor = fro.fro_c_cor,
                             fro_c_placa = fro.fro_c_placa,
                             fro_c_caracteristicas = fro.fro_c_caracteristicas,
                             fro_cli_n_codigo = fro.fro_cli_n_codigo.ToString(),
                             fro_mav_n_codigo = fro.fro_mav_n_codigo.ToString(),
                             Marca = mav.mav_c_descricao.ToString(),
                             buscaSimples = fro.fro_c_placa
                         });

            if (!string.IsNullOrEmpty(filter.fro_cli_n_codigo_filter))
            {
                if (filter.fro_cli_n_codigo_filter == "0")
                {
                    query = query.Where(w => w.fro_cli_n_codigo == null);
                }
                else
                {
                    query = query.Where(w => w.fro_cli_n_codigo == filter.fro_cli_n_codigo_filter);
                }
            }

            if (!string.IsNullOrEmpty(filter.fro_c_placa_filter))
            {
                query = query.Where(w => w.fro_c_placa.Contains(filter.fro_c_placa_filter));

            }

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

    }
}
