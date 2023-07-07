using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    class ZoneamentoClienteService : RepositoryBase<tb_zoc_zoneamentoCliente>, IZoneamentoClienteService
    {
        private IconnectCoreContext context;

        public ZoneamentoClienteService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public ZoneamentoClienteViewModel InsertOrUpdate(ZoneamentoClienteViewModel model)
        {
            try
            {
                int? codeCli = null;
                if (model.zoc_cli_n_codigo != null && model.zoc_cli_n_codigo != "")
                {
                    codeCli = Convert.ToInt32(model.zoc_cli_n_codigo);
                }

                int codeZoc = Convert.ToInt32(model.zoc_n_codigo);
                int codeEqc = Convert.ToInt32(model.zoc_eqc_n_codigo);
                int? codeCla = null;

                if (model.zoc_cla_n_codigo != null && model.zoc_cla_n_codigo != "")
                {
                    codeCla = Convert.ToInt32(model.zoc_cla_n_codigo);
                }

                if (codeZoc == 0)
                {
                    Insert(new tb_zoc_zoneamentoCliente()
                    {
                        zoc_cli_n_codigo = codeCli,
                        zoc_cla_n_codigo = codeCla,
                        zoc_eqc_n_codigo = codeEqc,
                        zoc_c_nomePonto = model.zoc_c_nomePonto,
                        zoc_c_zona = model.zoc_c_zona,
                        zoc_n_TemporizadorDisparo = Convert.ToInt32(model.zoc_n_TemporizadorDisparo),
                        zoc_c_tipoSensor = model.zoc_c_tipoSensor,
                        zoc_c_unique = Guid.NewGuid(),
                        zoc_d_atualizado = DateTime.Now,
                        zoc_d_inclusao = DateTime.Now,
                        zoc_d_modificacao = DateTime.Now
                    });
                }
                else
                {
                    var zoc = (from zoneamento in context.tb_zoc_zoneamentoCliente where zoneamento.zoc_n_codigo == codeZoc select zoneamento).FirstOrDefault();
                    //var zoc = (from zoneamento in context.tb_zec_zeladorCliente where zelador.zec_n_codigo == codeZec select zelador).FirstOrDefault();

                    zoc.zoc_cli_n_codigo = codeCli;
                    zoc.zoc_cla_n_codigo = codeCla;
                    zoc.zoc_eqc_n_codigo = codeEqc;
                    zoc.zoc_c_nomePonto = model.zoc_c_nomePonto;
                    zoc.zoc_c_zona = model.zoc_c_zona;
                    zoc.zoc_n_TemporizadorDisparo = Convert.ToInt32(model.zoc_n_TemporizadorDisparo);
                    zoc.zoc_c_tipoSensor = model.zoc_c_tipoSensor;
                    zoc.zoc_d_atualizado = DateTime.Now;
                    zoc.zoc_d_modificacao = DateTime.Now;

                    Update(zoc);
                }
                context.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
            }
            return model;


        }

        public IPagedList<ZoneamentoClienteViewModel> GetZoneamentoFiltrado(ZoneamentoClienteFilterModel filter)
        {
            try
            {
                int codCli = Convert.ToInt32(filter.zoc_cli_n_codigo_filter);

                var query = (from zoc in Context.tb_zoc_zoneamentoCliente
                             join eqc in context.tb_eqc_equipamentoCliente on zoc.zoc_eqc_n_codigo equals eqc.eqc_n_codigo
                             join cla in Context.tb_cla_cabecalhoLayout on zoc.zoc_cla_n_codigo equals cla.cla_n_codigo
                             into C
                             from cla in C.DefaultIfEmpty()
                             orderby zoc.zoc_c_nomePonto ascending
                             //into g
                             //from ct in g.DefaultIfEmpty()
                             //where c.ExpirationDate != null
                             select new ZoneamentoClienteViewModel
                             {
                                 zoc_n_codigo = zoc.zoc_n_codigo.ToString(),
                                 zoc_cla_n_codigo = zoc.zoc_cla_n_codigo.ToString(),
                                 zoc_cli_n_codigo = zoc.zoc_cli_n_codigo.ToString(),
                                 zoc_eqc_n_codigo = zoc.zoc_eqc_n_codigo.ToString(),
                                 zoc_c_nomePonto = zoc.zoc_c_nomePonto,
                                 zoc_c_zona = zoc.zoc_c_zona.ToString(),
                                 zoc_n_TemporizadorDisparo = zoc.zoc_n_TemporizadorDisparo.ToString(),
                                 zoc_c_tipoSensor = zoc.zoc_c_tipoSensor,
                                 zoc_centralDescricao = eqc.eqc_c_nomePonto + " | " + eqc.eqc_c_ip,
                                 zoc_LayoutDescricao = cla.cla_c_nome,
                                 zoc_zonaDescricao = "Setor " + zoc.zoc_c_zona,
                             });


                if (codCli > 0)
                {
                    query = query.Where(w => w.zoc_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.zoc_cli_n_codigo == null);
                }


                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeletarZoneamento(int id)
        {
            try
            {
                Delete(context.tb_zoc_zoneamentoCliente.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public ZoneamentoClienteViewModel GetZoneamento(int id)
        {

            return (from zoc in Context.tb_zoc_zoneamentoCliente
                    where zoc.zoc_n_codigo == id

                    select new ZoneamentoClienteViewModel
                    {
                        zoc_n_codigo = zoc.zoc_n_codigo.ToString(),
                        zoc_cla_n_codigo = zoc.zoc_cla_n_codigo.ToString(),
                        zoc_cli_n_codigo = zoc.zoc_cli_n_codigo.ToString(),
                        zoc_eqc_n_codigo = zoc.zoc_eqc_n_codigo.ToString(),
                        zoc_c_nomePonto = zoc.zoc_c_nomePonto,
                        zoc_c_zona = zoc.zoc_c_zona,
                        zoc_n_TemporizadorDisparo = zoc.zoc_n_TemporizadorDisparo.ToString(),
                        zoc_c_tipoSensor = zoc.zoc_c_tipoSensor,
                    }).FirstOrDefault();
        }

        public bool ExcluirTemporarios()
        {
            try
            {
                List<tb_zoc_zoneamentoCliente> lista = new List<tb_zoc_zoneamentoCliente>();


                lista = (from zoc in context.tb_zoc_zoneamentoCliente where zoc.zoc_cli_n_codigo == null select zoc).OrderBy(x => x.zoc_c_nomePonto).ToList();


                foreach (var item in lista)
                {

                    DeletarZoneamento(item.zoc_n_codigo);
                }
                return true;

            }
            catch (Exception)
            {
                return false;

                throw;
            }
        }

        public bool Vincular(int id)
        {
            try
            {
                var lista = context.tb_zoc_zoneamentoCliente.Where(x => x.zoc_cli_n_codigo == null).ToList();

                if (lista.Count() > 0)
                {
                    foreach (var item in lista)
                    {
                        item.zoc_cli_n_codigo = id;
                        Update(item);
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
    }
}

