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

namespace Iconnect.Aplicacao.Services
{
    class VeiculoService : RepositoryBase<tb_vec_veiculo>, IVeiculoService
    {
        private IconnectCoreContext context;

        public VeiculoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public IPagedList<VeiculoViewModel> GetVeiculoFiltrado(VeiculoFilterModel filter)
        {
            var query = (from vec in Context.tb_vec_veiculo
                         join mav in Context.tb_mav_marcaVeiculo on vec.vec_mav_n_codigo equals mav.mav_n_codigo
                         join grf in context.tb_grf_grupoFamiliar on vec.vec_grf_n_codigo equals grf.grf_n_codigo
                         select new VeiculoViewModel
                         {
                             vec_n_codigo = vec.vec_n_codigo.ToString(),
                             vec_c_modelo = vec.vec_c_modelo,
                             vec_c_cor = vec.vec_c_cor,
                             vec_c_placa = vec.vec_c_placa,
                             vec_c_caracteristicas = vec.vec_c_caracteristicas,
                             vec_grf_n_codigo = vec.vec_grf_n_codigo.ToString(),
                             vec_d_modificacao = vec.vec_d_modificacao.ToString(),
                             vec_mav_n_codigo = vec.vec_mav_n_codigo.ToString(),
                             vec_c_unique = vec.vec_c_unique.ToString(),
                             vec_d_atualizado = vec.vec_d_atualizado.ToString(),
                             vec_d_inclusao = vec.vec_d_inclusao.ToString(),
                             Marca = mav.mav_c_descricao.ToString(),
                         });

            if (!string.IsNullOrEmpty(filter.vec_grf_n_codigo_filter))
            {
                if (filter.vec_grf_n_codigo_filter == "0")
                {
                    query = query.Where(w => w.vec_grf_n_codigo == null);
                }
                else
                {
                    query = query.Where(w => w.vec_grf_n_codigo == filter.vec_grf_n_codigo_filter);
                }
            }

            if (!string.IsNullOrEmpty(filter.vec_c_placa))
            {
                query = query.Where(w => w.vec_c_placa == filter.vec_c_placa);
            }

            return query.DistinctBy(p => p.vec_n_codigo).OrderBy(x => x.vec_n_codigo).ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public bool SalvarVeiculo(VeiculoViewModel model)
        {
            try
            {
                int? auxIdGrupo = null;
                if (model.vec_grf_n_codigo != "0")
                {
                    auxIdGrupo = Convert.ToInt32(model.vec_grf_n_codigo);
                }

                if (string.IsNullOrEmpty(model.vec_n_codigo) || model.vec_n_codigo.ToString() == "0")
                {

                    var duplicado = validaPlaca(model.vec_c_placa, Convert.ToInt32(model.vec_n_codigo));

                    if (duplicado == true)
                    {
                        return false;
                    }

                    Insert(new tb_vec_veiculo()
                    {
                        vec_c_modelo = model.vec_c_modelo,
                        vec_c_cor = model.vec_c_cor,
                        vec_c_placa = model.vec_c_placa,
                        vec_c_caracteristicas = model.vec_c_caracteristicas,
                        vec_grf_n_codigo = auxIdGrupo,
                        vec_d_modificacao = DateTime.Now,
                        vec_mav_n_codigo = Convert.ToInt32(model.vec_mav_n_codigo),
                        vec_c_unique = new Guid(),
                        vec_d_atualizado = DateTime.Now,
                        vec_d_inclusao = DateTime.Now
                    });
                }
                else
                {
                    var Veiculo = (from vec in context.tb_vec_veiculo where vec.vec_n_codigo == Convert.ToInt32(model.vec_n_codigo) select vec).FirstOrDefault();
                    Veiculo.vec_c_modelo = model.vec_c_modelo;
                    Veiculo.vec_c_cor = model.vec_c_cor;
                    Veiculo.vec_c_placa = model.vec_c_placa;
                    Veiculo.vec_c_caracteristicas = model.vec_c_caracteristicas;
                    Veiculo.vec_d_modificacao = DateTime.Now;
                    Veiculo.vec_mav_n_codigo = Convert.ToInt32(model.vec_mav_n_codigo);
                    Veiculo.vec_d_atualizado = DateTime.Now;

                    var duplicado = validaPlaca(Veiculo.vec_c_placa, Veiculo.vec_n_codigo);

                    if (duplicado == true)
                    {
                        return false;
                    }

                    Update(Veiculo);
                }

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool validaPlaca(string placa, int id)
        {
            var Placa = (from vec in context.tb_vec_veiculo where vec.vec_c_placa == placa && vec.vec_n_codigo != id select vec).Count();

            if (Placa > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeletarVeiculo(int id)
        {
            try
            {
                Delete(context.tb_vec_veiculo.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarVeiculoSemGrupo()
        {
            try
            {
                var lstVeiculos = context.tb_vec_veiculo.Where(x => x.vec_grf_n_codigo == null).ToList();

                if (lstVeiculos.Count() > 0)
                {
                    foreach (var aviso in lstVeiculos)
                    {
                        Delete(aviso);
                    }

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool VincularVeiculos(int idGrupo)
        {
            try
            {
                var lstVeiculos = context.tb_vec_veiculo.Where(x => x.vec_grf_n_codigo == null).ToList();

                if (lstVeiculos.Count() > 0)
                {
                    foreach (var aviso in lstVeiculos)
                    {
                        aviso.vec_grf_n_codigo = idGrupo;
                        Update(aviso);
                    }

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IPagedList<VeiculoViewModel> GetVeiculoBuscarFiltrado(VeiculoFilterModel filter)
        {
            var query = (from vec in Context.tb_vec_veiculo
                         join mav in Context.tb_mav_marcaVeiculo on vec.vec_mav_n_codigo equals mav.mav_n_codigo
                         join grf in context.tb_grf_grupoFamiliar on vec.vec_grf_n_codigo equals grf.grf_n_codigo
                         join lcg in context.tb_lcg_localidadeClienteGrupoFamiliar on grf.grf_n_codigo equals lcg.lcg_grf_n_codigo
                         join lccB in context.tb_lcc_localidadeCliente on lcg.lcg_lcc_n_codigoBlocoQuadra equals lccB.lcc_n_codigo
                         join lccL in context.tb_lcc_localidadeCliente on lcg.lcg_lcc_n_codigoLoteApto equals lccL.lcc_n_codigo
                         select new VeiculoViewModel
                         {
                             vec_n_codigo = vec.vec_n_codigo.ToString(),
                             vec_c_modelo = vec.vec_c_modelo,
                             vec_c_cor = vec.vec_c_cor,
                             vec_c_placa = vec.vec_c_placa,
                             vec_c_caracteristicas = vec.vec_c_caracteristicas,
                             vec_grf_n_codigo = vec.vec_grf_n_codigo.ToString(),
                             vec_d_modificacao = vec.vec_d_modificacao.ToString(),
                             vec_mav_n_codigo = vec.vec_mav_n_codigo.ToString(),
                             vec_c_unique = vec.vec_c_unique.ToString(),
                             vec_d_atualizado = vec.vec_d_atualizado.ToString(),
                             vec_d_inclusao = vec.vec_d_inclusao.ToString(),
                             Marca = mav.mav_c_descricao.ToString(),
                             vec_grf_blocoQuadra = lccB.lcc_c_descricao,
                             vec_grf_loteApto = lccL.lcc_c_descricao,
                             vec_grf_cli_n_codigo = grf.grf_cli_n_codigo.ToString(),
                         });

            if (!string.IsNullOrEmpty(filter.vec_grf_n_codigo_filter))
            {
                if (filter.vec_grf_n_codigo_filter == "0")
                {
                    query = query.Where(w => w.vec_grf_n_codigo == null);
                }
                else
                {
                    query = query.Where(w => w.vec_grf_n_codigo == filter.vec_grf_n_codigo_filter);
                }
            }

            if (!string.IsNullOrEmpty(filter.vec_c_placa))
            {
                query = query.Where(w => w.vec_c_placa.Contains(filter.vec_c_placa));
            }

            if (!string.IsNullOrEmpty(filter.vec_grf_blocoQuadra))
            {
                query = query.Where(w => w.vec_grf_blocoQuadra == filter.vec_grf_blocoQuadra);
            }

            if (!string.IsNullOrEmpty(filter.vec_grf_loteApto))
            {
                query = query.Where(w => w.vec_grf_loteApto == filter.vec_grf_loteApto);
            }

            if (!string.IsNullOrEmpty(filter.vec_grf_cli_n_codigo))
            {
                query = query.Where(w => w.vec_grf_cli_n_codigo == filter.vec_grf_cli_n_codigo);
            }

            return query.DistinctBy(p => p.vec_n_codigo).OrderBy(x => x.vec_n_codigo).ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public List<VeiculoViewModel> GetVeiculoGrupoFamiliar(int id)
        {
            return (from vec in Context.tb_vec_veiculo
                    join mav in Context.tb_mav_marcaVeiculo on vec.vec_mav_n_codigo equals mav.mav_n_codigo
                    join grf in context.tb_grf_grupoFamiliar on vec.vec_grf_n_codigo equals grf.grf_n_codigo
                    where vec.vec_grf_n_codigo == id
                    select new VeiculoViewModel
                    {
                        vec_n_codigo = vec.vec_n_codigo.ToString(),
                        vec_c_modelo = vec.vec_c_modelo,
                        vec_grf_cli_n_codigo = grf.grf_cli_n_codigo.ToString(),
                    }).ToList();
        }
    }
}