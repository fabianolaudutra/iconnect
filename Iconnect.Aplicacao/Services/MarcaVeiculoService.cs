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
    public class MarcaVeiculoService : RepositoryBase<tb_mav_marcaVeiculo>, IMarcaVeiculoService
    {
        private readonly IconnectCoreContext context;
        public MarcaVeiculoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool DeletarMarcaVeiculo(int id)
        {
            try
            {
                Delete(context.tb_mav_marcaVeiculo.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public int SalvarMarcaVeiculo(MarcaVeiculoViewModel model)
        {
            try
            {
                int idMarca = 0;

                if (!string.IsNullOrEmpty(model.mav_n_codigo) && (!model?.mav_n_codigo?.Equals("0") ?? false))
                {
                    idMarca = Convert.ToInt32(model.mav_n_codigo);
                }

                tb_mav_marcaVeiculo marcaVeiculo;
                if (idMarca == 0)
                {
                    Insert(marcaVeiculo = new tb_mav_marcaVeiculo()
                    {
                        mav_c_descricao = model.mav_c_descricao,
                        mav_c_unique = Guid.NewGuid(),
                        mav_d_modificacao = DateTime.Now,
                        mav_d_atualizado = DateTime.Now,
                        mav_d_inclusao = DateTime.Now,
                    });
                }
                else
                {
                    marcaVeiculo = (from mav in context.tb_mav_marcaVeiculo where mav.mav_n_codigo == idMarca select mav).FirstOrDefault();
                    marcaVeiculo.mav_c_descricao = model.mav_c_descricao;
                    Update(marcaVeiculo);
                }

                context.SaveChanges();
                return marcaVeiculo.mav_n_codigo;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IPagedList<MarcaVeiculoViewModel> GetMarcaVeiculoFiltrado(MarcaVeiculoFilterModel filter)
        {
            var query = (from mav in Context.tb_mav_marcaVeiculo
                         orderby mav.mav_c_descricao
                         select new MarcaVeiculoViewModel
                         {
                             mav_n_codigo = mav.mav_n_codigo.ToString(),
                             mav_c_descricao = mav.mav_c_descricao,
                             mav_c_unique = mav.mav_c_unique,
                             mav_d_atualizado = mav.mav_d_atualizado,
                             mav_d_inclusao = mav.mav_d_inclusao,
                             mav_d_modificacao = mav.mav_d_modificacao,
                         });

            if (!string.IsNullOrEmpty(filter.Descricao))
            {
                query = query.Where(w => w.mav_c_descricao.Contains(filter.Descricao));
            }
            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public MarcaVeiculoViewModel GetMarcaVeiculo(int id)
        {

            return (from mav in context.tb_mav_marcaVeiculo
                    where mav.mav_n_codigo == id
                    select new MarcaVeiculoViewModel()
                    {
                        mav_n_codigo = mav.mav_n_codigo.ToString(),
                        mav_c_descricao = mav.mav_c_descricao,
                        mav_c_unique = mav.mav_c_unique,
                        mav_d_atualizado = mav.mav_d_atualizado,
                        mav_d_inclusao = mav.mav_d_inclusao,
                        mav_d_modificacao = mav.mav_d_modificacao,

                    }).FirstOrDefault();

        }

        public List<MarcaVeiculoViewModel> GetAll()
        {
            return (from mav in context.tb_mav_marcaVeiculo
                    where mav.mav_c_descricao != null
                    orderby mav.mav_c_descricao
                    select new MarcaVeiculoViewModel()
                    {
                        mav_n_codigo = mav.mav_n_codigo.ToString(),
                        mav_c_descricao = mav.mav_c_descricao,
                        mav_c_unique = mav.mav_c_unique,
                        mav_d_atualizado = mav.mav_d_atualizado,
                        mav_d_inclusao = mav.mav_d_inclusao,
                        mav_d_modificacao = mav.mav_d_modificacao
                    }).ToList();
        }

        public byte[] GeraExcel(MarcaVeiculoFilterModel filter)
        {
            var query = (from mav in Context.tb_mav_marcaVeiculo
                         select new MarcaVeiculoViewModel
                         {
                             mav_n_codigo = mav.mav_n_codigo.ToString(),
                             mav_c_descricao = mav.mav_c_descricao,
                             mav_c_unique = mav.mav_c_unique,
                             mav_d_atualizado = mav.mav_d_atualizado,
                             mav_d_inclusao = mav.mav_d_inclusao,
                             mav_d_modificacao = mav.mav_d_modificacao,
                         });

            if (!string.IsNullOrEmpty(filter.Descricao))
            {
                query = query.Where(w => w.mav_c_descricao.Contains(filter.Descricao));
            }

            var listaMarcas = query.ToList();
            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Código",
                    "Descrição",
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
                    foreach (var marca in listaMarcas)
                    {
                        worksheet.Cells["A" + j].Value = marca.mav_n_codigo;
                        worksheet.Cells["B" + j].Value = marca.mav_c_descricao;

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
