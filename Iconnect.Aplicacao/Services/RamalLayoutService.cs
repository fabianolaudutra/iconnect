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
    class RamalLayoutService : RepositoryBase<tb_ral_ramalLayout>, IRamalLayoutService
    {
        private IconnectCoreContext context;

        public RamalLayoutService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public object InsertOrUpdate(RamalLayoutViewModel model)
        {
            Retorno retorno = new Retorno();

            try
            {
                int codCla = Convert.ToInt32(model.ral_cla_n_codigo);
                int codRal = Convert.ToInt32(model.ral_n_codigo);


                var verificaMultiplos = (from ramalLayout in context.tb_ral_ramalLayout where ramalLayout.ral_c_ramal == model.ral_c_ramal && ramalLayout.ral_cla_n_codigo == codCla select ramalLayout).ToList();

                if (verificaMultiplos.Count > 0)
                {
                    retorno.status = "duplicado";
                    retorno.conteudo = "Já existe um layout vinculado a este ramal.";
                    return retorno;
                }


                if (codRal == 0)
                {
                    Insert(new tb_ral_ramalLayout()
                    {
                        ral_cla_n_codigo = codCla,
                        ral_c_ramal = model.ral_c_ramal,
                        ral_c_unique = Guid.NewGuid(),
                        ral_d_atualizado = DateTime.Now,
                        ral_d_inclusao = DateTime.Now,
                        ral_d_modificacao = DateTime.Now
                    }); ;
                }
                else
                {
                    var ral = (from ramalLayout in context.tb_ral_ramalLayout where ramalLayout.ral_n_codigo == codRal select ramalLayout).FirstOrDefault();

                    ral.ral_cla_n_codigo = codCla;
                    ral.ral_c_ramal = model.ral_c_ramal;
                    ral.ral_d_atualizado = DateTime.Now;
                    ral.ral_d_modificacao = DateTime.Now;

                    Update(ral);
                }
                context.SaveChanges();
                retorno.status = "sucesso";
                retorno.conteudo = "Dados salvos com sucesso.";
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.status = "erro";
                retorno.conteudo = "Ocorreu um erro ao salvar os dados.";
                return retorno;
            }
        }

        public IPagedList<RamalLayoutViewModel> GetRamalLayoutFiltrado(RamalLayoutFilterModel filter)
        {
            try
            {
                List<tb_cla_cabecalhoLayout> listaLayout = new List<tb_cla_cabecalhoLayout>();
                List<tb_ral_ramalLayout> listaRamalLayout = new List<tb_ral_ramalLayout>();
                List<RamalLayoutViewModel> query = new List<RamalLayoutViewModel>();
                //List<tb_ral_ramalLayout> listaRamalLayoutTemp = new List<tb_ral_ramalLayout>();


                //var query = (from ral in Context.tb_ral_ramalLayout
                //             //join eqc in context.tb_eqc_equipamentoCliente on zoc.zoc_eqc_n_codigo equals eqc.eqc_n_codigo
                //             //join cla in Context.tb_cla_cabecalhoLayout on zoc.zoc_cla_n_codigo equals cla.cla_n_codigo
                //             select new RamalLayoutViewModel
                //             {
                //                 ral_n_codigo = ral.ral_n_codigo.ToString(),
                //                 ral_cla_n_codigo = ral.ral_cla_n_codigo.ToString(),
                //                 ral_lay_n_codigo = ral.ral_lay_n_codigo.ToString(),
                //                 ral_c_ramal = ral.ral_c_ramal,

                //             });
                int codCli = Convert.ToInt32(filter.ral_cli_codigo_filter);

                listaLayout = (from cla in context.tb_cla_cabecalhoLayout where cla.cla_cli_n_codigo == codCli select cla).ToList();
                listaRamalLayout = (from ral in context.tb_ral_ramalLayout select ral).ToList();

                foreach (var cla in listaLayout)
                {
                    var listaRamalLayoutTemp = listaRamalLayout.Where(w => w.ral_cla_n_codigo == cla.cla_n_codigo);

                    foreach (var ral in listaRamalLayoutTemp)
                    {
                        RamalLayoutViewModel model = new RamalLayoutViewModel();
                        model.ral_cla_nome = cla.cla_c_nome;
                        model.ral_n_codigo = ral.ral_n_codigo.ToString();
                        model.ral_c_ramal = ral.ral_c_ramal;


                        query.Add(model);
                    }
                }

                return query.OrderBy(x=> x.ral_cla_nome).ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeletarRamalLayout(int id)
        {
            try
            {
                Delete(context.tb_ral_ramalLayout.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public RamalLayoutViewModel GetRamalLayout(int id)
        {

            return (from ral in Context.tb_ral_ramalLayout
                    where ral.ral_n_codigo == id

                    select new RamalLayoutViewModel
                    {
                        ral_n_codigo = ral.ral_n_codigo.ToString(),
                        ral_cla_n_codigo = ral.ral_cla_n_codigo.ToString(),
                        ral_lay_n_codigo = ral.ral_lay_n_codigo.ToString(),
                        ral_c_ramal = ral.ral_c_ramal.ToString(),

                    }).FirstOrDefault();
        }

    }
}
